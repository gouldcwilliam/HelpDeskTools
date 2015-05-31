namespace Retail_HD.Forms
{
    partial class frmAgentStatus
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
            this.components = new System.ComponentModel.Container();
            this.dgvAgents = new System.Windows.Forms.DataGridView();
            this.cmsAdmin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCallUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCallUserUser = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).BeginInit();
            this.cmsAdmin.SuspendLayout();
            this.cmsUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAgents
            // 
            this.dgvAgents.AllowUserToAddRows = false;
            this.dgvAgents.AllowUserToDeleteRows = false;
            this.dgvAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAgents.Location = new System.Drawing.Point(0, 0);
            this.dgvAgents.MultiSelect = false;
            this.dgvAgents.Name = "dgvAgents";
            this.dgvAgents.ReadOnly = true;
            this.dgvAgents.RowHeadersVisible = false;
            this.dgvAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgents.Size = new System.Drawing.Size(353, 329);
            this.dgvAgents.TabIndex = 0;
            // 
            // cmsAdmin
            // 
            this.cmsAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeStatus,
            this.toolStripMenuItem1,
            this.btnCallUser,
            this.toolStripMenuItem2,
            this.btnLogout});
            this.cmsAdmin.Name = "contextMenuStrip1";
            this.cmsAdmin.Size = new System.Drawing.Size(189, 104);
            this.cmsAdmin.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cmsClosing);
            this.cmsAdmin.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(188, 22);
            this.btnChangeStatus.Text = "Change Status: Ready";
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // btnCallUser
            // 
            this.btnCallUser.Name = "btnCallUser";
            this.btnCallUser.Size = new System.Drawing.Size(188, 22);
            this.btnCallUser.Text = "Call User";
            this.btnCallUser.Click += new System.EventHandler(this.CallUser_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
            // 
            // btnLogout
            // 
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(188, 22);
            this.btnLogout.Text = "Logout User";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // cmsUser
            // 
            this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCallUserUser});
            this.cmsUser.Name = "cmsUser";
            this.cmsUser.Size = new System.Drawing.Size(121, 26);
            this.cmsUser.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cmsClosing);
            this.cmsUser.Opening += new System.ComponentModel.CancelEventHandler(this.cmsUser_Opening);
            // 
            // btnCallUserUser
            // 
            this.btnCallUserUser.Name = "btnCallUserUser";
            this.btnCallUserUser.Size = new System.Drawing.Size(152, 22);
            this.btnCallUserUser.Text = "Call User";
            this.btnCallUserUser.Click += new System.EventHandler(this.CallUser_Click);
            // 
            // frmAgentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 329);
            this.Controls.Add(this.dgvAgents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAgentStatus";
            this.Text = "Agent Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgentStatus_FormClosing);
            this.Load += new System.EventHandler(this.frmAgentStatus_Load);
            this.Shown += new System.EventHandler(this.frmAgentStatus_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgents)).EndInit();
            this.cmsAdmin.ResumeLayout(false);
            this.cmsUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAgents;
        private System.Windows.Forms.ContextMenuStrip cmsAdmin;
        private System.Windows.Forms.ToolStripMenuItem btnChangeStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnLogout;
        private System.Windows.Forms.ToolStripMenuItem btnCallUser;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip cmsUser;
        private System.Windows.Forms.ToolStripMenuItem btnCallUserUser;
    }
}