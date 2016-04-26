namespace Retail_HD.Forms
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	partial class StoreSearch
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDM = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTZ = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtType = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.txtState = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.dgvStores = new System.Windows.Forms.DataGridView();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.txtMP = new System.Windows.Forms.TextBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txtManager = new System.Windows.Forms.TextBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.txtBAMS = new System.Windows.Forms.TextBox();
			this.gbTop = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStores)).BeginInit();
			this.groupBox10.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.gbTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDM);
			this.groupBox1.Location = new System.Drawing.Point(298, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(124, 45);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "District Manager";
			// 
			// txtDM
			// 
			this.txtDM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDM.Location = new System.Drawing.Point(6, 19);
			this.txtDM.Name = "txtDM";
			this.txtDM.Size = new System.Drawing.Size(112, 20);
			this.txtDM.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtTZ);
			this.groupBox2.Location = new System.Drawing.Point(87, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(76, 45);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Time Zone";
			// 
			// txtTZ
			// 
			this.txtTZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTZ.AutoCompleteCustomSource.AddRange(new string[] {
            "EST",
            "CST",
            "MST",
            "PST"});
			this.txtTZ.FormattingEnabled = true;
			this.txtTZ.Items.AddRange(new object[] {
            "EST",
            "CST",
            "MST",
            "PST"});
			this.txtTZ.Location = new System.Drawing.Point(6, 19);
			this.txtTZ.Name = "txtTZ";
			this.txtTZ.Size = new System.Drawing.Size(64, 21);
			this.txtTZ.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtName);
			this.groupBox3.Location = new System.Drawing.Point(428, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(121, 45);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(6, 19);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(109, 20);
			this.txtName.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtType);
			this.groupBox4.Location = new System.Drawing.Point(549, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(124, 45);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Type";
			// 
			// txtType
			// 
			this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtType.Location = new System.Drawing.Point(6, 19);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(112, 20);
			this.txtType.TabIndex = 0;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtAddress);
			this.groupBox5.Location = new System.Drawing.Point(214, 63);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(280, 45);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Address";
			// 
			// txtAddress
			// 
			this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddress.Location = new System.Drawing.Point(6, 19);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(268, 20);
			this.txtAddress.TabIndex = 0;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.txtCity);
			this.groupBox6.Location = new System.Drawing.Point(500, 63);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(135, 45);
			this.groupBox6.TabIndex = 9;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "City";
			// 
			// txtCity
			// 
			this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCity.Location = new System.Drawing.Point(6, 19);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(123, 20);
			this.txtCity.TabIndex = 0;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.txtState);
			this.groupBox7.Location = new System.Drawing.Point(641, 63);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(53, 45);
			this.groupBox7.TabIndex = 10;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "State";
			// 
			// txtState
			// 
			this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtState.Location = new System.Drawing.Point(6, 19);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(41, 20);
			this.txtState.TabIndex = 0;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.txtZip);
			this.groupBox8.Location = new System.Drawing.Point(697, 63);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(88, 45);
			this.groupBox8.TabIndex = 11;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Zip Code";
			// 
			// txtZip
			// 
			this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtZip.Location = new System.Drawing.Point(6, 19);
			this.txtZip.Name = "txtZip";
			this.txtZip.Size = new System.Drawing.Size(76, 20);
			this.txtZip.TabIndex = 0;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.txtPhone);
			this.groupBox9.Location = new System.Drawing.Point(679, 12);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(139, 45);
			this.groupBox9.TabIndex = 5;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Phone";
			// 
			// txtPhone
			// 
			this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPhone.Location = new System.Drawing.Point(6, 19);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(127, 20);
			this.txtPhone.TabIndex = 0;
			// 
			// dgvStores
			// 
			this.dgvStores.AllowUserToAddRows = false;
			this.dgvStores.AllowUserToDeleteRows = false;
			this.dgvStores.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.dgvStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStores.Location = new System.Drawing.Point(0, 114);
			this.dgvStores.Name = "dgvStores";
			this.dgvStores.ReadOnly = true;
			this.dgvStores.RowHeadersVisible = false;
			this.dgvStores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStores.Size = new System.Drawing.Size(942, 239);
			this.dgvStores.TabIndex = 11;
			this.dgvStores.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.txtMP);
			this.groupBox10.Location = new System.Drawing.Point(87, 63);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(121, 45);
			this.groupBox10.TabIndex = 7;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "MP ID";
			// 
			// txtMP
			// 
			this.txtMP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMP.Location = new System.Drawing.Point(6, 19);
			this.txtMP.Name = "txtMP";
			this.txtMP.Size = new System.Drawing.Size(109, 20);
			this.txtMP.TabIndex = 0;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.txtManager);
			this.groupBox11.Location = new System.Drawing.Point(163, 12);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(135, 45);
			this.groupBox11.TabIndex = 1;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Manager";
			// 
			// txtManager
			// 
			this.txtManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtManager.Location = new System.Drawing.Point(6, 19);
			this.txtManager.Name = "txtManager";
			this.txtManager.Size = new System.Drawing.Size(123, 20);
			this.txtManager.TabIndex = 0;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.txtIP);
			this.groupBox12.Location = new System.Drawing.Point(791, 63);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(139, 45);
			this.groupBox12.TabIndex = 12;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "IP";
			// 
			// txtIP
			// 
			this.txtIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIP.Location = new System.Drawing.Point(6, 19);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(127, 20);
			this.txtIP.TabIndex = 0;
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.txtBAMS);
			this.groupBox13.Location = new System.Drawing.Point(825, 12);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(105, 45);
			this.groupBox13.TabIndex = 6;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "BAMS";
			// 
			// txtBAMS
			// 
			this.txtBAMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBAMS.Location = new System.Drawing.Point(6, 19);
			this.txtBAMS.Name = "txtBAMS";
			this.txtBAMS.Size = new System.Drawing.Size(93, 20);
			this.txtBAMS.TabIndex = 0;
			// 
			// gbTop
			// 
			this.gbTop.Controls.Add(this.btnClear);
			this.gbTop.Controls.Add(this.btnSearch);
			this.gbTop.Controls.Add(this.groupBox2);
			this.gbTop.Controls.Add(this.groupBox13);
			this.gbTop.Controls.Add(this.groupBox1);
			this.gbTop.Controls.Add(this.groupBox12);
			this.gbTop.Controls.Add(this.groupBox4);
			this.gbTop.Controls.Add(this.groupBox11);
			this.gbTop.Controls.Add(this.groupBox3);
			this.gbTop.Controls.Add(this.groupBox10);
			this.gbTop.Controls.Add(this.groupBox5);
			this.gbTop.Controls.Add(this.groupBox6);
			this.gbTop.Controls.Add(this.groupBox7);
			this.gbTop.Controls.Add(this.groupBox9);
			this.gbTop.Controls.Add(this.groupBox8);
			this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTop.Location = new System.Drawing.Point(0, 0);
			this.gbTop.Name = "gbTop";
			this.gbTop.Size = new System.Drawing.Size(942, 108);
			this.gbTop.TabIndex = 0;
			this.gbTop.TabStop = false;
			// 
			// btnClear
			// 
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClear.Location = new System.Drawing.Point(6, 79);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 14;
			this.btnClear.Text = "&Clear >";
			this.btnClear.UseVisualStyleBackColor = true;
			// 
			// btnSearch
			// 
			this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSearch.Location = new System.Drawing.Point(6, 29);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 13;
			this.btnSearch.Text = "&Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// StoreSearch
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClear;
			this.ClientSize = new System.Drawing.Size(942, 353);
			this.Controls.Add(this.gbTop);
			this.Controls.Add(this.dgvStores);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(958, 181);
			this.Name = "StoreSearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Store Search";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StoreSearch_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStores)).EndInit();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.gbTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtDM;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox txtTZ;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox txtZip;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.DataGridView dgvStores;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox txtMP;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.TextBox txtBAMS;
		private System.Windows.Forms.GroupBox gbTop;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnSearch;
	}
}