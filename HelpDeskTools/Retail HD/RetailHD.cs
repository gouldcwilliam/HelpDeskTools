﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using CiscoFinesseNET;
using Shared;


namespace Retail_HD
{
    /// <summary> class definition - main form
    /// </summary>
    public partial class RetailHD : Form
    {
        //
        #region Phone Variables

        const string _pStore = "Previous: {0}";

        int tickCount = 0;
        int tickCountNagger = 0;
        string previousStore = string.Empty;
        bool isWrapUpOpen = false;
        string _curNum = string.Empty;
        string currentStoreNumber
        {
            get
            {
                return _curNum;
            }
            set
            {
                if (value.Length == 4) { _curNum = string.Format("Store {0}", value); }
                else { _curNum = string.Format("{0}", value); }
            }
        }

        bool hasCallWrappedUp = false;
        UserState _cState;
        UserState curState
        {
            get
            {
                return _cState;
            }
            set
            {
                prevState = _cState;
                _cState = value;
            }
        }
        UserState prevState = UserState.UNKNOWN;
        Timer _t = new Timer();
        TimeSpan _timeSinceStateChange = new TimeSpan(0, 0, 0);
        CiscoFinesseNET.UserState availableState = UserState.READY;
        int fUpCount = 0;

        //
        #endregion


        //
        #region Variables

        bool _AgentLoginEnabled = false;
        bool _NetworkEnabled { get; set; }
        bool hasRun = false;
        Timer _loadWait = new Timer();

        List<Computer> _computers
        {
            get
            {
                return Info.selectedComputers;
            }
        }

        Forms.AgentStatus agentStatus = new Forms.AgentStatus();
        Forms.ReportIssue ReportIssue = new Forms.ReportIssue();
        Forms.WrapUp wrapUp = new Forms.WrapUp();
        Forms.Confirm nagger = new Forms.Confirm("You are in work, change to READY?", "Change Status?");
        Forms.UsefulInfo UsefulInfo = new Forms.UsefulInfo();
        Forms.StoreSearch StoreSearch = new Forms.StoreSearch();
        Forms.ListActions ListAction = new Forms.ListActions();
        Forms.HistorySearch HistorySearch = new Forms.HistorySearch();
        Forms.EditSettings EditSettings = new Forms.EditSettings();
        Forms.AddNewStore AddNewStore = new Forms.AddNewStore();
        Forms.AdditionalPhone AdditionalPhone = new Forms.AdditionalPhone();
        Forms.Splash startup = new Forms.Splash(GlobalResources.wat_help);
        Forms.IPs ips = new Forms.IPs();
        Forms.EditCalls editCalls = new Forms.EditCalls();
        Forms.StoreNotes storeNotes = new Forms.StoreNotes();
        Forms.SpencerOrder spencerOrder = new Forms.SpencerOrder();
        #endregion


        /// <summary> The main form
        /// </summary>
        public RetailHD()
        {

            InitializeComponent();
            Initialize_Buttons_ToolTips();
            Initialize_MainHandlers();

            PingUC.btnOK.Click += PingUC_OK_Click;
            ServicesUC.btnOK.Click += ServicesUC_OK_Click;

            Shared.Functions.UpdateLocalBatFiles();

            _NetworkEnabled = Shared.Functions.DnsLookup(Shared.SQLSettings.Default._ServerName);

            //phone stuff
            Helper.OnUpdatedInformation += Helper_OnUpdatedInformation;

            _t.Interval = 1000; //1 second between manual refreshes, this is in case the XMPP isn't returned as expected
            _t.Tick += _t_Tick;

            switch (Environment.UserName.ToUpper())
            {
                case "WHITEBR":
                case "OVERWAPA":
                case "PERSINER":
                case "WITTCHR":
                case "SHUTICAN":
                case "BERGMAJA":
                case "NEDDMI":
                case "GOULDCH":
                    Shared.SQLSettings.Default._Database = "RetailHD";
                    break;
                default:
                    Shared.SQLSettings.Default._Database = "Specialists";
                    break;
            }
            switch (Environment.UserName.ToUpper())
            {
                case "OVERWAPA":
                    startup = new Forms.Splash(GlobalResources.JKJ);
                    break;
                case "WHITEBR":
                case "PERSINER":
                case "WITTCHR":
                case "BERGMAJA":
                case "NEDDMI":
                case "GOULDCH":
                case "SHUTICAN":
                    startup = new Forms.Splash(GlobalResources.trumps);
                    break;
                default:
                    break;
            }

            startup.ShowDialog();


            // Prompts for Finesse login
            string msg = "Would you like to log into the Cisco Finesse Server?";
            Forms.Confirm ConfirmAgentLogin = new Forms.Confirm(msg);
            ConfirmAgentLogin.TopMost = true;
            ConfirmAgentLogin.btnOK.Text = "Yes";
            ConfirmAgentLogin.btnCancel.Text = "No";

            if ((System.Diagnostics.Debugger.IsAttached && Properties.Settings.Default._debugDisableLoginPrompt )
                || DialogResult.OK != ConfirmAgentLogin.ShowDialog())
            {
                _AgentLoginEnabled = false;
                ts_Top_tsb_Logout.Enabled = false;
                ts_Top_tsb_ChangeState.Enabled = false;
                ts_Top_tsb_CallStore.Enabled = false;
                ts_Top_tsb_TeamStatus.Enabled = false;
            }
            else
            {
                _AgentLoginEnabled = true;
                v_CheckLoginConfig();
            }

        }

        //
        #region HANDLER INITIALIZATIONS


        private void Initialize_Buttons_ToolTips()
        {
            tt_Main.SetToolTip(PCAnywhere, "Remotely connect to computer(s) using Dameware Mini Remote\nPress F1");
            tt_Main.SetToolTip(Unlock, "Unlocks the Cashier Number entered\nPress F2");
            tt_Main.SetToolTip(Browse, "Opens C:\\ on computer(s) in Windows Explorer to browse files remotely\nPress F3");
            tt_Main.SetToolTip(RemoteCMD, "Opens a CMD window on your machine running on the remote computer(s),\n Nice when a simple command may fix issue\nPress F4");
            tt_Main.SetToolTip(LocalCMD, "Opens a CMD window on selected machines desktop, very useful while remotely connected\nPress F5");
            tt_Main.SetToolTip(ListActions, "Opens a window able to perform actions on multiple store computers\nPress F6");
            tt_Main.SetToolTip(KillPOS, "Quickly closes POS software rather than talking caller through taskmanager\nPress F7");
            tt_Main.SetToolTip(Services, "Submenu with actions regarding POS services\nPress F8");
            tt_Main.SetToolTip(Ping, "Submenu for pinging common store network devices\nPress F9");
            tt_Main.SetToolTip(WrapUp, "Form to be used after each call for capturing Store Number, Issue, Time, etc.\nPress F10");
            tt_Main.SetToolTip(Restart, "Forces the computer to restart\nPress F11");
            tt_Main.SetToolTip(btnDelayed, "Tagets register 1 and attempts to start SQL and Express a defined number of times with a delay in between attemps\nUsed when a register is improperly shutdown and the rebuilding RAID is preventing service autostart\nPress F12");
            tt_Main.SetToolTip(RecentCalls_dgv, "Recent call wrap-ups with the most recent at the top\nRed rows indicate there was a Trax ticket recorded\nCtrl + DoubleClick to open Trax URL");
        }

        /// <summary>
        /// Sets the common handlers for controls
        /// </summary>
        private void Initialize_MainHandlers()
        {
            // Set handlers for all the buttons
            foreach (System.Windows.Forms.Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Name == "Services" || btn.Name == "Ping") { continue; }
                btn.Click += Main_Click;
                btn.KeyDown += Main_KeyDown;
            }
            // Set handlers for the tool strip
            foreach (ToolStripButton tsb in this.Controls.OfType<ToolStripButton>())
            {
                tsb.Click += Main_Click;
            }
            // Set handlers for the menu
            foreach (ToolStripMenuItem tsmi in this.ms_Top.Items.OfType<ToolStripMenuItem>())
            {
                tsmi.Click += Main_Click;
            }
            // Sets handlers for the text boxes
            foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
            {
                foreach (TextBox tb in gb.Controls.OfType<TextBox>())
                {
                    if (tb.Name != "txtStore") { tb.DoubleClick += MainText_DoubleClick; }
                    tb.Click += MainText_Click;
                    tb.Click += Main_Click;
                    tb.KeyDown += Main_KeyDown;
                }
            }
            foreach (UserControl uc in this.Controls.OfType<UserControl>())
            {
                uc.KeyDown += Main_KeyDown;
            }
            foreach (ToolStripStatusLabel tssl in this.ss_Bottom_.Items.OfType<ToolStripStatusLabel>())
            {
                tssl.Click += Main_Click;
            }
        }


        #endregion



        //
        #region HELPER FUNCTIONS - common methods used throughout form

        private bool isOnScreen(Form _form)
        {
            Screen[] screens = Screen.AllScreens;

            foreach (Screen _screen in screens)
            {
                Point bounds = new Point(Left, Top);

                if (_screen.WorkingArea.Contains(bounds))
                {
                    return true;
                }
            }

            return false;
        }


        DateTime GenerateDateFromString(string _input)
        {
            //int.Parse(Helper.loggedInUser.stateChangeTime.Substring(0,4))
            //2014-10-21T05:05:05.309Z
            int year = int.Parse(_input.Substring(0, 4));
            int month = int.Parse(_input.Substring(5, 2));
            int day = int.Parse(_input.Substring(8, 2));
            int hour = int.Parse(_input.Substring(11, 2));
            int minute = int.Parse(_input.Substring(14, 2));
            int second = int.Parse(_input.Substring(17, 2));
            int milisecond = int.Parse(_input.Substring(20, 3));

            return new DateTime(year, month, day, hour, minute, second, milisecond, DateTimeKind.Utc).ToLocalTime();
        }


        #endregion



        // 
        #region FINESSE HELPER FUNCTIONS - finesse methods used throughout form


        private void v_CheckLoginConfig()
        {
            if (fUpCount > 2)
            {
                MessageBox.Show("Try turning off your CAPS LOCK, or typing slower, or talk to Chad for 10 minutes about being a lumberjack.", "Nice try, but still error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!Helper.CheckConfiguration())
            {
                //instantiate modal login dialog box here
                //frmCiscoLogin loginForm = new frmCiscoLogin();
                Forms.CiscoSettings loginForm = new Forms.CiscoSettings();
                if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //login user
                    if (!Helper.IsUserInfoCaptured())
                    {
                        curState = Helper.LoginUser(loginForm.ciscoSettings.s_AgentUsername, loginForm.ciscoSettings.s_AgentPassword, loginForm.ciscoSettings.s_AgentACD);
                        //curState = Helper.LoginUser(GlobalFunctions._pusr, GlobalFunctions._ppas, GlobalFunctions._pacd);
                        //isLoggedIn = true;
                    }
                    else
                    {
                        curState = Helper.LoginUser();
                        //isLoggedIn = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("There is an error in your Cisco login settings!\n Check your login settings?", "Config Check Failure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        v_CheckLoginConfig();
                        return;
                    }
                    else
                    {
                        Application.Exit(); //user must be logged in
                    }
                }
            }
            else
            {
                curState = Helper.LoginUser();
                //isLoggedIn = true;
            }

            if (curState == UserState.UNKNOWN)
            {
                //at least one of the settings was wrong
                MessageBox.Show("At least one of the settings for Cisco is incorrect, please correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.InvalidateSettings();
                fUpCount++;
                v_CheckLoginConfig();
                return;
            }
            else if (curState == UserState.LOGOUT)
            {
                //process a normal log out, then login
                Helper.ChangeUserState(UserState.LOGOUT);
                _t.Stop();
                Helper.DisconnectXMPP();

                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
                curState = Helper.LoginUser();

                if (curState != UserState.NOT_READY)
                {
                    MessageBox.Show("At least one of the settings for Cisco is incorrect, please correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.InvalidateSettings();
                    fUpCount++;
                    v_CheckLoginConfig();
                    return;
                }
            }

            //_stateTimer.Start();
            Init.mainSettings.AppID = "RetailHD";
            _t.Start();
            Helper.ConnectXMPP();
            Shared.SQL.b_UpdateAgentInformation(System.Environment.UserName, curState.ToString(), "");
        }


        void _t_Tick(object sender, EventArgs e)
        {
            tickCountNagger++;

            if (tickCountNagger % 60 == 0) //this way even if the counter is not reset it will still trigger on 60 or every 60 after that (so if the first 60 is ignored, it will trigger on 120)
            {
                if (!wrapUp.Visible)
                {
                    if (!nagger.Visible)
                    {
                        if (curState == UserState.WORK)
                        {
                            //if (MessageBox.Show(this, "You are still in WORK and not able to take calls!\nChange status to READY now?", "Change Status?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                            if (nagger.ShowDialog() == DialogResult.OK)
                            {
                                tickCountNagger = 0;
                                CiscoFinesseNET.Helper.ChangeUserState(UserState.READY);
                            }

                        }
                    }
                }
                else tickCountNagger = 0;

            }

            if (tickCount % 3 == 0) //every 3 seconds
            {
                //change the color of the label for LULZ
                if (ts_Top.InvokeRequired)
                {
                    ts_Top.Invoke(new MethodInvoker(delegate
                    {
                        //if (!Properties.Settings.Default._EnableAutoReady && !ts_Top_tsl_Override.Visible)
                        ////if (!userPrefs.AutoReady && !ts_Top_tsl_Override.Visible)
                        //                     {
                        //                         ts_Top_tsl_Override.Visible = true;
                        //                     }
                        //                     else if (Properties.Settings.Default._EnableAutoReady && ts_Top_tsl_Override.Visible)
                        ////else if (userPrefs.AutoReady && ts_Top_tsl_Override.Visible)
                        //                     {
                        //                         ts_Top_tsl_Override.Visible = false;
                        //                     }

                        if (ts_Top_tsl_CurrentCall.Visible)
                        {
                            if (ts_Top_tsl_CurrentCall.ForeColor == SystemColors.HotTrack) ts_Top_tsl_CurrentCall.ForeColor = Color.Red;
                            else ts_Top_tsl_CurrentCall.ForeColor = SystemColors.HotTrack;
                        }

                        //if (ts_Top_tsl_Override.Visible)
                        //{
                        //    if (ts_Top_tsl_Override.ForeColor == Color.Red) ts_Top_tsl_Override.ForeColor = Color.Purple;
                        //    else ts_Top_tsl_Override.ForeColor = Color.Red;
                        //}
                    }));
                }
                else
                {
                    //if (!Properties.Settings.Default._EnableAutoReady && !ts_Top_tsl_Override.Visible)
                    ////if (!userPrefs.AutoReady && !ts_Top_tsl_Override.Visible)
                    //               {
                    //                   ts_Top_tsl_Override.Visible = true;
                    //               }
                    //               else if (Properties.Settings.Default._EnableAutoReady && ts_Top_tsl_Override.Visible)
                    ////else if (userPrefs.AutoReady && ts_Top_tsl_Override.Visible)
                    //               {
                    //                   ts_Top_tsl_Override.Visible = false;
                    //               }

                    if (ts_Top_tsl_CurrentCall.Visible)
                    {
                        if (ts_Top_tsl_CurrentCall.ForeColor == SystemColors.HotTrack) ts_Top_tsl_CurrentCall.ForeColor = Color.Red;
                        else ts_Top_tsl_CurrentCall.ForeColor = SystemColors.HotTrack;
                    }

                    //if (ts_Top_tsl_Override.Visible)
                    //{
                    //    if (ts_Top_tsl_Override.ForeColor == Color.Red) ts_Top_tsl_Override.ForeColor = Color.Purple;
                    //    else ts_Top_tsl_Override.ForeColor = Color.Red;
                    //}
                }
            }

            if (tickCount == 20) //20 iterations = 20 seconds
            {
                tickCount = 0;
                Helper.RefreshUserData();
            }
            else
            {
                tickCount++;
                //do timer stuff

                _timeSinceStateChange = _timeSinceStateChange.Add(new TimeSpan(0, 0, 1));
                if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_Time.Text = _timeSinceStateChange.ToString(@"hh\:mm\:ss"); }));
                else ss_Bottom_ssl_Time.Text = _timeSinceStateChange.ToString(@"hh\:mm\:ss");
            }
        }


        private void StupidOverrideForChad()
        {
            hasCallWrappedUp = false;
            int count = 0;
            while (curState == UserState.WORK && count < 20) //will refresh every 0.1 second until currentstate is no longer work, or until 20 iterations have run
            {
                Helper.RefreshUserData();
                System.Threading.Thread.Sleep(100);
                count++;
            }
        }

        // handles updates from finesse server
        void Helper_OnUpdatedInformation(object sender, UpdatedInformationEventArgs e)
        {
            bool useStoreInformation = false;

            if (Helper.loggedInUser != null)
            {
                curState = Helper.loggedInUser.state;
                try
                {
                    if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.Text = curState.ToString().Replace('_', ' '); }));
                    else ss_Bottom_ssl_State.Text = curState.ToString().Replace('_', ' ');
                }
                catch (ObjectDisposedException)
                {
                    //fuck you objectdisposedexception
                }

                if (curState != prevState)
                {
                    _timeSinceStateChange = new TimeSpan(0, 0, 0);

                    if (prevState == UserState.WORK || prevState == UserState.READY) hasCallWrappedUp = false;
                }
                if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ts_Top_tsb_ChangeState.Enabled = true; }));
                else ts_Top_tsb_ChangeState.Enabled = true;
                switch (curState)
                {
                    case UserState.READY:
                        hasCallWrappedUp = false;
                        useStoreInformation = false;
                        availableState = SetAvailableState(UserState.NOT_READY);
                        if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Green; }));
                        else ss_Bottom_ssl_State.ForeColor = Color.Green;

                        CurrentCall(false);
                        //this.tslblStatus.ForeColor = Color.Green;
                        break;
                    case UserState.NOT_READY:
                        useStoreInformation = false;
                        availableState = SetAvailableState(UserState.READY);
                        if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Red; }));
                        else ss_Bottom_ssl_State.ForeColor = Color.Red;
                        CurrentCall(false);
                        //this.tslblStatus.ForeColor = Color.Red;
                        break;
                    case UserState.LOGOUT:
                        useStoreInformation = false;
                        availableState = SetAvailableState(UserState.UNKNOWN);
                        if (ss_Bottom_.InvokeRequired) { ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Black; })); }
                        else { ss_Bottom_ssl_State.ForeColor = Color.Black; }
                        if (ts_Top.InvokeRequired) { ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_ChangeState.Enabled = false; })); }
                        else { ts_Top_tsb_ChangeState.Enabled = false; }
                        CurrentCall(false);
                        break;
                    case UserState.RESERVED:
                        useStoreInformation = true;
                        availableState = SetAvailableState(UserState.UNKNOWN);
                        if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Purple; }));
                        else ss_Bottom_ssl_State.ForeColor = Color.Purple;
                        FindStoreByPhone(e);
                        CurrentCall(true);
                        break;
                    case UserState.TALKING:
                        useStoreInformation = true;
                        availableState = SetAvailableState(UserState.UNKNOWN);
                        if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Blue; }));
                        else ss_Bottom_ssl_State.ForeColor = Color.Blue;

                        CurrentCall(true);
                        //this.tslblStatus.ForeColor = Color.Blue;
                        break;
                    case UserState.WORK:
                        if (prevState != UserState.WORK) tickCountNagger = 0; //set counter to 0 when entering work status
                        useStoreInformation = false;
                        availableState = SetAvailableState(UserState.READY);
                        if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Orange; ss_Bottom_ssl_PreviousCall.Text = previousStore; }));
                        else { ss_Bottom_ssl_State.ForeColor = Color.Orange; ss_Bottom_ssl_PreviousCall.Text = previousStore; }
                        //open call wrap up
                        CurrentCall(false);
                        if (!wrapUp.Visible)
                        {
                            isWrapUpOpen = true;
                            Shared.SQL.b_UpdateAgentInformation(System.Environment.UserName, curState.ToString(), (useStoreInformation) ? currentStoreNumber : "");
                            if (this.InvokeRequired) this.Invoke(new MethodInvoker(delegate { Buttons_WrapUp_Click(this, new WrapUpInvokeEventArgs(true)); }));
                            else Buttons_WrapUp_Click(this, new WrapUpInvokeEventArgs(true));

                            return;
                        }
                        break;
                    default:
                        if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_State.ForeColor = Color.Black; }));
                        else ss_Bottom_ssl_State.ForeColor = Color.Black;
                        availableState = SetAvailableState(UserState.UNKNOWN);
                        CurrentCall(false);
                        break;
                }

                if (curState != prevState) //no sense in updating this every few seconds...
                {
                    Shared.SQL.b_UpdateAgentInformation(System.Environment.UserName, curState.ToString(), (useStoreInformation) ? string.Format("Store {0}", txtStore.Text) : "", CiscoFinesseNET.Helper.loggedInUser.extension);
                }
            }
        }

        // change the state change tool strip button's icon based on current state
        private UserState SetAvailableState(UserState availableState)
        {
            switch (availableState)
            {
                case UserState.READY:
                    if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_ChangeState.Image = Shared.GlobalResources.icon_play; }));
                    else ts_Top_tsb_ChangeState.Image = Shared.GlobalResources.icon_play;
                    break;
                case UserState.NOT_READY:
                    if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_ChangeState.Image = Shared.GlobalResources.icon_stop; }));
                    else ts_Top_tsb_ChangeState.Image = Shared.GlobalResources.icon_stop;
                    break;
                default:
                    break;
            }

            return availableState;
        }

        // fills the store number by phone number if possible
        private void FindStoreByPhone(UpdatedInformationEventArgs e)
        {
            Helper.GetDialogs(); //make sure dialogs are refreshed first

            //find the store number, and update the textbox for store number
            if (Helper.loggedInUser._dialogList.Dialog != null)
            {
                //no error getting info from server
                string number2Search = string.Empty;//Helper.loggedInUser._dialogList.Dialog[0].fromAddress;
                string originalNumber = string.Empty;
                foreach (CiscoFinesseNET.DialogsDialogParticipant part in Helper.loggedInUser._dialogList.Dialog[0].participants)
                {
                    if (part.mediaAddress.ToString().Length > 9 && e.updateType == UpdateType.Dialog && Helper.loggedInUser._dialogList.Dialog[0].state == "ALERTING")
                    {
                        number2Search = part.mediaAddress.ToString();
                    }
                }

                if (number2Search != string.Empty && number2Search.Substring(0, 2) == "81")
                {
                    number2Search = number2Search.Substring(2);
                    originalNumber = number2Search;
                    number2Search = "%" + number2Search.Substring(0, 3) + "%" + number2Search.Substring(3, 3) + "%" + number2Search.Substring(6) + "%"; //should give us a phone number with wildcards in between
                                                                                                                                                        //match the store to the phone number
                    Console.WriteLine(number2Search);

                    System.Data.DataTable _dt = Shared.SQL.dt_SelectStoreByPhone(number2Search);
                    if (_dt.Rows.Count > 0)
                    {
                        System.Data.DataRow _r = _dt.Rows[0];
                        //shouldn't be more than 1 here
                        Console.WriteLine(_r["store"]);
                        if (txtStore.InvokeRequired) txtStore.Invoke(new MethodInvoker(delegate { txtStore.Text = _r["store"].ToString(); }));
                        else txtStore.Text = _r["store"].ToString();
                        currentStoreNumber = txtStore.Text == "9999" ? originalNumber : txtStore.Text;
                        previousStore = string.Format(_pStore, string.Format("Store {0}", txtStore.Text));
                        return; //just in case there is more than 1
                    }

                    //no store data, enter 9999
                    if (txtStore.InvokeRequired) txtStore.Invoke(new MethodInvoker(delegate { txtStore.Text = "9999"; }));
                    else txtStore.Text = "9999";

                    currentStoreNumber = txtStore.Text == "9999" ? originalNumber : txtStore.Text;
                    previousStore = string.Format(_pStore, string.Format("Store {0}", txtStore.Text));
                }
            }
        }



        #endregion



        // 
        #region ACTION BUTTONS FOR FIXING COMMON REGISTER ISSUES - register fixing methods

        // 

        /// <summary> connect to remote desktop
        /// </summary>
        private void Buttons_Dameware_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            //if (Info.reg1 == string.Empty) { return; }
            Functions.ConnectWithDW(_computers);
        }

        /// <summary> Opens fmrInput for cashier number, writes, copies, and executes BAT file remotley to unlock user account.
        /// Has a status bar and gives progress reports of background process
        /// </summary>
        private void Buttons_Unlock_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (Info.reg1 == string.Empty || txtStore.Text.Trim() == string.Empty) { return; };

            Forms.UserInput InputCashier = new Forms.UserInput("Enter cashier number");
            if (InputCashier.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (InputCashier._UserInput == string.Empty) { return; };
                Info.cashier = InputCashier._UserInput;
                Forms.BGWorkers.Unlock UnlockCashier = new Forms.BGWorkers.Unlock(Info.reg1, Info.cashier);
                UnlockCashier.Show();
            }
        }

        /// <summary> Browse c: drive of selected retList
        /// </summary>
        private void Buttons_Browse_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            Functions.BrowseComputer(_computers);
        }

        /// <summary> Opens remote cmd prompt on your local machine
        /// </summary>
        private void Buttons_RemoteCMD_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            Functions.RemoteCMD(_computers);
        }

        /// <summary> Opens local admin cmd prompt on remote machine
        /// </summary>
        private void Buttons_LocalCMD_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            Functions.LocalCMD(_computers);
        }

        /// <summary> Removes temp files responsible for repeat crashing of POS
        /// </summary>
        private void Buttons_ListAction_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (ListAction.Visible) { ListAction.BringToFront(); return; }
            ListAction = new Forms.ListActions();
            ListAction.Show();
        }

        /// <summary> Kill the POS software
        /// </summary>
        private void Buttons_KillPOS_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            Forms.Confirm killConfirm = new Forms.Confirm("Confirming will kill the POS software");
            if (killConfirm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Forms.BGWorkers.KillPOS kill = new Forms.BGWorkers.KillPOS(_computers);
                kill.Show();
            }
        }

        /// <summary> shows the user control menu for services
        /// </summary>
        private void Buttons_Services_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false;

            if (ServicesUC.Visible)
            {
                ServicesUC.Visible = false;
            }
            else
            {
                ServicesUC.Visible = true;
            }
        }

        /// <summary> shows the user control menu for ping
        /// </summary>
        private void Buttons_Ping_Click(object sender, EventArgs e)
        {
            ServicesUC.Visible = false;

            //if (Info.store > 999) { PingUC.ckbSensor.Enabled = false; PingUC.ckbSensorGate.Enabled = false; }
            //else { PingUC.ckbSensor.Enabled = true; PingUC.ckbSensorGate.Enabled = true; }


            if (PingUC.Visible)
            {
                PingUC.Visible = false;

            }
            else
            {
                PingUC.Visible = true;
            }
        }

        /// <summary> Call wrap up form
        /// </summary>
        private void Buttons_WrapUp_Click(object sender, EventArgs e)
        {
            // makes you ready if this is called once wrap up is done
            if (e is WrapUpInvokeEventArgs && hasCallWrappedUp)
            {
                if ((Properties.Settings.Default._EnableAutoReady && curState == UserState.WORK) || Environment.UserName.ToUpper() != "WITTCHR")
                //if (userPrefs.AutoReady && curState == UserState.WORK)
                {
                    hasCallWrappedUp = false;
                    Helper.ChangeUserState(UserState.READY);
                    StupidOverrideForChad();
                }
            }
            // If window is not open and call not wrapped up
            else if (!wrapUp.Visible && !hasCallWrappedUp)
            {
                PingUC.Visible = false; ServicesUC.Visible = false;
                if (txtStore.Text == string.Empty
                    || txtStore.Text.Length > 4
                    || txtStore.Text.Length < 3) { txtStore.Text = "9999"; }
                if (!Shared.Functions.isTxtBoxNumeric(txtStore)) { return; }

                wrapUp = new Forms.WrapUp();
                Point startLocation = new Point(this.Location.X + (this.Width / 3), this.Location.Y + (this.Height / 2));
                wrapUp.Location = startLocation;

                if (wrapUp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // only change to ready, if the user was in work (meaning normal call flow). 
                    // A dialed number will make you not ready, and then auto ready on the server-side if you were ready before
                    if ((Properties.Settings.Default._EnableAutoReady && curState == UserState.WORK) || Environment.UserName.ToUpper() != "WITTCHR")
                    //if (userPrefs.AutoReady && curState == UserState.WORK)
                    {
                        hasCallWrappedUp = false;
                        Helper.ChangeUserState(UserState.READY);
                        StupidOverrideForChad();
                    }
                }
                else if ((curState != UserState.READY) && (curState != UserState.NOT_READY))
                //else if ((curState != UserState.READY && curState != UserState.NOT_READY))
                {
                    if (MessageBox.Show("Call not wrapped up! Bypass wrapup?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        isWrapUpOpen = false;
                        hasCallWrappedUp = true;
                        return;
                    }
                    else
                    {
                        isWrapUpOpen = false;
                        hasCallWrappedUp = false;
                        return;
                    }
                }
                else if (curState == UserState.READY || curState == UserState.NOT_READY)
                {
                    isWrapUpOpen = false;
                    hasCallWrappedUp = false;
                    ClearInfo();
                    UpdateInfo(true);
                    return;
                }
                else
                {
                    //recall this function
                    Buttons_WrapUp_Click(this, new WrapUpInvokeEventArgs(false));
                    isWrapUpOpen = false;
                    hasCallWrappedUp = false;
                    return;
                }

                isWrapUpOpen = false;
                tickCount = 19; //2 seconds to refresh, in case you go from work -> reserved as sometimes there is no notification sent

                //only set haswrapped up to true, if they were in the normal call flow and wrapped up during the call
                if (curState == UserState.RESERVED || curState == UserState.TALKING || curState == UserState.WORK) hasCallWrappedUp = true;

                ClearInfo();
                UpdateInfo(true);
            }

        }

        /// <summary> Opens History window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttons_History_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (HistorySearch.Visible) { HistorySearch.BringToFront(); return; }

            HistorySearch = new Forms.HistorySearch();
            HistorySearch.Show();
        }

        /// <summary> Restart the Computer
        /// </summary>
        private void Buttons_Restart_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            Forms.Confirm restartConfirm = new Forms.Confirm("Confirming will restart the Computer(s) selected");
            if (restartConfirm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Forms.BGWorkers.Restart restart = new Forms.BGWorkers.Restart(_computers);
                restart.Show();
            }
        }

        /// <summary> runs the delayed SQL start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttons_Delayed_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (Info.computers.Count() > 0)
            {
                Shared.Functions.ExecuteCommand(@".\DelayedStartServices.exe", Info.reg1, true, "Delayed Services on " + Info.reg1, false);
            }
        }

        /// <summary> ping menu actions
        /// </summary>
        private void PingUC_OK_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false;
        }

        /// <summary> service menu actions
        /// </summary>
        private void ServicesUC_OK_Click(object sender, EventArgs e)
        {
            ServicesUC.Visible = false;
        }


        private void Journal_Click(object sender, EventArgs e)
        {
            //Functions.BrowseComputer(Info.reg1, @"Program Files\SAP\Retail Systems\Xpress Server\sdata");
            Cursor oldCursor = Cursor;
            try
            {
                Cursor = Cursors.WaitCursor;

                List<string> tempFiles = new List<string>();
                List<string> files = new List<string>();

                tempFiles.AddRange(System.IO.Directory.GetFiles(string.Format(@"\\{0}\C$\Program Files\SAP\Retail Systems\Xpress Server\sdata", Info.reg1), "*.jrn", SearchOption.AllDirectories));

                foreach (string file in tempFiles) { Console.WriteLine(file); }

                foreach (string computer in _computers)
                {
                    files.Add(tempFiles.Find(x => x.Contains(Info.store.ToString() + "0" + computer.Substring(11, 1))));
                }
                foreach (string file in files) { System.Diagnostics.Process.Start("NOTEPAD", file); }
            }
            catch (Exception) {; }
            Cursor = oldCursor;
        }



        #endregion



        //
        #region RECENT CALLS DATA GRID - call history methods/handlers

        private void RecentCalls_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                System.Diagnostics.Process.Start(RecentCalls_dgv.SelectedRows[0].Cells["URL"].Value.ToString());
            }
            else
            {

                if (RecentCalls_dgv.Rows.Count > 0)
                {
                    string id = RecentCalls_dgv.SelectedRows[0].Cells["ID"].Value.ToString();
                    string store = RecentCalls_dgv.SelectedRows[0].Cells["Store"].Value.ToString();
                    string date = RecentCalls_dgv.SelectedRows[0].Cells["Date"].Value.ToString();
                    string tech = RecentCalls_dgv.SelectedRows[0].Cells["Tech"].Value.ToString();
                    string category = RecentCalls_dgv.SelectedRows[0].Cells["Category"].Value.ToString();
                    string topic = RecentCalls_dgv.SelectedRows[0].Cells["Topic"].Value.ToString();
                    string details = RecentCalls_dgv.SelectedRows[0].Cells["Details"].Value.ToString();
                    string type = RecentCalls_dgv.SelectedRows[0].Cells["In/Out"].Value.ToString();
                    bool trax = (RecentCalls_dgv.SelectedRows[0].Cells["Trax"].Value.ToString().Contains("True"));
                    string url = RecentCalls_dgv.SelectedRows[0].Cells["URL"].Value.ToString();

                    if (editCalls.Visible) { editCalls.BringToFront(); }
                    editCalls = new Forms.EditCalls(id, store, date, tech, category, topic, details, type, trax, url);
                    editCalls = new Forms.EditCalls(id);
                    editCalls.ButtonClicked += new EventHandler(editCalls_ButtonClicked);
                    editCalls.Show();
                }
            }
        }

        void editCalls_ButtonClicked(object sender, EventArgs e)
        {
            UpdateInfo(true);
        }

        private void RecentCalls_dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle red = RecentCalls_dgv.DefaultCellStyle.Clone();
            red.BackColor = Color.Red;
            foreach (DataGridViewRow r in RecentCalls_dgv.Rows)
            {

                if (r.Cells["Trax"].Value.ToString().Contains("True"))
                {
                    r.DefaultCellStyle = red;
                    r.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

        }

        #endregion



        // 
        #region STORE INFORMATION - store's information methods/handlers




        // handles when store number Text box Text has changed
        private void txtStore_TextChanged(object sender, EventArgs e)
        {
            if (!_NetworkEnabled) { return; }
            Info.Clear();
            int store;

            if (txtStore.Text.Length > 2 && txtStore.Text.Length < 5
                && Shared.Functions.isTxtBoxNumeric(txtStore, out store))
            {
                if (store != Info.store) { Info.store = store; }
                UpdateInfo();
            }
            else
            {
                Info.store = 9999;
                ClearInfo();
            }
            ServicesUC.Visible = false;
            PingUC.Visible = false;
        }

        // handles when an item in the computer list is changing it's checked state
        private void clbComputers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Computer computer = Info.computers.FirstOrDefault(x => x.name == clbComputers.SelectedItem.ToString());
            if (computer != null) { computer.selected = (!computer.selected); }
        }



        #endregion



        // 
        #region MENU STRIP TOP - menu strip methods/handlers

        // when menu file->settings is clicked
        private void Settings_Click(object sender, EventArgs e)
        {
            if (EditSettings.Visible) { EditSettings.BringToFront(); return; }
            EditSettings = new Forms.EditSettings();
            EditSettings.Show();
        }

        // when menu help->what the junk is clicked
        private void IssueReport_Click(object sender, EventArgs e)
        {
            if (ReportIssue.Visible) { ReportIssue.BringToFront(); return; }
            ReportIssue = new Forms.ReportIssue();
            ReportIssue.Show();
        }

        // when menu info is clicked
        private void Info_Click(object sender, EventArgs e)
        {
            if (UsefulInfo.Visible) { UsefulInfo.BringToFront(); return; }
            UsefulInfo = new Forms.UsefulInfo();
            UsefulInfo.Show();
        }

        // Opens new bat menu when clicked
        private void OldBatMenu_Click(object sender, EventArgs e)
        {
            //GlobalFunctions.i_ExecuteCommand(Settings.Default._OldMenuPath, true);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = Properties.Settings.Default._OldMenuPath;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(startInfo);
            //process.WaitForExit();
        }

        // Opens Konami code entry form
        private void CodeEntry_Click(object sender, EventArgs e)
        {
            Forms.KonamiCodeEntry codeEntryForm = new Forms.KonamiCodeEntry();
            if (codeEntryForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string adjustedPath = string.Empty;
                string[] pathParts = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split('\\');
                for (int i = 0; i < pathParts.Length - 1; i++)
                {
                    adjustedPath += pathParts[i] + "\\";
                }
                var absolute_path = Path.Combine(adjustedPath, @"Resources\Contra_33.mp3");
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("wmplayer", "\"" + absolute_path + "\"");
                info.CreateNoWindow = true;
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                System.Diagnostics.Process.Start(info);
            }
        }

        // Runs the external computer refresh program
        private void RefreshComputers_Click(object sender, EventArgs e)
        {
            Functions.UpdateComputersFromAD();
        }

        // open form for new store entry
        private void AddStore_Click(object sender, EventArgs e)
        {
            if (AddNewStore.Visible) { AddNewStore.BringToFront(); return; }
            AddNewStore = new Forms.AddNewStore();
            AddNewStore.ShowDialog();
            UpdateInfo();
        }


        private void ImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
                Forms.ExcelLoadTables eSchemaInfo = new Forms.ExcelLoadTables(ofd.FileName);
                eSchemaInfo.Show();
            }
        }
        
        private void AdditionalPhone_Click(object sender, EventArgs e)
        {
            if (AdditionalPhone.Visible) { AdditionalPhone.BringToFront(); return; }
            AdditionalPhone = new Forms.AdditionalPhone(Info.store.ToString(), currentStoreNumber);
            AdditionalPhone.Show();
        }

        private void FlushDNS_Click(object sender, EventArgs e)
        {
            Shared.Functions.ExecuteCommand("ipconfig", "/flushdns", true);
        }

        #endregion



        //
        #region TOOL STRIP TOP - tool strip methods


        // changes the queue state
        private void ChangeState_Click(object sender, EventArgs e)
        {
            if (!_AgentLoginEnabled) { return; }
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (availableState == UserState.READY || availableState == UserState.NOT_READY)
            {
                //valid states
                Helper.ChangeUserState(availableState);
                if (availableState == UserState.READY)
                {
                    StupidOverrideForChad();
                }
            }
        }

        // log in/out of the queue
        private void Login_Click(object sender, EventArgs e)
        {
            if (!_AgentLoginEnabled) { return; }
            PingUC.Visible = false; ServicesUC.Visible = false;

            if (curState == UserState.READY)
            {
                //go not ready first
                Helper.ChangeUserState(UserState.NOT_READY);
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
                Helper.ChangeUserState(UserState.LOGOUT);
            }
            else if (curState == UserState.NOT_READY)
            {
                Helper.ChangeUserState(UserState.LOGOUT);
                _t.Stop();
                Helper.DisconnectXMPP();

                //change the button too
                if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_Logout.Image = Shared.GlobalResources.login; }));
                else ts_Top_tsb_Logout.Image = Shared.GlobalResources.login;
            }
            else if (curState == UserState.LOGOUT)
            {
                //process login and change the Text to read logout
                curState = Helper.LoginUser();

                if (curState == UserState.UNKNOWN || curState == UserState.LOGOUT)
                {
                    //at least one of the settings was wrong
                    MessageBox.Show("At least one of the settings for Cisco is incorrect, please correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.InvalidateSettings();
                    v_CheckLoginConfig();
                    return;
                }

                if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_Logout.Image = Shared.GlobalResources.logout; }));
                else ts_Top_tsb_Logout.Image = Shared.GlobalResources.logout;

                v_CheckLoginConfig();
                tickCount = 20; //1 seconds until refresh

                if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_Time.Text = "00:00:00"; }));
                else ss_Bottom_ssl_Time.Text = "00:00:00";

                return;
            }
            else
            {
                MessageBox.Show("You are not in a state that allows Logout/Login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // shows status of other team members
        private void AgentStatusList_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;

            if (!agentStatus.Visible && _AgentLoginEnabled)
            {
                agentStatus = new Forms.AgentStatus();
                agentStatus.Show();
            }
            else
            { agentStatus.BringToFront(); }
        }

        // call the current store
        private void CallStore_Click(object sender, EventArgs e)
        {
            if (!_AgentLoginEnabled) { return; }
            PingUC.Visible = false; ServicesUC.Visible = false;
            Console.WriteLine("Calling store # {0}", txtStore.Text);
            if (txtPhone.Text != "(555) 555-5555" && txtPhone.Text != string.Empty && txtPhone.Text.Length > 6 && (curState == UserState.READY || curState == UserState.WORK || curState == UserState.HOLD || curState == UserState.NOT_READY))
            {
                //we can make da call
                string number2call = string.Empty;
                char[] _tmp = txtPhone.Text.ToCharArray();

                foreach (char _c in _tmp) //get rid of dashes, slashes, and periods and other junk
                {
                    if (Shared.Functions.isNumeric(_c)) number2call += _c.ToString();
                }

                number2call = "81" + number2call;

                Helper.MakeCall(number2call);
            }
            else
            {
                MessageBox.Show("Either you are not in a valid state to make a phone call, or there is no store selected. Please correct and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Opens the store search form
        private void StoreSearch_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (StoreSearch.Visible) { StoreSearch.BringToFront(); return; }
            StoreSearch = new Forms.StoreSearch();
            StoreSearch.Show();
            bw.RunWorkerAsync();
        }

        // Opens the history search form
        private void HistorySearch_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
            if (HistorySearch.Visible) { HistorySearch.BringToFront(); return; }

            HistorySearch = new Forms.HistorySearch();
            HistorySearch.Show();
        }

        // Show the new VLAN IPs for the meraki install
        private void NewIps_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;

            if (ips.Visible) { ips.BringToFront(); return; }
            ips = new Forms.IPs(Info.store.ToString());
            ips.Show();
        }

        // Show the store note window
        private void StoreNote_Click(object sender, EventArgs e)
        {
            if (storeNotes.Visible) { storeNotes.BringToFront(); }
            else
            {
                storeNotes = new Forms.StoreNotes();
                storeNotes.Show();
                storeNotes.BringToFront();
            }

        }

        private void RegisterOrder_Click(object sender, EventArgs e)
        {
            if(txtStore.Text.Length < 3) { return; }
            if (spencerOrder.Visible) { spencerOrder.BringToFront(); }
            else
            {
                spencerOrder = new Forms.SpencerOrder(Info.store.ToString(), Info.phone, Info.TZ, Info.reg1, Info.pos, Info.pos_gate);
                spencerOrder.Show();
                spencerOrder.BringToFront();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            UpdateInfo(true);
        }

        #endregion



        // 
        #region MAIN FORM EVENTS - methods/handlers for whole form

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            bool breakIf = false;
            if (txtStore.Focused)
            {
                string keyVal = string.Empty;
                switch (e.KeyCode)
                {
                    case Keys.D0:
                    case Keys.NumPad0:
                        keyVal = "0";
                        break;
                    case Keys.D1:
                    case Keys.NumPad1:
                        keyVal = "1";
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        keyVal = "2";
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                        keyVal = "3";
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                        keyVal = "4";
                        break;
                    case Keys.D5:
                    case Keys.NumPad5:
                        keyVal = "5";
                        break;
                    case Keys.D6:
                    case Keys.NumPad6:
                        keyVal = "6";
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                        keyVal = "7";
                        break;
                    case Keys.D8:
                    case Keys.NumPad8:
                        keyVal = "8";
                        break;
                    case Keys.D9:
                    case Keys.NumPad9:
                        keyVal = "9";
                        break;
                    case Keys.Back:
                    case Keys.Delete:
                        return;
                    case Keys.Escape:
                    case Keys.Home:
                    case Keys.F1:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F12:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.F:
                    case Keys.M:
                    case Keys.R:
                    case Keys.S:
                    case Keys.T:
                    case Keys.E:
                    case Keys.P:
                    case Keys.Return:
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        breakIf = true;
                        break;
                    case Keys.Left:
                    case Keys.Right:
                        breakIf = true;
                        break;
                    default:
                        keyVal = ((char)e.KeyValue).ToString();
                        break;
                }
                if (!Shared.Functions.isNumeric(keyVal) && !breakIf)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    txtStore.Text = string.Empty;
                    txtStore.Focus();
                    Info.Clear();
                    //ServicesUC.Visible = false;
                    //PingUC.Visible = false;
                    break;
                case Keys.Home:
                    txtStore.Focus();
                    //ServicesUC.Visible = false;
                    //PingUC.Visible = false;
                    break;
                case Keys.F1:
                    Buttons_Dameware_Click(sender, null);
                    break;
                case Keys.F2:
                    Buttons_Unlock_Click(sender, null);
                    break;
                case Keys.F3:
                    Buttons_Browse_Click(sender, null);
                    break;
                case Keys.F4:
                    Buttons_RemoteCMD_Click(sender, null);
                    break;
                case Keys.F5:
                    Buttons_LocalCMD_Click(sender, null);
                    break;
                case Keys.F6:
                    Buttons_ListAction_Click(sender, null);
                    break;
                case Keys.F7:
                    Buttons_KillPOS_Click(sender, null);
                    break;
                case Keys.F8:
                    Buttons_Services_Click(sender, null);
                    break;
                case Keys.F9:
                    Buttons_Ping_Click(sender, null);
                    break;
                case Keys.F10:
                    Buttons_WrapUp_Click(sender, null);
                    break;
                case Keys.F11:
                    Buttons_Restart_Click(sender, null);
                    break;
                case Keys.F12:
                    Buttons_Delayed_Click(sender, null);
                    break;
                case Keys.C:
                    if (PingUC.Visible) { PingUC.ckbCCTV.Checked = (!PingUC.ckbCCTV.Checked); }
                    else if (e.Modifiers == Keys.Control && clbComputers.Focused)
                    {
                        Clipboard.SetText(clbComputers.SelectedItem.ToString());
                    }
                    break;
                case Keys.D:
                    if (e.Modifiers == Keys.Control) { ts_Top_tsb_CallStore.PerformClick(); }
                    break;
                case Keys.E:
                    break;
                case Keys.F:
                    if (PingUC.Visible) { PingUC.ckbFortinet.Checked = (!PingUC.ckbFortinet.Checked); }
                    break;
                case Keys.M:
                    if (PingUC.Visible)
                    {
                        PingUC.ckbMim.Checked = (!PingUC.ckbMim.Checked);
                    }
                    break;
                case Keys.R:
                    if (e.Modifiers == Keys.Control) { UpdateInfo(); }
                    else if (PingUC.Visible)
                    {
                        PingUC.ckbRegister.Checked = (!PingUC.ckbRegister.Checked);
                    }
                    break;
                case Keys.S:
                    if (e.Modifiers == Keys.Control) { ts_Top_tsb_ChangeState.PerformClick(); }
                    else if (PingUC.Visible)
                    {
                        PingUC.ckbSensor.Checked = (!PingUC.ckbSensor.Checked);
                    }
                    break;
                case Keys.T:
                    if (e.Modifiers == Keys.Control) { Test(); }
                    break;
                case Keys.Return:
                    if (PingUC.Visible) { PingUC.btnOK.PerformClick(); }
                    else if (ServicesUC.Visible) { ServicesUC.btnOK.PerformClick(); }
                    break;
                case Keys.L:
                    if (e.Modifiers == Keys.Control) { ts_Top_tsb_Logout.PerformClick(); }
                    break;
                default:
                    break;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default._DrawingSize.Width == 0) Properties.Settings.Default.Upgrade();

            if (Properties.Settings.Default._DrawingSize.Width < this.MinimumSize.Width || Properties.Settings.Default._DrawingSize.Height < this.MinimumSize.Height)
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = this.MinimumSize;
                this.Location = new Point(20, 20);
            }
            else
            {
                this.WindowState = Properties.Settings.Default._DrawingState;

                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                this.Location = Properties.Settings.Default._DrawingLocation;

                this.Size = Properties.Settings.Default._DrawingSize;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop state timer
            if (_t.Enabled)
            {
                _t.Stop();
            }

            // Agent logout
            if (_AgentLoginEnabled)
            {
                if (curState != UserState.NOT_READY)
                {
                    Helper.ChangeUserState(UserState.NOT_READY);
                    Shared.SQL.b_UpdateAgentInformation(System.Environment.UserName, UserState.NOT_READY.ToString(), "");
                    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
                }
                Helper.ChangeUserState(UserState.LOGOUT);
                Shared.SQL.b_UpdateAgentInformation(System.Environment.UserName, UserState.LOGOUT.ToString(), "");
                Helper.DisconnectXMPP();
            }
            //if log file is larger than 500kb, email it in
            //call up the log sender app and close this

            //// Save Settings
            ////userPrefs.FormStart = Location;
            //Properties.Settings.Default._DrawingLocation = Location;

            //if (WindowState == FormWindowState.Normal)
            //{
            //    Properties.Settings.Default._DrawingSize = Size;
            //    //userPrefs.FormSize = Size;
            //}
            //else
            //{
            //    Properties.Settings.Default._DrawingSize = RestoreBounds.Size;
            //    //userPrefs.FormSize = RestoreBounds.Size;
            //}
            //Properties.Settings.Default.Save();

            Properties.Settings.Default._DrawingState = this.WindowState;
            if(this.WindowState==FormWindowState.Normal)
            {
                Properties.Settings.Default._DrawingLocation = this.Location;
                Properties.Settings.Default._DrawingSize = this.Size;
            }
            else
            {
                Properties.Settings.Default._DrawingLocation = this.RestoreBounds.Location;
                Properties.Settings.Default._DrawingSize = this.RestoreBounds.Size;
            }
            Properties.Settings.Default.Save();
        }

        private void Main_FormShown(object sender, EventArgs e)
        {
            _loadWait.Interval = 200;
            _loadWait.Tick += _loadWait_Tick;
            _loadWait.Start();
        }

        private void _loadWait_Tick(object sender, EventArgs e)
        {
            Shared.Functions.CreateTempFolder(true);
            Shared.Functions.InstallPSTools();
            Shared.Functions.CheckForFiles(Shared.GlobalResources.batServices, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices);
            Shared.Functions.CheckForFiles(Shared.GlobalResources.batUnlock, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatUnlock);
            Shared.Functions.CheckForFiles(Shared.GlobalResources.batInstallEndpoint12, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatEndpoint);
            Shared.Functions.CheckForFiles(Shared.GlobalResources.argsXML, Shared.Settings.Default._TempPath + "args.xml");
            Shared.Functions.CheckForFiles(Shared.GlobalResources.Zip_Logs, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip);
            Shared.Functions.CheckForFiles(Shared.GlobalResources.Zipper, Shared.Settings.Default._TempPath + Shared.Settings.Default._PSZip);
            Shared.Functions.CheckForFiles(Shared.GlobalResources.batWSAdmin, Shared.Settings.Default._TempPath + Shared.Settings.Default._WSAdmin);

            //restore the position of the form
            //if (!hasRun)
            //{
            //    Location = Properties.Settings.Default._DrawingLocation;
            //    if (!isOnScreen(this))
            //    {
            //        //set the location to a default
            //        Location = new Point(200, 200);
            //    }

            //    hasRun = true;
            //}

            //if (_NetworkEnabled) { UpdateWrapUpTotal(); }
            //if (Properties.Settings.Default._DrawingSize != null)
            //{
            //    Size = Properties.Settings.Default._DrawingSize;
            //}
            _loadWait.Stop();
        }


        private void Main_Click(object sender, EventArgs e)
        {
            PingUC.Visible = false; ServicesUC.Visible = false;
        }

        private void MainText_Click(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.SelectAll();
        }

        private void MainText_DoubleClick(object sender, EventArgs e)
        {
            Forms.StoreInfoAddEdit storeInfo = new Forms.StoreInfoAddEdit();
            storeInfo.ShowDialog();
            UpdateInfo(true);
        }

        #endregion



        //
        #region FORM DATA METHODS -  methods/handlers for form data


        // Clear all the form information fields
        private void ClearInfo()
        {
            // Clear the store information
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtDM.Text = string.Empty;
            txtRM.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIP.Text = string.Empty;
            txtManager.Text = string.Empty;
            txtMpId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtState.Text = string.Empty;
            txtType.Text = string.Empty;
            txtTZ.Text = string.Empty;
            txtZip.Text = string.Empty;
            txtRank.Text = string.Empty;
            txtIncome.Text = string.Empty;
            txtBAMS.Text = string.Empty;
            txtSVS.Text = string.Empty;
            txtTID1.Text = string.Empty;
            txtTID2.Text = string.Empty;
            txtTID3.Text = string.Empty;
            txtTID4.Text = string.Empty;
            clbComputers.Items.Clear();
            RecentCalls_dgv.DataBindings.Clear();
            Info.computers.Clear();
        }

        // Update all the form information from the store information gathered from SQL
        private void UpdateInfo(bool notChanged=false)
        {
            if (!_NetworkEnabled) { return; }
            ClearInfo();
            if (Info.GetStoreInfo())
            {
                txtAddress.Text = Info.address;
                txtCity.Text = Info.city;
                txtDM.Text = Info.dm;
                txtRM.Text = Info.rm;
                txtEmail.Text = Info.email;
                txtIP.Text = Info.pos;
                txtManager.Text = Info.manager;
                txtMpId.Text = Info.MP;
                txtName.Text = Info.name;
                txtState.Text = Info.state;
                txtType.Text = Info.type;
                txtTZ.Text = Info.TZ;
                txtZip.Text = Info.zip;
                txtBAMS.Text = Info.BAMS;
                txtSVS.Text = Info.SVS;
                txtTID1.Text = Info.TID1;
                txtTID2.Text = Info.TID2;
                txtTID3.Text = Info.TID3;
                txtTID4.Text = Info.TID4;
                if (Info.income == string.Empty) { txtIncome.Text = string.Empty; }
                else { txtIncome.Text = "$" + Info.income; }
                if (Info.rank == string.Empty) { txtRank.Text = string.Empty; }
                else { txtRank.Text = Info.rank; }
                if (!string.IsNullOrEmpty(Info.phone))
                {
                    if (Info.phone.Length == 10)
                    {
                        txtPhone.Text = Info.phone.Substring(0, 3) + "-" + Info.phone.Substring(3, 3) + "-" + Info.phone.Substring(6);
                    }
                    else if (Info.phone.Length == 7)
                    {
                        txtPhone.Text = Info.phone.Substring(0, 3) + "-" + Info.phone.Substring(3);
                    }
                    else { txtPhone.Text = Info.phone; }
                }
                //PingUC.ckbCCTV.Enabled = (Info.cctv != string.Empty);
                PingUC.ckbCCTV.Enabled = (Info.cctv != string.Empty);
            }
            // Fill the computer list
            if (Info.GetComputers())
            {
                foreach (Computer computer in Info.computers)
                {
                    clbComputers.Items.Add(computer.name);
                }
            }
            // Fill the recent calls
            if (Info.GetRecentCalls())
            {
                RecentCalls_dgv.DataSource = Info.recentCalls;
                try
                {
                    RecentCalls_dgv.Columns["ID"].Visible = false;
                    RecentCalls_dgv.Columns["Store"].Visible = false;
                    RecentCalls_dgv.Columns["Date"].FillWeight = 4;
                    RecentCalls_dgv.Columns["Tech"].FillWeight = 1;
                    RecentCalls_dgv.Columns["Category"].FillWeight = 3;
                    RecentCalls_dgv.Columns["Topic"].FillWeight = 3;
                    RecentCalls_dgv.Columns["Details"].FillWeight = 12;
                    RecentCalls_dgv.Columns["In/Out"].FillWeight = 1;
                    RecentCalls_dgv.Columns["Trax"].Visible = false;
                    RecentCalls_dgv.Columns["URL"].Visible = false;
                }
                catch (Exception ex) { Console.WriteLine("Update Info: {0}\n => {1}", RecentCalls_dgv.Name, ex.Message); }
            }

            if (Info.FillNotes())
            {
                if (storeNotes.Visible) { storeNotes.Close(); }
                DataRow[] foundRows = Info.notes.Select("resolved='False'");
                if (foundRows.Length > 0 && !notChanged)
                {
                    storeNotes = new Forms.StoreNotes();
                    storeNotes.Show();
                    storeNotes.BringToFront();
                }
            }

            // Call the method to update call totals
            UpdateWrapUpTotal();

        }

        // Update the team's and user's total calls
        private void UpdateWrapUpTotal()
        {
            try
            {
                DataRow dr = Shared.SQL.dt_SelectWrapupsTotal().Rows[0];
                DataRow dr1 = Shared.SQL.dt_teamCalls().Rows[0];
                if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_UserCalls.Text = "Total Calls: " + dr["Total"].ToString(); ss_Bottom_ssl_TeamCalls.Text = "Team Calls: " + dr1["Total"].ToString(); }));
                else { ss_Bottom_ssl_UserCalls.Text = "Total Calls: " + dr["Total"].ToString(); ss_Bottom_ssl_TeamCalls.Text = "Team Calls: " + dr1["Total"].ToString(); }
            }
            catch (Exception ex)
            {
                if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_UserCalls.Text = "Total Calls: Err"; ss_Bottom_ssl_TeamCalls.Text = "Team Calls: Err"; }));
                else { ss_Bottom_ssl_UserCalls.Text = "Total Calls: Er"; ss_Bottom_ssl_TeamCalls.Text = "Team Calls: "; }
                Console.WriteLine(ex.Message);
            }
        }

        // displays the current caller
        private void CurrentCall(bool isShown)
        {
            //set the label to the correct text
            if (isShown)
            {
                if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsl_CurrentCall.Text = string.Format("Call with: {0}", currentStoreNumber); }));
                else ts_Top_tsl_CurrentCall.Text = string.Format("Call with: {0}", currentStoreNumber);
            }
            //make it visible
            if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsl_CurrentCall.Visible = isShown; }));
            else ts_Top_tsl_CurrentCall.Visible = isShown;

        }

        // Methods when the ping user control changes visibility
        private void Ping_UC_VisibleChanged(object sender, EventArgs e)
        {
            PingUC.Clear();
            //if (PingUC.Visible) { PingUC.Focus(); }
        }

        // Methods when the services user control changes visibility
        private void Services_UC_VisibleChanged(object sender, EventArgs e)
        {
            ServicesUC.Clear();
            //if (ServicesUC.Visible) { ServicesUC.Focus(); }
        }


        #endregion


        //
        #region BACKGROUND WORKER


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (txtStore.Text == string.Empty)
            {
                if (txtStore.InvokeRequired) txtStore.Invoke(new MethodInvoker(delegate { txtStore.Text = "9999"; }));
                else txtStore.Text = "9999";
            }
            if (Info.store == 0) { Info.store = 9999; }
            while (StoreSearch.Visible)
            {
                if (txtStore.Text != Info.store.ToString())
                {
                    if (txtStore.InvokeRequired) txtStore.Invoke(new MethodInvoker(delegate { txtStore.Text = Info.store.ToString(); }));
                    else txtStore.Text = Info.store.ToString();
                }
                System.Threading.Thread.Sleep(1000);
            }
            e.Result = 0;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtStore.Text = Info.store.ToString();
            ClearInfo();
            UpdateInfo();
        }


        #endregion


        // Test methods
        private void Test()
        {
            //foreach (TextBox tb in Retail_HD.RetailHD.ActiveForm.Controls.OfType<TextBox>())
            //{
            //    Console.WriteLine(tb.Name);
            //}
            Forms.StoreInfoAddEdit storeInfoAddEdit = new Forms.StoreInfoAddEdit();
            storeInfoAddEdit.Show();
        }


    }

    public class WrapUpInvokeEventArgs : EventArgs
    {
        public bool isAutoInvoke { get; private set; }

        public WrapUpInvokeEventArgs(bool autoInvoke)
        {
            isAutoInvoke = autoInvoke;
        }
    }
}
;