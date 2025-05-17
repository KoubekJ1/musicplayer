namespace musicplayer
{
	partial class AlbumDisplayControl
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
			button = new Button();
			label = new Label();
			SuspendLayout();
			// 
			// button
			// 
			button.Location = new Point(3, 3);
			button.Name = "button";
			button.Size = new Size(194, 200);
			button.TabIndex = 0;
			button.Text = "button1";
			button.UseVisualStyleBackColor = true;
			// 
			// label
			// 
			label.AutoSize = true;
			label.Location = new Point(3, 206);
			label.MinimumSize = new Size(194, 43);
			label.Name = "label";
			label.Size = new Size(194, 43);
			label.TabIndex = 1;
			label.Text = "label1";
			label.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// AlbumDisplayControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(label);
			Controls.Add(button);
			Name = "AlbumDisplayControl";
			Size = new Size(200, 250);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button;
		private Label label;
	}
}
