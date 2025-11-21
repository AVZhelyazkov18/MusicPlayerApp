using MusicPlayerApp.Enums;
using MusicPlayerApp.Models;
using MusicPlayerApp.Service;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MusicPlayerApp.Forms
{
    public partial class MusicPlayerForm : Form
    {
        private string resourceDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName + "\\Resources";
        private PrivateFontCollection pfc;
        private string[] fontPaths = {
            "Fonts\\Roboto-Thin.ttf",
            "Fonts\\Roboto-Bold.ttf",
            "Fonts\\OpenSans-Bold.ttf"
        };

        private Button _lastRightClickedPlaylist;
        private Button _lastSelectedPlaylist;
        private Button _lastSelectedMusicTrack;

        private readonly Dictionary<string, Button> _trackButtons = new();

        private readonly IPlaylistService _playlistService;
        private readonly IMusicTrackService _musicTrackService;
        private readonly IPlaybackService _playbackService;
        public MusicPlayerForm(IPlaylistService playlistService, IMusicTrackService musicTrackService, IPlaybackService playbackService)
        {
            _playlistService = playlistService;
            _musicTrackService = musicTrackService;
            _playbackService = playbackService;

            InitializeComponent();
            LoadCustomFonts();
            LoadPlaylistComponents();

            _playbackService.GetMediaPlayer().PlayStateChange += MediaPlayer_TrackStateChanged;
        }

        private void LoadCustomFonts()
        {
            pfc = new PrivateFontCollection();

            for (int i = fontPaths.Length - 1; i >= 0; i--)
            {
                var path = System.IO.Path.Combine(resourceDirectory, fontPaths[i]);
                pfc.AddFontFile(path);
            }
        }

        private void LoadPlaylistComponents()
        {


            List<Playlist> playlists = _playlistService.GetPlaylists();

            lblPlaylists.Font = new Font(pfc.Families[0], lblPlaylists.Font.Size, FontStyle.Bold);
            lblPlaylists.UseCompatibleTextRendering = true;

            panelPlaylistHolder.AutoScroll = true;

            panelPlaylistHolder.Controls.Clear();


            int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
            int yOffset = 10;

            foreach (var playlist in playlists)
            {
                Button btnPlaylist = new Button
                {
                    Text = playlist.GetName(),
                    AutoSize = true,
                    Font = new Font(pfc.Families[1], 18, FontStyle.Bold),
                    Size = new Size(panelPlaylistHolder.Width - scrollbarWidth, 40),
                    Location = new Point(0, yOffset),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Flat,
                    Margin = Padding.Empty
                };

                btnPlaylist.Tag = playlist.id;
                btnPlaylist.FlatAppearance.BorderSize = 0;

                btnPlaylist.MouseUp += cmsPlaylistButton_MouseUp;

                panelPlaylistHolder.Controls.Add(btnPlaylist);

                yOffset += btnPlaylist.Height + 10;
            }
        }

        //-- Playlists' Event Handlers and View

        private async void addPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _playlistService.CreatePlaylistAsync();
            LoadPlaylistComponents();
        }

        private void panelPlaylistHolder_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmsPlaylist.Show(panelPlaylistHolder, e.Location);
        }
        private void cmsPlaylistButton_MouseUp(object? sender, MouseEventArgs e)
        {
            var btn = (Button)sender!;

            if (e.Button == MouseButtons.Right)
            {
                _lastRightClickedPlaylist = btn;

                var screenPoint = btn.PointToScreen(e.Location);
                cmsPlaylistButton.Show(screenPoint);
            }
            else if (e.Button == MouseButtons.Left)
            {
                SelectionChange(btn, Selection.Playlist);
            }
        }

        private async void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_lastRightClickedPlaylist == null)
                return;

            await _playlistService.DeletePlaylistAsync((string)_lastRightClickedPlaylist.Tag!);
            LoadPlaylistComponents();
        }

        private void renamePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_lastRightClickedPlaylist == null)
                return;

            Playlist playlist = _playlistService.GetPlaylistById((string)_lastRightClickedPlaylist.Tag!);

            string? newName = ShowInputDialog(
                "Rename Playlist",
                "Enter a new playlist name:",
                playlist.playlistName
            );

            if (string.IsNullOrWhiteSpace(newName))
                return;

            _playlistService.RenamePlaylist((string)_lastRightClickedPlaylist.Tag!, newName);

            _lastRightClickedPlaylist.Text = newName;
        }

        private string? ShowInputDialog(string title, string message, string defaultText = "")
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };

            Label textLabel = new Label() { Left = 10, Top = 10, Text = message, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 300, Text = defaultText };

            Button confirmation = new Button() { Text = "OK", Left = 220, Width = 90, Top = 70 };
            confirmation.DialogResult = DialogResult.OK;

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        //-- Tracks' Event Handlers And View

        // Loads all Tracks in the panelTrackHolder
        private void LoadTracksForPlaylist(string playlistId)
        {
            if (string.IsNullOrEmpty(playlistId))
                return;

            List<string> trackIds = _playlistService.GetMusicTrackIdsFromPlaylistId(playlistId);
            List<MusicTrack> tracks = _musicTrackService.GetTracksByIds(trackIds);

            panelTrackHolder.Controls.Clear();
            _trackButtons.Clear();

            if (tracks != null && tracks.Count > 0)
            {
                MusicTrack? currentPlaybackTrack = _playbackService.CurrentMusicPlaying();

                foreach (MusicTrack track in tracks)
                {

                    string title = track.trackTitle;
                    string album = track.trackAlbum ?? "Unspecified";
                    string dateAdded = track.trackDateAdded.ToString("MMM d, yyyy");
                    string duration = track.trackDuration.ToString(@"m\:ss");

                    Button trackRow = CreateTrackRow(track.trackId, title, album, dateAdded, duration);


                    if (currentPlaybackTrack != null && currentPlaybackTrack.trackId == track.trackId)
                        _lastSelectedMusicTrack = trackRow;

                    panelTrackHolder.Controls.Add(trackRow);
                    _trackButtons[track.trackId] = trackRow;
                }
            }
        }
        private Button CreateTrackRow(string id, string title, string album, string dateAdded, string duration)
        {
            Button trackBox = new Button
            {
                Height = 50,
                Width = panelTrackHolder.ClientSize.Width,
                BackColor = Color.FromKnownColor(KnownColor.White),
                Margin = new Padding(0, 10, 0, 0)
            };

            trackBox.Tag = id;
            int labelHeight = trackBox.Height - 20;
            int centerY = (trackBox.Height - labelHeight) / 2;

            Label lblTitle = new Label
            {
                Text = title,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DarkGray,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Width = (int)(trackBox.Width * 0.2),
                Location = new Point(10, centerY),
                Height = labelHeight,
                Margin = new Padding(0, 5, 0, 0)
            };

            Label lblAlbum = new Label
            {
                Text = album,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkGray,
                Font = new Font(pfc.Families[1], 10, FontStyle.Regular),
                Width = (int)(trackBox.Width * 0.3),
                Location = new Point(lblTitle.Right + 10, centerY),
                Height = labelHeight,
                Margin = new Padding(0, 5, 0, 0)
            };

            Label lblDateAdded = new Label
            {
                Text = dateAdded,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkGray,
                Font = new Font(pfc.Families[1], 10, FontStyle.Regular),
                Width = (int)(trackBox.Width * 0.20),
                Location = new Point(lblAlbum.Right + 10, centerY),
                Height = labelHeight,
            };

            Label lblDuration = new Label
            {
                Text = duration,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkGray,
                Font = new Font(pfc.Families[1], 10, FontStyle.Regular),
                Width = (int)(trackBox.Width * 0.07),
                Location = new Point(trackBox.Width - 70, centerY),
                Height = labelHeight,
            };

            trackBox.MouseClick += TrackRow_Click;
            lblTitle.MouseClick += TrackRow_Click;
            lblAlbum.MouseClick += TrackRow_Click;
            lblDateAdded.MouseClick += TrackRow_Click;
            lblDuration.MouseClick += TrackRow_Click;

            trackBox.Controls.Add(lblTitle);
            trackBox.Controls.Add(lblAlbum);
            trackBox.Controls.Add(lblDateAdded);
            trackBox.Controls.Add(lblDuration);

            return trackBox;
        }

        private void TrackRow_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control obj = (Control)sender!;

                Button trackBox = obj as Button ?? (Button)obj.Parent!;

                if (trackBox == null)
                    return;

                string trackId = (string)trackBox.Tag!;

                if (trackId == null)
                    return;

                SelectionChange(trackBox, Selection.MusicTrack);

                _playbackService.ChangePlaylist((string)_lastSelectedPlaylist.Tag!, (string)_lastSelectedMusicTrack.Tag!);
            }
            else if (e.Button == MouseButtons.Right)
            { }
        }

        private void SelectionChange(Control selectedObject, Selection selectionObject)
        {
            switch (selectionObject)
            {
                case Selection.Playlist:

                    if (_lastSelectedPlaylist != null)
                    {
                        _lastSelectedPlaylist.BackColor = Color.FromKnownColor(KnownColor.Menu);
                        _lastSelectedPlaylist.FlatAppearance.BorderSize = 0;
                    }

                    Button btn1 = (Button)selectedObject;

                    btn1.FlatAppearance.BorderSize = 2;
                    btn1.FlatAppearance.BorderColor = Color.Gray;
                    btn1.BackColor = Color.FromArgb(230, 240, 255);

                    LoadTracksForPlaylist((string)btn1.Tag!);

                    _lastSelectedPlaylist = btn1;
                    break;
                case Selection.MusicTrack:

                    if (_lastSelectedMusicTrack != null)
                    {
                        _lastSelectedMusicTrack.BackColor = Color.FromKnownColor(KnownColor.Menu);
                        _lastSelectedPlaylist.FlatAppearance.BorderSize = 0;
                    }

                    Button btn2 = (Button)selectedObject;

                    btn2.FlatAppearance.BorderSize = 2;
                    btn2.FlatAppearance.BorderColor = Color.Gray;
                    btn2.BackColor = Color.FromArgb(230, 240, 255);

                    _lastSelectedMusicTrack = btn2;
                    break;
            }
        }

        public void UpdateTrackSelection(string trackId)
        {
            if (_lastSelectedMusicTrack != null)
            {
                _lastSelectedMusicTrack.BackColor = Color.FromKnownColor(KnownColor.Menu);
                _lastSelectedPlaylist.FlatAppearance.BorderSize = 0;
            }

            if (_trackButtons[trackId] == null)
                return;

            Button btn = _trackButtons[trackId];

            _lastSelectedMusicTrack = btn;

            _lastSelectedMusicTrack.FlatAppearance.BorderSize = 2;
            _lastSelectedMusicTrack.FlatAppearance.BorderColor = Color.Gray;
            _lastSelectedMusicTrack.BackColor = Color.FromArgb(230, 240, 255);

            lblCurrentTrack.Text = _musicTrackService.GetTrackById(trackId).trackTitle;
        }

        private async void addAMusicTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a music file";
                ofd.Filter = "Audio Files|*.mp3;*.wav;*.ogg;|All Files|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string trackPath = ofd.FileName;
                    if (string.IsNullOrEmpty(trackPath))
                        return;

                    string playlistId = (string)_lastSelectedPlaylist.Tag!;

                    if (playlistId != null)
                    {
                        await _musicTrackService.CreateTrackFromData(playlistId, trackPath);
                        LoadTracksForPlaylist(playlistId);
                    }
                }
            }
        }

        private void panelTrackHolder_MouseUp(object sender, MouseEventArgs e)
        {
            if (panelTrackHolder.Visible && e.Button == MouseButtons.Right)
            {
                cmsMusicTrackAdd.Show(panelTrackHolder, e.Location);
            }
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            _playbackService.PlayPrevious();

            MusicTrack? currentTrack = _playbackService.CurrentMusicPlaying();
            if (currentTrack != null)
                UpdateTrackSelection(currentTrack.trackId);
        }
        private void btnForward_MouseClick(object sender, MouseEventArgs e)
        {
            _playbackService.PlayNext();

            MusicTrack? currentTrack = _playbackService.CurrentMusicPlaying();
            if (currentTrack != null)
                UpdateTrackSelection(currentTrack.trackId);
        }
        private void btnPlayPause_MouseClick(object sender, MouseEventArgs e)
        {
            _playbackService.TogglePlayPause();

            MusicTrack? currentTrack = _playbackService.CurrentMusicPlaying();
            if (currentTrack != null)
                UpdateTrackSelection(currentTrack.trackId);
        }

        // Autoplay Tracks after selected has ended.
        private void MediaPlayer_TrackStateChanged(int newState)
        {
            if ((WMPLib.WMPPlayState)newState == WMPLib.WMPPlayState.wmppsMediaEnded)
                _playbackService.PlayNext();

            MusicTrack? currentTrack = _playbackService.CurrentMusicPlaying();
            if (currentTrack != null)
                UpdateTrackSelection(currentTrack.trackId);
        }
    }
}
