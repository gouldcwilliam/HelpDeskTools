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
    /// <summary>
    /// New store form
    /// </summary>
	public partial class AddNewStore : Form
	{
        /// <summary>
        /// Form to add a new store
        /// </summary>
		public AddNewStore()
		{
			InitializeComponent();
		}
        /// <summary>
        /// <seealso cref="AddNewStore"/>
        /// </summary>
        /// <param name="store"></param>
		public AddNewStore(string store)
		{
			InitializeComponent();
			txtStore.Text = store;
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!checkInput()) { return; }

			if (!Shared.SQL.b_InsertNewStore(
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
				txtFirst.Text.Trim(),
                txtSecond.Text.Trim(),
                txtThird.Text.Trim(),
                txtLan1.Text.Trim(),
                txtLan2.Text.Trim(),
                txtLan3.Text.Trim(),
                txtLan4.Text.Trim(),
                txtGate1.Text.Trim(),
                txtGate2.Text.Trim(),
                txtGate3.Text.Trim(),
                txtGate4.Text.Trim(),
                txtSVS.Text.Trim(),
                txtBAMS.Text.Trim(),
                txtTID1.Text.Trim(),
                txtTID2.Text.Trim(),
                txtTID3.Text.Trim(),
                txtTID4.Text.Trim()
                ))
			{
				return;
			}
			Close();

		}

		private bool checkInput()
		{
			if (txtCity.Text.Trim() == string.Empty) return false;
			if (txtAddress.Text.Trim() == string.Empty) return false;
			if (txtMPID.Text.Trim() == string.Empty) return false;
			if (txtName.Text.Trim() == string.Empty) return false;
			if (txtState.Text.Trim() == string.Empty) return false;
			if (txtStore.Text.Trim() == string.Empty) return false;
			if (txtType.Text.Trim() == string.Empty) return false;
			if (txtTZ.Text.Trim() == string.Empty) return false;
			if (txtZip.Text.Trim() == string.Empty) return false;
            if (txtFirst.Text.Trim() == string.Empty) return false;
            if (txtSecond.Text.Trim() == string.Empty) return false;
            if (txtLan1.Text.Trim() == string.Empty) return false;
            if (txtLan2.Text.Trim() == string.Empty) return false;
            if (txtLan3.Text.Trim() == string.Empty) return false;
            if (txtLan4.Text.Trim() == string.Empty) return false;
            if (txtGate1.Text.Trim() == string.Empty) return false;
            if (txtGate2.Text.Trim() == string.Empty) return false;
            if (txtGate3.Text.Trim() == string.Empty) return false;
            if (txtGate4.Text.Trim() == string.Empty) return false;
			return true;
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

        private void txtStore_TextChanged(object sender, EventArgs e)
        {
            if (txtStore.Text.Trim().Length == 3) 
            { 
                lblEmail.Text = string.Format("Store0{0}@wwwinc.com", txtStore.Text.Trim()); 
            }
            else if (txtStore.Text.Trim().Length == 4)
            {
                lblEmail.Text = string.Format("Store{0}@wwwinc.com", txtStore.Text.Trim());
            }
            else
            {
                lblEmail.Text = "StoreXXXX@wwwinc.com";
            }

        }
	}
}
