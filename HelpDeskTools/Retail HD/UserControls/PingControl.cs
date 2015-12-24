using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
				GlobalFunctions.v_Pinger(Info.pos_gate, Info.store + " Fortinet");
			}

			if (this.ckbMim.Checked)
			{
				GlobalFunctions.v_Pinger(Info.mim, Info.store + " MIMs");
			}

			if (this.ckbMimGate.Checked)
			{
				GlobalFunctions.v_Pinger(Info.mim_gate, Info.store + " MIMs Gateway");
			}

			if (this.ckbRegister.Checked)
			{
				if (Info.OneSelected()&& Info.computers.Count > 0)
				{
					GlobalFunctions.v_PingRegisters(Info.computers.FindAll(x => x.selected == true));
				}
				else
				{
					GlobalFunctions.v_PingRegisters(Info.computers);
				}
			}

			if (this.ckbSensor.Checked)
			{
				GlobalFunctions.v_Pinger(Info.sensor, Info.store + " Sensor");
			}

			if (this.ckbSensorGate.Checked)
			{
				GlobalFunctions.v_Pinger(Info.sensor_gate, Info.store + " Sensor Gateway");
			}

            if (this.ckbCCTV.Checked)
            {
                //GlobalFunctions.v_Pinger(Info.cctv, Info.store + "CCTV");
                GlobalFunctions.v_Pinger(Info.cctv, Info.store + "CCTV");
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
