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
            panelTrackHolder = new Panel();
            panel2 = new Panel();
            cmsPlaylist = new ContextMenuStrip(components);
            addPlaylistToolStripMenuItem = new ToolStripMenuItem();
            cmsPlaylistButton = new ContextMenuStrip(components);
            deletePlaylistToolStripMenuItem = new ToolStripMenuItem();
            panelBackgroundPlaylists.SuspendLayout();
            cmsPlaylist.SuspendLayout();
            cmsPlaylistButton.SuspendLayout();
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
            lblPlaylists.Click += lblPlaylists_Click;
            // 
            // panelTrackHolder
            // 
            panelTrackHolder.BackColor = SystemColors.Menu;
            panelTrackHolder.Location = new Point(268, 12);
            panelTrackHolder.Name = "panelTrackHolder";
            panelTrackHolder.Size = new Size(984, 502);
            panelTrackHolder.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Menu;
            panel2.Location = new Point(268, 533);
            panel2.Name = "panel2";
            panel2.Size = new Size(984, 136);
            panel2.TabIndex = 2;
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
            cmsPlaylistButton.Items.AddRange(new ToolStripItem[] { deletePlaylistToolStripMenuItem });
            cmsPlaylistButton.Name = "cmsPlaylistButton";
            cmsPlaylistButton.Size = new Size(181, 48);
            cmsPlaylistButton.MouseUp += cmsPlaylistButton_MouseUp;
            // 
            // deletePlaylistToolStripMenuItem
            // 
            deletePlaylistToolStripMenuItem.Name = "deletePlaylistToolStripMenuItem";
            deletePlaylistToolStripMenuItem.Size = new Size(180, 22);
            deletePlaylistToolStripMenuItem.Text = "Delete Playlist";
            deletePlaylistToolStripMenuItem.Click += deletePlaylistToolStripMenuItem_Click;
            // 
            // MusicPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel2);
            Controls.Add(panelTrackHolder);
            Controls.Add(panelBackgroundPlaylists);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MusicPlayerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            panelBackgroundPlaylists.ResumeLayout(false);
            panelBackgroundPlaylists.PerformLayout();
            cmsPlaylist.ResumeLayout(false);
            cmsPlaylistButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBackgroundPlaylists;
        private System.Windows.Forms.Label lblPlaylists;
        private FlowLayoutPanel panelPlaylistHolder;
        private Panel lineBreak1;
        private Panel panelTrackHolder;
        private Panel panel2;
        private ContextMenuStrip cmsPlaylist;
        private ToolStripMenuItem addPlaylistToolStripMenuItem;
        private ContextMenuStrip cmsPlaylistButton;
        private ToolStripMenuItem deletePlaylistToolStripMenuItem;
    }
}