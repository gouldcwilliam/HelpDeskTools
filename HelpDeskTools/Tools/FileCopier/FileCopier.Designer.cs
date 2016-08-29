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
            this.button2 = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.gbStores = new System.Windows.Forms.GroupBox();
            this.txtComputers = new System.Windows.Forms.TextBox();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.rbDirectory = new System.Windows.Forms.RadioButton();
            this.rbFiles = new System.Windows.Forms.RadioButton();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.ckbFileList = new System.Windows.Forms.CheckedListBox();
            this.gbStores.SuspendLayout();
            this.gbFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(358, 422);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(439, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(6, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(99, 17);
            this.rbAll.TabIndex = 2;
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
            this.gbStores.TabIndex = 3;
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
            this.txtComputers.TabIndex = 6;
            // 
            // rbList
            // 
            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(6, 42);
            this.rbList.Name = "rbList";
            this.rbList.Size = new System.Drawing.Size(141, 17);
            this.rbList.TabIndex = 5;
            this.rbList.TabStop = true;
            this.rbList.Text = "List of Stores/Computers";
            this.rbList.UseVisualStyleBackColor = true;
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
            this.gbFiles.TabIndex = 7;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files To Transfer";
            // 
            // rbDirectory
            // 
            this.rbDirectory.AutoSize = true;
            this.rbDirectory.Location = new System.Drawing.Point(6, 19);
            this.rbDirectory.Name = "rbDirectory";
            this.rbDirectory.Size = new System.Drawing.Size(112, 17);
            this.rbDirectory.TabIndex = 7;
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
            this.rbFiles.TabIndex = 8;
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
            this.btnChooseFile.TabIndex = 8;
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
            this.ckbFileList.TabIndex = 9;
            // 
            // FileCopier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 457);
            this.Controls.Add(this.gbFiles);
            this.Controls.Add(this.gbStores);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Name = "FileCopier";
            this.Text = "File Copier";
            this.gbStores.ResumeLayout(false);
            this.gbStores.PerformLayout();
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox gbStores;
        private System.Windows.Forms.TextBox txtComputers;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.RadioButton rbFiles;
        private System.Windows.Forms.RadioButton rbDirectory;
        private System.Windows.Forms.CheckedListBox ckbFileList;
    }
}

