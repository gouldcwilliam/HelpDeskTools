using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDSharedServices.Forms
{
    public partial class frmNotify : Form
    {
        public frmNotify(string title = "", string message = "")
        {
            InitializeComponent();

            if (title != "")
            {
                this.Text = title;
            }

            if (message != "")
            {
                lblMessage.Text = message;
            }
        }
    }
}
