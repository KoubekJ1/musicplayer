namespace musicplayer
{
	partial class AddAlbumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAlbumForm));
            lName = new Label();
            tbName = new TextBox();
            pbImage = new PictureBox();
            bChange = new Button();
            lSongs = new Label();
            label1 = new Label();
            tbSearch = new TextBox();
            bAdd = new Button();
            lSearch = new Label();
            bUp = new Button();
            bDown = new Button();
            bRemove = new Button();
            bAddAlbum = new Button();
            lbAllSongs = new ListBox();
            lbSongs = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(20, 14);
            lName.Margin = new Padding(5, 0, 5, 0);
            lName.Name = "lName";
            lName.Size = new Size(78, 32);
            lName.TabIndex = 0;
            lName.Text = "Name";
            // 
            // tbName
            // 
            tbName.Location = new Point(20, 51);
            tbName.Margin = new Padding(5, 5, 5, 5);
            tbName.Name = "tbName";
            tbName.Size = new Size(275, 39);
            tbName.TabIndex = 1;
            // 
            // pbImage
            // 
            pbImage.Image = (Image)resources.GetObject("pbImage.Image");
            pbImage.InitialImage = (Image)resources.GetObject("pbImage.InitialImage");
            pbImage.Location = new Point(20, 104);
            pbImage.Margin = new Padding(5, 5, 5, 5);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(203, 200);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.TabIndex = 2;
            pbImage.TabStop = false;
            // 
            // bChange
            // 
            bChange.Location = new Point(20, 314);
            bChange.Margin = new Padding(5, 5, 5, 5);
            bChange.Name = "bChange";
            bChange.Size = new Size(203, 46);
            bChange.TabIndex = 3;
            bChange.Text = "Change";
            bChange.UseVisualStyleBackColor = true;
            bChange.Click += bChange_Click;
            // 
            // lSongs
            // 
            lSongs.AutoSize = true;
            lSongs.Location = new Point(307, 14);
            lSongs.Margin = new Padding(5, 0, 5, 0);
            lSongs.Name = "lSongs";
            lSongs.Size = new Size(79, 32);
            lSongs.TabIndex = 5;
            lSongs.Text = "Songs";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(642, 14);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 32);
            label1.TabIndex = 7;
            label1.Text = "All Songs";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(897, 88);
            tbSearch.Margin = new Padding(5, 5, 5, 5);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(350, 39);
            tbSearch.TabIndex = 8;
            // 
            // bAdd
            // 
            bAdd.Location = new Point(642, 323);
            bAdd.Margin = new Padding(5, 5, 5, 5);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(245, 46);
            bAdd.TabIndex = 9;
            bAdd.Text = "Add";
            bAdd.UseVisualStyleBackColor = true;
            // 
            // lSearch
            // 
            lSearch.AutoSize = true;
            lSearch.Location = new Point(897, 51);
            lSearch.Margin = new Padding(5, 0, 5, 0);
            lSearch.Name = "lSearch";
            lSearch.Size = new Size(254, 32);
            lSearch.TabIndex = 10;
            lSearch.Text = "Search songs by name";
            // 
            // bUp
            // 
            bUp.Location = new Point(562, 51);
            bUp.Margin = new Padding(5, 5, 5, 5);
            bUp.Name = "bUp";
            bUp.Size = new Size(70, 46);
            bUp.TabIndex = 11;
            bUp.Text = "↑";
            bUp.UseVisualStyleBackColor = true;
            // 
            // bDown
            // 
            bDown.Location = new Point(562, 107);
            bDown.Margin = new Padding(5, 5, 5, 5);
            bDown.Name = "bDown";
            bDown.Size = new Size(70, 46);
            bDown.TabIndex = 12;
            bDown.Text = "↓";
            bDown.UseVisualStyleBackColor = true;
            // 
            // bRemove
            // 
            bRemove.Location = new Point(307, 323);
            bRemove.Margin = new Padding(5, 5, 5, 5);
            bRemove.Name = "bRemove";
            bRemove.Size = new Size(245, 46);
            bRemove.TabIndex = 13;
            bRemove.Text = "Remove";
            bRemove.UseVisualStyleBackColor = true;
            // 
            // bAddAlbum
            // 
            bAddAlbum.Location = new Point(20, 397);
            bAddAlbum.Margin = new Padding(5, 5, 5, 5);
            bAddAlbum.Name = "bAddAlbum";
            bAddAlbum.Size = new Size(203, 46);
            bAddAlbum.TabIndex = 14;
            bAddAlbum.Text = "Add Album";
            bAddAlbum.UseVisualStyleBackColor = true;
            bAddAlbum.Click += bAddAlbum_Click;
            // 
            // lbAllSongs
            // 
            lbAllSongs.FormattingEnabled = true;
            lbAllSongs.Location = new Point(642, 51);
            lbAllSongs.Margin = new Padding(5, 5, 5, 5);
            lbAllSongs.Name = "lbAllSongs";
            lbAllSongs.Size = new Size(243, 260);
            lbAllSongs.TabIndex = 15;
            // 
            // lbSongs
            // 
            lbSongs.FormattingEnabled = true;
            lbSongs.Location = new Point(307, 51);
            lbSongs.Margin = new Padding(5, 5, 5, 5);
            lbSongs.Name = "lbSongs";
            lbSongs.Size = new Size(243, 260);
            lbSongs.TabIndex = 16;
            // 
            // AddAlbumForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 469);
            Controls.Add(lbSongs);
            Controls.Add(lbAllSongs);
            Controls.Add(bAddAlbum);
            Controls.Add(bRemove);
            Controls.Add(bDown);
            Controls.Add(bUp);
            Controls.Add(lSearch);
            Controls.Add(bAdd);
            Controls.Add(tbSearch);
            Controls.Add(label1);
            Controls.Add(lSongs);
            Controls.Add(bChange);
            Controls.Add(pbImage);
            Controls.Add(tbName);
            Controls.Add(lName);
            Margin = new Padding(5, 5, 5, 5);
            Name = "AddAlbumForm";
            Text = "Add Album";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lName;
		private TextBox tbName;
		private PictureBox pbImage;
		private Button bChange;
		private Label lSongs;
		private Label label1;
		private TextBox tbSearch;
		private Button bAdd;
		private Label lSearch;
		private Button bUp;
		private Button bDown;
		private Button bRemove;
		private Button bAddAlbum;
		private ListBox lbAllSongs;
		private ListBox lbSongs;
	}
}