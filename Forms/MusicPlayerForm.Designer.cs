namespace MusicPlayerApp.Forms
{
    partial class MusicPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelBackgroundPlaylists = new Panel();
            lineBreak1 = new Panel();
            panelPlaylistHolder = new FlowLayoutPanel();
            lblPlaylists = new Label();
            panelTrackBackground = new Panel();
            lblCurrentTrack = new Label();
            panel2 = new Panel();
            btnForward = new Button();
            btnBackward = new Button();
            btnPlayPause = new Button();
            cmsPlaylist = new ContextMenuStrip(components);
            addPlaylistToolStripMenuItem = new ToolStripMenuItem();
            cmsPlaylistButton = new ContextMenuStrip(components);
            deletePlaylistToolStripMenuItem = new ToolStripMenuItem();
            renamePlaylistToolStripMenuItem = new ToolStripMenuItem();
            panel3 = new Panel();
            panelTrackHolder = new FlowLayoutPanel();
            cmsMusicTrackAdd = new ContextMenuStrip(components);
            addAMusicTrackToolStripMenuItem = new ToolStripMenuItem();
            panelBackgroundPlaylists.SuspendLayout();
            panelTrackBackground.SuspendLayout();
            panel2.SuspendLayout();
            cmsPlaylist.SuspendLayout();
            cmsPlaylistButton.SuspendLayout();
            cmsMusicTrackAdd.SuspendLayout();
            SuspendLayout();
            // 
            // panelBackgroundPlaylists
            // 
            panelBackgroundPlaylists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBackgroundPlaylists.BackColor = SystemColors.Menu;
            panelBackgroundPlaylists.Controls.Add(lineBreak1);
            panelBackgroundPlaylists.Controls.Add(panelPlaylistHolder);
            panelBackgroundPlaylists.Controls.Add(lblPlaylists);
            panelBackgroundPlaylists.Location = new Point(12, 12);
            panelBackgroundPlaylists.Name = "panelBackgroundPlaylists";
            panelBackgroundPlaylists.Padding = new Padding(20, 20, 0, 20);
            panelBackgroundPlaylists.Size = new Size(233, 657);
            panelBackgroundPlaylists.TabIndex = 0;
            // 
            // lineBreak1
            // 
            lineBreak1.BackColor = Color.Gainsboro;
            lineBreak1.Location = new Point(0, 79);
            lineBreak1.Margin = new Padding(0);
            lineBreak1.Name = "lineBreak1";
            lineBreak1.Size = new Size(231, 2);
            lineBreak1.TabIndex = 1;
            // 
            // panelPlaylistHolder
            // 
            panelPlaylistHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPlaylistHolder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelPlaylistHolder.Location = new Point(0, 79);
            panelPlaylistHolder.Name = "panelPlaylistHolder";
            panelPlaylistHolder.Size = new Size(233, 578);
            panelPlaylistHolder.TabIndex = 0;
            panelPlaylistHolder.MouseUp += panelPlaylistHolder_MouseUp;
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.BackColor = Color.Transparent;
            lblPlaylists.Font = new Font("Segoe UI", 24F);
            lblPlaylists.Location = new Point(38, 20);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(132, 45);
            lblPlaylists.TabIndex = 0;
            lblPlaylists.Text = "Playlists";
            // 
            // panelTrackBackground
            // 
            panelTrackBackground.BackColor = SystemColors.Menu;
            panelTrackBackground.Controls.Add(lblCurrentTrack);
            panelTrackBackground.Location = new Point(268, 12);
            panelTrackBackground.Name = "panelTrackBackground";
            panelTrackBackground.Size = new Size(984, 502);
            panelTrackBackground.TabIndex = 1;
            // 
            // lblCurrentTrack
            // 
            lblCurrentTrack.AutoSize = true;
            lblCurrentTrack.BackColor = Color.Transparent;
            lblCurrentTrack.Font = new Font("Segoe UI", 16F);
            lblCurrentTrack.Location = new Point(19, 20);
            lblCurrentTrack.Name = "lblCurrentTrack";
            lblCurrentTrack.Size = new Size(241, 30);
            lblCurrentTrack.TabIndex = 0;
            lblCurrentTrack.Text = "Currently Playing: None";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Menu;
            panel2.Controls.Add(btnForward);
            panel2.Controls.Add(btnBackward);
            panel2.Controls.Add(btnPlayPause);
            panel2.Location = new Point(268, 533);
            panel2.Name = "panel2";
            panel2.Size = new Size(984, 136);
            panel2.TabIndex = 2;
            // 
            // btnForward
            // 
            btnForward.BackColor = Color.Transparent;
            btnForward.Image = Properties.Resources.next_arrow;
            btnForward.Location = new Point(530, 86);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(40, 40);
            btnForward.TabIndex = 2;
            btnForward.UseVisualStyleBackColor = false;
            btnForward.MouseClick += btnForward_MouseClick;
            // 
            // btnBackward
            // 
            btnBackward.BackColor = Color.Transparent;
            btnBackward.Image = Properties.Resources.previous_arrow;
            btnBackward.Location = new Point(430, 86);
            btnBackward.Name = "btnBackward";
            btnBackward.Size = new Size(40, 40);
            btnBackward.TabIndex = 1;
            btnBackward.UseVisualStyleBackColor = false;
            btnBackward.Click += btnBackward_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.BackColor = Color.Transparent;
            btnPlayPause.Image = Properties.Resources.play;
            btnPlayPause.Location = new Point(480, 86);
            btnPlayPause.Margin = new Padding(0);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(40, 40);
            btnPlayPause.TabIndex = 0;
            btnPlayPause.UseVisualStyleBackColor = false;
            btnPlayPause.MouseClick += btnPlayPause_MouseClick;
            // 
            // cmsPlaylist
            // 
            cmsPlaylist.Items.AddRange(new ToolStripItem[] { addPlaylistToolStripMenuItem });
            cmsPlaylist.Name = "contextMenuStrip1";
            cmsPlaylist.Size = new Size(137, 26);
            // 
            // addPlaylistToolStripMenuItem
            // 
            addPlaylistToolStripMenuItem.Name = "addPlaylistToolStripMenuItem";
            addPlaylistToolStripMenuItem.Size = new Size(136, 22);
            addPlaylistToolStripMenuItem.Text = "Add Playlist";
            addPlaylistToolStripMenuItem.Click += addPlaylistToolStripMenuItem_Click;
            // 
            // cmsPlaylistButton
            // 
            cmsPlaylistButton.Items.AddRange(new ToolStripItem[] { deletePlaylistToolStripMenuItem, renamePlaylistToolStripMenuItem });
            cmsPlaylistButton.Name = "cmsPlaylistButton";
            cmsPlaylistButton.Size = new Size(158, 48);
            cmsPlaylistButton.MouseUp += cmsPlaylistButton_MouseUp;
            // 
            // deletePlaylistToolStripMenuItem
            // 
            deletePlaylistToolStripMenuItem.Name = "deletePlaylistToolStripMenuItem";
            deletePlaylistToolStripMenuItem.Size = new Size(157, 22);
            deletePlaylistToolStripMenuItem.Text = "Delete Playlist";
            deletePlaylistToolStripMenuItem.Click += deletePlaylistToolStripMenuItem_Click;
            // 
            // renamePlaylistToolStripMenuItem
            // 
            renamePlaylistToolStripMenuItem.Name = "renamePlaylistToolStripMenuItem";
            renamePlaylistToolStripMenuItem.Size = new Size(157, 22);
            renamePlaylistToolStripMenuItem.Text = "Rename Playlist";
            renamePlaylistToolStripMenuItem.Click += renamePlaylistToolStripMenuItem_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(268, 91);
            panel3.Name = "panel3";
            panel3.Size = new Size(983, 2);
            panel3.TabIndex = 1;
            // 
            // panelTrackHolder
            // 
            panelTrackHolder.BackColor = SystemColors.Menu;
            panelTrackHolder.Location = new Point(268, 99);
            panelTrackHolder.Name = "panelTrackHolder";
            panelTrackHolder.Size = new Size(984, 412);
            panelTrackHolder.TabIndex = 1;
            panelTrackHolder.MouseUp += panelTrackHolder_MouseUp;
            // 
            // cmsMusicTrackAdd
            // 
            cmsMusicTrackAdd.Items.AddRange(new ToolStripItem[] { addAMusicTrackToolStripMenuItem });
            cmsMusicTrackAdd.Name = "cmsMusicTrackAdd";
            cmsMusicTrackAdd.Size = new Size(174, 26);
            // 
            // addAMusicTrackToolStripMenuItem
            // 
            addAMusicTrackToolStripMenuItem.Name = "addAMusicTrackToolStripMenuItem";
            addAMusicTrackToolStripMenuItem.Size = new Size(173, 22);
            addAMusicTrackToolStripMenuItem.Text = "Add A Music Track";
            addAMusicTrackToolStripMenuItem.Click += addAMusicTrackToolStripMenuItem_Click;
            // 
            // MusicPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelTrackHolder);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panelTrackBackground);
            Controls.Add(panelBackgroundPlaylists);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MusicPlayerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            panelBackgroundPlaylists.ResumeLayout(false);
            panelBackgroundPlaylists.PerformLayout();
            panelTrackBackground.ResumeLayout(false);
            panelTrackBackground.PerformLayout();
            panel2.ResumeLayout(false);
            cmsPlaylist.ResumeLayout(false);
            cmsPlaylistButton.ResumeLayout(false);
            cmsMusicTrackAdd.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBackgroundPlaylists;
        private System.Windows.Forms.Label lblPlaylists;
        private FlowLayoutPanel panelPlaylistHolder;
        private Panel lineBreak1;
        private Panel panelTrackBackground;
        private Panel panel2;
        private ContextMenuStrip cmsPlaylist;
        private ToolStripMenuItem addPlaylistToolStripMenuItem;
        private ContextMenuStrip cmsPlaylistButton;
        private ToolStripMenuItem deletePlaylistToolStripMenuItem;
        private Label lblCurrentTrack;
        private Panel panel3;
        private FlowLayoutPanel panelTrackHolder;
        private ContextMenuStrip cmsMusicTrackAdd;
        private ToolStripMenuItem addAMusicTrackToolStripMenuItem;
        private Button btnPlayPause;
        private Button btnBackward;
        private Button btnForward;
        private ToolStripMenuItem renamePlaylistToolStripMenuItem;
    }
}