using MusicPlayerApp.Models;
using MusicPlayerApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp.Forms
{
    public partial class MusicPlayerForm : Form
    {
        private string resourceDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName + "\\Resources";
        private PrivateFontCollection pfc;
        private Panel panel1;
        private string[] fontPaths = {
            "Fonts\\Roboto-Thin.ttf",
            "Fonts\\Roboto-Bold.ttf",
            "Fonts\\OpenSans-Bold.ttf"
        };

        private readonly IPlaylistService _playlistService;

        public MusicPlayerForm(IPlaylistService playlistService)
        {
            _playlistService = playlistService;

            InitializeComponent();
            LoadCustomFonts();
            LoadPlaylistComponents();
            //LoadTrackPanelComponents();
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

            // Destroys already existing buttons
            panelPlaylistHolder.Controls.Clear();


            int scrollbarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;

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

        private void lblPlaylists_Click(object sender, EventArgs e)
        {

        }

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


        private string? _lastRightClickedPlaylistId;

        private void cmsPlaylistButton_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var btn = (Button)sender!;
            _lastRightClickedPlaylistId = btn.Tag as string;

            var screenPoint = btn.PointToScreen(e.Location);
            cmsPlaylistButton.Show(screenPoint);
        }

        private async void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_lastRightClickedPlaylistId == null)
                return;

            await _playlistService.DeletePlaylistAsync(_lastRightClickedPlaylistId);
            LoadPlaylistComponents();
        }
    }
}
