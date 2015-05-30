using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared.Forms
{
    public partial class frmReasonSelector : Form
    {
        public object selectedReason = null;
        public string selectedType = string.Empty;

        CiscoFinesseNET.WrapUpReasons wrapReasons = null;
        CiscoFinesseNET.ReasonCodes reasonCodes = null;

        public frmReasonSelector(string title, object list, string listT)
        {
            InitializeComponent();

            if (list is CiscoFinesseNET.WrapUpReasons) wrapReasons = list as CiscoFinesseNET.WrapUpReasons;
            else if (list is CiscoFinesseNET.ReasonCodes) reasonCodes = list as CiscoFinesseNET.ReasonCodes;

            selectedType = listT;

            this.Text = title;
            selectedType = listT;

            //load the listbox up
            if (reasonCodes != null)
            {
                lbSelectReason.ValueMember = "code";
                lbSelectReason.DisplayMember = "label";

                foreach (CiscoFinesseNET.ReasonCode code in reasonCodes.ReasonCode)
                {
                    lbSelectReason.Items.Add(code);
                }
            }
            else if (wrapReasons != null)
            {
                lbSelectReason.ValueMember = "uri";
                lbSelectReason.DisplayMember = "label";

                foreach (CiscoFinesseNET.WrapUpReason reason in wrapReasons.WrapUpReason)
                {
                    lbSelectReason.Items.Add(reason);
                }
            }

            this.Focus();
            this.BringToFront();
            this.TopMost = true;
            
            lbSelectReason.SelectedIndex = 0;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (reasonCodes != null)
            {
                selectedReason = reasonCodes.ReasonCode[lbSelectReason.SelectedIndex];
            }
            else if (wrapReasons != null)
            {
                selectedReason = wrapReasons.WrapUpReason[lbSelectReason.SelectedIndex];
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmReasonSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                if (selectedType == "wrapUpReason")
                {
                    e.Cancel = true;
                }
                else this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void lbSelectReason_DoubleClick(object sender, EventArgs e)
        {
            //get the doubleclicked item, return as if they clicked ok
            btnOkay_Click(sender, e);
        }
    }
}
