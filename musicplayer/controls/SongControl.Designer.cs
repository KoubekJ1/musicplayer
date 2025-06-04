namespace musicplayer.controls
{
	partial class SongControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			bPlay = new Button();
			lSongName = new Label();
			lLength = new Label();
			SuspendLayout();
			// 
			// bPlay
			// 
			bPlay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			bPlay.Location = new Point(3, 3);
			bPlay.Name = "bPlay";
			bPlay.Size = new Size(54, 54);
			bPlay.TabIndex = 0;
			bPlay.Text = "Play";
			bPlay.UseVisualStyleBackColor = true;
			bPlay.Click += bPlay_Click;
			// 
			// lSongName
			// 
			lSongName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			lSongName.AutoSize = true;
			lSongName.Location = new Point(63, 20);
			lSongName.Name = "lSongName";
			lSongName.Size = new Size(49, 20);
			lSongName.TabIndex = 1;
			lSongName.Text = "Name";
			// 
			// lLength
			// 
			lLength.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			lLength.AutoSize = true;
			lLength.Location = new Point(743, 20);
			lLength.Name = "lLength";
			lLength.Size = new Size(54, 20);
			lLength.TabIndex = 2;
			lLength.Text = "Length";
			// 
			// SongControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(lLength);
			Controls.Add(lSongName);
			Controls.Add(bPlay);
			Name = "SongControl";
			Size = new Size(800, 60);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button bPlay;
		private Label lSongName;
		private Label lLength;
	}
}
