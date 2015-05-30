namespace Shared.Forms
{
    partial class frmReasonSelector
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
            this.lbSelectReason = new System.Windows.Forms.ListBox();
            this.btnOkay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSelectReason
            // 
            this.lbSelectReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectReason.FormattingEnabled = true;
            this.lbSelectReason.ItemHeight = 16;
            this.lbSelectReason.Location = new System.Drawing.Point(12, 12);
            this.lbSelectReason.Name = "lbSelectReason";
            this.lbSelectReason.Size = new System.Drawing.Size(260, 212);
            this.lbSelectReason.TabIndex = 0;
            this.lbSelectReason.DoubleClick += new System.EventHandler(this.lbSelectReason_DoubleClick);
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(197, 230);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // frmReasonSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.lbSelectReason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReasonSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHANGETEXT";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReasonSelector_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSelectReason;
        private System.Windows.Forms.Button btnOkay;
    }
}