using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CiscoFinesseNET;

namespace Retail_HD.Forms
{
    // TODO - needs a cleaner UI

    /// <summary>
    /// Agent status form
    /// </summary>
    public partial class AgentStatus : Form
    {
        Timer _t = new Timer();
        BindingList<Classes.AgentStatus> agents = new BindingList<Classes.AgentStatus>();
        const string ButtonText = "Change Status: {0}"; //parameter is for Status
        const string NoChangeText = "Unavailable"; //display if status change is not possible
        CiscoFinesseNET.UserState availableState = CiscoFinesseNET.UserState.READY;
        bool AllowLogout = false;

        /// <summary>
        /// <seealso cref="AgentStatus"/>
        /// </summary>
        public AgentStatus()
        {
            InitializeComponent();

            _t.Interval = 3000; //increased to 3 seconds to allow time for supervisor to click on buttonz
            _t.Tick += _t_Tick;
        }

        void _t_Tick(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void frmAgentStatus_Load(object sender, EventArgs e)
        {
            //if supervisor, enable context menu
            if ((CiscoFinesseNET.Helper.loggedInUser.role & CiscoFinesseNET.Role.Supervisor) == CiscoFinesseNET.Role.Supervisor)
            {
                dgvAgents.ContextMenuStrip = cmsAdmin;
                this.Width = 480;
                this.Height = 320;
            }
            else
            {
                dgvAgents.ContextMenuStrip = cmsUser;
                this.Width = 388;
                this.Height = 300;
            }

            //load up the infos
            UpdateInfo();
        }

        private string MakeQuery(bool showMe)
        {
            string tech = Environment.UserName.ToUpper();
            if (showMe) { tech = ""; }
            return string.Format(Shared.SQLSettings.Default._AgentStatus, tech);
        }

        private void UpdateInfo()
        {
            agents.Clear();
            dgvAgents.DataSource = Shared.SQL.Select(MakeQuery(Properties.Settings.Default._ShowMeInAgentStatus));

            try
            {
                dgvAgents.Columns["login"].Visible = false;
                dgvAgents.Columns["ID"].Visible = false;
                dgvAgents.Columns["Information2"].Visible = false;
                if (!(dgvAgents.ContextMenuStrip != null)) //because if you check for equivilence to null, you get a null reference exception... LOL
                {
                    if ((CiscoFinesseNET.Helper.loggedInUser.role & CiscoFinesseNET.Role.Supervisor) == CiscoFinesseNET.Role.Supervisor)
                    {
                        dgvAgents.ContextMenuStrip = cmsAdmin;
                    }
                    else
                    {
                        dgvAgents.ContextMenuStrip = cmsUser;
                    }
                }
            }
            catch (Exception) {; }
        }

        private void frmAgentStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            _t.Stop();
        }



        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            //need basically the same code from the main page here
            Classes.AgentStatus _s = new Classes.AgentStatus();
            //figure out which agent is being opened, and adjust the change status button to accurately reflect that
            if (dgvAgents.SelectedRows.Count > 0)
            {
                _s = new Classes.AgentStatus(dgvAgents.SelectedRows[0]);
            }
            CiscoFinesseNET.Helper.ChangeOtherUserState(availableState, _s.LoginName.ToLower());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //this... will probably work?
            Classes.AgentStatus _s = new Classes.AgentStatus();
            //figure out which agent is being opened, and adjust the change status button to accurately reflect that
            if (dgvAgents.SelectedRows.Count > 0)
            {
                _s = new Classes.AgentStatus(dgvAgents.SelectedRows[0]);
            }
            if (_s.CurrentStatus == CiscoFinesseNET.UserState.READY)
            {
                //change to not ready first
                CiscoFinesseNET.Helper.ChangeOtherUserState(CiscoFinesseNET.UserState.NOT_READY, _s.LoginName.ToLower());
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
            }

            CiscoFinesseNET.Helper.ChangeOtherUserState(CiscoFinesseNET.UserState.LOGOUT, _s.LoginName.ToLower());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _t.Stop(); //prevents that stupid refresh bullshit
            Classes.AgentStatus _s = new Classes.AgentStatus();
            //figure out which agent is being opened, and adjust the change status button to accurately reflect that
            if (dgvAgents.SelectedRows.Count > 0)
            {
                _s = new Classes.AgentStatus(dgvAgents.SelectedRows[0]);
            }
            if (_s.LoginName.ToLower() == System.Environment.UserName.ToLower() || !isNumeric(_s.Information2))
            {
                btnCallUser.Enabled = false;
            }
            else
            {
                btnCallUser.Enabled = true;
            }

            switch (_s.CurrentStatus)
            {
                case CiscoFinesseNET.UserState.NOT_READY:
                    availableState = CiscoFinesseNET.UserState.READY;
                    AllowLogout = true;
                    break;
                case CiscoFinesseNET.UserState.READY:
                    availableState = CiscoFinesseNET.UserState.NOT_READY;
                    AllowLogout = true;
                    break;
                case CiscoFinesseNET.UserState.WORK:
                    availableState = CiscoFinesseNET.UserState.READY;
                    AllowLogout = false;
                    break;
                default:
                    availableState = CiscoFinesseNET.UserState.UNKNOWN;
                    AllowLogout = false;
                    break;
            }

            if (availableState != CiscoFinesseNET.UserState.UNKNOWN)
            {
                btnChangeStatus.Text = string.Format(ButtonText, availableState.ToString());
                btnLogout.Enabled = AllowLogout;
            }
            else
            {
                btnChangeStatus.Text = NoChangeText;
                btnChangeStatus.Enabled = false;
                btnLogout.Enabled = AllowLogout;
            }
        }

        private void CallUser_Click(object sender, EventArgs e)
        {
            //call the currently selected user
            Classes.AgentStatus _s = new Classes.AgentStatus();
            //figure out which agent is being opened, and adjust the change status button to accurately reflect that
            if (dgvAgents.SelectedRows.Count > 0)
            {
                _s = new Classes.AgentStatus(dgvAgents.SelectedRows[0]);
            }
            //unless it's you, you can't call you silly!
            if (_s.LoginName.ToLower() == System.Environment.UserName.ToLower())
            {
                MessageBox.Show("You can't call yourself, silly!", "Can't complete call as dialed, please hang up and try again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CiscoFinesseNET.Helper.MakeCall(_s.Information2); //no 81 needed for internal extensions
        }

        private bool isNumeric(string data)
        {
            try
            {
                int a = int.Parse(data);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void cmsClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _t.Start();
        }

        private void cmsUser_Opening(object sender, CancelEventArgs e)
        {
            _t.Stop();

            Classes.AgentStatus _s = new Classes.AgentStatus();
            //figure out which agent is being opened, and adjust the change status button to accurately reflect that
            if (dgvAgents.SelectedRows.Count > 0)
            {
                _s = new Classes.AgentStatus(dgvAgents.SelectedRows[0]);
            }
            if (_s.LoginName.ToLower() == System.Environment.UserName.ToLower() || !isNumeric(_s.Information2))
            {
                btnCallUser.Enabled = false;
            }
            else
            {
                btnCallUser.Enabled = true;
            }
        }

        private void frmAgentStatus_Shown(object sender, EventArgs e)
        {
            _t.Start();
        }
    }
}
