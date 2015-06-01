namespace Retail_HD.Forms
{
	partial class ExcelLoadTables
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbColumnsE = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbTablesE = new System.Windows.Forms.CheckedListBox();
            this.btnLoadE = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(537, 367);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(429, 367);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbColumnsE);
            this.groupBox2.Location = new System.Drawing.Point(307, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(336, 346);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Columns";
            // 
            // ckbColumnsE
            // 
            this.ckbColumnsE.CheckOnClick = true;
            this.ckbColumnsE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbColumnsE.FormattingEnabled = true;
            this.ckbColumnsE.Location = new System.Drawing.Point(4, 19);
            this.ckbColumnsE.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnsE.Name = "ckbColumnsE";
            this.ckbColumnsE.Size = new System.Drawing.Size(328, 323);
            this.ckbColumnsE.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckbTablesE);
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(232, 247);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sheets";
            // 
            // ckbTablesE
            // 
            this.ckbTablesE.CheckOnClick = true;
            this.ckbTablesE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbTablesE.FormattingEnabled = true;
            this.ckbTablesE.Location = new System.Drawing.Point(4, 19);
            this.ckbTablesE.Margin = new System.Windows.Forms.Padding(4);
            this.ckbTablesE.Name = "ckbTablesE";
            this.ckbTablesE.Size = new System.Drawing.Size(224, 224);
            this.ckbTablesE.TabIndex = 1;
            // 
            // btnLoadE
            // 
            this.btnLoadE.Location = new System.Drawing.Point(253, 83);
            this.btnLoadE.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadE.Name = "btnLoadE";
            this.btnLoadE.Size = new System.Drawing.Size(46, 93);
            this.btnLoadE.TabIndex = 11;
            this.btnLoadE.Text = "-->";
            this.btnLoadE.UseVisualStyleBackColor = true;
            this.btnLoadE.Click += new System.EventHandler(this.btnLoadE_Click);
            // 
            // ExcelLoadTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnLoadE);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExcelLoadTables";
            this.Text = "ExcelSchemaInfo";
            this.Load += new System.EventHandler(this.ExcelSchemaInfo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox ckbColumnsE;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox ckbTablesE;
        private System.Windows.Forms.Button btnLoadE;
	}
}