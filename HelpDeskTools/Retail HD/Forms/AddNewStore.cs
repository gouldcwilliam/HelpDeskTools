using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
	public partial class AddNewStore : Form
	{
		public AddNewStore()
		{
			InitializeComponent();
		}

		public AddNewStore(string store)
		{
			InitializeComponent();
			txtStore.Text = store;
		}

		int store = 0, octet2 = 0, octet3 = 0, pos = 0, posGate = 0, sensor = 0, sensorGate = 0, mim = 0, mimGate = 0;

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!checkInput()) { return; }

			if (!SQL.b_InsertStore(
				txtStore.Text.Trim(),
				txtTZ.Text.Trim(),
				txtMPID.Text.Trim(),
				txtManager.Text.Trim(),
				txtDM.Text.Trim(),
				txtMall.Text.Trim(),
				txtName.Text.Trim(),
				txtType.Text.Trim(),
				txtAddress.Text.Trim(),
				txtCity.Text.Trim(),
				txtState.Text.Trim(),
				txtZip.Text.Trim(),
				lblEmail.Text.Trim(),
				txtPhone.Text.Trim(),
				lblPosgate.Text.Trim(),
				lblIP.Text.Trim() + octet3.ToString() + txtPOS.Text.Trim(),
				lblMimGate.Text.Trim(),
				lblMim.Text.Trim(),
				lblSensGate.Text.Trim(),
				lblSens.Text.Trim()))
			{
				return;
			}
			Close();

			//Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}",
			//	txtStore.sText.Trim(),
			//	txtTZ.sText.Trim(),
			//	txtMPID.sText.Trim(),
			//	txtManager.sText.Trim(),
			//	txtDM.sText.Trim(),
			//	txtMall.sText.Trim(),
			//	txtName.sText.Trim(),
			//	txtType.sText.Trim(),
			//	txtAddress.sText.Trim(),
			//	txtCity.sText.Trim(),
			//	txtState.sText.Trim(),
			//	txtZip.sText.Trim(),
			//	lblEmail.sText.Trim(),
			//	txtPhone.sText.Trim(),
			//	lblPosgate.sText.Trim(),
			//	lblIP.sText.Trim() + octet3.ToString() + txtPOS.sText.Trim(),
			//	lblMimGate.sText.Trim(),
			//	lblMim.sText.Trim(),
			//	lblSensGate.sText.Trim(),
			//	lblSens.sText.Trim());
		}

		private bool checkInput()
		{
			if (txt3rd.Text == string.Empty) return false;
			if (txtCity.Text == string.Empty) return false;
			if (txtAddress.Text == string.Empty) return false;
			//if (txtDM.sText == string.Empty) return false;
			//if (txtMall.sText == string.Empty) return false;
			//if (txtManager.sText == string.Empty) return false;
			if (txtMPID.Text == string.Empty) return false;
			if (txtName.Text == string.Empty) return false;
			//if (txtPhone.sText == string.Empty) return false;
			if (txtPOS.Text == string.Empty) return false;
			if (txtState.Text == string.Empty) return false;
			if (txtStore.Text == string.Empty) return false;
			if (txtType.Text == string.Empty) return false;
			if (txtTZ.Text == string.Empty) return false;
			if (txtZip.Text == string.Empty) return false;
			return true;
		}


		private void updateLabels()
		{
			lblIP.Text = string.Format("10.{0}.", octet2.ToString());
			lblPosgate.Text = string.Format("10.{0}.{1}.{2}", octet2.ToString(), octet3.ToString(), posGate.ToString());
			lblSens.Text = string.Format("10.{0}.{1}.{2}", octet2.ToString(), octet3.ToString(), sensor.ToString());
			lblSensGate.Text = string.Format("10.{0}.{1}.{2}", octet2.ToString(), octet3.ToString(), sensorGate.ToString());
			lblMim.Text = string.Format("10.{0}.{1}.{2}", octet2.ToString(), octet3.ToString(), mim.ToString());
			lblMimGate.Text = string.Format("10.{0}.{1}.{2}", octet2.ToString(), octet3.ToString(), mimGate.ToString());
		}


		private void txtStore_TextChanged(object sender, EventArgs e)
		{
			if (txtStore.Text == string.Empty) { return; }
			if (!int.TryParse(txtStore.Text, out store))
			{
				txtStore.Text = txtStore.Text.Substring(0, txtStore.Text.Length - 1);
			}
			if (store > LDAP.RetailOUs.Europe.Lower && LDAP.RetailOUs.Europe.Upper > store)
			{
				octet2 = 102;
				pos = 11;
				txtPOS.ReadOnly = true;
			}
			else if (store > LDAP.RetailOUs.Michigan.Lower && LDAP.RetailOUs.Michigan.Upper > store)
			{
				octet2 = 100;
				pos = 11;
				txtPOS.ReadOnly = true;
			}
			else if ((store > LDAP.RetailOUs.Boston.Lower && LDAP.RetailOUs.Boston.Upper > store) || (store > 399 && 500 > store))
			{
				octet2 = 101;
				pos = 0;
				txtPOS.ReadOnly = false;
			}
			else
			{
				octet2 = 0;
				txtPOS.ReadOnly = false;
			}

			if (txtStore.Text.Length == 3)
			{
				lblEmail.Text = string.Format("Store0{0}@wwwinc.com", txtStore.Text);
			}
			else if (txtStore.Text.Length == 4)
			{
				lblEmail.Text = string.Format("Store{0}@wwwinc.com", txtStore.Text);
			}
			else
			{
				lblEmail.Text = "StoreXXXX@wwwinc.com";
			}

			txtPOS.Text = pos.ToString();
			updateLabels();
		}

		private void txt3rd_TextChanged(object sender, EventArgs e)
		{
			if (txt3rd.Text == string.Empty) { return; }
			if (!int.TryParse(txt3rd.Text, out octet3))
			{
				txt3rd.Text = txt3rd.Text.Substring(0, txt3rd.Text.Length - 1);
			}
			updateLabels();
		}

		private void txtPOS_TextChanged(object sender, EventArgs e)
		{
			if (txtPOS.Text == string.Empty) { return; }
			if (!int.TryParse(txtPOS.Text, out pos))
			{
				txtPOS.Text = txtPOS.Text.Substring(0, txtPOS.Text.Length - 1);
			}
			if (octet2 == 101)
			{
				posGate = pos + 5;
				sensor = posGate + 3;
				sensorGate = sensor + 5;
				mim = sensorGate + 11;
				mimGate = mim + 5;
			}
			if (octet2 == 100 || octet2 == 102)
			{
				posGate = 62;
				sensor = 65;
				sensorGate = 126;
				mim = 195;
				mimGate = 254;
			}
			//else
			//{
			//	pos = 0;
			//	posGate = 0;
			//	sensor = 0;
			//	sensorGate = 0;
			//	mim = 0;
			//	mimGate = 0;
			//}
			updateLabels();
		}

		private void txtName_Enter(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			txt.SelectAll();
		}

		private void txtName_MouseClick(object sender, MouseEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			txt.SelectAll();
		}

		private void txtStore_MouseClick(object sender, MouseEventArgs e)
		{
			MaskedTextBox txt = (MaskedTextBox)sender;
			txt.SelectAll();
		}

		private void txtStore_Enter(object sender, EventArgs e)
		{
			MaskedTextBox txt = (MaskedTextBox)sender;
			txt.SelectAll();
		}

		private void txtTZ_MouseClick(object sender, MouseEventArgs e)
		{
			txtTZ.DroppedDown = true;
		}

		private void AddNewStore_Load(object sender, EventArgs e)
		{

		}

	
	}
}
