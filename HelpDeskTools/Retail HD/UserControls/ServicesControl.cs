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
	public partial class ServicesControl : UserControl
	{
		public ServicesControl()
		{
			InitializeComponent();
		}

		public void Clear()
		{
			this.rbCredit.Checked = false;
			this.rbRestart.Checked = false;
			this.rbSQL.Checked = false;
			this.rbStart.Checked = false;
			this.rbStop.Checked = false;
			this.rbPCA.Checked = false;
			this.rbCitrix.Checked = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{

		}

	}
}
