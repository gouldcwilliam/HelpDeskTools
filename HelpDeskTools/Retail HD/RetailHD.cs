using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using CiscoFinesseNET;
using HDSharedServices;
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
                if (value.Length > 4) //it's not a store number
                {
                    if (Functions.isNumeric(value) && value.Length == 10)
                    {
                        //if a phone number was passed as the value
                        string name = GlobalFunctions.s_LookupPhoneNumber(value);
                        if (name == string.Empty)
                        {
                            _curNum = string.Format("{0:(###)###-####}", Convert.ToInt64(value));
                        }
                        else
                        {
                            _curNum = name;
                        }
                        
                    }
                    else
                    {
                        //if name was looked up and passed as the value or is non looked up extension
                        _curNum = string.Format("{0}", value);
                    }
                }
                else _curNum = string.Format("Store {0}", value);
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
		bool hasRun = false;

		private List<Computer> _computers
		{
			get
			{
				List<Computer> retList = Info.computers.FindAll(x => x.selected == true);
				if (retList.Count < 1)
				{
					if (Info.computers.Count == 1) { return Info.computers; }
					Forms.Confirm confirm = new Forms.Confirm("Perform on all computers?", "No computers selected", true);
					if (confirm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { return Info.computers; }
					return new List<Computer>();
				}
				else { return retList; }
			}
		}

		HDSharedServices.Forms.frmAgentStatus agentStatus = new HDSharedServices.Forms.frmAgentStatus();

		Forms.ReportIssue ReportIssue = new Forms.ReportIssue();
		Forms.WrapUp wrapUp = new Forms.WrapUp();
		Forms.Confirm nagger = new Forms.Confirm("You are in work, change to READY?", "Change Status?");
		Forms.UsefulInfo UsefulInfo = new Forms.UsefulInfo();
		Forms.StoreSearch StoreSearch = new Forms.StoreSearch();
		Forms.ListActions ListAction = new Forms.ListActions();
		Forms.HistorySearch HistorySearch = new Forms.HistorySearch();
		Forms.EditSettings EditSettings = new Forms.EditSettings();
		Forms.AddNewStore AddNewStore = new Forms.AddNewStore();

		#endregion


		/// <summary> The main form
		/// </summary>
		public RetailHD()
		{
			InitializeComponent();
			Initialize_Buttons_ToolTips();

			PingUC.btnOK.Click += Ping_OK_Click;
			ServicesUC.btnOK.Click += Services_OK_Click;

			GlobalFunctions.v_InstallPsTools();
			GlobalFunctions.v_Install_DelayedStartServices();
			GlobalFunctions.v_CreateTempFolder();

			//phone stuff
			Helper.OnUpdatedInformation += Helper_OnUpdatedInformation;

			_t.Interval = 1000; //1 second between manual refreshes, this is in case the XMPP isn't returned as expected
			_t.Tick += _t_Tick;


			// Prompts for Finesse login
			string msg="Would you like to log into the Cisco Finesse Server?";
			Forms.Confirm ConfirmAgentLogin = new Forms.Confirm(msg);
			ConfirmAgentLogin.TopMost = true;
			ConfirmAgentLogin.btnOK.Text = "Yes"; 
			ConfirmAgentLogin.btnCancel.Text = "No";
			if( DialogResult.OK == ConfirmAgentLogin.ShowDialog())
			{
				_AgentLoginEnabled = true;
				v_CheckLoginConfig();
			}
			else
			{
				_AgentLoginEnabled = false;
				ts_Top_tsb_Logout.Enabled = false;
				ts_Top_tsb_ChangeState.Enabled = false;
				ts_Top_tsb_CallStore.Enabled = false;
				ts_Top_tsb_TeamStatus.Enabled = false;
			}
			DataTable dt = SQL.Select("SELECT [version] from [Versions]");
		}


		//
		#region HANDLER INITIALIZATIONS


		private void Initialize_Buttons_ToolTips()
		{
			tt_Main.SetToolTip(PCAnywhere, "Remotely connect using PCAnyWhere\nPress F1");
			tt_Main.SetToolTip(Unlock, "Connects to and runs POS SQL unlock for the Cashier Number entered\nPress F2");
			tt_Main.SetToolTip(Browse, "Opens C:\\ in Windows Explorer to browse files remotely\nPress F3");
			tt_Main.SetToolTip(RemoteCMD, "Remotely connect with CMD window, nice when a simple command may fix issue\nPress F4");
			tt_Main.SetToolTip(LocalCMD, "Open local CMD window on selected machines, very useful while remotely connected\nPress F5");
			tt_Main.SetToolTip(CrashingFix, "Opens a dialog to perform actions on multiple store computers\nPress F6");
			tt_Main.SetToolTip(KillPOS, "Quickly closes POS software rather than talking caller through taskmanager\nPress F7");
			tt_Main.SetToolTip(Services, "Shows a submenu with actions regarding POS services\nPress F8");
			tt_Main.SetToolTip(Ping, "Submenu for pinging common store network devices\nPress F9");
			tt_Main.SetToolTip(WrapUp, "Form to be used after each call for capturing Store Number, Issue, Time, etc.\nPress F10");
			tt_Main.SetToolTip(Restart, "Forces the computer to restart\nPress F11");
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
				HDSharedServices.Forms.frmCiscoLogin loginForm = new HDSharedServices.Forms.frmCiscoLogin();
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
				else Application.Exit(); //user must be logged in
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
			SQL.b_UpdateAgentInformation(System.Environment.UserName, curState.ToString(), "");
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
                            if (!HDSharedServices.Settings.Default._EnableAutoReady && !ts_Top_tsl_Override.Visible)
                            {
                                ts_Top_tsl_Override.Visible = true;
                            }
                            else if (HDSharedServices.Settings.Default._EnableAutoReady && ts_Top_tsl_Override.Visible)
                            {
                                ts_Top_tsl_Override.Visible = false;
                            }

                            if (ts_Top_tsl_CurrentCall.Visible)
                            {
                                if (ts_Top_tsl_CurrentCall.ForeColor == SystemColors.HotTrack) ts_Top_tsl_CurrentCall.ForeColor = Color.Red;
                                else ts_Top_tsl_CurrentCall.ForeColor = SystemColors.HotTrack;
                            }

                            if (ts_Top_tsl_Override.Visible)
                            {
                                if (ts_Top_tsl_Override.ForeColor == Color.Red) ts_Top_tsl_Override.ForeColor = Color.Purple;
                                else ts_Top_tsl_Override.ForeColor = Color.Red;
                            }
                        }));
                }
                else
                {
                    if (!HDSharedServices.Settings.Default._EnableAutoReady && !ts_Top_tsl_Override.Visible)
                    {
                        ts_Top_tsl_Override.Visible = true;
                    }
                    else if (HDSharedServices.Settings.Default._EnableAutoReady && ts_Top_tsl_Override.Visible)
                    {
                        ts_Top_tsl_Override.Visible = false;
                    }

                    if (ts_Top_tsl_CurrentCall.Visible)
                    {
                        if (ts_Top_tsl_CurrentCall.ForeColor == SystemColors.HotTrack) ts_Top_tsl_CurrentCall.ForeColor = Color.Red;
                        else ts_Top_tsl_CurrentCall.ForeColor = SystemColors.HotTrack;
                    }

                    if (ts_Top_tsl_Override.Visible)
                    {
                        if (ts_Top_tsl_Override.ForeColor == Color.Red) ts_Top_tsl_Override.ForeColor = Color.Purple;
                        else ts_Top_tsl_Override.ForeColor = Color.Red;
                    }
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
                            SQL.b_UpdateAgentInformation(System.Environment.UserName, curState.ToString(), (useStoreInformation) ? currentStoreNumber : "");
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
                    SQL.b_UpdateAgentInformation(System.Environment.UserName, curState.ToString(), (useStoreInformation) ? string.Format("Store {0}", txtStore.Text) : "", CiscoFinesseNET.Helper.loggedInUser.extension);
                }
            }
        }

		// change the state change tool strip button's icon based on current state
        private UserState SetAvailableState(UserState availableState)
        {
            switch (availableState)
            {
                case UserState.READY:
                    if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_ChangeState.Image = GlobalResources.icon_play; }));
                    else ts_Top_tsb_ChangeState.Image = GlobalResources.icon_play;
                    break;
                case UserState.NOT_READY:
                    if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_ChangeState.Image = GlobalResources.icon_stop; }));
                    else ts_Top_tsb_ChangeState.Image = GlobalResources.icon_stop;
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

                    System.Data.DataTable _dt = SQL.dt_SelectStoreByPhone(number2Search);

                    foreach (System.Data.DataRow _r in _dt.Rows)
                    {
                        //shouldn't be more than 1 here
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
		private void Buttons_PCAnywhere_Click(object sender, EventArgs e)
		{
			PingUC.Visible = false; ServicesUC.Visible = false;
			if (Info.reg1 == string.Empty) { return; }
			GlobalFunctions.v_ConnectWithAltiris(_computers);
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
				Forms.Unlock UnlockCashier = new Forms.Unlock(Info.reg1, Info.cashier);
				UnlockCashier.Show();
			}
		}

		/// <summary> Browse c: drive of selected retList
		/// </summary>
		private void Buttons_Browse_Click(object sender, EventArgs e)
		{
			PingUC.Visible = false; ServicesUC.Visible = false;
			GlobalFunctions.v_BrowseComputer(_computers);
		}
		/// <summary> Opens remote cmd prompt on your local machine
		/// </summary>
		private void Buttons_RemoteCMD_Click(object sender, EventArgs e)
		{
			PingUC.Visible = false; ServicesUC.Visible = false;
			GlobalFunctions.v_RemoteCMD(_computers);
		}
		/// <summary> Opens local admin cmd prompt on remote machine
		/// </summary>
		private void Buttons_LocalCMD_Click(object sender, EventArgs e)
		{
			PingUC.Visible = false; ServicesUC.Visible = false;
			GlobalFunctions.v_LocalCMD(_computers);
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
				Forms.bwKillPOS kill = new Forms.bwKillPOS(_computers);
				kill.Show();
			}
		}
		/// <summary> shows the user control menu for services
		/// </summary>
		private void Buttons_Services_Click(object sender, EventArgs e)
		{
			PingUC.Visible = false;
			PingUC.Visible = false;

			if (ServicesUC.Visible)
			{
				ServicesUC.Visible = false;
			}
			else
			{
				ServicesUC.Focus();
				ServicesUC.Visible = true;
			}
		}
		/// <summary> shows the user control menu for ping
		/// </summary>
		private void Buttons_Ping_Click(object sender, EventArgs e)
		{
			ServicesUC.Visible = false;

			if (PingUC.Visible)
			{
				PingUC.Visible = false;
				
			}
			else
			{
				PingUC.Focus();
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
                if (HDSharedServices.Settings.Default._EnableAutoReady && curState == UserState.WORK)
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
                if (!HDSharedServices.Functions.isTxtBoxNumeric(txtStore)) { return; }

                wrapUp = new Forms.WrapUp();
                Point startLocation = new Point(this.Location.X + (this.Width / 3), this.Location.Y + (this.Height / 2));
                wrapUp.Location = startLocation;

                if (wrapUp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
					// only change to ready, if the user was in work (meaning normal call flow). 
					// A dialed number will make you not ready, and then auto ready on the server-side if you were ready before
                    if (HDSharedServices.Settings.Default._EnableAutoReady && curState == UserState.WORK)
                    {
                        hasCallWrappedUp = false;
                        Helper.ChangeUserState(UserState.READY);
                        StupidOverrideForChad();
                    }
                }
                //else if ((curState != UserState.READY) && (curState != UserState.NOT_READY))
                else if ((curState != UserState.READY && curState != UserState.NOT_READY))
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
                    UpdateInfo();
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
                if(curState == UserState.RESERVED || curState==UserState.TALKING || curState== UserState.WORK) hasCallWrappedUp = true;

                ClearInfo();
                UpdateInfo();
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
				Forms.Restart restart = new Forms.Restart(_computers);
				restart.Show();
			}
		}
		/// <summary> runs the delayed SQL start
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Buttons_Delayed_Click(object sender, EventArgs e)
		{
			if (Info.computers.Count() > 0)
			{
				GlobalFunctions.i_ExecuteCommand("DelayedStartServices.exe", true, Info.reg1, "Delayed Services on " + Info.reg1, false);
			}
		}
		/// <summary> ping menu actions
		/// </summary>
		private void Ping_OK_Click(object sender, EventArgs e)
		{
			PingUC.Visible = false;
		}
		/// <summary> service menu actions
		/// </summary>
		private void Services_OK_Click(object sender, EventArgs e)
		{
			string service = string.Empty;
			string action = string.Empty;
			foreach (RadioButton rb in ServicesUC.gbServices.Controls.OfType<RadioButton>())
			{
				if (rb.Checked) { service = rb.Tag.ToString(); }
			}
			foreach (RadioButton rb in ServicesUC.gbAction.Controls.OfType<RadioButton>())
			{
				if (rb.Checked) { action = rb.Tag.ToString(); }
			}
			if (action == string.Empty || service == string.Empty) { ServicesUC.Visible = false; return; }
			
			ServicesUC.Visible = false;

			if (!GlobalFunctions.b_WriteBatFile(GlobalResources.batServices)) { return; }

			foreach (Computer computer in Info.computers.FindAll(x => x.selected == true))
			{
				if (!GlobalFunctions.b_CopyBatFile(computer.name)) { return; }

				string args = string.Format("-r:{0} {1} {2}", computer.name, HDSharedServices.Settings.Default._TempFile, action + " " + service);
				//Console.WriteLine(args);
				GlobalFunctions.i_ExecuteCommand("WINRS", true, args, false);
			}

		}




		#endregion



		//
		#region RECENT CALLS DATA GRID - call history methods/handlers

		private void RecentCalls_MouseDoubleClick(object sender, MouseEventArgs e)
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

				Forms.EditCalls editCalls = new Forms.EditCalls(id, store, date, tech, category, topic, details, type, trax, url);
				editCalls.ShowDialog();
				UpdateInfo();
			}
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
				}
			}

		}

		#endregion



		// 
		#region STORE INFORMATION - store's information methods/handlers

		// Mouse Click

		private void txtStore_MouseClick(object sender, MouseEventArgs e)
		{
			txtStore.SelectAll();
		}

		private void txtPhone_MouseClick(object sender, MouseEventArgs e)
		{
			txtPhone.SelectAll();
		}

		private void txtManager_MouseClick(object sender, MouseEventArgs e)
		{
			txtManager.SelectAll();
		}

		private void txtMpId_MouseClick(object sender, MouseEventArgs e)
		{
			txtMpId.SelectAll();
		}

		private void txtAddress_MouseClick(object sender, MouseEventArgs e)
		{
			txtAddress.SelectAll();
		}

		private void txtEmail_MouseClick(object sender, MouseEventArgs e)
		{
			txtEmail.SelectAll();
		}

		private void txtIP_MouseClick(object sender, MouseEventArgs e)
		{
			txtIP.SelectAll();
		}

		private void txtCity_MouseClick(object sender, MouseEventArgs e)
		{
			txtCity.SelectAll();
		}

		private void txtDM_MouseClick(object sender, MouseEventArgs e)
		{
			txtDM.SelectAll();
		}

		private void txtName_MouseClick(object sender, MouseEventArgs e)
		{
			txtName.SelectAll();
		}

		private void txtType_MouseClick(object sender, MouseEventArgs e)
		{
			txtType.SelectAll();
		}

		private void txtState_MouseClick(object sender, MouseEventArgs e)
		{
			txtState.SelectAll();
		}

		private void txtZip_MouseClick(object sender, MouseEventArgs e)
		{
			txtZip.SelectAll();
		}

		private void txtTZ_MouseClick(object sender, MouseEventArgs e)
		{
			txtTZ.SelectAll();
		}

		private void txtBAMS_MouseClick(object sender, MouseEventArgs e)
		{
			txtBAMS.SelectAll();
		}

		private void txtSVS_MouseClick(object sender, MouseEventArgs e)
		{
			txtSVS.SelectAll();
		}

		private void txtTID1_MouseClick(object sender, MouseEventArgs e)
		{
			txtTID1.SelectAll();
		}

		private void txtTID2_MouseClick(object sender, MouseEventArgs e)
		{
			txtTID2.SelectAll();
		}

		private void txtTID3_MouseClick(object sender, MouseEventArgs e)
		{
			txtTID3.SelectAll();
		}

		private void txtTID4_MouseClick(object sender, MouseEventArgs e)
		{
			txtTID4.SelectAll();
		}

		// Mouse double clicks
		private void storeInfo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (Info.infoFilled)
			{
				Forms.EditStoreInfo editStoreInfo = new Forms.EditStoreInfo();
				editStoreInfo.ShowDialog();
			}
			else
			{
				Forms.AddNewStore addStore = new Forms.AddNewStore(Info.store.ToString());
				addStore.ShowDialog();
			}
			UpdateInfo();
		}

		// handles when store number Text box Text has changed
		private void txtStore_TextChanged(object sender, EventArgs e)
		{
			Info.Clear();
			int store;
			
			if (txtStore.Text.Length > 2 && txtStore.Text.Length < 5
				&& HDSharedServices.Functions.isTxtBoxNumeric(txtStore, out store))
			{
				if (store != Info.store) { Info.store = store; }
				UpdateInfo();
			}
			else
			{
				Info.store = 9999;
				ClearInfo();
			}

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
			startInfo.FileName = HDSharedServices.Settings.Default._OldMenuPath;
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = true;
			System.Diagnostics.Process process = System.Diagnostics.Process.Start(startInfo);
			//process.WaitForExit();
		}

		// Opens Konami code entry form
		private void CodeEntry_Click(object sender, EventArgs e)
		{
			frmCodeEntry codeEntryForm = new frmCodeEntry();
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
			GlobalFunctions.v_UpdateComputersFromAD();
		}

		// open form for new store entry
		private void AddStore_Click(object sender, EventArgs e)
		{
			if (AddNewStore.Visible) { AddNewStore.BringToFront(); return; }
			AddNewStore = new Forms.AddNewStore();
			AddNewStore.Show();
			UpdateInfo();
		}

		// Runs the tool updater program
		private void UpdateThisTool_Click(object sender, EventArgs e)
		{
			GlobalFunctions.i_ExecuteCommand(@"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\UpdateRHDMenu\UpdateRHDMenu.exe", false, "restart", false);
		}


		#endregion



		//
		#region TOOL STRIP TOP - tool strip methods


		// changes the queue state
		private void ChangeState_Click(object sender, EventArgs e)
		{
			if (!_AgentLoginEnabled) { return; }

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
				if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_Logout.Image = GlobalResources.login; }));
				else ts_Top_tsb_Logout.Image = GlobalResources.login;
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

				if (ts_Top.InvokeRequired) ts_Top.Invoke(new MethodInvoker(delegate { ts_Top_tsb_Logout.Image = GlobalResources.logout; }));
				else ts_Top_tsb_Logout.Image = GlobalResources.logout;

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
			if (!agentStatus.Visible && _AgentLoginEnabled)
			{
				agentStatus = new HDSharedServices.Forms.frmAgentStatus();
				agentStatus.Show();
			}
			else
			{ agentStatus.BringToFront(); }
		}

		// call the current store
		private void CallStore_Click(object sender, EventArgs e)
		{
			if (!_AgentLoginEnabled) { return; }

			if (txtPhone.Text != "(555) 555-5555" && txtPhone.Text != string.Empty && txtPhone.Text.Length > 6 && (curState == UserState.READY || curState == UserState.WORK || curState == UserState.HOLD || curState == UserState.NOT_READY))
			{
				//we can make da call
				string number2call = string.Empty;
				char[] _tmp = txtPhone.Text.ToCharArray();

				foreach (char _c in _tmp) //get rid of dashes, slashes, and periods and other junk
				{
					if (HDSharedServices.Functions.isNumeric(_c)) number2call += _c.ToString();
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
		


		#endregion



		// 
		#region MAIN FORM EVENTS - methods/handlers for whole form

		/// <summary> key press event handlers for all objects in frmMain
		/// </summary>
		private void Main_keyDown(object sender, KeyEventArgs e)
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
                if (!Functions.isNumeric(keyVal) && !breakIf)
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
					ClearInfo();
					Info.Clear();
					ServicesUC.Visible = false;
					PingUC.Visible = false;
					break;
				case Keys.Home:
					txtStore.Focus();
					ServicesUC.Visible = false;
					PingUC.Visible = false;
					break;
				case Keys.F1:
					Buttons_PCAnywhere_Click(sender, null);
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
				case Keys.D:
                    if (e.Modifiers == Keys.Control) { ts_Top_tsb_CallStore.PerformClick(); }
					break;
                case Keys.E:
                    break;
				case Keys.F:
					if (PingUC.Visible)
					{
						PingUC.ckbFortinet.Checked = (!PingUC.ckbFortinet.Checked);
					}
					break;
				case Keys.M:
					if (PingUC.Visible)
					{
						PingUC.ckbMim.Checked = (!PingUC.ckbMim.Checked);
					}
					break;
				case Keys.R:
					if (e.Modifiers == Keys.Control) { UpdateInfo(); }
					else if(PingUC.Visible)
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
					if (PingUC.Visible)
					{
						PingUC.btnOK.PerformClick();
					}
					break;
				case Keys.C:
					if(e.Modifiers == Keys.Control && clbComputers.Focused)
					{
						Clipboard.SetText(clbComputers.SelectedItem.ToString());
					}
					break;
				case Keys.L:
					if (e.Modifiers == Keys.Control) { ts_Top_tsb_Logout.PerformClick(); }
					break;
				default:
					break;
			}
		}

		/// <summary> Method when the form is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
				Helper.DisconnectXMPP();

				if (curState != UserState.NOT_READY)
				{
					Helper.ChangeUserState(UserState.NOT_READY);
					SQL.b_UpdateAgentInformation(System.Environment.UserName, UserState.NOT_READY.ToString(), "");
					System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
				}
				Helper.ChangeUserState(UserState.LOGOUT);
				SQL.b_UpdateAgentInformation(System.Environment.UserName, UserState.LOGOUT.ToString(), "");
			}
			//if log file is larger than 500kb, email it in
			//call up the log sender app and close this

			// Save Settings
			HDSharedServices.Settings.Default._DrawingLocation = Location;
			if (WindowState == FormWindowState.Normal)
			{
				HDSharedServices.Settings.Default._DrawingSize = Size;
			}
			else
			{
				HDSharedServices.Settings.Default._DrawingSize = RestoreBounds.Size;
			}
			HDSharedServices.Settings.Default.Save();
		}

		/// <summary> Methods when the main form is shown
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_FormShown(object sender, EventArgs e)
		{
			UpdateWrapUpTotal();
			if (HDSharedServices.Settings.Default._DrawingSize != null)
			{
				Size = HDSharedServices.Settings.Default._DrawingSize;
			}

		}

		/// <summary> Methods when the form is loaded
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_Load(object sender, EventArgs e)
		{
			//restore the position of the form
			if (!hasRun)
			{
				Location = HDSharedServices.Settings.Default._DrawingLocation;
				if (!isOnScreen(this))
				{
					//set the location to a default
					Location = new Point(200, 200);
				}

				hasRun = true;
			}
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
			txtBAMS.Text = string.Empty;
			txtSVS.Text = string.Empty;
			txtTID1.Text = string.Empty;
			txtTID2.Text = string.Empty;
			txtTID3.Text = string.Empty;
			txtTID4.Text = string.Empty;
			// Clear the computer list
			clbComputers.Items.Clear();
			// Clear the recent calls
			RecentCalls_dgv.DataBindings.Clear();
			// Clear the info container
			Info.computers.Clear();
		}


		// Update all the form information from the store information gathered from SQL
		private void UpdateInfo()
		{
			ClearInfo();
			// Fill the store information area
			if (GlobalFunctions.b_FillStoreInfo())
			{
				txtAddress.Text = Info.address;
				txtCity.Text = Info.city;
				txtDM.Text = Info.dm;
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
				else { txtRank.Text = Info.rank + "/" + Info.totalStores; }
				if (Info.phone != string.Empty)
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
			}
			// Fill the computer list
			if (GlobalFunctions.b_FillComputers())
			{
				foreach (Computer computer in Info.computers)
				{
				 	clbComputers.Items.Add(computer.name);
				}
			}
			// Fill the recent calls
			if (GlobalFunctions.b_FillRecentCalls())
			{
				RecentCalls_dgv.DataSource = Info.recentCalls;
				try
				{
					RecentCalls_dgv.Columns["ID"].Visible = false;
					RecentCalls_dgv.Columns["Store"].Visible = false;
					RecentCalls_dgv.Columns["Date"].FillWeight = 2;
					RecentCalls_dgv.Columns["Tech"].FillWeight = 2;
					RecentCalls_dgv.Columns["Category"].FillWeight = 3;
					RecentCalls_dgv.Columns["Topic"].FillWeight = 3;
					RecentCalls_dgv.Columns["Details"].FillWeight = 12;
					RecentCalls_dgv.Columns["In/Out"].FillWeight = 2;
					RecentCalls_dgv.Columns["Trax"].Visible = false;
					RecentCalls_dgv.Columns["URL"].Visible = false;
				}
				catch (Exception ex) { MessageBox.Show(ex.Message); }
			}
			// Call the method to update call totals
			UpdateWrapUpTotal();
		}


		// Update the team's and user's total calls
		private void UpdateWrapUpTotal()
		{
			try
			{
				DataRow dr = SQL.dt_CallCount_User().Rows[0];
				DataRow dr1 = SQL.dt_CallCount_Team().Rows[0];
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
		}


		// Methods when the services user control changes visibility
		private void Services_UC_VisibleChanged(object sender, EventArgs e)
		{
			ServicesUC.Clear();
		}


		#endregion


		//
		#region BACKGROUND WORKER


		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			if (txtStore.Text == string.Empty) {
				if (txtStore.InvokeRequired) txtStore.Invoke(new MethodInvoker(delegate { txtStore.Text = "9999"; }));
				else txtStore.Text = "9999";
			}
			if (Info.store == 0) { Info.store = 9999; }
			while (StoreSearch.Visible)
			{
				if(txtStore.Text != Info.store.ToString())
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
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
				Forms.ExcelLoadTables eSchemaInfo = new Forms.ExcelLoadTables(ofd.FileName);
				eSchemaInfo.Show();
			}
		}

		
	}
}
