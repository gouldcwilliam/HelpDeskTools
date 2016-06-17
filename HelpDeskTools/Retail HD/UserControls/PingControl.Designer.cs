namespace Retail_HD.UCs
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	partial class PingControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
            this.ckbCCTV = new System.Windows.Forms.CheckBox();
            this.ckbSensorGate = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.ckbLan3 = new System.Windows.Forms.CheckBox();
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
            this.ckbFortinet.Size = new System.Drawing.Size(74, 17);
            this.ckbFortinet.TabIndex = 1;
            this.ckbFortinet.Text = "POS Gate";
            this.ckbFortinet.UseVisualStyleBackColor = true;
            // 
            // ckbMimGate
            // 
            this.ckbMimGate.AutoSize = true;
            this.ckbMimGate.Location = new System.Drawing.Point(86, 42);
            this.ckbMimGate.Name = "ckbMimGate";
            this.ckbMimGate.Size = new System.Drawing.Size(73, 17);
            this.ckbMimGate.TabIndex = 3;
            this.ckbMimGate.Text = "MIM Gate";
            this.ckbMimGate.UseVisualStyleBackColor = true;
            // 
            // ckbMim
            // 
            this.ckbMim.AutoSize = true;
            this.ckbMim.Location = new System.Drawing.Point(86, 19);
            this.ckbMim.Name = "ckbMim";
            this.ckbMim.Size = new System.Drawing.Size(47, 17);
            this.ckbMim.TabIndex = 2;
            this.ckbMim.Text = "MIM";
            this.ckbMim.UseVisualStyleBackColor = true;
            // 
            // ckbSensor
            // 
            this.ckbSensor.AutoSize = true;
            this.ckbSensor.Location = new System.Drawing.Point(165, 19);
            this.ckbSensor.Name = "ckbSensor";
            this.ckbSensor.Size = new System.Drawing.Size(59, 17);
            this.ckbSensor.TabIndex = 4;
            this.ckbSensor.Text = "Sensor";
            this.ckbSensor.UseVisualStyleBackColor = true;
            // 
            // gbPing
            // 
            this.gbPing.Controls.Add(this.ckbLan3);
            this.gbPing.Controls.Add(this.ckbCCTV);
            this.gbPing.Controls.Add(this.ckbSensorGate);
            this.gbPing.Controls.Add(this.ckbRegister);
            this.gbPing.Controls.Add(this.ckbSensor);
            this.gbPing.Controls.Add(this.ckbFortinet);
            this.gbPing.Controls.Add(this.ckbMim);
            this.gbPing.Controls.Add(this.ckbMimGate);
            this.gbPing.Location = new System.Drawing.Point(3, 3);
            this.gbPing.Name = "gbPing";
            this.gbPing.Size = new System.Drawing.Size(336, 66);
            this.gbPing.TabIndex = 0;
            this.gbPing.TabStop = false;
            this.gbPing.Text = "Ping";
            // 
            // ckbCCTV
            // 
            this.ckbCCTV.AutoSize = true;
            this.ckbCCTV.Location = new System.Drawing.Point(256, 19);
            this.ckbCCTV.Name = "ckbCCTV";
            this.ckbCCTV.Size = new System.Drawing.Size(54, 17);
            this.ckbCCTV.TabIndex = 6;
            this.ckbCCTV.Text = "CCTV";
            this.ckbCCTV.UseVisualStyleBackColor = true;
            // 
            // ckbSensorGate
            // 
            this.ckbSensorGate.AutoSize = true;
            this.ckbSensorGate.Location = new System.Drawing.Point(165, 42);
            this.ckbSensorGate.Name = "ckbSensorGate";
            this.ckbSensorGate.Size = new System.Drawing.Size(85, 17);
            this.ckbSensorGate.TabIndex = 5;
            this.ckbSensorGate.Text = "Sensor Gate";
            this.ckbSensorGate.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(258, 75);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ckbLan3
            // 
            this.ckbLan3.AutoSize = true;
            this.ckbLan3.Location = new System.Drawing.Point(255, 42);
            this.ckbLan3.Name = "ckbLan3";
            this.ckbLan3.Size = new System.Drawing.Size(56, 17);
            this.ckbLan3.TabIndex = 7;
            this.ckbLan3.Text = "LAN 3";
            this.ckbLan3.UseVisualStyleBackColor = true;
            // 
            // PingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbPing);
            this.Name = "PingControl";
            this.Size = new System.Drawing.Size(342, 101);
            this.gbPing.ResumeLayout(false);
            this.gbPing.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPing;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.CheckBox ckbRegister;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.CheckBox ckbFortinet;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.CheckBox ckbMimGate;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.CheckBox ckbMim;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.CheckBox ckbSensor;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.CheckBox ckbSensorGate;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.Button btnOK;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.CheckBox ckbCCTV;
        public System.Windows.Forms.CheckBox ckbLan3;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    }
}
