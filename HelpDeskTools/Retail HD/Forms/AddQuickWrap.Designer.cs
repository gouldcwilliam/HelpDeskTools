namespace Retail_HD.Forms
{
    partial class AddQuickWrap
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtDisclaimer = new System.Windows.Forms.TextBox();
			this.txtWrapUp = new System.Windows.Forms.TextBox();
			this.cmbCategories = new System.Windows.Forms.ComboBox();
			this.gbWrapUp = new System.Windows.Forms.GroupBox();
			this.gbCategory = new System.Windows.Forms.GroupBox();
			this.ckbMandatory = new System.Windows.Forms.CheckBox();
			this.gbWrapUp.SuspendLayout();
			this.gbCategory.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(118, 235);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(199, 235);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtDisclaimer
			// 
			this.txtDisclaimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDisclaimer.BackColor = System.Drawing.SystemColors.Control;
			this.txtDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDisclaimer.ForeColor = System.Drawing.Color.Red;
			this.txtDisclaimer.Location = new System.Drawing.Point(12, 12);
			this.txtDisclaimer.Multiline = true;
			this.txtDisclaimer.Name = "txtDisclaimer";
			this.txtDisclaimer.ReadOnly = true;
			this.txtDisclaimer.Size = new System.Drawing.Size(262, 108);
			this.txtDisclaimer.TabIndex = 2;
			this.txtDisclaimer.Text = "STOP!  Clear this with bossman Berg Man first";
			// 
			// txtWrapUp
			// 
			this.txtWrapUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtWrapUp.Location = new System.Drawing.Point(6, 19);
			this.txtWrapUp.Name = "txtWrapUp";
			this.txtWrapUp.Size = new System.Drawing.Size(250, 20);
			this.txtWrapUp.TabIndex = 3;
			// 
			// cmbCategories
			// 
			this.cmbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategories.FormattingEnabled = true;
			this.cmbCategories.Location = new System.Drawing.Point(6, 19);
			this.cmbCategories.Name = "cmbCategories";
			this.cmbCategories.Size = new System.Drawing.Size(133, 21);
			this.cmbCategories.TabIndex = 4;
			// 
			// gbWrapUp
			// 
			this.gbWrapUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbWrapUp.Controls.Add(this.txtWrapUp);
			this.gbWrapUp.Location = new System.Drawing.Point(12, 184);
			this.gbWrapUp.Name = "gbWrapUp";
			this.gbWrapUp.Size = new System.Drawing.Size(262, 45);
			this.gbWrapUp.TabIndex = 5;
			this.gbWrapUp.TabStop = false;
			this.gbWrapUp.Text = "Wrap Up";
			// 
			// gbCategory
			// 
			this.gbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbCategory.Controls.Add(this.cmbCategories);
			this.gbCategory.Location = new System.Drawing.Point(12, 126);
			this.gbCategory.Name = "gbCategory";
			this.gbCategory.Size = new System.Drawing.Size(145, 52);
			this.gbCategory.TabIndex = 6;
			this.gbCategory.TabStop = false;
			this.gbCategory.Text = "Category";
			// 
			// ckbMandatory
			// 
			this.ckbMandatory.AutoSize = true;
			this.ckbMandatory.Location = new System.Drawing.Point(163, 145);
			this.ckbMandatory.Name = "ckbMandatory";
			this.ckbMandatory.Size = new System.Drawing.Size(76, 17);
			this.ckbMandatory.TabIndex = 7;
			this.ckbMandatory.Text = "Mandatory";
			this.ckbMandatory.UseVisualStyleBackColor = true;
			// 
			// AddQuickWrap
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(286, 270);
			this.Controls.Add(this.ckbMandatory);
			this.Controls.Add(this.gbCategory);
			this.Controls.Add(this.gbWrapUp);
			this.Controls.Add(this.txtDisclaimer);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.MaximizeBox = false;
			this.Name = "AddQuickWrap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmAddQuickWrap";
			this.TopMost = true;
			this.gbWrapUp.ResumeLayout(false);
			this.gbWrapUp.PerformLayout();
			this.gbCategory.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDisclaimer;
        private System.Windows.Forms.TextBox txtWrapUp;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.GroupBox gbWrapUp;
        private System.Windows.Forms.GroupBox gbCategory;
		private System.Windows.Forms.CheckBox ckbMandatory;
    }
}