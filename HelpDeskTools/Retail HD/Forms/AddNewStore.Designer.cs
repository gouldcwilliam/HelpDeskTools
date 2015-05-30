namespace Retail_HD.Forms
{
	partial class AddNewStore
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
			this.txtStore = new System.Windows.Forms.MaskedTextBox();
			this.gbName = new System.Windows.Forms.GroupBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.gbState = new System.Windows.Forms.GroupBox();
			this.txtState = new System.Windows.Forms.TextBox();
			this.gbZip = new System.Windows.Forms.GroupBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.gbTZ = new System.Windows.Forms.GroupBox();
			this.txtTZ = new System.Windows.Forms.ComboBox();
			this.gbPhone = new System.Windows.Forms.GroupBox();
			this.txtPhone = new System.Windows.Forms.MaskedTextBox();
			this.gbType = new System.Windows.Forms.GroupBox();
			this.txtType = new System.Windows.Forms.TextBox();
			this.gbPos = new System.Windows.Forms.GroupBox();
			this.txtPOS = new System.Windows.Forms.MaskedTextBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txtMall = new System.Windows.Forms.TextBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.txtDM = new System.Windows.Forms.TextBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.txtManager = new System.Windows.Forms.TextBox();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.txtMPID = new System.Windows.Forms.TextBox();
			this.gbAddress = new System.Windows.Forms.GroupBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.gb3rd = new System.Windows.Forms.GroupBox();
			this.txt3rd = new System.Windows.Forms.MaskedTextBox();
			this.lblIP = new System.Windows.Forms.Label();
			this.lblPosgate = new System.Windows.Forms.Label();
			this.lblSensGate = new System.Windows.Forms.Label();
			this.lblMimGate = new System.Windows.Forms.Label();
			this.lblMim = new System.Windows.Forms.Label();
			this.lblSens = new System.Windows.Forms.Label();
			this.gbStore.SuspendLayout();
			this.gbName.SuspendLayout();
			this.gbState.SuspendLayout();
			this.gbZip.SuspendLayout();
			this.gbTZ.SuspendLayout();
			this.gbPhone.SuspendLayout();
			this.gbType.SuspendLayout();
			this.gbPos.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.gbAddress.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gb3rd.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbStore
			// 
			this.gbStore.Controls.Add(this.txtStore);
			this.gbStore.Location = new System.Drawing.Point(12, 12);
			this.gbStore.Name = "gbStore";
			this.gbStore.Size = new System.Drawing.Size(76, 42);
			this.gbStore.TabIndex = 0;
			this.gbStore.TabStop = false;
			this.gbStore.Text = "Store #";
			// 
			// txtStore
			// 
			this.txtStore.Location = new System.Drawing.Point(6, 19);
			this.txtStore.Mask = "0000";
			this.txtStore.Name = "txtStore";
			this.txtStore.Size = new System.Drawing.Size(64, 20);
			this.txtStore.TabIndex = 0;
			this.txtStore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStore_MouseClick);
			this.txtStore.TextChanged += new System.EventHandler(this.txtStore_TextChanged);
			this.txtStore.Enter += new System.EventHandler(this.txtStore_Enter);
			// 
			// gbName
			// 
			this.gbName.Controls.Add(this.txtName);
			this.gbName.Location = new System.Drawing.Point(94, 12);
			this.gbName.Name = "gbName";
			this.gbName.Size = new System.Drawing.Size(162, 42);
			this.gbName.TabIndex = 1;
			this.gbName.TabStop = false;
			this.gbName.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(6, 19);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(150, 20);
			this.txtName.TabIndex = 0;
			this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// gbState
			// 
			this.gbState.Controls.Add(this.txtState);
			this.gbState.Location = new System.Drawing.Point(135, 105);
			this.gbState.Name = "gbState";
			this.gbState.Size = new System.Drawing.Size(56, 42);
			this.gbState.TabIndex = 4;
			this.gbState.TabStop = false;
			this.gbState.Text = "State";
			// 
			// txtState
			// 
			this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtState.Location = new System.Drawing.Point(6, 19);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(44, 20);
			this.txtState.TabIndex = 0;
			this.txtState.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtState.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// gbZip
			// 
			this.gbZip.Controls.Add(this.txtZip);
			this.gbZip.Location = new System.Drawing.Point(197, 105);
			this.gbZip.Name = "gbZip";
			this.gbZip.Size = new System.Drawing.Size(93, 42);
			this.gbZip.TabIndex = 5;
			this.gbZip.TabStop = false;
			this.gbZip.Text = "Zip";
			// 
			// txtZip
			// 
			this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtZip.Location = new System.Drawing.Point(6, 19);
			this.txtZip.Name = "txtZip";
			this.txtZip.Size = new System.Drawing.Size(81, 20);
			this.txtZip.TabIndex = 0;
			this.txtZip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtZip.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// gbTZ
			// 
			this.gbTZ.Controls.Add(this.txtTZ);
			this.gbTZ.Location = new System.Drawing.Point(12, 153);
			this.gbTZ.Name = "gbTZ";
			this.gbTZ.Size = new System.Drawing.Size(62, 42);
			this.gbTZ.TabIndex = 6;
			this.gbTZ.TabStop = false;
			this.gbTZ.Text = "TZ";
			// 
			// txtTZ
			// 
			this.txtTZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTZ.FormattingEnabled = true;
			this.txtTZ.Items.AddRange(new object[] {
            "EST",
            "CST",
            "MST",
            "PST"});
			this.txtTZ.Location = new System.Drawing.Point(6, 18);
			this.txtTZ.Name = "txtTZ";
			this.txtTZ.Size = new System.Drawing.Size(50, 21);
			this.txtTZ.TabIndex = 0;
			this.txtTZ.Text = "EST";
			this.txtTZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTZ_MouseClick);
			// 
			// gbPhone
			// 
			this.gbPhone.Controls.Add(this.txtPhone);
			this.gbPhone.Location = new System.Drawing.Point(80, 153);
			this.gbPhone.Name = "gbPhone";
			this.gbPhone.Size = new System.Drawing.Size(111, 42);
			this.gbPhone.TabIndex = 7;
			this.gbPhone.TabStop = false;
			this.gbPhone.Text = "Phone";
			// 
			// txtPhone
			// 
			this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPhone.Location = new System.Drawing.Point(6, 19);
			this.txtPhone.Mask = "999-000-0000";
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(99, 20);
			this.txtPhone.TabIndex = 0;
			this.txtPhone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStore_MouseClick);
			this.txtPhone.Enter += new System.EventHandler(this.txtStore_Enter);
			// 
			// gbType
			// 
			this.gbType.Controls.Add(this.txtType);
			this.gbType.Location = new System.Drawing.Point(12, 198);
			this.gbType.Name = "gbType";
			this.gbType.Size = new System.Drawing.Size(200, 42);
			this.gbType.TabIndex = 8;
			this.gbType.TabStop = false;
			this.gbType.Text = "Store Type";
			// 
			// txtType
			// 
			this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtType.Location = new System.Drawing.Point(6, 19);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(188, 20);
			this.txtType.TabIndex = 0;
			this.txtType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtType.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// gbPos
			// 
			this.gbPos.Controls.Add(this.txtPOS);
			this.gbPos.Location = new System.Drawing.Point(115, 243);
			this.gbPos.Name = "gbPos";
			this.gbPos.Size = new System.Drawing.Size(50, 42);
			this.gbPos.TabIndex = 11;
			this.gbPos.TabStop = false;
			this.gbPos.Text = "POS";
			// 
			// txtPOS
			// 
			this.txtPOS.Location = new System.Drawing.Point(6, 19);
			this.txtPOS.Mask = "000";
			this.txtPOS.Name = "txtPOS";
			this.txtPOS.Size = new System.Drawing.Size(38, 20);
			this.txtPOS.TabIndex = 2;
			this.txtPOS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStore_MouseClick);
			this.txtPOS.TextChanged += new System.EventHandler(this.txtPOS_TextChanged);
			this.txtPOS.Enter += new System.EventHandler(this.txtStore_Enter);
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.txtMall);
			this.groupBox11.Location = new System.Drawing.Point(395, 156);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(298, 42);
			this.groupBox11.TabIndex = 22;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Mall (Search Google by Address)";
			// 
			// txtMall
			// 
			this.txtMall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMall.Location = new System.Drawing.Point(6, 19);
			this.txtMall.Name = "txtMall";
			this.txtMall.Size = new System.Drawing.Size(286, 20);
			this.txtMall.TabIndex = 0;
			this.txtMall.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtMall.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.txtDM);
			this.groupBox12.Location = new System.Drawing.Point(573, 108);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(120, 42);
			this.groupBox12.TabIndex = 21;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "DM (Last Name)";
			// 
			// txtDM
			// 
			this.txtDM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDM.Location = new System.Drawing.Point(6, 19);
			this.txtDM.Name = "txtDM";
			this.txtDM.Size = new System.Drawing.Size(108, 20);
			this.txtDM.TabIndex = 0;
			this.txtDM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtDM.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.txtManager);
			this.groupBox13.Location = new System.Drawing.Point(395, 108);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(172, 42);
			this.groupBox13.TabIndex = 20;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Manager";
			// 
			// txtManager
			// 
			this.txtManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtManager.Location = new System.Drawing.Point(6, 19);
			this.txtManager.Name = "txtManager";
			this.txtManager.Size = new System.Drawing.Size(160, 20);
			this.txtManager.TabIndex = 0;
			this.txtManager.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtManager.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.txtMPID);
			this.groupBox14.Location = new System.Drawing.Point(395, 60);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(105, 42);
			this.groupBox14.TabIndex = 19;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "MP ID";
			// 
			// txtMPID
			// 
			this.txtMPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMPID.Location = new System.Drawing.Point(6, 19);
			this.txtMPID.Name = "txtMPID";
			this.txtMPID.Size = new System.Drawing.Size(93, 20);
			this.txtMPID.TabIndex = 0;
			this.txtMPID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtMPID.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// gbAddress
			// 
			this.gbAddress.Controls.Add(this.txtAddress);
			this.gbAddress.Location = new System.Drawing.Point(12, 57);
			this.gbAddress.Name = "gbAddress";
			this.gbAddress.Size = new System.Drawing.Size(279, 42);
			this.gbAddress.TabIndex = 2;
			this.gbAddress.TabStop = false;
			this.gbAddress.Text = "Address";
			// 
			// txtAddress
			// 
			this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddress.Location = new System.Drawing.Point(6, 19);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(267, 20);
			this.txtAddress.TabIndex = 0;
			this.txtAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtAddress.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(398, 34);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(141, 13);
			this.lblEmail.TabIndex = 18;
			this.lblEmail.Text = "StoreXXXX@WWWinc.com";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(628, 380);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 24;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(394, 217);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(299, 110);
			this.textBox1.TabIndex = 23;
			this.textBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtCity);
			this.groupBox2.Location = new System.Drawing.Point(12, 105);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(117, 42);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "City";
			// 
			// txtCity
			// 
			this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCity.Location = new System.Drawing.Point(6, 19);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(105, 20);
			this.txtCity.TabIndex = 0;
			this.txtCity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
			this.txtCity.Enter += new System.EventHandler(this.txtName_Enter);
			// 
			// gb3rd
			// 
			this.gb3rd.Controls.Add(this.txt3rd);
			this.gb3rd.Location = new System.Drawing.Point(59, 243);
			this.gb3rd.Name = "gb3rd";
			this.gb3rd.Size = new System.Drawing.Size(50, 42);
			this.gb3rd.TabIndex = 10;
			this.gb3rd.TabStop = false;
			this.gb3rd.Text = "3rd";
			// 
			// txt3rd
			// 
			this.txt3rd.Location = new System.Drawing.Point(6, 19);
			this.txt3rd.Mask = "000";
			this.txt3rd.Name = "txt3rd";
			this.txt3rd.Size = new System.Drawing.Size(38, 20);
			this.txt3rd.TabIndex = 1;
			this.txt3rd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStore_MouseClick);
			this.txt3rd.TextChanged += new System.EventHandler(this.txt3rd_TextChanged);
			this.txt3rd.Enter += new System.EventHandler(this.txtStore_Enter);
			// 
			// lblIP
			// 
			this.lblIP.AutoSize = true;
			this.lblIP.Location = new System.Drawing.Point(15, 265);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new System.Drawing.Size(31, 13);
			this.lblIP.TabIndex = 25;
			this.lblIP.Text = "10.0.";
			// 
			// lblPosgate
			// 
			this.lblPosgate.AutoSize = true;
			this.lblPosgate.Location = new System.Drawing.Point(15, 292);
			this.lblPosgate.Name = "lblPosgate";
			this.lblPosgate.Size = new System.Drawing.Size(46, 13);
			this.lblPosgate.TabIndex = 26;
			this.lblPosgate.Text = "10.0.0.0";
			// 
			// lblSensGate
			// 
			this.lblSensGate.AutoSize = true;
			this.lblSensGate.Location = new System.Drawing.Point(15, 337);
			this.lblSensGate.Name = "lblSensGate";
			this.lblSensGate.Size = new System.Drawing.Size(46, 13);
			this.lblSensGate.TabIndex = 27;
			this.lblSensGate.Text = "10.0.0.0";
			// 
			// lblMimGate
			// 
			this.lblMimGate.AutoSize = true;
			this.lblMimGate.Location = new System.Drawing.Point(15, 383);
			this.lblMimGate.Name = "lblMimGate";
			this.lblMimGate.Size = new System.Drawing.Size(46, 13);
			this.lblMimGate.TabIndex = 28;
			this.lblMimGate.Text = "10.0.0.0";
			// 
			// lblMim
			// 
			this.lblMim.AutoSize = true;
			this.lblMim.Location = new System.Drawing.Point(15, 360);
			this.lblMim.Name = "lblMim";
			this.lblMim.Size = new System.Drawing.Size(46, 13);
			this.lblMim.TabIndex = 29;
			this.lblMim.Text = "10.0.0.0";
			// 
			// lblSens
			// 
			this.lblSens.AutoSize = true;
			this.lblSens.Location = new System.Drawing.Point(15, 314);
			this.lblSens.Name = "lblSens";
			this.lblSens.Size = new System.Drawing.Size(46, 13);
			this.lblSens.TabIndex = 30;
			this.lblSens.Text = "10.0.0.0";
			// 
			// AddNewStore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 415);
			this.Controls.Add(this.lblSens);
			this.Controls.Add(this.lblMim);
			this.Controls.Add(this.lblMimGate);
			this.Controls.Add(this.lblSensGate);
			this.Controls.Add(this.lblPosgate);
			this.Controls.Add(this.lblIP);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.groupBox11);
			this.Controls.Add(this.groupBox12);
			this.Controls.Add(this.groupBox13);
			this.Controls.Add(this.groupBox14);
			this.Controls.Add(this.gbAddress);
			this.Controls.Add(this.gbPos);
			this.Controls.Add(this.gb3rd);
			this.Controls.Add(this.gbType);
			this.Controls.Add(this.gbPhone);
			this.Controls.Add(this.gbTZ);
			this.Controls.Add(this.gbZip);
			this.Controls.Add(this.gbState);
			this.Controls.Add(this.gbName);
			this.Controls.Add(this.gbStore);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.Name = "AddNewStore";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add A New Store Entry";
			this.Load += new System.EventHandler(this.AddNewStore_Load);
			this.gbStore.ResumeLayout(false);
			this.gbStore.PerformLayout();
			this.gbName.ResumeLayout(false);
			this.gbName.PerformLayout();
			this.gbState.ResumeLayout(false);
			this.gbState.PerformLayout();
			this.gbZip.ResumeLayout(false);
			this.gbZip.PerformLayout();
			this.gbTZ.ResumeLayout(false);
			this.gbPhone.ResumeLayout(false);
			this.gbPhone.PerformLayout();
			this.gbType.ResumeLayout(false);
			this.gbType.PerformLayout();
			this.gbPos.ResumeLayout(false);
			this.gbPos.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.gbAddress.ResumeLayout(false);
			this.gbAddress.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.gb3rd.ResumeLayout(false);
			this.gb3rd.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbStore;
		private System.Windows.Forms.GroupBox gbName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.GroupBox gbState;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.GroupBox gbZip;
		private System.Windows.Forms.TextBox txtZip;
		private System.Windows.Forms.GroupBox gbTZ;
		private System.Windows.Forms.ComboBox txtTZ;
		private System.Windows.Forms.GroupBox gbPhone;
		private System.Windows.Forms.MaskedTextBox txtPhone;
		private System.Windows.Forms.GroupBox gbType;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.GroupBox gbPos;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TextBox txtMall;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.TextBox txtDM;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.TextBox txtManager;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.TextBox txtMPID;
		private System.Windows.Forms.GroupBox gbAddress;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.MaskedTextBox txtStore;
		private System.Windows.Forms.GroupBox gb3rd;
		private System.Windows.Forms.Label lblIP;
		private System.Windows.Forms.MaskedTextBox txtPOS;
		private System.Windows.Forms.MaskedTextBox txt3rd;
		private System.Windows.Forms.Label lblPosgate;
		private System.Windows.Forms.Label lblSensGate;
		private System.Windows.Forms.Label lblMimGate;
		private System.Windows.Forms.Label lblMim;
		private System.Windows.Forms.Label lblSens;
	}
}