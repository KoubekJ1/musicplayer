namespace musicplayer.forms
{
    partial class AddSongForm
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
            label1 = new Label();
            tbName = new TextBox();
            lFile = new Label();
            bFile = new Button();
            bAdd = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // tbName
            // 
            tbName.Location = new Point(12, 44);
            tbName.Name = "tbName";
            tbName.Size = new Size(406, 39);
            tbName.TabIndex = 1;
            // 
            // lFile
            // 
            lFile.AutoSize = true;
            lFile.Location = new Point(12, 86);
            lFile.Name = "lFile";
            lFile.Size = new Size(195, 32);
            lFile.TabIndex = 2;
            lFile.Text = "(No file selected)";
            // 
            // bFile
            // 
            bFile.Location = new Point(12, 121);
            bFile.Name = "bFile";
            bFile.Size = new Size(150, 46);
            bFile.TabIndex = 3;
            bFile.Text = "Select file";
            bFile.UseVisualStyleBackColor = true;
            bFile.Click += bFile_Click;
            // 
            // bAdd
            // 
            bAdd.Location = new Point(12, 198);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(150, 46);
            bAdd.TabIndex = 4;
            bAdd.Text = "Add";
            bAdd.UseVisualStyleBackColor = true;
            bAdd.Click += bAdd_Click;
            // 
            // AddSongForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 300);
            Controls.Add(bAdd);
            Controls.Add(bFile);
            Controls.Add(lFile);
            Controls.Add(tbName);
            Controls.Add(label1);
            Name = "AddSongForm";
            Text = "Add Song";
            Load += AddSongForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private Label lFile;
        private Button bFile;
        private Button bAdd;
    }
}