namespace musicplayer
{
	partial class ArtistsControl
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
			flpArtists = new FlowLayoutPanel();
			flpAlbs = new FlowLayoutPanel();
			SuspendLayout();
			// 
			// flpArtists
			// 
			flpArtists.AutoScroll = true;
			flpArtists.Dock = DockStyle.Left;
			flpArtists.Location = new Point(0, 0);
			flpArtists.Name = "flpArtists";
			flpArtists.Size = new Size(300, 711);
			flpArtists.TabIndex = 0;
			// 
			// flpAlbs
			// 
			flpAlbs.Dock = DockStyle.Right;
			flpAlbs.Location = new Point(306, 0);
			flpAlbs.Name = "flpAlbs";
			flpAlbs.Size = new Size(783, 711);
			flpAlbs.TabIndex = 1;
			// 
			// ArtistsControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(flpAlbs);
			Controls.Add(flpArtists);
			Name = "ArtistsControl";
			Size = new Size(1089, 711);
			ResumeLayout(false);
		}

		#endregion

		private FlowLayoutPanel flpArtists;
		private FlowLayoutPanel flpAlbs;
	}
}
