namespace Retail_HD
{
    partial class frmCodeEntry
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
			this.lblEntry = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblEntry
			// 
			this.lblEntry.AutoSize = true;
			this.lblEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEntry.Location = new System.Drawing.Point(12, 9);
			this.lblEntry.Name = "lblEntry";
			this.lblEntry.Size = new System.Drawing.Size(264, 48);
			this.lblEntry.TabIndex = 0;
			this.lblEntry.Text = "Enter the code, if you dare.\r\nPress ESC to exit.";
			// 
			// frmCodeEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 119);
			this.Controls.Add(this.lblEntry);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmCodeEntry";
			this.Text = "CodeEntry";
			this.Load += new System.EventHandler(this.frmCodeEntry_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodeEntry_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntry;
    }
}