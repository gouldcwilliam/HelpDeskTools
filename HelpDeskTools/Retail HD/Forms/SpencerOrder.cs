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
    public partial class SpencerOrder : Form
    {
        string _subnet = "";
        public SpencerOrder()
        {
            InitializeComponent();
        }
        public SpencerOrder(string store,string phone, string Name, string IP, string Gateway)
        {
            InitializeComponent();
            txtStore.Text = store;
            txtPhone.Text = phone;
            txtName.Text = Name;
            txtIP.Text = IP;
            txtIP.Text = "";
            txtGate.Text = Gateway;
            if (store.Length == 3) { _subnet = "255.255.255.192"; }
            else if (store.Length == 4) { _subnet = "255.255.255.248"; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            string body = string.Format(
                "Store:\t\t\t {0}\r" +
                "Phone:\t\t\t {1}\r" +
                "Hours:\t\t\t {2} - {3}\r" +
                "Register #\t\t {4}\r" +
                "Tech:\t\t\t {5}\r" +
                "Dispatch:\t\t {6}\r" +
                "Replacemet Name:\t {7}\r" +
                "IP:\t\t\t {8}\r" +
                "Subnet:\t\t {9}\r" +
                "Gate:\t\t\t {10}\r" +
                "DNS:\t\t\t 10.63.33.41\r" +
                "\t\t\t 10.63.33.42\r" +
                "Password:\t\t {11}\r" +
                "Details:\t\t\t {12}\r",
                txtStore.Text, txtPhone.Text, txtHrs1.Text, txtHrs2.Text, txtReg.Text, ckbTech.Checked.ToString(),
                txtDispatch.Text, txtName.Text, txtIP.Text, _subnet, txtGate.Text, txtPassword.Text, txtDetails.Text                
                );
            //Console.WriteLine(body);
            Shared.Functions.SendMail(Environment.UserName + "@wwwinc.com", Environment.UserName + "@wwwinc.com", "Spencer order" + txtStore.Text, body);
            this.Close();            
        }
    }
}
