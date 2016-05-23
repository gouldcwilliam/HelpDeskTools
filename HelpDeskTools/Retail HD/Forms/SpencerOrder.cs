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
        string _name = "";
        string _ip = "";
        public SpencerOrder()
        {
            InitializeComponent();
        }
        public SpencerOrder(string store,string phone,string TZ, string Name, string IP, string Gateway)
        {
            InitializeComponent();
            txtStore.Text = store;
            txtPhone.Text = phone;
            lblTZ.Text = TZ;
            _name = Name.Substring(0,11);
            txtName.Text = _name;
            _ip = IP.Substring(0, IP.Length - 2);
            txtIP.Text = _ip;
            //txtIP.Text = "";
            txtGate.Text = Gateway;
            if (store.Length == 3) { _subnet = "255.255.255.192"; }
            else if (store.Length == 4) { _subnet = "255.255.255.248"; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if(_name == txtName.Text) { MessageBox.Show("Must provide a valid computer name","Invalid Input",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            if(_ip==txtIP.Text) { MessageBox.Show("Must provide a valid ip", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            string body = string.Format(
                "Store:\t\t\t {0}\r" +
                "Phone:\t\t\t {1}\r" +
                "Hours:\t\t\t {2} - {3}\r" +
                "Register #\t\t {4}\r" +
                "Tech:\t\t\t {5}\r" +
                "Dispatch:\t\t {6} {13}\r" +
                "Replacemet Name:\t {7}\r" +
                "IP:\t\t\t {8}\r" +
                "Subnet:\t\t {9}\r" +
                "Gate:\t\t\t {10}\r" +
                "DNS:\t\t\t 10.63.33.41\r" +
                "\t\t\t 10.63.33.42\r" +
                "Password:\t\t {11}\r" +
                "Details:\t\t\t {12}\r",
                txtStore.Text, txtPhone.Text, txtHrs1.Text, txtHrs2.Text, txtReg.Text, ckbTech.Checked.ToString(),
                txtDispatch.Text, txtName.Text, txtIP.Text, _subnet, txtGate.Text, txtPassword.Text, txtDetails.Text, lblTZ.Text                
                );
            if (txtReg.Text == "1") { MessageBox.Show("Create a trax ticket for article replacement", "Create Articles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            //Console.WriteLine(body);
            Shared.Functions.SendMail(Environment.UserName + "@wwwinc.com", Environment.UserName + "@wwwinc.com", "Spencer order" + txtStore.Text, body);
            this.Close();            
        }
    }
}
