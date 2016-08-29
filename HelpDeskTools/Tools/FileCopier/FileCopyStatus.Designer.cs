namespace FileCopier
{
    partial class FileCopyStatus
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
            this.progressBarComputer = new System.Windows.Forms.ProgressBar();
            this.textBoxComputer = new System.Windows.Forms.TextBox();
            this.progressBarFile = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBarComputer
            // 
            this.progressBarComputer.Location = new System.Drawing.Point(12, 59);
            this.progressBarComputer.Name = "progressBarComputer";
            this.progressBarComputer.Size = new System.Drawing.Size(288, 26);
            this.progressBarComputer.TabIndex = 0;
            // 
            // textBoxComputer
            // 
            this.textBoxComputer.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxComputer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxComputer.Location = new System.Drawing.Point(12, 40);
            this.textBoxComputer.Name = "textBoxComputer";
            this.textBoxComputer.Size = new System.Drawing.Size(288, 13);
            this.textBoxComputer.TabIndex = 1;
            this.textBoxComputer.Text = "Copying Files To Computer - This may take some time";
            // 
            // progressBarFile
            // 
            this.progressBarFile.Location = new System.Drawing.Point(12, 110);
            this.progressBarFile.Name = "progressBarFile";
            this.progressBarFile.Size = new System.Drawing.Size(288, 26);
            this.progressBarFile.TabIndex = 2;
            // 
            // FileCopyStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 160);
            this.Controls.Add(this.progressBarFile);
            this.Controls.Add(this.textBoxComputer);
            this.Controls.Add(this.progressBarComputer);
            this.Name = "FileCopyStatus";
            this.Text = "Copy Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBarComputer;
        public System.Windows.Forms.TextBox textBoxComputer;
        public System.Windows.Forms.ProgressBar progressBarFile;
    }
}