namespace Retail_HD.UCs
{
	partial class PingControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ckbRegister = new System.Windows.Forms.CheckBox();
			this.ckbFortinet = new System.Windows.Forms.CheckBox();
			this.ckbMimGate = new System.Windows.Forms.CheckBox();
			this.ckbMim = new System.Windows.Forms.CheckBox();
			this.ckbSensor = new System.Windows.Forms.CheckBox();
			this.gbPing = new System.Windows.Forms.GroupBox();
			this.ckbSensorGate = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.gbPing.SuspendLayout();
			this.SuspendLayout();
			// 
			// ckbRegister
			// 
			this.ckbRegister.AutoSize = true;
			this.ckbRegister.Location = new System.Drawing.Point(6, 19);
			this.ckbRegister.Name = "ckbRegister";
			this.ckbRegister.Size = new System.Drawing.Size(65, 17);
			this.ckbRegister.TabIndex = 0;
			this.ckbRegister.Text = "Register";
			this.ckbRegister.UseVisualStyleBackColor = true;
			// 
			// ckbFortinet
			// 
			this.ckbFortinet.AutoSize = true;
			this.ckbFortinet.Location = new System.Drawing.Point(6, 42);
			this.ckbFortinet.Name = "ckbFortinet";
			this.ckbFortinet.Size = new System.Drawing.Size(61, 17);
			this.ckbFortinet.TabIndex = 1;
			this.ckbFortinet.Text = "Fortinet";
			this.ckbFortinet.UseVisualStyleBackColor = true;
			// 
			// ckbMimGate
			// 
			this.ckbMimGate.AutoSize = true;
			this.ckbMimGate.Location = new System.Drawing.Point(73, 42);
			this.ckbMimGate.Name = "ckbMimGate";
			this.ckbMimGate.Size = new System.Drawing.Size(73, 17);
			this.ckbMimGate.TabIndex = 3;
			this.ckbMimGate.Text = "MIM Gate";
			this.ckbMimGate.UseVisualStyleBackColor = true;
			// 
			// ckbMim
			// 
			this.ckbMim.AutoSize = true;
			this.ckbMim.Location = new System.Drawing.Point(73, 19);
			this.ckbMim.Name = "ckbMim";
			this.ckbMim.Size = new System.Drawing.Size(47, 17);
			this.ckbMim.TabIndex = 2;
			this.ckbMim.Text = "MIM";
			this.ckbMim.UseVisualStyleBackColor = true;
			// 
			// ckbSensor
			// 
			this.ckbSensor.AutoSize = true;
			this.ckbSensor.Location = new System.Drawing.Point(152, 19);
			this.ckbSensor.Name = "ckbSensor";
			this.ckbSensor.Size = new System.Drawing.Size(59, 17);
			this.ckbSensor.TabIndex = 4;
			this.ckbSensor.Text = "Sensor";
			this.ckbSensor.UseVisualStyleBackColor = true;
			// 
			// gbPing
			// 
			this.gbPing.Controls.Add(this.ckbSensorGate);
			this.gbPing.Controls.Add(this.ckbRegister);
			this.gbPing.Controls.Add(this.ckbSensor);
			this.gbPing.Controls.Add(this.ckbFortinet);
			this.gbPing.Controls.Add(this.ckbMim);
			this.gbPing.Controls.Add(this.ckbMimGate);
			this.gbPing.Location = new System.Drawing.Point(3, 3);
			this.gbPing.Name = "gbPing";
			this.gbPing.Size = new System.Drawing.Size(244, 66);
			this.gbPing.TabIndex = 0;
			this.gbPing.TabStop = false;
			this.gbPing.Text = "Ping";
			// 
			// ckbSensorGate
			// 
			this.ckbSensorGate.AutoSize = true;
			this.ckbSensorGate.Location = new System.Drawing.Point(152, 42);
			this.ckbSensorGate.Name = "ckbSensorGate";
			this.ckbSensorGate.Size = new System.Drawing.Size(85, 17);
			this.ckbSensorGate.TabIndex = 5;
			this.ckbSensorGate.Text = "Sensor Gate";
			this.ckbSensorGate.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(172, 75);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// ucPing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gbPing);
			this.Name = "ucPing";
			this.Size = new System.Drawing.Size(250, 101);
			this.gbPing.ResumeLayout(false);
			this.gbPing.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPing;
		public System.Windows.Forms.CheckBox ckbRegister;
		public System.Windows.Forms.CheckBox ckbFortinet;
		public System.Windows.Forms.CheckBox ckbMimGate;
		public System.Windows.Forms.CheckBox ckbMim;
		public System.Windows.Forms.CheckBox ckbSensor;
		public System.Windows.Forms.CheckBox ckbSensorGate;
		public System.Windows.Forms.Button btnOK;

	}
}
