using System;
using System.Linq;
using System.Windows.Forms;

using Shared;

namespace Retail_HD.UCs
{
	public partial class PingControl : UserControl
	{
		public PingControl()
		{
			InitializeComponent();
		}

		void btnOK_Click(object sender, EventArgs e)
		{
			if (this.ckbFortinet.Checked)
			{
				Functions.Pinger(Info.pos_gate, Info.store + " Fortinet");
			}

			if (this.ckbMim.Checked)
			{
				Functions.Pinger(Info.mim, Info.store + " MIMs");
			}

			if (this.ckbMimGate.Checked)
			{
				Functions.Pinger(Info.mim_gate, Info.store + " MIMs Gateway");
			}

			if (this.ckbRegister.Checked)
			{
				if (Info.OneSelected()&& Info.computers.Count > 0)
				{
					Functions.Pinger(Info.computers.FindAll(x => x.selected == true));
				}
				else
				{
					Functions.Pinger(Info.computers);
				}
			}

			if (this.ckbSensor.Checked)
			{
				Functions.Pinger(Info.sensor, Info.store + " Sensor");
			}

			if (this.ckbSensorGate.Checked)
			{
				Functions.Pinger(Info.sensor_gate, Info.store + " Sensor Gateway");
			}

            if (this.ckbCCTV.Checked)
            {
				Functions.Pinger(Info.cctv, Info.store + "CCTV");
            }
		}

		public void Clear()
		{
			foreach (CheckBox cb in gbPing.Controls.OfType<CheckBox>())
			{
				cb.Checked = false;
			}
		}
	}
}
