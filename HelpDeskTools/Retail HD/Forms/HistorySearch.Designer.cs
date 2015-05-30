namespace Retail_HD.Forms
{
	partial class HistorySearch
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
			this.dgvResults = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtResultLimit = new System.Windows.Forms.TextBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txtDetails = new System.Windows.Forms.TextBox();
			this.ckbTrax = new System.Windows.Forms.CheckBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cmbTech = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cmbTopic = new System.Windows.Forms.ComboBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
			this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtStore = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmbType = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvResults
			// 
			this.dgvResults.AllowUserToAddRows = false;
			this.dgvResults.AllowUserToDeleteRows = false;
			this.dgvResults.AllowUserToOrderColumns = true;
			this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResults.Location = new System.Drawing.Point(12, 182);
			this.dgvResults.MultiSelect = false;
			this.dgvResults.Name = "dgvResults";
			this.dgvResults.ReadOnly = true;
			this.dgvResults.RowHeadersVisible = false;
			this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResults.Size = new System.Drawing.Size(942, 451);
			this.dgvResults.TabIndex = 1;
			this.dgvResults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvResults_DataBindingComplete);
			this.dgvResults.DoubleClick += new System.EventHandler(this.dgvResults_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.btnExport);
			this.groupBox1.Controls.Add(this.btnClear);
			this.groupBox1.Controls.Add(this.btnSearch);
			this.groupBox1.Controls.Add(this.groupBox10);
			this.groupBox1.Controls.Add(this.groupBox9);
			this.groupBox1.Controls.Add(this.ckbTrax);
			this.groupBox1.Controls.Add(this.groupBox8);
			this.groupBox1.Controls.Add(this.groupBox7);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(942, 164);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search Fields";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtResultLimit);
			this.groupBox2.Location = new System.Drawing.Point(518, 115);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(131, 43);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Result Limit";
			// 
			// txtResultLimit
			// 
			this.txtResultLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResultLimit.Location = new System.Drawing.Point(6, 17);
			this.txtResultLimit.Name = "txtResultLimit";
			this.txtResultLimit.Size = new System.Drawing.Size(119, 20);
			this.txtResultLimit.TabIndex = 0;
			// 
			// btnExport
			// 
			this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExport.Location = new System.Drawing.Point(861, 130);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 12;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.Export);
			// 
			// btnClear
			// 
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClear.Location = new System.Drawing.Point(6, 130);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 11;
			this.btnClear.Text = "Clear >";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.ClearForm);
			// 
			// btnSearch
			// 
			this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSearch.Location = new System.Drawing.Point(6, 34);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.Search);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.txtURL);
			this.groupBox10.Location = new System.Drawing.Point(518, 70);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(418, 40);
			this.groupBox10.TabIndex = 8;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Trax URL";
			// 
			// txtURL
			// 
			this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtURL.Location = new System.Drawing.Point(6, 17);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(406, 20);
			this.txtURL.TabIndex = 0;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.txtDetails);
			this.groupBox9.Location = new System.Drawing.Point(124, 70);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(327, 89);
			this.groupBox9.TabIndex = 6;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Details";
			// 
			// txtDetails
			// 
			this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDetails.Location = new System.Drawing.Point(6, 17);
			this.txtDetails.Multiline = true;
			this.txtDetails.Name = "txtDetails";
			this.txtDetails.Size = new System.Drawing.Size(315, 69);
			this.txtDetails.TabIndex = 0;
			// 
			// ckbTrax
			// 
			this.ckbTrax.AutoSize = true;
			this.ckbTrax.Location = new System.Drawing.Point(457, 89);
			this.ckbTrax.Name = "ckbTrax";
			this.ckbTrax.Size = new System.Drawing.Size(55, 17);
			this.ckbTrax.TabIndex = 7;
			this.ckbTrax.Text = "TRAX";
			this.ckbTrax.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.cmbCategory);
			this.groupBox8.Location = new System.Drawing.Point(496, 20);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(166, 44);
			this.groupBox8.TabIndex = 3;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Category";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new System.Drawing.Point(6, 19);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(154, 21);
			this.cmbCategory.TabIndex = 0;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.cmbTech);
			this.groupBox7.Location = new System.Drawing.Point(840, 20);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(96, 44);
			this.groupBox7.TabIndex = 5;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Tech";
			// 
			// cmbTech
			// 
			this.cmbTech.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTech.FormattingEnabled = true;
			this.cmbTech.Location = new System.Drawing.Point(6, 19);
			this.cmbTech.Name = "cmbTech";
			this.cmbTech.Size = new System.Drawing.Size(84, 21);
			this.cmbTech.TabIndex = 0;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cmbTopic);
			this.groupBox5.Location = new System.Drawing.Point(668, 20);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(166, 44);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Topic";
			// 
			// cmbTopic
			// 
			this.cmbTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTopic.FormattingEnabled = true;
			this.cmbTopic.Location = new System.Drawing.Point(6, 19);
			this.cmbTopic.Name = "cmbTopic";
			this.cmbTopic.Size = new System.Drawing.Size(154, 21);
			this.cmbTopic.TabIndex = 0;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.dtpDate2);
			this.groupBox6.Controls.Add(this.dtpDate1);
			this.groupBox6.Location = new System.Drawing.Point(281, 19);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(209, 44);
			this.groupBox6.TabIndex = 2;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Date";
			// 
			// dtpDate2
			// 
			this.dtpDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpDate2.Checked = false;
			this.dtpDate2.CustomFormat = "";
			this.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDate2.Location = new System.Drawing.Point(119, 20);
			this.dtpDate2.Name = "dtpDate2";
			this.dtpDate2.ShowCheckBox = true;
			this.dtpDate2.Size = new System.Drawing.Size(84, 20);
			this.dtpDate2.TabIndex = 1;
			// 
			// dtpDate1
			// 
			this.dtpDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpDate1.Checked = false;
			this.dtpDate1.CustomFormat = "";
			this.dtpDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDate1.Location = new System.Drawing.Point(6, 20);
			this.dtpDate1.Name = "dtpDate1";
			this.dtpDate1.ShowCheckBox = true;
			this.dtpDate1.Size = new System.Drawing.Size(84, 20);
			this.dtpDate1.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtStore);
			this.groupBox4.Location = new System.Drawing.Point(124, 20);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(70, 43);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Store";
			// 
			// txtStore
			// 
			this.txtStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStore.Location = new System.Drawing.Point(6, 17);
			this.txtStore.Name = "txtStore";
			this.txtStore.Size = new System.Drawing.Size(58, 20);
			this.txtStore.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbType);
			this.groupBox3.Location = new System.Drawing.Point(200, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(75, 44);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Type";
			// 
			// cmbType
			// 
			this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {
            "In",
            "Out"});
			this.cmbType.Location = new System.Drawing.Point(6, 19);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(63, 21);
			this.cmbType.TabIndex = 0;
			// 
			// HistorySearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 645);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dgvResults);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.Name = "HistorySearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "History";
			this.Load += new System.EventHandler(this.SQLquery_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView dgvResults;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox txtDetails;
		private System.Windows.Forms.CheckBox ckbTrax;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ComboBox cmbTech;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cmbTopic;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.DateTimePicker dtpDate1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtStore;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.DateTimePicker dtpDate2;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtResultLimit;
	}
}