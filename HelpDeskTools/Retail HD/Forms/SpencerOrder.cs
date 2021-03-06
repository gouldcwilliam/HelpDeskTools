﻿using System;
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
            string tech = "No";
            if (ckbTech.Checked) { tech = "Yes"; }
            string body = string.Format(
                "Store: {0} -|- "+
                "Phone: {1} -|- " +
                "Hours: {2} - {3} {13} -|- " +
                "Register # {4} -|- " +
                "Tech: {5} -|- " +
                "Dispatch: {6} -|- " +
                "Replacement Name: {7} -|- " +
                "IP: {8} -|- " +
                "Subnet: {9} -|- " +
                "Gate: {10} -|- " +
                "DNS: 10.63.33.41 -|- " +
                " 10.63.33.42 -|- " +
                "Password: {11} -|- " +
                "Details: {12}",
                txtStore.Text, txtPhone.Text, txtHrs1.Text, txtHrs2.Text, txtReg.Text, tech,
                txtDispatch.Text, txtName.Text, txtIP.Text, _subnet, txtGate.Text, txtPassword.Text, txtDetails.Text, lblTZ.Text                
                );

            if (txtReg.Text == "1")
            {
                string annetteSpeal =
                    "1. Create a Trax ticket for the creation of replacement articles. Make sure to note if the current register 1 is up in the ticket.<br>" +
                    "2.Assign the Trax ticket to the Retail queue.<br>" +
                    "3.Copy the ticket number and add it to the Register replacement ticket in the Retail Helpdesk queue.";
                Shared.Functions.SendEmail("retail.helpdesk@wwwinc.com", annetteSpeal , "Article Ticket Creation for " + txtStore.Text);
            }
            Shared.Functions.SendMail(Environment.UserName + "@wwwinc.com", Environment.UserName + "@wwwinc.com", "Spencer order" + txtStore.Text, body);
            this.Close();
        }
    }
}
