using System;

namespace CiscoFinesseNET
{
	public class ConfigurationNotCompletedException : Exception
    {
        public ConfigurationNotCompletedException(): base()
        {
        }

        public ConfigurationNotCompletedException(string message)
            : base(message)
        {
        }
    }

    public class UpdatedInformationEventArgs : EventArgs
    {
        public UpdateType updateType { get; private set; }

        public UpdatedInformationEventArgs(UpdateType _updateType)
        {
            updateType = _updateType;
        }
    }

    public enum UpdateType
    {
        User,
        Dialog,
        Other,
        Failure,
        Transfer
    }

    public static class Helper
    {
        //events
        public delegate void UpdatedInformationHandler(object sender, UpdatedInformationEventArgs e);
        public static event UpdatedInformationHandler OnUpdatedInformation;

        //private variables
        private static User curUser = new User();
        private const string loginXML = "<User><state>LOGIN</state><extension>{0}</extension></User>";
        private const string changeUserStateXML = "<User><state>{0}</state></User>";
        private const string changeUserStateWithReasonXML = "<User><state>{0}</state><reasonCodeId>{1}</reasonCodeId></User>"; //required for global hd not ready and log out
        private const string makeCallXML = "<Dialog><requestedAction>MAKE_CALL</requestedAction><fromAddress>{0}</fromAddress><toAddress>{1}</toAddress></Dialog>";
        private const string modifyCallVariables = "<Dialog> <requestedAction>UPDATE_CALL_DATA</requestedAction> <mediaProperties>   <wrapUpReason>{0}</wrapUpReason> </mediaProperties></Dialog>";
        public static User loggedInUser = null;
        private static XMPPHandler _xmpp = new XMPPHandler();

        //GLOBAL HD ONLY: set to NULL by default, these must be set by an Init call
        public static ReasonCodes NotReadyReasonCodes = null;
        public static ReasonCodes LogOutReasonCodes = null;
        public static WrapUpReasons WrapUpCodes = null;
        public static DialogsDialog currentDialog = null;

        //public methods
        /// <summary>
        /// Checks if Configuration has been run already.
        /// </summary>
        /// <returns>Pass/Fail for loading settings.</returns>
        public static bool CheckConfiguration()
        {
            if (Init.mainSettings != null && Init.mainSettings.GetSaveLocation(false) != string.Empty)
            {
                if (System.IO.Directory.Exists(Init.mainSettings.GetSaveLocation(false)) && System.IO.File.Exists(Init.mainSettings.GetSaveLocation(true)))
                {
                    return Init.LoadSettings();
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Configures the main settings so the API can connect and work.
        /// </summary>
        /// <param name="saveLocation">Location (Excact or relative) to save the settings file.</param>
        /// <param name="FQDN">Hostname for the Finesse server, do not include https://</param>
        /// <param name="port">Port used for connection, or 0 if not used.</param>
        /// <param name="useHTTPS"></param>
        /// <returns></returns>
        public static bool RunConfiguration(string saveLocation, string FQDN, int port, bool useHTTPS)
        {
            try
            {
                Settings main = new Settings();
                main.FQDN = FQDN;
                main.port = port;
                main.useHTTPS = useHTTPS;
                main.SetSaveLocation(saveLocation);

                Init.mainSettings = main;
            }
            catch (Exception)
            {
                return false;
            }
            return Init.SaveSettings();
        }

        /// <summary>
        /// This checks if a user's information is stored in the settings object already.
        /// </summary>
        /// <returns>Pass/Fail for finding user credentials.</returns>
        public static bool IsUserInfoCaptured()
        {
            if (Init.mainSettings != null)
            {
                if (Init.mainSettings.userName == string.Empty)
                {
                    return false;
                }
                else return true;
            }
            else
            {
                Init.mainSettings = new Settings();
                return false;
            }
        }

        public static bool RunInit()
        {
            try
            {
                Init.LoadSettings();
                //log user in
            }
            catch (ConfigurationNotCompletedException)
            {
                //rethrow exception here so user code catches it
                throw new ConfigurationNotCompletedException("Configuration should be completed before running initialization!");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static UserState LoginUser()
        {
            //all this does is log in the user
            string login = string.Format(loginXML, Init.mainSettings.ACD);

            string retval = Init.PerformAPIOperation(HTTPOperation.PUT, "User/" + Init.mainSettings.userName, login, Init.mainSettings.loginString);
            if (retval.ToLower().Contains("<!-- custom cisco error page -->")) return UserState.UNKNOWN;
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
            DeserializeUser(GetUserData());

            return loggedInUser.state;
        }

        public static UserState LoginUser(string user, string pass, string acd)
        {
            //save user settings for login
            Init.mainSettings.ACD = acd;
            Init.mainSettings.userName = user;
            Init.mainSettings.password = pass;
            Init.SaveSettings();

            //all this does is log in the user
            string login = string.Format(loginXML, Init.mainSettings.ACD);

            string retval = Init.PerformAPIOperation(HTTPOperation.PUT, "User/" + Init.mainSettings.userName, login, Init.mainSettings.loginString);
            if (retval.ToLower().Contains("<!-- custom cisco error page -->")) return UserState.UNKNOWN;

            System.Xml.Serialization.XmlSerializer _s = new System.Xml.Serialization.XmlSerializer(typeof(User));
            User _u = new User();
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
            using (System.IO.TextReader _tr = new System.IO.StringReader(GetUserData()))
            {
                _u = _s.Deserialize(_tr) as User;
            }

            loggedInUser = _u;

            return loggedInUser.state;
        }

        /// <summary>
        /// Changes user state without a reason code.
        /// </summary>
        /// <param name="newState">State to change to</param>
        /// <returns>Success</returns>
        public static bool ChangeUserState(UserState newState)
        {
            Init.PerformAPIOperation(HTTPOperation.PUT, "User/" + Init.mainSettings.userName, string.Format(changeUserStateXML, newState.ToString()), Init.mainSettings.loginString);
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 2)); //block execution for 2 seconds to give the server time to update, this reduces errors
            System.Xml.Serialization.XmlSerializer _s = new System.Xml.Serialization.XmlSerializer(typeof(User));
            User _u = new User();
            using (System.IO.TextReader _tr = new System.IO.StringReader(GetUserData()))
            {
                _u = _s.Deserialize(_tr) as User;
            }

            if (_u.state == newState)
            {
                loggedInUser = _u;
                GetDialogs();
                GetQueues();
                return true;
            }
            else return false;
        }

        public static bool UpdateWrapUpReason(WrapUpReason reason, DialogsDialog _curDialog)
        {
            try
            {
                //update call data with wrap up reason
                Init.PerformAPIOperation(HTTPOperation.PUT, "Dialog/" + _curDialog.id, string.Format(modifyCallVariables, reason.label), Init.mainSettings.loginString);
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));

                //set user to ready
                ChangeUserState(UserState.READY);
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Uses a reason code to change the users status.
        /// </summary>
        /// <param name="newState">State to change to</param>
        /// <param name="reasonCode">ID of reason code to use</param>
        /// <returns>Success</returns>
        public static bool ChangeUserState(UserState newState, ReasonCode reasonCode)
        {
            int test = 0;
            string[] test1 = reasonCode.uri.Split('/');
            int.TryParse(test1[test1.Length - 1], out test);

            Init.PerformAPIOperation(HTTPOperation.PUT, "User/" + Init.mainSettings.userName, string.Format(changeUserStateWithReasonXML, newState.ToString(), test), Init.mainSettings.loginString);
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 2)); //reduces errors
            System.Xml.Serialization.XmlSerializer _s = new System.Xml.Serialization.XmlSerializer(typeof(User));
            User _u = new User();

            using (System.IO.TextReader _tr = new System.IO.StringReader(GetUserData()))
            {
                _u = _s.Deserialize(_tr) as User;
            }

            if (_u.state == newState)
            {
                loggedInUser = _u;
                GetDialogs();
                GetQueues();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Updates the call dialog with the wrap up reason.
        /// </summary>
        /// <param name="_reason">WrapUp Reason to push</param>
        /// <returns>Success</returns>
        public static bool UpdateDialog(WrapUpReason _reason)
        {
            //get the current dialog, and set the wrap up reason, then push to finesse
            if (currentDialog != null)
            {
                currentDialog.mediaProperties.wrapUpReason = _reason.label;
                //push new dialog object back to finesse
                System.Xml.Serialization.XmlSerializer _s = new System.Xml.Serialization.XmlSerializer(typeof(DialogsDialog));
                string xml2Send = string.Empty;
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    _s.Serialize(sw, currentDialog);
                    xml2Send = sw.ToString();
                }
                Init.PerformAPIOperation(HTTPOperation.PUT, "Dialog/" + currentDialog.id, xml2Send, Init.mainSettings.loginString);
                return true;
            }
            else return false;
        }

        public static bool ChangeOtherUserState(UserState newState, string userID)
        {
            System.Net.HttpWebResponse response;
            Init.PerformAPIOperation(HTTPOperation.PUT, "User/" + userID, string.Format(changeUserStateXML, newState.ToString()), out response, Init.mainSettings.loginString);

            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool RefreshUserData()
        {
            DeserializeUser(GetUserData());
            UpdateInformation(UpdateType.User);
            
            if (loggedInUser != null) return true;
            else return false;
            
        }

        public static string GetUserData()
        {
            return Init.PerformAPIOperation(HTTPOperation.GET, "User/" + Init.mainSettings.userName, "", Init.mainSettings.loginString);
        }

        public static bool GetDialogs()
        {
            if (loggedInUser != null)
            {
                try
                {
                    Dialogs _retVal = new Dialogs();
                    string _str = Init.PerformAPIOperation(HTTPOperation.GET, loggedInUser.dialogs, "", Init.mainSettings.loginString);
                    System.Xml.Serialization.XmlSerializer _serial = new System.Xml.Serialization.XmlSerializer(typeof(Dialogs));

                    if (!_str.ToLower().Contains("<dialogs>"))
                    {
                        _str = "<Dialogs>" + _str + "</Dialogs>";
                    }

                    using (System.IO.TextReader _tr = new System.IO.StringReader(_str))
                    {
                        _retVal = _serial.Deserialize(_tr) as Dialogs;
                    }

                    loggedInUser._dialogList = _retVal;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;
        }

        public static bool MakeCall(string _to)
        {
            if (loggedInUser != null)
            {
                Init.PerformAPIOperation(HTTPOperation.POST, string.Format("User/{0}/Dialogs", loggedInUser.loginId), string.Format(makeCallXML, loggedInUser.extension, _to), Init.mainSettings.loginString);
                return true;
            }
            else return false;
        }

        public static Queues GetQueues()
        {
            Queues _q = new Queues();
            string _response = Init.PerformAPIOperation(HTTPOperation.GET, string.Format("User/{0}/Queues", loggedInUser.loginId), "", Init.mainSettings.loginString);
            System.Xml.Serialization.XmlSerializer _serial = new System.Xml.Serialization.XmlSerializer(typeof(Queues));

            if (!_response.ToLower().Contains("<queues>"))
            {
                _response = "<Queues>" + _response + "</Queues>";
            }

            using (System.IO.TextReader _tr = new System.IO.StringReader(_response))
            {
                _q = _serial.Deserialize(_tr) as Queues;
            }

            return _q;
        }

        public static bool ConnectXMPP()
        {
            try
            {
                _xmpp.Connect(Init.mainSettings);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool DisconnectXMPP()
        {
            try
            {
                _xmpp.CloseSession();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void InvalidateSettings()
        {
            Init.mainSettings = null;
        }

        internal static void UpdateObjects(string message)
        {
            string _final = string.Empty;
            int startIndex = 0;
            int endIndex = 0;
            //figure out what kind of object this is
            if (message.ToLower().Contains("<user>")) //user object
            {
                //trim everything before the user object and after it
                startIndex = message.ToLower().IndexOf("<user>");
                endIndex = message.ToLower().IndexOf("</data>");
                _final = message.Substring(startIndex, (endIndex - startIndex));
                _final = _final.Replace("<user>", "<User>");
                _final = _final.Replace("</user>", "</User>");

                //deserialize the user object like normal now
                DeserializeUser(_final);

                //push updated event so that main code can see the update
                UpdateInformation(UpdateType.User);
            }
            else if (message.ToLower().Contains("<dialog>")) //dialog object
            {
                startIndex = message.ToLower().IndexOf("<dialogs>");
                if (startIndex < 0) startIndex = message.ToLower().IndexOf("<dialog>");
                endIndex = message.ToLower().IndexOf("</data>");
                _final = message.Substring(startIndex, (endIndex - startIndex));
                _final = _final.Replace("<dialogs>", "<Dialogs>");
                _final = _final.Replace("</dialogs>", "</Dialogs>");

                if (_final.ToLower().Contains("<calltype>transfer</calltype>"))
                {
                    //transfer detected... let's not try to deserialize because it's still f***ing buggy
                    UpdateInformation(UpdateType.Transfer);
                    return;
                }

                DeserializeDialogs(_final);

                UpdateInformation(UpdateType.Dialog);
            }
            else //should be a keep-alive message then...
            {
                UpdateInformation(UpdateType.Other);
            }
        }

        private static void UpdateInformation(UpdateType _type)
        {
            if (OnUpdatedInformation == null) return;

            UpdatedInformationEventArgs args = new UpdatedInformationEventArgs(_type);
            OnUpdatedInformation(null, args);
        }

        private static bool DeserializeDialogs(string _data)
        {
            try
            {
                Dialogs _retVal = new Dialogs();
                System.Xml.Serialization.XmlSerializer _serial = new System.Xml.Serialization.XmlSerializer(typeof(Dialogs));

                if (!_data.ToLower().Contains("<dialogs>"))
                {
                    _data = "<Dialogs>" + _data + "</Dialogs>";
                }

                using (System.IO.TextReader _tr = new System.IO.StringReader(_data))
                {
                    _retVal = _serial.Deserialize(_tr) as Dialogs;
                }

                loggedInUser._dialogList = _retVal;
                currentDialog = _retVal.Dialog[0]; //first dialog is always the current dialog
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool DeserializeUser(string _data)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer _serial = new System.Xml.Serialization.XmlSerializer(typeof(User));
                User _u = new User();

                using (System.IO.TextReader _tr = new System.IO.StringReader(_data))
                {
                    _u = _serial.Deserialize(_tr) as User;
                }

                loggedInUser = _u;

                GetDialogs();
                GetQueues();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
