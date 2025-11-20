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

        public MusicPlayerForm()
        {
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
            List<string> playlists = new List<string>
            {
                "Playlist 1",  "Playlist 2",  "Playlist 3",  "Playlist 4",
                "Playlist 5",  "Playlist 6",  "Playlist 7",  "Playlist 8",
                "Playlist 9",  "Playlist 10", "Playlist 11", "Playlist 12",
                "Playlist 13", "Playlist 14", "Playlist 15", "Playlist 16",
                "Playlist 17", "Playlist 18", "Playlist 19", "Playlist 20",
                "Playlist 21", "Playlist 22", "Playlist 23", "Playlist 24",
                "Playlist 25"
            };

            lblPlaylists.Font = new Font(pfc.Families[0], lblPlaylists.Font.Size, FontStyle.Bold);
            lblPlaylists.UseCompatibleTextRendering = true;

            panelPlaylists.AutoScroll = true;

            int scrollbarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;

            int yOffset = 10;

            foreach (var playlist in playlists)
            {
                Button btnPlaylist = new Button
                {
                    Text = playlist,
                    AutoSize = true,
                    Font = new Font(pfc.Families[1], 18, FontStyle.Bold),
                    Size = new Size(panelPlaylists.Width - scrollbarWidth, 40),
                    Location = new Point(0, yOffset),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Flat,
                    Margin = Padding.Empty
                };

                btnPlaylist.FlatAppearance.BorderSize = 0;

                panelPlaylists.Controls.Add(btnPlaylist);

                yOffset += btnPlaylist.Height + 10;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
