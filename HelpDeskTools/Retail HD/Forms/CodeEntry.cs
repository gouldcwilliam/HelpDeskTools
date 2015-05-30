using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD
{
    public partial class frmCodeEntry : Form
    {
        int keyCount = 0;
        Keys[] keyPattern = new Keys[10];

        public frmCodeEntry()
        {
            InitializeComponent();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Right) return true;
            if (keyData == Keys.Left) return true;
            if (keyData == Keys.Up) return true;
            if (keyData == Keys.Down) return true;

            else return base.IsInputKey(keyData);
        }

        private void KonamiCode(KeyEventArgs e)
        {
            switch (keyCount)
            {
                case 0:
                    keyPattern[0] = e.KeyCode;
                    break;
                case 1:
                    if (keyPattern[0] == Keys.Up)
                    {
                        keyPattern[1] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 2:
                    if (keyPattern[1] == Keys.Up)
                    {
                        keyPattern[2] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 3:
                    if (keyPattern[2] == Keys.Down)
                    {
                        keyPattern[3] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 4:
                    if (keyPattern[3] == Keys.Down)
                    {
                        keyPattern[4] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 5:
                    if (keyPattern[4] == Keys.Left)
                    {
                        keyPattern[5] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 6:
                    if (keyPattern[5] == Keys.Right)
                    {
                        keyPattern[6] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 7:
                    if (keyPattern[6] == Keys.Left)
                    {
                        keyPattern[7] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 8:
                    if (keyPattern[7] == Keys.Right)
                    {
                        keyPattern[8] = e.KeyCode;
                    }
                    else
                    {
                        keyCount = 0;
                        return;
                    }
                    break;
                case 9:
                    if (keyPattern[8] == Keys.B && e.KeyCode == Keys.A)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    keyCount = 0;
                    return;
                default:
                    break;
            }

            keyCount++;
        }

        private void frmCodeEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            KonamiCode(e);
        }

		private void frmCodeEntry_Load(object sender, EventArgs e)
		{

		}
    }
}
