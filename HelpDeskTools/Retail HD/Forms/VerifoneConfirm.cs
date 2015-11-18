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
    public partial class VerifoneConfirm : Form
    {
        public VerifoneConfirm(string Computer)
        {
            InitializeComponent();
            _Computer = Computer;
            this.Text = this.Text + " " + _Computer;
        }
        private string _Computer = string.Empty;

        private bool copyArgsXML(string Computer)
        {
            string tempFile = @"C:\temp\args.xml";
            try { System.IO.File.WriteAllText(tempFile, GlobalResources.args.ToString()); }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            try
            {
                string Destination = string.Format(@"\\{0}\C$\Program Files\VeriFone\MX915\vfQueryUpdate\args.xml", Computer);
                Console.WriteLine(Destination);
                System.IO.File.Copy(tempFile, Destination, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        private void StupidFuckingVerifone_Shown(object sender, EventArgs e)
        {
            // nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			string args2 = string.Format("-r:{0} {1} {2}", _Computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "start credit");
            GlobalFunctions.ExecuteCommand("WINRS", args2, true, false);
            this.Close();
        }
    }
}
