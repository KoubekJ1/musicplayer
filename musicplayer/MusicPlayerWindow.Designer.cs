namespace musicplayer
{
	partial class MusicPlayerWindow
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
            read = new Button();
            upload = new Button();
            panelContent = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            artistToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            panelMenu = new Panel();
            buttonArtists = new Button();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // read
            // 
            read.Location = new Point(741, 308);
            read.Margin = new Padding(4, 6, 4, 6);
            read.Name = "read";
            read.Size = new Size(546, 195);
            read.TabIndex = 0;
            read.Text = "Read";
            read.UseVisualStyleBackColor = true;
            read.Click += read_Click;
            // 
            // upload
            // 
            upload.Location = new Point(741, 690);
            upload.Margin = new Padding(4, 6, 4, 6);
            upload.Name = "upload";
            upload.Size = new Size(546, 195);
            upload.TabIndex = 1;
            upload.Text = "Upload";
            upload.UseVisualStyleBackColor = true;
            upload.Click += upload_Click;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelContent.Location = new Point(1314, 55);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(880, 1245);
            panelContent.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, addToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(2213, 44);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 38);
            editToolStripMenuItem.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { artistToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(77, 38);
            addToolStripMenuItem.Text = "Add";
            // 
            // artistToolStripMenuItem
            // 
            artistToolStripMenuItem.Name = "artistToolStripMenuItem";
            artistToolStripMenuItem.Size = new Size(359, 44);
            artistToolStripMenuItem.Text = "Artist";
            artistToolStripMenuItem.Click += artistToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(84, 38);
            helpToolStripMenuItem.Text = "Help";
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(buttonArtists);
            panelMenu.Location = new Point(13, 55);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(325, 1245);
            panelMenu.TabIndex = 4;
            // 
            // buttonArtists
            // 
            buttonArtists.Location = new Point(3, 4);
            buttonArtists.Margin = new Padding(3, 4, 3, 4);
            buttonArtists.Name = "buttonArtists";
            buttonArtists.Size = new Size(318, 96);
            buttonArtists.TabIndex = 0;
            buttonArtists.Text = "Artists";
            buttonArtists.UseVisualStyleBackColor = true;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(359, 44);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // MusicPlayerWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2213, 1316);
            Controls.Add(panelMenu);
            Controls.Add(panelContent);
            Controls.Add(upload);
            Controls.Add(read);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 6, 4, 6);
            Name = "MusicPlayerWindow";
            Text = "Music Player";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button read;
		private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonArtists;
        private ToolStripMenuItem artistToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}

