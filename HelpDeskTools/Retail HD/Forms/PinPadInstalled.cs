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
    public partial class PinPadInstalled : Form
    {
        public PinPadInstalled()
        {
            InitializeComponent();
        }

        private void PinPadInstalled_Load(object sender, EventArgs e)
        {
            this.Text += " @ Store " + Info.store;
            ckPP.Checked = Info.pinpad;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
            parameters.Add(new System.Data.SqlClient.SqlParameter("@pin", this.ckPP.Checked));
            parameters.Add(new System.Data.SqlClient.SqlParameter("@store", Info.store));

            if (Shared.SQL.Update("UPDATE [Stores] set [pinpad] = @pin where [store] = @store", parameters))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
