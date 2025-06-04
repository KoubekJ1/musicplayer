namespace musicplayer
{
	partial class AlbumsListControl
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
			flpAlbs = new FlowLayoutPanel();
			SuspendLayout();
			// 
			// flpAlbs
			// 
			flpAlbs.AutoScroll = true;
			flpAlbs.Dock = DockStyle.Fill;
			flpAlbs.Location = new Point(0, 0);
			flpAlbs.Name = "flpAlbs";
			flpAlbs.Size = new Size(830, 650);
			flpAlbs.TabIndex = 0;
			// 
			// AlbumsListControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(flpAlbs);
			Name = "AlbumsListControl";
			Size = new Size(830, 650);
			ResumeLayout(false);
		}

		#endregion

		private FlowLayoutPanel flpAlbs;
	}
}
