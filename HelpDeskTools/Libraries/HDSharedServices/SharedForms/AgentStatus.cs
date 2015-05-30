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
    public partial class frmAgentStatus : Form
    {
        Timer _t = new Timer();
        BindingList<AgentStatus> agents = new BindingList<AgentStatus>();
        const string ButtonText = "Change Status: {0}"; //parameter is for Status
        const string NoChangeText = "Unavailable"; //display if status change is not possible
        CiscoFinesseNET.UserState availableState = CiscoFinesseNET.UserState.READY;
        bool AllowLogout = false;

        public frmAgentStatus()
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

        private string MakeQuery(bool showMe, bool showOffline)
        {
            //SELECT Technicians.full_name AS Name, Technicians.technician AS login, Technicians.id as ID, CurrentStatus, TimeStatusChanged, Information1, Information2 FROM AgentStatus INNER JOIN Technicians ON AgentStatus.TechnicianID = Technicians.id WHERE Technicians.technician <> 'kiddjo' AND CurrentStatus <> 'LOGOUT';
            string baseQuery = "SELECT Technicians.full_name AS Name, Technicians.technician AS login, Technicians.id as ID, CurrentStatus, TimeStatusChanged, Information1, Information2 FROM AgentStatus INNER JOIN Technicians ON AgentStatus.TechnicianID = Technicians.id";
            string excludeMe = string.Format("Technicians.technician <> '{0}'", System.Environment.UserName);
            string excludeOffline = "CurrentStatus <> 'LOGOUT'";

            if (showMe && showOffline)
            {
                return baseQuery + ";"; //i like semicolons
            }
            else if (!showMe && showOffline)
            {
                return string.Format("{0} WHERE {1};", baseQuery, excludeMe);
            }
            else if (!showOffline && showMe)
            {
                return string.Format("{0} WHERE {1};", baseQuery, excludeOffline);
            }
            else
            {
                return string.Format("{0} WHERE {1} AND {2};", baseQuery, excludeOffline, excludeMe);
            }
        }

        private void UpdateInfo()
        {
            agents.Clear();
			string query = MakeQuery(Settings.Default._ShowMeInAgentStatus, Settings.Default._ShowLoggedOutUsers);
			query = MakeQuery(Config.PerUser.Load().ShownInAgentStatus, Config.PerUser.Load().ShowLoggedOutUsers);

            //if (Settings.Default._ShowLoggedOutUsers) query = "SELECT Technicians.full_name AS Name, Technicians.technician AS login, Technicians.id as ID, CurrentStatus, TimeStatusChanged, Information1, Information2 FROM AgentStatus INNER JOIN Technicians ON AgentStatus.TechnicianID = Technicians.id;";
            //else query = "SELECT Technicians.full_name AS Name, Technicians.technician AS login, Technicians.id as ID, CurrentStatus, TimeStatusChanged, Information1, Information2 FROM AgentStatus INNER JOIN Technicians ON AgentStatus.TechnicianID = Technicians.id WHERE CurrentStatus <> 'LOGOUT';";

            System.Data.DataTable dt = SQL.Select(query);
            //update the List of Agents here
            agents.Clear();
            foreach (DataRow _r in dt.Rows)
            {
                AgentStatus _a = new AgentStatus();
                _a.AgentID = int.Parse(_r["ID"].ToString());
                _a.AgentName = _r["Name"].ToString();
                _a.CurrentStatus = (CiscoFinesseNET.UserState)Enum.Parse(typeof(CiscoFinesseNET.UserState), _r["CurrentStatus"].ToString());
                _a.Information1 = _r["Information1"].ToString();
                _a.Information2 = _r["Information2"].ToString();
                _a.LoginName = _r["login"].ToString();
                _a.TimeStatusChanged = DateTime.Parse(_r["TimeStatusChanged"].ToString());

                //make sure this agent isn't already in the list, if they are update them, otherwise add

                agents.Add(_a);
            }

            if (agents.Count < 1) //no agents logged in, or no one besides you is logged in
            {
                AgentStatus _a = new AgentStatus();
                _a.AgentName = "No one logged in.";
                _a.AgentID = 0;
                _a.CurrentStatus = CiscoFinesseNET.UserState.UNKNOWN;
                _a.Information1 = "";
                _a.Information2 = "";
                _a.LoginName = "";
                _a.TimeStatusChanged = DateTime.Now;
                agents.Add(_a);
            }
            
            //if we are not showing the currently logged in user, find and remove them from the list now

            BuildDGV();

            if (agents[0].AgentName == "No one logged in." && dgvAgents.Columns.Count > 2)
            {
                //remove the status column....
                dgvAgents.Columns.Remove("Current Status");
                dgvAgents.Columns.Remove("Information");
                dgvAgents.Columns["Name"].HeaderText = " ";

                //disable context menu
                dgvAgents.ContextMenuStrip = null;
            }

            if (dgvAgents.Rows.Count < 1)
            {
                dgvAgents.DataSource = agents;
            }
            //dgvAgents.Refresh();
        }

        private void frmAgentStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            _t.Stop();
        }

        private void BuildDGV()
        {
            //check if this has already been done
            if (dgvAgents.Columns.Count > 1) return;
            else if (dgvAgents.Columns.Count == 1) dgvAgents.Columns.RemoveAt(0); //gets rid of the extra name column

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

            dgvAgents.AutoGenerateColumns = false;
            dgvAgents.Columns.Add("Name", "Name");
            dgvAgents.Columns.Add("Current Status", "Current Status");
            dgvAgents.Columns.Add("Information", "Information");

            dgvAgents.Columns["Name"].FillWeight = 18.0f;
            dgvAgents.Columns["Information"].FillWeight = 30.0f;

            dgvAgents.Columns["Name"].DataPropertyName = "AgentName";
            dgvAgents.Columns["Information"].DataPropertyName = "Information1";

            if ((CiscoFinesseNET.Helper.loggedInUser.role & CiscoFinesseNET.Role.Supervisor) == CiscoFinesseNET.Role.Supervisor)
            {
                dgvAgents.Columns["Current Status"].FillWeight = 30.0f;
                dgvAgents.Columns["Current Status"].DataPropertyName = "statusSince";
            }
            else
            {
                dgvAgents.Columns["Current Status"].FillWeight = 18.0f;
                dgvAgents.Columns["Current Status"].DataPropertyName = "CurrentStatus";
            }

            //dgvAgents.AutoResizeColumns();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            //need basically the same code from the main page here
            DataGridViewSelectedRowCollection _c = dgvAgents.SelectedRows;
            AgentStatus _s = _c[0].DataBoundItem as AgentStatus;

            CiscoFinesseNET.Helper.ChangeOtherUserState(availableState, _s.LoginName.ToLower());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //this... will probably work?
            DataGridViewSelectedRowCollection _c = dgvAgents.SelectedRows;
            AgentStatus _s = _c[0].DataBoundItem as AgentStatus;

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

            //figure out which agent is being opened, and adjust the change status button to accurately reflect that
            DataGridViewSelectedRowCollection _c = dgvAgents.SelectedRows;
            AgentStatus _s = _c[0].DataBoundItem as AgentStatus;
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
            DataGridViewSelectedRowCollection _c = dgvAgents.SelectedRows;
            AgentStatus _s = _c[0].DataBoundItem as AgentStatus;

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

            DataGridViewSelectedRowCollection _c = dgvAgents.SelectedRows;
            AgentStatus _s = _c[0].DataBoundItem as AgentStatus;

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
