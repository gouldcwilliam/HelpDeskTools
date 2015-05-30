namespace Retail_HD.Forms
{
	partial class ExcelCompareData
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
			this.dg_main = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dg_main)).BeginInit();
			this.SuspendLayout();
			// 
			// dg_main
			// 
			this.dg_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dg_main.Location = new System.Drawing.Point(0, 0);
			this.dg_main.Name = "dg_main";
			this.dg_main.Size = new System.Drawing.Size(933, 671);
			this.dg_main.TabIndex = 0;
			// 
			// XcelTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 671);
			this.Controls.Add(this.dg_main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.Name = "XcelTest";
			this.Text = "Excel Test";
			this.Load += new System.EventHandler(this.XcelTest_Load);
			((System.ComponentModel.ISupportInitialize)(this.dg_main)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dg_main;
	}
}