using System;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CiscoFinesseNET
{
	public class Settings
    {
        public int port { get; set; }
        public string ACD { get; set; }
        public string userName { get; set; }
        public bool useHTTPS { get; set; }
        public string AppID { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        private string saveLocation = string.Empty;
        [System.Xml.Serialization.XmlIgnore]
        private RegistryKey _key = null;
        private void InitRegistry()
        {
            //try to load the value from the key, otherwise create the default
            try
            {
                _key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RetailHD\PhoneCisco", false);
                SetSaveLocation((string)_key.GetValue("SettingsSaveLocation", @"C:\FINESSE\"));
            }
            catch
            {
                //create new key
                if (_key != null)
                {
                    //subkey exists, but value doesn't
                    _key.SetValue("SettingsSaveLocation", @"C:\FINESSE\", RegistryValueKind.String);
                }
                else
                {
                    _key = Registry.CurrentUser;
                    _key.CreateSubKey(@"SOFTWARE\RetailHD\PhoneCisco");
                    _key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RetailHD\PhoneCisco", true);
                    _key.SetValue("SettingsSaveLocation", @"C:\FINESSE\");
                }
            }
        }

        //private void SaveSaveLocationRegistry()
        //{
        //    try
        //    {
        //        _key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RetailHD\PhoneCisco", false);
        //        _key.SetValue("SettingsSaveLocation", GetSaveLocation(false));
        //    }
        //    catch
        //    {
        //        //don't crash, but don't do anything either
        //    }
        //}
        //const string saveLocation = @"C:\FINESSE\";
        public string GetSaveLocation(bool withFilename) 
        {
            if (withFilename)
            {
                return string.Format("{0}main.{1}.settings", saveLocation, Environment.UserName);
            }
            else
            {
                if (saveLocation.Substring(saveLocation.Length - 2, 1) != "\\")
                {
                    return saveLocation + "\\";
                }
                else return saveLocation;
            }
        }
        public void SetSaveLocation(string loc)
        {
            saveLocation = loc;
            //SaveSaveLocationRegistry();
        }


        [System.Xml.Serialization.XmlIgnore]
        public string password { get; set; } //we don't want to serialize the password in clear text

        private string fqdn;
        public string FQDN 
        {
            get
            {
                if (port > 0) return string.Format("{0}:{1}", fqdn, port);
                else return fqdn;
            }
            set
            {
                if(value.Contains(':'))
                {
                    fqdn = value.Split(':')[0];
                }
                else fqdn = value;
            }
        }
        public string GetNakedFQDN() { return fqdn; }
        public string loginString 
        {
            get
            {
                byte[] toEncode = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password));
                return Convert.ToBase64String(toEncode);
            }
            set
            {
                byte[] tmp = Convert.FromBase64String(value);
                string decodedString = Encoding.UTF8.GetString(tmp);

                if (decodedString.Contains(':'))
                {
                    //userName = Split(':')[0];
                    userName = decodedString.Split(':')[0];
                    password = decodedString.Split(':')[1];
                }
                else
                {
                    userName = string.Empty;
                    password = string.Empty;
                }
            }
        }

        public Settings()
        {
            //default everything
            port = 0;
            ACD = string.Empty;
            userName = string.Empty;
            password = string.Empty;
            fqdn = string.Empty;
            useHTTPS = true;
            InitRegistry();
        }
    }
}
