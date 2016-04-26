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
    /// Form to add additional phone to a store
    /// </summary>
    public partial class AdditionalPhone : Form
    {
        /// <summary>
        /// <seealso cref="AdditionalPhone"/>
        /// </summary>
        public AdditionalPhone()
        {
            InitializeComponent();
        }
        /// <summary>
        /// <seealso cref="AdditionalPhone"/>
        /// </summary>
        /// <param name="storeNumber"></param>
        public AdditionalPhone(string storeNumber)
        {
            InitializeComponent();
            txtStore.Text = storeNumber;
        }
        /// <summary>
        /// <seealso cref="AdditionalPhone"/>
        /// </summary>
        /// <param name="storeNumber"></param>
        /// <param name="phoneNumber"></param>
		public AdditionalPhone(string storeNumber, string phoneNumber)
		{
			InitializeComponent();
			txtStore.Text = storeNumber;
			txtPhone.Text = phoneNumber;
		}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtStore.Text == string.Empty || txtPhone.Text == string.Empty) { return; }
            List<System.Data.SqlClient.SqlParameter> pList = new List<System.Data.SqlClient.SqlParameter>();
            pList.Add(new System.Data.SqlClient.SqlParameter("@store", txtStore.Text));
            pList.Add(new System.Data.SqlClient.SqlParameter("@phone",txtPhone.Text));
            Shared.SQL.Insert("Insert into [Phones] ([phone],[store]) values (dbo.RemoveNonNumericCharacters(@phone),@store)", pList);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
