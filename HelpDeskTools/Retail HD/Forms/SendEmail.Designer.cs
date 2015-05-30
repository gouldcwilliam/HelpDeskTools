namespace Retail_HD.Forms
{
    partial class frmSendEmail
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
            this.components = new System.ComponentModel.Container();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lbAttachedFiles = new System.Windows.Forms.ListBox();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cmsLBAttachedFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLBAttachedFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbBody
            // 
            this.rtbBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBody.ForeColor = System.Drawing.SystemColors.GrayText;
            this.rtbBody.Location = new System.Drawing.Point(12, 81);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(559, 324);
            this.rtbBody.TabIndex = 2;
            this.rtbBody.Text = "Body";
            this.rtbBody.Enter += new System.EventHandler(this.rtbBody_Enter);
            this.rtbBody.Leave += new System.EventHandler(this.rtbBody_Leave);
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(12, 15);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(323, 20);
            this.lblTeam.TabIndex = 0;
            this.lblTeam.Text = "Send to: Network (Infrastructure) Team";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(496, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(415, 479);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(12, 425);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 23);
            this.btnAttach.TabIndex = 3;
            this.btnAttach.Text = "Attach Files";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // lbAttachedFiles
            // 
            this.lbAttachedFiles.ContextMenuStrip = this.cmsLBAttachedFiles;
            this.lbAttachedFiles.FormattingEnabled = true;
            this.lbAttachedFiles.Location = new System.Drawing.Point(93, 425);
            this.lbAttachedFiles.Name = "lbAttachedFiles";
            this.lbAttachedFiles.Size = new System.Drawing.Size(478, 43);
            this.lbAttachedFiles.TabIndex = 4;
            // 
            // ofdMain
            // 
            this.ofdMain.Multiselect = true;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.ForeColor = System.Drawing.Color.Gray;
            this.txtSubject.Location = new System.Drawing.Point(12, 55);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(559, 20);
            this.txtSubject.TabIndex = 1;
            this.txtSubject.Text = "Subject";
            this.txtSubject.Enter += new System.EventHandler(this.txtSubject_Enter);
            this.txtSubject.Leave += new System.EventHandler(this.txtSubject_Leave);
            // 
            // cmsLBAttachedFiles
            // 
            this.cmsLBAttachedFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeItemToolStripMenuItem});
            this.cmsLBAttachedFiles.Name = "cmsLBAttachedFiles";
            this.cmsLBAttachedFiles.Size = new System.Drawing.Size(145, 26);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // frmSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(583, 514);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lbAttachedFiles);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.rtbBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSendEmail";
            this.Text = "Send Email";
            this.Load += new System.EventHandler(this.frmSendEmail_Load);
            this.cmsLBAttachedFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.ListBox lbAttachedFiles;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.ContextMenuStrip cmsLBAttachedFiles;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
    }
}