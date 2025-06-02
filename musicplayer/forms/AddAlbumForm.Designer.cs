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
			lName.Location = new Point(12, 9);
			lName.Name = "lName";
			lName.Size = new Size(49, 20);
			lName.TabIndex = 0;
			lName.Text = "Name";
			// 
			// tbName
			// 
			tbName.Location = new Point(12, 32);
			tbName.Name = "tbName";
			tbName.Size = new Size(171, 27);
			tbName.TabIndex = 1;
			// 
			// pbImage
			// 
			pbImage.Image = (Image)resources.GetObject("pbImage.Image");
			pbImage.InitialImage = (Image)resources.GetObject("pbImage.InitialImage");
			pbImage.Location = new Point(12, 65);
			pbImage.Name = "pbImage";
			pbImage.Size = new Size(125, 125);
			pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
			pbImage.TabIndex = 2;
			pbImage.TabStop = false;
			// 
			// bChange
			// 
			bChange.Location = new Point(12, 196);
			bChange.Name = "bChange";
			bChange.Size = new Size(125, 29);
			bChange.TabIndex = 3;
			bChange.Text = "Change";
			bChange.UseVisualStyleBackColor = true;
			bChange.Click += bChange_Click;
			// 
			// lSongs
			// 
			lSongs.AutoSize = true;
			lSongs.Location = new Point(189, 9);
			lSongs.Name = "lSongs";
			lSongs.Size = new Size(49, 20);
			lSongs.TabIndex = 5;
			lSongs.Text = "Songs";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(395, 9);
			label1.Name = "label1";
			label1.Size = new Size(71, 20);
			label1.TabIndex = 7;
			label1.Text = "All Songs";
			// 
			// tbSearch
			// 
			tbSearch.Location = new Point(552, 55);
			tbSearch.Name = "tbSearch";
			tbSearch.Size = new Size(217, 27);
			tbSearch.TabIndex = 8;
			// 
			// bAdd
			// 
			bAdd.Location = new Point(395, 202);
			bAdd.Name = "bAdd";
			bAdd.Size = new Size(151, 29);
			bAdd.TabIndex = 9;
			bAdd.Text = "Add";
			bAdd.UseVisualStyleBackColor = true;
			// 
			// lSearch
			// 
			lSearch.AutoSize = true;
			lSearch.Location = new Point(552, 32);
			lSearch.Name = "lSearch";
			lSearch.Size = new Size(156, 20);
			lSearch.TabIndex = 10;
			lSearch.Text = "Search songs by name";
			// 
			// bUp
			// 
			bUp.Location = new Point(346, 32);
			bUp.Name = "bUp";
			bUp.Size = new Size(43, 29);
			bUp.TabIndex = 11;
			bUp.Text = "↑";
			bUp.UseVisualStyleBackColor = true;
			// 
			// bDown
			// 
			bDown.Location = new Point(346, 67);
			bDown.Name = "bDown";
			bDown.Size = new Size(43, 29);
			bDown.TabIndex = 12;
			bDown.Text = "↓";
			bDown.UseVisualStyleBackColor = true;
			// 
			// bRemove
			// 
			bRemove.Location = new Point(189, 202);
			bRemove.Name = "bRemove";
			bRemove.Size = new Size(151, 29);
			bRemove.TabIndex = 13;
			bRemove.Text = "Remove";
			bRemove.UseVisualStyleBackColor = true;
			// 
			// bAddAlbum
			// 
			bAddAlbum.Location = new Point(12, 248);
			bAddAlbum.Name = "bAddAlbum";
			bAddAlbum.Size = new Size(125, 29);
			bAddAlbum.TabIndex = 14;
			bAddAlbum.Text = "Add Album";
			bAddAlbum.UseVisualStyleBackColor = true;
			// 
			// lbAllSongs
			// 
			lbAllSongs.FormattingEnabled = true;
			lbAllSongs.Location = new Point(395, 32);
			lbAllSongs.Name = "lbAllSongs";
			lbAllSongs.Size = new Size(151, 164);
			lbAllSongs.TabIndex = 15;
			// 
			// lbSongs
			// 
			lbSongs.FormattingEnabled = true;
			lbSongs.Location = new Point(189, 32);
			lbSongs.Name = "lbSongs";
			lbSongs.Size = new Size(151, 164);
			lbSongs.TabIndex = 16;
			// 
			// AddAlbumForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(779, 293);
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