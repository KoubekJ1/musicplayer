﻿namespace musicplayer
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
			bAdd = new Button();
			bUp = new Button();
			bDown = new Button();
			bRemove = new Button();
			bAddAlbum = new Button();
			lbSongs = new ListBox();
			lArtist = new Label();
			lArtistName = new Label();
			bPickArtist = new Button();
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
			tbName.Size = new Size(328, 27);
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
			lSongs.Location = new Point(189, 65);
			lSongs.Name = "lSongs";
			lSongs.Size = new Size(49, 20);
			lSongs.TabIndex = 5;
			lSongs.Text = "Songs";
			// 
			// bAdd
			// 
			bAdd.Location = new Point(189, 258);
			bAdd.Name = "bAdd";
			bAdd.Size = new Size(151, 29);
			bAdd.TabIndex = 9;
			bAdd.Text = "Add";
			bAdd.UseVisualStyleBackColor = true;
			// 
			// bUp
			// 
			bUp.Location = new Point(346, 123);
			bUp.Name = "bUp";
			bUp.Size = new Size(43, 29);
			bUp.TabIndex = 11;
			bUp.Text = "↑";
			bUp.UseVisualStyleBackColor = true;
			// 
			// bDown
			// 
			bDown.Location = new Point(347, 158);
			bDown.Name = "bDown";
			bDown.Size = new Size(43, 29);
			bDown.TabIndex = 12;
			bDown.Text = "↓";
			bDown.UseVisualStyleBackColor = true;
			// 
			// bRemove
			// 
			bRemove.Location = new Point(189, 293);
			bRemove.Name = "bRemove";
			bRemove.Size = new Size(151, 29);
			bRemove.TabIndex = 13;
			bRemove.Text = "Remove";
			bRemove.UseVisualStyleBackColor = true;
			// 
			// bAddAlbum
			// 
			bAddAlbum.Location = new Point(12, 293);
			bAddAlbum.Name = "bAddAlbum";
			bAddAlbum.Size = new Size(125, 29);
			bAddAlbum.TabIndex = 14;
			bAddAlbum.Text = "Add Album";
			bAddAlbum.UseVisualStyleBackColor = true;
			bAddAlbum.Click += bAddAlbum_Click;
			// 
			// lbSongs
			// 
			lbSongs.FormattingEnabled = true;
			lbSongs.Location = new Point(189, 88);
			lbSongs.Name = "lbSongs";
			lbSongs.Size = new Size(151, 164);
			lbSongs.TabIndex = 16;
			// 
			// lArtist
			// 
			lArtist.AutoSize = true;
			lArtist.Location = new Point(346, 9);
			lArtist.Name = "lArtist";
			lArtist.Size = new Size(44, 20);
			lArtist.TabIndex = 17;
			lArtist.Text = "Artist";
			// 
			// lArtistName
			// 
			lArtistName.AutoSize = true;
			lArtistName.Location = new Point(346, 32);
			lArtistName.Name = "lArtistName";
			lArtistName.Size = new Size(132, 20);
			lArtistName.TabIndex = 18;
			lArtistName.Text = "(no artist selected)";
			// 
			// bPickArtist
			// 
			bPickArtist.Location = new Point(346, 55);
			bPickArtist.Name = "bPickArtist";
			bPickArtist.Size = new Size(94, 29);
			bPickArtist.TabIndex = 19;
			bPickArtist.Text = "Pick Artist";
			bPickArtist.UseVisualStyleBackColor = true;
			bPickArtist.Click += bClickArtist_Click;
			// 
			// AddAlbumForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(532, 345);
			Controls.Add(bPickArtist);
			Controls.Add(lArtistName);
			Controls.Add(lArtist);
			Controls.Add(lbSongs);
			Controls.Add(bAddAlbum);
			Controls.Add(bRemove);
			Controls.Add(bDown);
			Controls.Add(bUp);
			Controls.Add(bAdd);
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
		private Button bAdd;
		private Button bUp;
		private Button bDown;
		private Button bRemove;
		private Button bAddAlbum;
		private ListBox lbSongs;
		private Label lArtist;
		private Label lArtistName;
		private Button bPickArtist;
	}
}