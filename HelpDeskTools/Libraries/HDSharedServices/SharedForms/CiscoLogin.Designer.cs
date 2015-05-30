namespace HDSharedServices.Forms
{
    partial class frmCiscoLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataStore = new System.Windows.Forms.TextBox();
            this.btnSaveLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtACD = new System.Windows.Forms.TextBox();
            this.ckbUseHTTPS = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShoeboxPWD = new System.Windows.Forms.TextBox();
            this.txtShoeboxUSR = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataStore:";
            // 
            // txtDataStore
            // 
            this.txtDataStore.Location = new System.Drawing.Point(152, 12);
            this.txtDataStore.Name = "txtDataStore";
            this.txtDataStore.Size = new System.Drawing.Size(150, 20);
            this.txtDataStore.TabIndex = 1;
            this.txtDataStore.Text = "C:\\FINESSE\\";
            // 
            // btnSaveLogin
            // 
            this.btnSaveLogin.Location = new System.Drawing.Point(298, 315);
            this.btnSaveLogin.Name = "btnSaveLogin";
            this.btnSaveLogin.Size = new System.Drawing.Size(96, 23);
            this.btnSaveLogin.TabIndex = 2;
            this.btnSaveLogin.Text = "Save && Login";
            this.btnSaveLogin.UseVisualStyleBackColor = true;
            this.btnSaveLogin.Click += new System.EventHandler(this.btnSaveLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(152, 131);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(120, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(152, 64);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(231, 20);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "8445";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port:";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(152, 38);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(231, 20);
            this.txtServerAddress.TabIndex = 8;
            this.txtServerAddress.Text = "rocccx01.wwwint.corp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Server Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "ACD:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(152, 157);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // txtACD
            // 
            this.txtACD.Location = new System.Drawing.Point(152, 183);
            this.txtACD.Name = "txtACD";
            this.txtACD.Size = new System.Drawing.Size(120, 20);
            this.txtACD.TabIndex = 12;
            // 
            // ckbUseHTTPS
            // 
            this.ckbUseHTTPS.AutoSize = true;
            this.ckbUseHTTPS.Checked = true;
            this.ckbUseHTTPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbUseHTTPS.Location = new System.Drawing.Point(152, 91);
            this.ckbUseHTTPS.Name = "ckbUseHTTPS";
            this.ckbUseHTTPS.Size = new System.Drawing.Size(15, 14);
            this.ckbUseHTTPS.TabIndex = 13;
            this.ckbUseHTTPS.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Use HTTPS:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(308, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtShoeboxPWD);
            this.groupBox1.Controls.Add(this.txtShoeboxUSR);
            this.groupBox1.Location = new System.Drawing.Point(11, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 85);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peoplesoft/MyShoebox";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "MyShoebox Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "MyShoebox Username:";
            // 
            // txtShoeboxPWD
            // 
            this.txtShoeboxPWD.Location = new System.Drawing.Point(141, 50);
            this.txtShoeboxPWD.Name = "txtShoeboxPWD";
            this.txtShoeboxPWD.PasswordChar = '*';
            this.txtShoeboxPWD.Size = new System.Drawing.Size(120, 20);
            this.txtShoeboxPWD.TabIndex = 1;
            this.txtShoeboxPWD.TextChanged += new System.EventHandler(this.txtShoeboxPWD_TextChanged);
            // 
            // txtShoeboxUSR
            // 
            this.txtShoeboxUSR.Location = new System.Drawing.Point(141, 21);
            this.txtShoeboxUSR.Name = "txtShoeboxUSR";
            this.txtShoeboxUSR.Size = new System.Drawing.Size(120, 20);
            this.txtShoeboxUSR.TabIndex = 0;
            this.txtShoeboxUSR.TextChanged += new System.EventHandler(this.txtShoeboxUSR_TextChanged);
            // 
            // frmCiscoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 350);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ckbUseHTTPS);
            this.Controls.Add(this.txtACD);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveLogin);
            this.Controls.Add(this.txtDataStore);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCiscoLogin";
            this.Text = "Finesse Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCiscoLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmCiscoLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataStore;
        private System.Windows.Forms.Button btnSaveLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtACD;
        private System.Windows.Forms.CheckBox ckbUseHTTPS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShoeboxPWD;
        private System.Windows.Forms.TextBox txtShoeboxUSR;
    }
}