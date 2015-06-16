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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtThird = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtLan1 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtGate1 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtLan2 = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtGate2 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtLan3 = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtGate3 = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txtLan4 = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtGate4 = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtSVS = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.txtBAMS = new System.Windows.Forms.TextBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.txtTID1 = new System.Windows.Forms.TextBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.txtTID2 = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.txtTID3 = new System.Windows.Forms.TextBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.txtTID4 = new System.Windows.Forms.TextBox();
            this.gbStore.SuspendLayout();
            this.gbName.SuspendLayout();
            this.gbState.SuspendLayout();
            this.gbZip.SuspendLayout();
            this.gbTZ.SuspendLayout();
            this.gbPhone.SuspendLayout();
            this.gbType.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.gbAddress.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox22.SuspendLayout();
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
            this.txtStore.TextChanged += new System.EventHandler(this.txtStore_TextChanged);
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
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtMall);
            this.groupBox11.Location = new System.Drawing.Point(405, 348);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(298, 42);
            this.groupBox11.TabIndex = 29;
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
            this.groupBox12.Location = new System.Drawing.Point(583, 300);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(120, 42);
            this.groupBox12.TabIndex = 28;
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
            this.groupBox13.Location = new System.Drawing.Point(405, 300);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(172, 42);
            this.groupBox13.TabIndex = 27;
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
            this.groupBox14.Location = new System.Drawing.Point(376, 60);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(105, 42);
            this.groupBox14.TabIndex = 20;
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
            this.lblEmail.Location = new System.Drawing.Point(392, 31);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(141, 13);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "StoreXXXX@WWWinc.com";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(628, 466);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFirst);
            this.groupBox1.Location = new System.Drawing.Point(12, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(43, 42);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1st";
            // 
            // txtFirst
            // 
            this.txtFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirst.Location = new System.Drawing.Point(6, 19);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(31, 20);
            this.txtFirst.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSecond);
            this.groupBox3.Location = new System.Drawing.Point(61, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(43, 42);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2nd";
            // 
            // txtSecond
            // 
            this.txtSecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecond.Location = new System.Drawing.Point(6, 19);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(31, 20);
            this.txtSecond.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = ".";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtThird);
            this.groupBox4.Location = new System.Drawing.Point(110, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(43, 42);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3rd";
            // 
            // txtThird
            // 
            this.txtThird.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThird.Location = new System.Drawing.Point(6, 19);
            this.txtThird.Name = "txtThird";
            this.txtThird.Size = new System.Drawing.Size(31, 20);
            this.txtThird.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtLan1);
            this.groupBox5.Location = new System.Drawing.Point(159, 246);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(47, 42);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "POS";
            // 
            // txtLan1
            // 
            this.txtLan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLan1.Location = new System.Drawing.Point(6, 19);
            this.txtLan1.Name = "txtLan1";
            this.txtLan1.Size = new System.Drawing.Size(35, 20);
            this.txtLan1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtGate1);
            this.groupBox6.Location = new System.Drawing.Point(227, 246);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(57, 42);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gate1";
            // 
            // txtGate1
            // 
            this.txtGate1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGate1.Location = new System.Drawing.Point(6, 19);
            this.txtGate1.Name = "txtGate1";
            this.txtGate1.Size = new System.Drawing.Size(45, 20);
            this.txtGate1.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtLan2);
            this.groupBox7.Location = new System.Drawing.Point(159, 294);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(62, 42);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Sensor";
            // 
            // txtLan2
            // 
            this.txtLan2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLan2.Location = new System.Drawing.Point(6, 19);
            this.txtLan2.Name = "txtLan2";
            this.txtLan2.Size = new System.Drawing.Size(50, 20);
            this.txtLan2.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtGate2);
            this.groupBox8.Location = new System.Drawing.Point(227, 294);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(57, 42);
            this.groupBox8.TabIndex = 17;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Gate2";
            // 
            // txtGate2
            // 
            this.txtGate2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGate2.Location = new System.Drawing.Point(6, 19);
            this.txtGate2.Name = "txtGate2";
            this.txtGate2.Size = new System.Drawing.Size(45, 20);
            this.txtGate2.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtLan3);
            this.groupBox9.Location = new System.Drawing.Point(159, 342);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(47, 42);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Lan3";
            // 
            // txtLan3
            // 
            this.txtLan3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLan3.Location = new System.Drawing.Point(6, 19);
            this.txtLan3.Name = "txtLan3";
            this.txtLan3.Size = new System.Drawing.Size(35, 20);
            this.txtLan3.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtGate3);
            this.groupBox10.Location = new System.Drawing.Point(227, 342);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(57, 42);
            this.groupBox10.TabIndex = 18;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Gate3";
            // 
            // txtGate3
            // 
            this.txtGate3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGate3.Location = new System.Drawing.Point(6, 19);
            this.txtGate3.Name = "txtGate3";
            this.txtGate3.Size = new System.Drawing.Size(45, 20);
            this.txtGate3.TabIndex = 0;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.txtLan4);
            this.groupBox15.Location = new System.Drawing.Point(159, 390);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(47, 42);
            this.groupBox15.TabIndex = 15;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Mim";
            // 
            // txtLan4
            // 
            this.txtLan4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLan4.Location = new System.Drawing.Point(6, 19);
            this.txtLan4.Name = "txtLan4";
            this.txtLan4.Size = new System.Drawing.Size(35, 20);
            this.txtLan4.TabIndex = 0;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtGate4);
            this.groupBox16.Location = new System.Drawing.Point(227, 390);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(57, 42);
            this.groupBox16.TabIndex = 19;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Gate4";
            // 
            // txtGate4
            // 
            this.txtGate4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGate4.Location = new System.Drawing.Point(6, 19);
            this.txtGate4.Name = "txtGate4";
            this.txtGate4.Size = new System.Drawing.Size(45, 20);
            this.txtGate4.TabIndex = 0;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtSVS);
            this.groupBox17.Location = new System.Drawing.Point(487, 60);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(105, 42);
            this.groupBox17.TabIndex = 21;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "SVS";
            // 
            // txtSVS
            // 
            this.txtSVS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSVS.Location = new System.Drawing.Point(6, 19);
            this.txtSVS.Name = "txtSVS";
            this.txtSVS.Size = new System.Drawing.Size(93, 20);
            this.txtSVS.TabIndex = 0;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.txtBAMS);
            this.groupBox18.Location = new System.Drawing.Point(598, 60);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(105, 42);
            this.groupBox18.TabIndex = 22;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "BAMS";
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
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.txtTID1);
            this.groupBox19.Location = new System.Drawing.Point(598, 108);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(105, 42);
            this.groupBox19.TabIndex = 23;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "TID1";
            // 
            // txtTID1
            // 
            this.txtTID1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTID1.Location = new System.Drawing.Point(6, 19);
            this.txtTID1.Name = "txtTID1";
            this.txtTID1.Size = new System.Drawing.Size(93, 20);
            this.txtTID1.TabIndex = 0;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.txtTID2);
            this.groupBox20.Location = new System.Drawing.Point(598, 156);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(105, 42);
            this.groupBox20.TabIndex = 24;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "TID2";
            // 
            // txtTID2
            // 
            this.txtTID2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTID2.Location = new System.Drawing.Point(6, 19);
            this.txtTID2.Name = "txtTID2";
            this.txtTID2.Size = new System.Drawing.Size(93, 20);
            this.txtTID2.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.txtTID3);
            this.groupBox21.Location = new System.Drawing.Point(598, 204);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(105, 42);
            this.groupBox21.TabIndex = 25;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "TID3";
            // 
            // txtTID3
            // 
            this.txtTID3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTID3.Location = new System.Drawing.Point(6, 19);
            this.txtTID3.Name = "txtTID3";
            this.txtTID3.Size = new System.Drawing.Size(93, 20);
            this.txtTID3.TabIndex = 0;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.txtTID4);
            this.groupBox22.Location = new System.Drawing.Point(598, 252);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(105, 42);
            this.groupBox22.TabIndex = 26;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "TID4";
            // 
            // txtTID4
            // 
            this.txtTID4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTID4.Location = new System.Drawing.Point(6, 19);
            this.txtTID4.Name = "txtTID4";
            this.txtTID4.Size = new System.Drawing.Size(93, 20);
            this.txtTID4.TabIndex = 0;
            // 
            // AddNewStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 501);
            this.Controls.Add(this.groupBox22);
            this.Controls.Add(this.groupBox21);
            this.Controls.Add(this.groupBox20);
            this.Controls.Add(this.groupBox19);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.gbAddress);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.MaskedTextBox txtStore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtThird;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtLan1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtGate1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtLan2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtGate2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtLan3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtGate3;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox txtLan4;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox txtGate4;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtSVS;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox txtBAMS;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TextBox txtTID1;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.TextBox txtTID2;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.TextBox txtTID3;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.TextBox txtTID4;
	}
}