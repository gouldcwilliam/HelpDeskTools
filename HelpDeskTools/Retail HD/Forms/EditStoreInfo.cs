﻿using System;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
    // TODO - add ALL of the store information fields
    /// <summary>
    /// <see cref="EditStoreInfo"/>
    /// </summary>
	public partial class EditStoreInfo : Form
	{
        /// <summary>
        /// Edits the store's information
        /// </summary>
		public EditStoreInfo()
		{
			InitializeComponent();
		}

		private void EditStoreInfo_Load(object sender, EventArgs e)
		{
			txtPhone.Text = Info.phone;
			txtManager.Text = Info.manager;
			txtMpId.Text = Info.MP;
			txtAddress.Text = Info.address;
			txtEmail.Text = Info.email;
			txtCity.Text = Info.city;
			txtDM.Text = Info.dm;
			txtName.Text = Info.name;
			txtType.Text = Info.type;
			txtState.Text = Info.state;
			txtZip.Text = Info.zip;
			txtTZ.Text = Info.TZ;
            txtRM.Text = Info.rm;

			Text = "Edit Info | Store: " + Info.store;

			txtAddress.TextChanged += Form_TextChanged;
			txtCity.TextChanged += Form_TextChanged;
			txtDM.TextChanged += Form_TextChanged;
            txtRM.TextChanged += Form_TextChanged;
			txtEmail.TextChanged += Form_TextChanged;
			txtManager.TextChanged += Form_TextChanged;
			txtMpId.TextChanged += Form_TextChanged;
			txtName.TextChanged += Form_TextChanged;
			txtPhone.TextChanged += Form_TextChanged;
			txtState.TextChanged += Form_TextChanged;
			txtType.TextChanged += Form_TextChanged;
			txtTZ.TextChanged += Form_TextChanged;
			txtZip.TextChanged += Form_TextChanged;
		}

		private void txtChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = true;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (Shared.SQL.b_updateStoreInfo(Info.store.ToString(), txtManager.Text, txtMpId.Text, txtAddress.Text, txtEmail.Text,
				txtCity.Text, txtDM.Text, txtName.Text, txtType.Text, txtState.Text, txtZip.Text, txtTZ.Text, txtRM.Text))
			{
                if (Shared.SQL.b_UpdatePhone(txtPhone.Text, Info.store.ToString()))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
			}
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}

		private void Form_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					if(btnOK.Enabled)
					{
						btnOK_Click(sender, null);
					}
					break;
				default:
					break;
			}
		}

		private void Form_TextChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = true;
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
	}
}
