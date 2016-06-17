using System;
using System.Linq;
using System.Windows.Forms;

using Shared;

namespace Retail_HD.UCs
{
    /// <summary>
    /// Usercontrol for the ping submenu
    /// </summary>
	public partial class PingControl : UserControl
	{
        /// <summary>
        /// <see cref="PingControl"/>
        /// </summary>
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
					Functions.Pinger(Info.selectedComputers);
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
            if(this.ckbLan3.Checked)
            {
                Functions.Pinger(Info.lan3, Info.store+" LAN 3");
            }
		}
        /// <summary>
        /// clears the check boxes
        /// </summary>
		public void Clear()
		{
			foreach (CheckBox cb in gbPing.Controls.OfType<CheckBox>())
			{
				cb.Checked = false;
			}
		}
	}
}
