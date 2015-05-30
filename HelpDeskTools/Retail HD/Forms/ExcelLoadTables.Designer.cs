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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ckbColumnsE = new System.Windows.Forms.CheckedListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ckbTablesE = new System.Windows.Forms.CheckedListBox();
			this.btnLoadE = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ckbColumsS = new System.Windows.Forms.CheckedListBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.ckbTablesS = new System.Windows.Forms.CheckedListBox();
			this.btnLoadS = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(465, 519);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(384, 519);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.btnLoadE);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(269, 513);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Excel";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ckbColumnsE);
			this.groupBox2.Location = new System.Drawing.Point(12, 226);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(255, 281);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Columns";
			// 
			// ckbColumnsE
			// 
			this.ckbColumnsE.CheckOnClick = true;
			this.ckbColumnsE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ckbColumnsE.FormattingEnabled = true;
			this.ckbColumnsE.Location = new System.Drawing.Point(3, 16);
			this.ckbColumnsE.Name = "ckbColumnsE";
			this.ckbColumnsE.Size = new System.Drawing.Size(249, 262);
			this.ckbColumnsE.TabIndex = 4;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ckbTablesE);
			this.groupBox3.Location = new System.Drawing.Point(12, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(174, 201);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Sheets";
			// 
			// ckbTablesE
			// 
			this.ckbTablesE.CheckOnClick = true;
			this.ckbTablesE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ckbTablesE.FormattingEnabled = true;
			this.ckbTablesE.Location = new System.Drawing.Point(3, 16);
			this.ckbTablesE.Name = "ckbTablesE";
			this.ckbTablesE.Size = new System.Drawing.Size(168, 182);
			this.ckbTablesE.TabIndex = 1;
			// 
			// btnLoadE
			// 
			this.btnLoadE.Location = new System.Drawing.Point(192, 103);
			this.btnLoadE.Name = "btnLoadE";
			this.btnLoadE.Size = new System.Drawing.Size(75, 23);
			this.btnLoadE.TabIndex = 8;
			this.btnLoadE.Text = "Load Sheet";
			this.btnLoadE.UseVisualStyleBackColor = true;
			this.btnLoadE.Click += new System.EventHandler(this.btnLoadE_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Controls.Add(this.btnLoadS);
			this.groupBox4.Location = new System.Drawing.Point(273, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(269, 513);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "SQL";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.ckbColumsS);
			this.groupBox5.Location = new System.Drawing.Point(12, 226);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(255, 281);
			this.groupBox5.TabIndex = 10;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Columns";
			// 
			// ckbColumsS
			// 
			this.ckbColumsS.CheckOnClick = true;
			this.ckbColumsS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ckbColumsS.FormattingEnabled = true;
			this.ckbColumsS.Location = new System.Drawing.Point(3, 16);
			this.ckbColumsS.Name = "ckbColumsS";
			this.ckbColumsS.Size = new System.Drawing.Size(249, 262);
			this.ckbColumsS.TabIndex = 4;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.ckbTablesS);
			this.groupBox6.Location = new System.Drawing.Point(12, 19);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(174, 201);
			this.groupBox6.TabIndex = 9;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Tables";
			// 
			// ckbTablesS
			// 
			this.ckbTablesS.CheckOnClick = true;
			this.ckbTablesS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ckbTablesS.FormattingEnabled = true;
			this.ckbTablesS.Location = new System.Drawing.Point(3, 16);
			this.ckbTablesS.Name = "ckbTablesS";
			this.ckbTablesS.Size = new System.Drawing.Size(168, 182);
			this.ckbTablesS.TabIndex = 1;
			// 
			// btnLoadS
			// 
			this.btnLoadS.Location = new System.Drawing.Point(192, 103);
			this.btnLoadS.Name = "btnLoadS";
			this.btnLoadS.Size = new System.Drawing.Size(75, 23);
			this.btnLoadS.TabIndex = 8;
			this.btnLoadS.Text = "Load Table";
			this.btnLoadS.UseVisualStyleBackColor = true;
			this.btnLoadS.Click += new System.EventHandler(this.btnLoadS_Click);
			// 
			// ExcelLoadTables
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(544, 554);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ExcelLoadTables";
			this.Text = "ExcelSchemaInfo";
			this.Load += new System.EventHandler(this.ExcelSchemaInfo_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckedListBox ckbColumnsE;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckedListBox ckbTablesE;
		private System.Windows.Forms.Button btnLoadE;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckedListBox ckbColumsS;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckedListBox ckbTablesS;
		private System.Windows.Forms.Button btnLoadS;
	}
}