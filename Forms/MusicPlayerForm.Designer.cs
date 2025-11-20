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
            panelBackgroundPlaylists = new Panel();
            lblPlaylists = new Label();
            panelPlaylists = new FlowLayoutPanel();
            panelBackgroundPlaylists.SuspendLayout();
            SuspendLayout();
            // 
            // panelBackgroundPlaylists
            // 
            panelBackgroundPlaylists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBackgroundPlaylists.BackColor = SystemColors.Window;
            panelBackgroundPlaylists.Controls.Add(panelPlaylists);
            panelBackgroundPlaylists.Controls.Add(lblPlaylists);
            panelBackgroundPlaylists.Location = new Point(12, 12);
            panelBackgroundPlaylists.Name = "panelBackgroundPlaylists";
            panelBackgroundPlaylists.Padding = new Padding(20, 20, 0, 20);
            panelBackgroundPlaylists.Size = new Size(231, 634);
            panelBackgroundPlaylists.TabIndex = 0;
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.BackColor = SystemColors.Window;
            lblPlaylists.Font = new Font("Segoe UI", 24F);
            lblPlaylists.Location = new Point(46, 20);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(132, 45);
            lblPlaylists.TabIndex = 0;
            lblPlaylists.Text = "Playlists";
            // 
            // panelPlaylists
            // 
            panelPlaylists.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPlaylists.Location = new Point(0, 79);
            panelPlaylists.Name = "panelPlaylists";
            panelPlaylists.Size = new Size(231, 555);
            panelPlaylists.TabIndex = 0;
            // 
            // MusicPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1112, 658);
            Controls.Add(panelBackgroundPlaylists);
            Name = "MusicPlayerForm";
            Text = "Music Player";
            panelBackgroundPlaylists.ResumeLayout(false);
            panelBackgroundPlaylists.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBackgroundPlaylists;
        private System.Windows.Forms.Label lblPlaylists;
        private FlowLayoutPanel panelPlaylists;
    }
}