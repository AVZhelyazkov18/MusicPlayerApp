using System.Drawing.Text;

namespace MusicPlayerApp
{
    public class App : System.Windows.Forms.Form
    {
        /*
        private string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
        private PrivateFontCollection pfc;
        private Panel panel1;
        private string[] fontPaths = {
            "Fonts\\Roboto-Thin.ttf",
            "Fonts\\Roboto-Bold.ttf",
            "Fonts\\OpenSans-Bold.ttf"
        };
        */

        public App()
        {
            InitializeComponent();
            //LoadCustomFonts();
            //LoadPlaylistComponents();
            //LoadTrackPanelComponents();
        }
        /*
        private void LoadCustomFonts()
        {
            pfc = new PrivateFontCollection();

            for (int i = fontPaths.Length - 1; i >= 0; i--)
            {
                pfc.AddFontFile(System.IO.Path.Combine(projectDirectory, fontPaths[i]));
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

        private void LoadTrackPanelComponents()
        {
            lblTrackTitle.Font = new Font(pfc.Families[0], lblTrackTitle.Font.Size, FontStyle.Bold);
            //lblAuthor.Font = new Font(pfc.Families[2], 14, FontStyle.Bold);
        }

        private void lblPlaylists_Click(object sender, EventArgs e)
        {

        }

        private void panelTrackBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        */
        private void InitializeComponent()
        {
            panel1 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(211, 198);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 395);
            panel1.TabIndex = 0;
            // 
            // App
            // 
            ClientSize = new Size(1112, 693);
            Controls.Add(panel1);
            Name = "App";
            ResumeLayout(false);

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}