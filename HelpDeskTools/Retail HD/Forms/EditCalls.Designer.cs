namespace Retail_HD.Forms
{
	partial class EditCalls
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
			this.gbStore = new System.Windows.Forms.GroupBox();
			this.txtStore = new System.Windows.Forms.TextBox();
			this.gbCategory = new System.Windows.Forms.GroupBox();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.gbProblem = new System.Windows.Forms.GroupBox();
			this.txtDetails = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbContact = new System.Windows.Forms.GroupBox();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.ckbTopics = new System.Windows.Forms.CheckedListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckbTrax = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtTech = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.gbTRAX = new System.Windows.Forms.GroupBox();
			this.txtTRAX = new System.Windows.Forms.TextBox();
			this.gbStore.SuspendLayout();
			this.gbCategory.SuspendLayout();
			this.gbProblem.SuspendLayout();
			this.gbContact.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gbTRAX.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbStore
			// 
			this.gbStore.Controls.Add(this.txtStore);
			this.gbStore.Location = new System.Drawing.Point(13, 55);
			this.gbStore.Name = "gbStore";
			this.gbStore.Size = new System.Drawing.Size(74, 40);
			this.gbStore.TabIndex = 10;
			this.gbStore.TabStop = false;
			this.gbStore.Text = "Store";
			// 
			// txtStore
			// 
			this.txtStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStore.Location = new System.Drawing.Point(6, 14);
			this.txtStore.Name = "txtStore";
			this.txtStore.Size = new System.Drawing.Size(62, 20);
			this.txtStore.TabIndex = 0;
			this.txtStore.TabStop = false;
			// 
			// gbCategory
			// 
			this.gbCategory.Controls.Add(this.cmbCategory);
			this.gbCategory.Location = new System.Drawing.Point(93, 55);
			this.gbCategory.Name = "gbCategory";
			this.gbCategory.Size = new System.Drawing.Size(144, 40);
			this.gbCategory.TabIndex = 0;
			this.gbCategory.TabStop = false;
			this.gbCategory.Text = "Category";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new System.Drawing.Point(6, 14);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(132, 21);
			this.cmbCategory.Sorted = true;
			this.cmbCategory.TabIndex = 0;
			this.cmbCategory.Text = "Software";
			this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
			this.cmbCategory.TextChanged += new System.EventHandler(this.cmbCategory_TextChanged);
			this.cmbCategory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbCategory_MouseClick);
			// 
			// gbProblem
			// 
			this.gbProblem.Controls.Add(this.txtDetails);
			this.gbProblem.Location = new System.Drawing.Point(13, 101);
			this.gbProblem.Name = "gbProblem";
			this.gbProblem.Size = new System.Drawing.Size(224, 126);
			this.gbProblem.TabIndex = 2;
			this.gbProblem.TabStop = false;
			this.gbProblem.Text = "Details";
			// 
			// txtDetails
			// 
			this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDetails.Location = new System.Drawing.Point(6, 14);
			this.txtDetails.Multiline = true;
			this.txtDetails.Name = "txtDetails";
			this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDetails.Size = new System.Drawing.Size(212, 106);
			this.txtDetails.TabIndex = 0;
			this.txtDetails.Click += new System.EventHandler(this.txtDetails_Click);
			this.txtDetails.Enter += new System.EventHandler(this.txtDetails_Enter);
			this.txtDetails.Leave += new System.EventHandler(this.txtDetails_Leave);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(346, 324);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
			// 
			// gbContact
			// 
			this.gbContact.Controls.Add(this.cmbType);
			this.gbContact.Location = new System.Drawing.Point(13, 233);
			this.gbContact.Name = "gbContact";
			this.gbContact.Size = new System.Drawing.Size(92, 40);
			this.gbContact.TabIndex = 3;
			this.gbContact.TabStop = false;
			this.gbContact.Text = "Call Type";
			// 
			// cmbType
			// 
			this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbType.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {
            "In",
            "Out"});
			this.cmbType.Location = new System.Drawing.Point(6, 14);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(80, 21);
			this.cmbType.TabIndex = 0;
			this.cmbType.Text = "In";
			this.cmbType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbType_MouseClick);
			// 
			// ckbTopics
			// 
			this.ckbTopics.BackColor = System.Drawing.SystemColors.Control;
			this.ckbTopics.CheckOnClick = true;
			this.ckbTopics.FormattingEnabled = true;
			this.ckbTopics.Location = new System.Drawing.Point(6, 19);
			this.ckbTopics.Name = "ckbTopics";
			this.ckbTopics.Size = new System.Drawing.Size(171, 229);
			this.ckbTopics.Sorted = true;
			this.ckbTopics.TabIndex = 1;
			this.ckbTopics.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckbTopics_ItemCheck);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckbTopics);
			this.groupBox1.Location = new System.Drawing.Point(242, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(183, 261);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Topics";
			// 
			// ckbTrax
			// 
			this.ckbTrax.AutoSize = true;
			this.ckbTrax.Location = new System.Drawing.Point(111, 249);
			this.ckbTrax.Name = "ckbTrax";
			this.ckbTrax.Size = new System.Drawing.Size(95, 17);
			this.ckbTrax.TabIndex = 4;
			this.ckbTrax.Text = "TRAX Created";
			this.ckbTrax.UseVisualStyleBackColor = true;
			this.ckbTrax.CheckedChanged += new System.EventHandler(this.ckbTrax_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(265, 324);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtTech);
			this.groupBox3.Location = new System.Drawing.Point(157, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(74, 40);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tech";
			// 
			// txtTech
			// 
			this.txtTech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTech.Location = new System.Drawing.Point(6, 14);
			this.txtTech.Name = "txtTech";
			this.txtTech.ReadOnly = true;
			this.txtTech.Size = new System.Drawing.Size(62, 20);
			this.txtTech.TabIndex = 0;
			this.txtTech.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtDate);
			this.groupBox4.Location = new System.Drawing.Point(13, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(138, 40);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Date";
			// 
			// txtDate
			// 
			this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDate.Location = new System.Drawing.Point(6, 14);
			this.txtDate.Name = "txtDate";
			this.txtDate.ReadOnly = true;
			this.txtDate.Size = new System.Drawing.Size(126, 20);
			this.txtDate.TabIndex = 0;
			this.txtDate.TabStop = false;
			// 
			// gbTRAX
			// 
			this.gbTRAX.Controls.Add(this.txtTRAX);
			this.gbTRAX.Location = new System.Drawing.Point(13, 274);
			this.gbTRAX.Name = "gbTRAX";
			this.gbTRAX.Size = new System.Drawing.Size(413, 44);
			this.gbTRAX.TabIndex = 5;
			this.gbTRAX.TabStop = false;
			this.gbTRAX.Text = "Trax URL";
			// 
			// txtTRAX
			// 
			this.txtTRAX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTRAX.Location = new System.Drawing.Point(6, 19);
			this.txtTRAX.Name = "txtTRAX";
			this.txtTRAX.Size = new System.Drawing.Size(401, 20);
			this.txtTRAX.TabIndex = 0;
			this.txtTRAX.Click += new System.EventHandler(this.txtTRAX_Click);
			// 
			// EditCalls
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(433, 355);
			this.Controls.Add(this.gbTRAX);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gbStore);
			this.Controls.Add(this.gbCategory);
			this.Controls.Add(this.gbProblem);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbContact);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ckbTrax);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = global::Shared.GlobalResources.icoMain;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(449, 389);
			this.Name = "EditCalls";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EditCalls";
			this.Load += new System.EventHandler(this.EditCalls_Load);
			this.gbStore.ResumeLayout(false);
			this.gbStore.PerformLayout();
			this.gbCategory.ResumeLayout(false);
			this.gbProblem.ResumeLayout(false);
			this.gbProblem.PerformLayout();
			this.gbContact.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gbTRAX.ResumeLayout(false);
			this.gbTRAX.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbStore;
		private System.Windows.Forms.TextBox txtStore;
		private System.Windows.Forms.GroupBox gbCategory;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.GroupBox gbProblem;
		private System.Windows.Forms.TextBox txtDetails;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox gbContact;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.CheckedListBox ckbTopics;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox ckbTrax;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtTech;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtDate;
		private System.Windows.Forms.GroupBox gbTRAX;
		private System.Windows.Forms.TextBox txtTRAX;

	}
}