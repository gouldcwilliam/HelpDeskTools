namespace FileCopier
{
    partial class FileCopier
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
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.gbStores = new System.Windows.Forms.GroupBox();
            this.txtComputers = new System.Windows.Forms.TextBox();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.btnSettings = new System.Windows.Forms.Button();
            this.rbDirectory = new System.Windows.Forms.RadioButton();
            this.rbFiles = new System.Windows.Forms.RadioButton();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.ckbFileList = new System.Windows.Forms.CheckedListBox();
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSchedule = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxHours = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDays = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMins = new System.Windows.Forms.MaskedTextBox();
            this.gbStores.SuspendLayout();
            this.gbFiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(439, 522);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Copy";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(6, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(99, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Stores In AD";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // gbStores
            // 
            this.gbStores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStores.Controls.Add(this.txtComputers);
            this.gbStores.Controls.Add(this.rbList);
            this.gbStores.Controls.Add(this.rbAll);
            this.gbStores.Location = new System.Drawing.Point(12, 12);
            this.gbStores.Name = "gbStores";
            this.gbStores.Size = new System.Drawing.Size(502, 154);
            this.gbStores.TabIndex = 0;
            this.gbStores.TabStop = false;
            this.gbStores.Text = "Stores To Transfer To";
            // 
            // txtComputers
            // 
            this.txtComputers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputers.Location = new System.Drawing.Point(6, 65);
            this.txtComputers.Multiline = true;
            this.txtComputers.Name = "txtComputers";
            this.txtComputers.Size = new System.Drawing.Size(489, 84);
            this.txtComputers.TabIndex = 2;
            // 
            // rbList
            // 
            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(6, 42);
            this.rbList.Name = "rbList";
            this.rbList.Size = new System.Drawing.Size(141, 17);
            this.rbList.TabIndex = 1;
            this.rbList.TabStop = true;
            this.rbList.Text = "List of Stores/Computers";
            this.rbList.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.Location = new System.Drawing.Point(12, 522);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // rbDirectory
            // 
            this.rbDirectory.AutoSize = true;
            this.rbDirectory.Location = new System.Drawing.Point(6, 19);
            this.rbDirectory.Name = "rbDirectory";
            this.rbDirectory.Size = new System.Drawing.Size(112, 17);
            this.rbDirectory.TabIndex = 0;
            this.rbDirectory.TabStop = true;
            this.rbDirectory.Text = "Directory Contents";
            this.rbDirectory.UseVisualStyleBackColor = true;
            // 
            // rbFiles
            // 
            this.rbFiles.AutoSize = true;
            this.rbFiles.Location = new System.Drawing.Point(6, 42);
            this.rbFiles.Name = "rbFiles";
            this.rbFiles.Size = new System.Drawing.Size(91, 17);
            this.rbFiles.TabIndex = 1;
            this.rbFiles.TabStop = true;
            this.rbFiles.Text = "Selected Files";
            this.rbFiles.UseVisualStyleBackColor = true;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFile.Image = global::FileCopier.Properties.Resources.folder;
            this.btnChooseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseFile.Location = new System.Drawing.Point(6, 65);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(112, 26);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "Browse";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // ckbFileList
            // 
            this.ckbFileList.CheckOnClick = true;
            this.ckbFileList.FormattingEnabled = true;
            this.ckbFileList.Location = new System.Drawing.Point(124, 19);
            this.ckbFileList.Name = "ckbFileList";
            this.ckbFileList.Size = new System.Drawing.Size(371, 214);
            this.ckbFileList.TabIndex = 3;
            // 
            // gbFiles
            // 
            this.gbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiles.Controls.Add(this.ckbFileList);
            this.gbFiles.Controls.Add(this.btnChooseFile);
            this.gbFiles.Controls.Add(this.rbFiles);
            this.gbFiles.Controls.Add(this.rbDirectory);
            this.gbFiles.Location = new System.Drawing.Point(12, 172);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Size = new System.Drawing.Size(502, 244);
            this.gbFiles.TabIndex = 1;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files To Transfer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBoxMins);
            this.groupBox1.Controls.Add(this.maskedTextBoxDays);
            this.groupBox1.Controls.Add(this.maskedTextBoxHours);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxSchedule);
            this.groupBox1.Location = new System.Drawing.Point(12, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedule";
            // 
            // checkBoxSchedule
            // 
            this.checkBoxSchedule.AutoSize = true;
            this.checkBoxSchedule.Location = new System.Drawing.Point(6, 24);
            this.checkBoxSchedule.Name = "checkBoxSchedule";
            this.checkBoxSchedule.Size = new System.Drawing.Size(71, 17);
            this.checkBoxSchedule.TabIndex = 0;
            this.checkBoxSchedule.Text = "Postpone";
            this.checkBoxSchedule.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "days(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hrs(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "min(s)";
            // 
            // maskedTextBoxHours
            // 
            this.maskedTextBoxHours.Location = new System.Drawing.Point(341, 22);
            this.maskedTextBoxHours.Mask = "00";
            this.maskedTextBoxHours.Name = "maskedTextBoxHours";
            this.maskedTextBoxHours.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxHours.TabIndex = 3;
            // 
            // maskedTextBoxDays
            // 
            this.maskedTextBoxDays.Location = new System.Drawing.Point(254, 22);
            this.maskedTextBoxDays.Mask = "00";
            this.maskedTextBoxDays.Name = "maskedTextBoxDays";
            this.maskedTextBoxDays.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxDays.TabIndex = 1;
            // 
            // maskedTextBoxMins
            // 
            this.maskedTextBoxMins.Location = new System.Drawing.Point(420, 22);
            this.maskedTextBoxMins.Mask = "00";
            this.maskedTextBoxMins.Name = "maskedTextBoxMins";
            this.maskedTextBoxMins.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxMins.TabIndex = 5;
            // 
            // FileCopier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 557);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.gbFiles);
            this.Controls.Add(this.gbStores);
            this.Controls.Add(this.btnOK);
            this.Name = "FileCopier";
            this.Text = "File Copier";
            this.gbStores.ResumeLayout(false);
            this.gbStores.PerformLayout();
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox gbStores;
        private System.Windows.Forms.TextBox txtComputers;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.RadioButton rbDirectory;
        private System.Windows.Forms.RadioButton rbFiles;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.CheckedListBox ckbFileList;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxSchedule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMins;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDays;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHours;
    }
}

