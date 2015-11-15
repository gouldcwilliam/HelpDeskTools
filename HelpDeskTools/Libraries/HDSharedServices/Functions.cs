using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.DirectoryServices.AccountManagement;

using System.Data;
using System.Data.OleDb;


namespace Shared
{
	/// <summary> Globaly Shared Functions
	/// </summary>
	public static class Functions
    {
        #region Variables for global/peoplesoft functionality
        const string FINDBirthdate = "<span  class='PSEDITBOX_DISPONLY' id='W_PERS_INFO_WRK_W_PERS_INFO'>";
        const string FINDName = "<span  class='PALEVEL0SECONDARY' id='PSOPRDEFN_OPRDEFNDESC'>";
        const string Shoebox_LoginURI = Shoebox_BaseURI + "/psp/PSPRDWS/?cmd=login&languageCd=ENG";
        const string Shoebox_LogoutURI = Shoebox_BaseURI + "/psp/PSPRDWS/EMPLOYEE/HRMS/?cmd=logout";
        const string Shoebox_BaseURI = "http://rocpsp02";
        const string Shoebox_UserLookup = Shoebox_BaseURI + "/psc/PSPRDWS/EMPLOYEE/HRMS/c/W_SETUP_HRMS.W_USERMAINT.GBL";
        const string Shoebox_MISC = Shoebox_BaseURI + "/psc/PSPRDWS/EMPLOYEE/HRMS/c/W_SETUP_HRMS.W_USERMAINT.GBL?FolderPath=PORTAL_ROOT_OBJECT.PT_PEOPLETOOLS.PT_SECURITY.PT_USER_PROFILES.W_USERMAINT&IsFolder=false&IgnoreParamTempl=FolderPath%2cIsFolder&PortalActualURL=http%3a%2f%2frocpsp02%2fpsc%2fPSPRDWS%2fEMPLOYEE%2fHRMS%2fc%2fW_SETUP_HRMS.W_USERMAINT.GBL&PortalContentURL=http%3a%2f%2frocpsp02%2fpsc%2fPSPRDWS%2fEMPLOYEE%2fHRMS%2fc%2fW_SETUP_HRMS.W_USERMAINT.GBL&PortalContentProvider=HRMS&PortalCRefLabel=User%20Profile%20HelpDesk-WWW&PortalRegistryName=EMPLOYEE&PortalServletURI=http%3a%2f%2frocpsp02%2fpsp%2fPSPRDWS%2f&PortalURI=http%3a%2f%2frocpsp02%2fpsc%2fPSPRDWS%2f&PortalHostNode=HRMS&NoCrumbs=yes&PortalKeyStruct=yes";
        static CookieContainer cookieJar = new CookieContainer();
        #endregion

        #region Functions for global/peoplesoft functionality
        public static void ClearCookies()
        {
            cookieJar = new CookieContainer();
        }

        public static string LoginToPeoplesoft(string username, string password)
        {
            //logs in using the specified username and password
            HttpWebRequest request = null;

            try
            {
                request = WebRequest.Create(Shoebox_LoginURI) as HttpWebRequest;
                request.CookieContainer = cookieJar;
                request.Method = "POST";
                request.UserAgent = "Helpdesk Tools (IE compatible)";

                using (Stream stream = request.GetRequestStream())
                {
                    string postData = string.Format("timezoneOffset=300&userid={0}&pwd={1}", username, password);

                    char[] reqData = postData.ToCharArray();
                    byte[] byteStream = Encoding.UTF8.GetBytes(reqData);

                    request.ContentType = "application/x-www-form-urlencoded";
                    stream.Write(byteStream, 0, byteStream.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex is WebException)
                {
                    string a = "";

                    using (StreamReader sr = new StreamReader((ex as WebException).Response.GetResponseStream()))
                    {
                        a = sr.ReadToEnd();
                    }

                    if (a != string.Empty) ;
                }
                throw;
            }
        }

        /// <summary>
        /// Search Peoplesoft for user info by employee number
        /// </summary>
        /// <param name="empNumber"></param>
        /// <returns></returns>
        public static string LookupUser(string empNumber)
        {
            HttpWebRequest request = null;

            try
            {
                request = WebRequest.Create(Shoebox_MISC) as HttpWebRequest;
                request.CookieContainer = cookieJar;
                request.Method = "GET";
                request.UserAgent = "Helpdesk Tools (IE compatible)";
                request.Referer = "http://rocpsp02/psp/PSPRDWS/EMPLOYEE/HRMS/c/W_SETUP_HRMS.W_USERMAINT.GBL?FolderPath=PORTAL_ROOT_OBJECT.PT_PEOPLETOOLS.PT_SECURITY.PT_USER_PROFILES.W_USERMAINT&IsFolder=false&IgnoreParamTempl=FolderPath%2cIsFolder";

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                }
                //looks up the user by employee number
                request = WebRequest.Create(Shoebox_UserLookup) as HttpWebRequest;
                request.CookieContainer = cookieJar;
                request.Method = "POST";
                request.UserAgent = "Helpdesk Tools (IE compatible)";
                request.Referer = "http://rocpsp02/psc/PSPRDWS/EMPLOYEE/HRMS/c/W_SETUP_HRMS.W_USERMAINT.GBL?FolderPath=PORTAL_ROOT_OBJECT.PT_PEOPLETOOLS.PT_SECURITY.PT_USER_PROFILES.W_USERMAINT&IsFolder=false&IgnoreParamTempl=FolderPath%2cIsFolder&PortalActualURL=http%3a%2f%2frocpsp02%2fpsc%2fPSPRDWS%2fEMPLOYEE%2fHRMS%2fc%2fW_SETUP_HRMS.W_USERMAINT.GBL&PortalContentURL=http%3a%2f%2frocpsp02%2fpsc%2fPSPRDWS%2fEMPLOYEE%2fHRMS%2fc%2fW_SETUP_HRMS.W_USERMAINT.GBL&PortalContentProvider=HRMS&PortalCRefLabel=User%20Profile%20HelpDesk-WWW&PortalRegistryName=EMPLOYEE&PortalServletURI=http%3a%2f%2frocpsp02%2fpsp%2fPSPRDWS%2f&PortalURI=http%3a%2f%2frocpsp02%2fpsc%2fPSPRDWS%2f&PortalHostNode=HRMS&NoCrumbs=yes&PortalKeyStruct=yes";

                using (Stream stream = request.GetRequestStream())
                {
                    //string postData = string.Format("timezoneOffset=300&userid={0}&pwd={1}", username, password);
                    string postData = string.Format("ICAJAX=1&ICNAVTYPEDROPDOWN=1&ICType=Panel&ICElementNum=0&ICStateNum=1&ICAction=%23KEY%0D%0A&ICXPos=0&ICYPos=0&ResponsetoDiffFrame=-1&TargetFrameName=None&FacetPath=None&ICFocus=W_OPRDEFN_SRCH_OPRID&ICSaveWarningFilter=0&ICChanged=-1&ICResubmit=0&ICSID=54T1dU88y%2BwmeGp7QsC5UyhVZ7ml5Qj9HgLjoHbwmEc%3D&ICActionPrompt=false&ICFind=&ICAddCount=&ICAPPCLSDATA=&#ICKeySelect=0&W_OPRDEFN_SRCH_OPRID$op=1&W_OPRDEFN_SRCH_OPRID={0}", empNumber);

                    char[] reqData = postData.ToCharArray();
                    byte[] byteStream = Encoding.UTF8.GetBytes(reqData);

                    request.ContentType = "application/x-www-form-urlencoded";
                    stream.Write(byteStream, 0, byteStream.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static string LogoutPeoplesoft()
        {

            HttpWebRequest request = null;

            try
            {
                //http://rocpsp02/psp/PSPRDWS/EMPLOYEE/HRMS/?cmd=logout

                request = WebRequest.Create(Shoebox_LogoutURI) as HttpWebRequest;
                request.CookieContainer = cookieJar;
                request.Method = "GET";
                request.UserAgent = "Helpdesk Tools (IE compatible)";

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static UserDetails FindNameBirthdate(string lookupDetails)
        {
            //for testing *REMOVE*
            //ResetPeoplesoftPassword(lookupDetails);
            // /testing
            try
            {

                UserDetails retVal = new UserDetails();

                if (lookupDetails.ToLower().Contains("no matching values were found"))
                {
                    retVal.name = "No matching employees.";
                    retVal.birthday = string.Empty;
                    return retVal;
                }

                retVal.name = lookupDetails.Split(new string[] { FINDName }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "</span>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                retVal.birthday = lookupDetails.Split(new string[] { FINDBirthdate }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "</span>" }, StringSplitOptions.RemoveEmptyEntries)[0];

                return retVal;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Your search was either too vauge, or returned no results", "Search Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new UserDetails("No matching employees.", "");
            }
        }

        public static bool ResetPeoplesoftPassword(string lookupDetails)
        {
            //find out if this account is locked out or not
            bool isLockedOut = (lookupDetails.Split(new string[] { "<input type='hidden' name='PSOPRDEFN_ACCTLOCK$chk' id='PSOPRDEFN_ACCTLOCK$chk' value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries)[0] == "1") ? true : false;

            if (isLockedOut)
            {
                HttpWebRequest request = null;

                try
                {
                    //http://rocpsp02/psp/PSPRDWS/EMPLOYEE/HRMS/?cmd=logout

                    request = WebRequest.Create(Shoebox_UserLookup) as HttpWebRequest;
                    request.CookieContainer = cookieJar;
                    request.Method = "POST";
                    request.Timeout = 5000;
                    request.UserAgent = "Helpdesk Tools (IE compatible)";

                    using (Stream stream = request.GetRequestStream())
                    {
                        //string postData = string.Format("timezoneOffset=300&userid={0}&pwd={1}", username, password);
                        //ICAJAX=1&ICNAVTYPEDROPDOWN=1&ICType=Panel&ICElementNum=0&ICStateNum=3&ICAction=%23ICSave&ICXPos=0&ICYPos=0&ResponsetoDiffFrame=-1&TargetFrameName=None&FacetPath=None&ICFocus=&ICSaveWarningFilter=0&ICChanged=0&ICResubmit=0&ICSID=6idQTGACipFWyHiioVcNLJCHz%2FbWTpt6V8DMHsML9%2FA%3D&ICActionPrompt=false&ICFind=&ICAddCount=&ICAPPCLSDATA=&PSOPRDEFN_ACCTLOCK$chk=0
                        string postData = string.Format("ICAJAX=1&ICNAVTYPEDROPDOWN=1&ICType=Panel&ICElementNum=0&ICStateNum=1&ICAction=%23KEY%0D%0A&ICXPos=0&ICYPos=0&ResponsetoDiffFrame=-1&TargetFrameName=None&FacetPath=None&ICFocus=W_OPRDEFN_SRCH_OPRID&ICSaveWarningFilter=0&ICChanged=-1&ICResubmit=0&ICSID=54T1dU88y%2BwmeGp7QsC5UyhVZ7ml5Qj9HgLjoHbwmEc%3D&ICActionPrompt=false&ICFind=&ICAddCount=&ICAPPCLSDATA=&#ICKeySelect=0&W_OPRDEFN_SRCH_OPRID$op=1&W_OPRDEFN_SRCH_OPRID={0}", "");

                        char[] reqData = postData.ToCharArray();
                        byte[] byteStream = Encoding.UTF8.GetBytes(reqData);

                        request.ContentType = "application/x-www-form-urlencoded";
                        stream.Write(byteStream, 0, byteStream.Length);
                    }

                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                    }
                }
                catch
                {
                    throw;
                }
            }

            return true;
        }

        private static List<LDAP.Result> results = null;

        public static string LookupUserAD(string empNumber)
        {
            try
            {
                empNumber = DropLeadingZeros(empNumber);
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)((employeeNumber={0})))";
                List<LDAP.Result> result = AD.SearchAD(ldapquery, string.Format(strFilter, empNumber), false);
                results = result;

                //survey says.... find me the info!!!!
                return result.Find(e => e.Attribute.ToLower() == "sAMAccountName".ToLower()).Value;
            }
            catch
            {
                return "Not Found";
            }
        }

        public static string LookupUserDepartmentAD(string empNumber)
        {
            try
            {
                empNumber = DropLeadingZeros(empNumber);

                if (results != null)
                {
                    if (results.Find(e => e.Attribute.ToLower() == "employeeNumber".ToLower()).Value == empNumber)
                    {
                        return results.Find(e => e.Attribute.ToLower() == "department".ToLower()).Value;
                    }
                }

                //if we make it this far, we need to look up the user
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)((employeeNumber={0})))";
                List<LDAP.Result> result = AD.SearchAD(ldapquery, string.Format(strFilter, empNumber), false);
                results = result;

                return result.Find(e => e.Attribute.ToLower() == "department".ToLower()).Value;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string LookupUserJobTitleAD(string empNumber)
        {
            try
            {
                empNumber = DropLeadingZeros(empNumber);

                if (results != null)
                {
                    if (results.Find(e => e.Attribute.ToLower() == "employeeNumber".ToLower()).Value == empNumber)
                    {
                        return results.Find(e => e.Attribute.ToLower() == "title".ToLower()).Value;
                    }
                }

                //if we make it this far, we need to look up the user
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)((employeeNumber={0})))";
                List<LDAP.Result> result = AD.SearchAD(ldapquery, string.Format(strFilter, empNumber), false);
                results = result;

                return result.Find(e => e.Attribute.ToLower() == "title".ToLower()).Value;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string LookupUserSupervisorAD(string empNumber)
        {
            try
            {
                string man = string.Empty;

                //find out the CN of the manager
                string[] test = null;

                int CNloc = 0;

                empNumber = DropLeadingZeros(empNumber);

                if (results != null)
                {
                    if (results.Find(e => e.Attribute.ToLower() == "employeeNumber".ToLower()).Value == empNumber)
                    {
                        //manager
                        man = results.Find(e => e.Attribute.ToLower() == "manager".ToLower()).Value;

                        //find out the CN of the manager
                        test = man.Split('=');

                        CNloc = 0;

                        foreach (string s in test)
                        {
                            if (s.Contains("CN"))
                            {
                                CNloc++;
                                break;
                            }
                            else CNloc++;
                        }

                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"(?<!\\),");
                        test = reg.Split(test[CNloc]);

                        return string.Format("{0}{1}", test[0].Split('\\')[0], test[0].Split('\\')[1]);
                    }
                }

                //if we make it this far, we need to look up the user
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)((employeeNumber={0})))";
                List<LDAP.Result> result = AD.SearchAD(ldapquery, string.Format(strFilter, empNumber), false);
                results = result;

                //get manager
                man = results.Find(e => e.Attribute.ToLower() == "manager".ToLower()).Value;

                //find out the CN of the manager
                test = man.Split('=');

                CNloc = 0;

                foreach (string s in test)
                {
                    if (s.Contains("CN"))
                    {
                        CNloc++;
                        break;
                    }
                    else CNloc++;
                }

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(?<!\\),");
                test = regex.Split(test[CNloc]);

                return string.Format("{0}{1}", test[0].Split('\\')[0], test[0].Split('\\')[1]);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static System.Drawing.Bitmap GetADImage(string empNumber)
        {
            try
            {
                empNumber = DropLeadingZeros(empNumber);
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)((employeeNumber={0})))";
                System.DirectoryServices.SearchResult result = AD.SearchADOneResult(ldapquery, string.Format(strFilter, empNumber));

                byte[] bytes = result.Properties["jpegPhoto"][0] as byte[];
                System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(System.Drawing.Bitmap));
                System.Drawing.Bitmap bm = (System.Drawing.Bitmap)tc.ConvertFrom(bytes);

                return bm;
            }
            catch
            {
                return null;
            }
        }

        public static string DropLeadingZeros(string empNum)
        {
            char[] split = empNum.ToCharArray();
            int indexOfFirstNonZero = 0;

            foreach (char testitem in split)
            {
                if (isNumeric(testitem))
                {
                    if (int.Parse(testitem.ToString()) == 0)
                    {
                        indexOfFirstNonZero++;
                    }
                    else break;
                }
                else break;
            }

            return empNum.Substring(indexOfFirstNonZero);
        }

        public static bool ResetUserPWDAD(string username, string newPassword)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
                    {
                        user.SetPassword(newPassword);
                        user.UnlockAccount();
                        user.ExpirePasswordNow();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool IsUserLockedout(string username)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
                    {
                        return user.IsAccountLockedOut();
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsUserDisabled(string username)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
                    {
                        return (bool)user.Enabled;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool UnlockUserPWDAD(string username)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
                    {
                        user.UnlockAccount();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion


		/// <summary> Search AD for user by phone number
		/// </summary>
		/// <param name="number"></param>
		/// <returns>username as a string</returns>
        public static string ADUserLookupByNumber(string number)
        {
            try
            {
                //if we make it this far, we need to look up the user
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)((ipPhone={0})))";
                List<LDAP.Result> result = AD.SearchAD(ldapquery, string.Format(strFilter, number), false);
                if (result != null)
                {
                    string returnValue = string.Format("{0} {1}", result.Find(e => e.Attribute.ToLower() == "givenName".ToLower()).Value, result.Find(e => e.Attribute.ToLower() == "sn".ToLower()).Value);
                    //return result.Find(e => e.Attribute.ToLower() == "title".ToLower()).Value;

                    return returnValue;
                }
                else return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }


		/// <summary> Search for DNS entry by hostname
		/// </summary>
		/// <param name="hostname"></param>
		/// <returns></returns>
        public static bool DnsLookup(string hostname)
		{
			System.Net.IPHostEntry host;
			try
			{
				host = System.Net.Dns.GetHostEntry(hostname);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Exception caught during DNS lookup\nThe computer is not online");
				return false;
			}
			if (host == null || host.AddressList.GetLength(0) == 0)
			{
				Console.WriteLine("No addresses availible for the hostname");
				return false;
			}
			return true;
		}


		/// <summary> Send an email
		/// </summary>
		/// <param name="to"></param>
		/// <param name="body"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static bool b_SendEmail(string to, string body, string subject)
		{
			try
			{
				string from = Environment.UserName.ToString() + "@wwwinc.com";
				//System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage(from, to, subject, body);
				System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage();
				_msg.From = new System.Net.Mail.MailAddress(from);
				_msg.Subject = subject;
				_msg.Body = body;
				_msg.To.Add(to);
				_msg.IsBodyHtml = true;

				System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
				client.UseDefaultCredentials = true;
				client.Send(_msg);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
		/// <summary> Send an email
		/// </summary>
		/// <param name="to"></param>
		/// <param name="body"></param>
		/// <param name="subject"></param>
		/// <param name="attachement"></param>
		/// <returns></returns>
		public static bool b_SendEmail(string to, string body, string subject, FileInfo attachement)
		{
			try
			{
				string from = Environment.UserName.ToString() + "@wwwinc.com";
				//System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage(from, to, subject, body);
				System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage();
				_msg.From = new System.Net.Mail.MailAddress(from);
				_msg.Subject = subject;
				_msg.Body = body;
				_msg.To.Add(to);
				_msg.Attachments.Add(new System.Net.Mail.Attachment(attachement.Open(FileMode.Open, FileAccess.Read, FileShare.Read), attachement.Name));
				_msg.IsBodyHtml = true;

				System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
				client.UseDefaultCredentials = true;
				client.Send(_msg);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
		/// <summary> Send an email
		/// </summary>
		/// <param name="to"></param>
		/// <param name="body"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static bool b_SendEmail(System.Collections.Specialized.StringCollection to, string body, string subject)
		{
			List<string> toL = new List<string>();
			foreach ( string s in to)
			{
				toL.Add(s);
			}
			return b_SendEmail(toL, body, subject);
		}
		/// <summary> Send an email
		/// </summary>
		/// <param name="to"></param>
		/// <param name="body"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static bool b_SendEmail(List<string> to, string body, string subject)
		{
			try
			{
				string from = Environment.UserName.ToString() + "@wwwinc.com";
				//System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage(from, to, subject, body);
				System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage();
				_msg.From = new System.Net.Mail.MailAddress(from);
				_msg.Subject = subject;
				_msg.Body = body;
				//_msg.To.Add(to);

				foreach (string _to in to)
				{
					_msg.To.Add(_to);
				}

				_msg.IsBodyHtml = true;

				System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
				client.UseDefaultCredentials = true;
				client.Send(_msg);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
		/// <summary> Sends an email
		/// </summary>
		/// <param name="to"></param>
		/// <param name="body"></param>
		/// <param name="subject"></param>
		/// <param name="attachement"></param>
		/// <returns></returns>
		public static bool b_SendEmail(List<string> to, string body, string subject, List<FileInfo> attachement)
		{
			try
			{
				string from = Environment.UserName.ToString() + "@wwwinc.com";
				//System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage(from, to, subject, body);
				System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage();
				_msg.From = new System.Net.Mail.MailAddress(from);
				_msg.Subject = subject;
				_msg.Body = body;
				//_msg.To.Add(to);

				foreach (string _to in to)
				{
					_msg.To.Add(_to);
				}

				//_msg.Attachments.Add(new System.Net.Mail.Attachment(attachement.Open(FileMode.Open, FileAccess.Read, FileShare.Read), attachement.Name));
				foreach (FileInfo _file in attachement)
				{
					_msg.Attachments.Add(new System.Net.Mail.Attachment(_file.Open(FileMode.Open, FileAccess.Read, FileShare.Read), _file.Name));
				}
				_msg.IsBodyHtml = true;

				System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
				client.UseDefaultCredentials = true;
				client.Send(_msg);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}


		/// <summary> Returns true if text property contains only numbers
		/// </summary>
		/// <param name="textBox"></param>
		/// <returns></returns>
		public static bool isTxtBoxNumeric(System.Windows.Forms.TextBox textBox)
		{
			int number = -1;
			return Int32.TryParse(textBox.Text, out number);
		}
		/// <summary> Returns true if text property contains only numbers and outputs it as an int
		/// </summary>
		/// <param name="textBox">TextBox to test text property</param>
		/// <param name="number">text as int</param>
		/// <returns></returns>
		public static bool isTxtBoxNumeric(System.Windows.Forms.TextBox textBox, out int number)
		{
			return Int32.TryParse(textBox.Text, out number);
		}


		/// <summary> Tests if char is numeric
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool isNumeric(char input)
		{
			int a = 0;
			return int.TryParse(input.ToString(), out a);
		}
		/// <summary> Tests if char is numeric
		/// </summary>
		/// <param name="input"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool isNumeric(char input, out int result)
		{
			return int.TryParse(input.ToString(), out result);
		}
		/// <summary> tests if a string is numeric
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool isNumeric(string input)
		{
			int result = -1;
			return int.TryParse(input, out result);
		}
		/// <summary> tests if string is numeric, also outputs results as int
		/// </summary>
		/// <param name="input"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool isNumeric(string input, out int result)
		{
			return int.TryParse(input, out result);
		}

        
		/// <summary> FUNCTION FOR EXPORT TO EXCEL
		/// </summary>
		/// <param name="dataTable"></param>
		/// <param name="worksheetName"></param>
		/// <param name="saveAsLocation"></param>
		/// <returns></returns>
		public static bool Excel_WriteDataTableToFile(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReportType)
		{
			Microsoft.Office.Interop.Excel.Application excel;
			Microsoft.Office.Interop.Excel.Workbook excelworkBook;
			Microsoft.Office.Interop.Excel.Worksheet excelSheet;
			Microsoft.Office.Interop.Excel.Range excelCellrange;

			try
			{
				// Start Excel and get Application object.
				excel = new Microsoft.Office.Interop.Excel.Application();

				// for making Excel visible
				excel.Visible = false;
				excel.DisplayAlerts = false;

				// Creation a new Workbook
				excelworkBook = excel.Workbooks.Add(Type.Missing);

				// Workk sheet
				excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
				excelSheet.Name = worksheetName;


				excelSheet.Cells[1, 1] = "Export";
				excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();

				// loop through each row and add values to our sheet
				int rowcount = 2;

				foreach (System.Data.DataRow datarow in dataTable.Rows)
				{
					rowcount += 1;
					for (int i = 1; i <= dataTable.Columns.Count; i++)
					{
						// on the first iteration we add the column headers
						if (rowcount == 3)
						{
							excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
							excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

						}

						excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

						//for alternate rows
						if (rowcount > 3)
						{
							if (i == dataTable.Columns.Count)
							{
								if (rowcount % 2 == 0)
								{
									excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
									Excel_FormatCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
								}

							}
						}

					}

				}

				// now we resize the columns
				excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
				excelCellrange.EntireColumn.AutoFit();
				Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
				border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
				border.Weight = 2d;


				excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
				Excel_FormatCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


				//now save the workbook and exit Excel


				excelworkBook.SaveAs(saveAsLocation); ;
				excelworkBook.Close();
				excel.Quit();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			finally
			{
				excelSheet = null;
				excelCellrange = null;
				excelworkBook = null;
			}

		}

		/// <summary> FUNCTION FOR FORMATTING EXCEL CELLS
		/// </summary>
		/// <param name="range"></param>
		/// <param name="HTMLcolorCode"></param>
		/// <param name="fontColor"></param>
		/// <param name="IsFontbool"></param>
		public static void Excel_FormatCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
		{
			range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
			range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
			if (IsFontbool == true)
			{
				range.Font.Bold = IsFontbool;
			}
		}


		public static void v_InstallPsTools()
		{
			try
			{
				if (!File.Exists(Shared.Settings.Default._TempPath + "PsExec.exe"))
				{
					Console.WriteLine(@"PsExec not found, copying to: {0}", Shared.Settings.Default._TempPath + "PsExec.exe");
					File.Copy(Shared.Settings.Default._NetworkShare + @"\Software\psexec\PsExec.exe",
						Shared.Settings.Default._TempPath + "PsExec.exe",
						true);
				}
				//if (!File.Exists(Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\PsExec.exe"))
				//{
				//	Console.WriteLine(@"PsExec not found, copying to: {0}\System32\", Environment.ExpandEnvironmentVariables("%WINDIR%"));
				//	File.Copy(Shared.Settings.Default._NetworkShare + @"\Software\psexec\PsExec.exe",
				//		Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\PsExec.exe",
				//		true);
				//}
			}
			catch (Exception) { }
		}
		public static void v_Install_DelayedStartServices()
		{
			try
			{
				File.Copy(Shared.Settings.Default._NetworkShare + @"\Software\DelayedStartServices\DelayedStartServices.exe",
						Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\DelayedStartServices.exe",
						true);
			}
			catch (Exception) { Console.WriteLine("Failed copying DelayedStartServices"); }
		}
        public static void v_RemoveDelayedStartServices()
        {
            string f = Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\DelayedStartServices.exe";
            try
            {
                   if(File.Exists(f)) { File.Delete(f);}
            }
            catch (Exception) { Console.WriteLine("Failed while removeing DelayedStartServices");;}
        }
		public static void v_CreateTempFolder()
		{
			if (!Directory.Exists(Shared.Settings.Default._TempPath))
			{
				Console.WriteLine("Creating temporary directory: " + Shared.Settings.Default._TempPath);
				Directory.CreateDirectory(Shared.Settings.Default._TempPath);
			}
			else { Console.WriteLine("Found temporary directory: " + Shared.Settings.Default._TempPath); }
		}

		public static bool PlaceCerts(string Computer)
		{
			try
			{
				string Cert1 = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\global.cer";
				string Cert2 = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\verisign-root.cer";
				string Destination1 = string.Format(@"\\{0}\C$\Temp\global.cer", Computer);
				string Destination2 = string.Format(@"\\{0}\C$\Temp\verisign-root.cer", Computer);
				File.Copy(Cert1, Destination1, true);
				File.Copy(Cert2, Destination2, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}


		/// <summary> QUERIES THE EXCEL FILE
		/// </summary>
		/// <param name="fileName"></param>
        /// <param name="xQuery"></param>
		/// <returns></returns>
		public static DataTable Excel_QuerySheet(string fileName, string xQuery)
		{
			DataTable t = new DataTable();
			OleDbConnection xconn = null;
			OleDbDataAdapter xadapter = null;
			try
			{
                if (fileName.Trim().EndsWith(".xlsx"))
                {
                    xconn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", fileName));
                }
                else if (fileName.Trim().EndsWith(".xls"))
                {
                    xconn = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", fileName));
                }
                else { return new DataTable(); }
                xadapter = new OleDbDataAdapter(xQuery, xconn);
				xadapter.Fill(t);
				return t;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new DataTable();
			}
			finally
			{
				if (t.Rows.Count == 0) { t.Dispose(); }
				if (xconn != null) { xconn.Close(); xconn.Dispose(); }
				if (xadapter != null) { xadapter.Dispose(); }
			}
		}

		/// <summary> IMPORTS THE TABLES NAMES OF THE GIVEN FILE
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="xQuery"></param>
		/// <returns></returns>
		public static DataTable Excel_GetTables(string fileName)
		{
			DataTable t = new DataTable();
			OleDbConnection xconn = null;
			try
			{
                if (fileName.Trim().EndsWith(".xlsx"))
                {
                    xconn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", fileName));
                }
                else if (fileName.Trim().EndsWith(".xls"))
                {
                    xconn = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", fileName));
                } 
                xconn.Open();
				t = xconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
				return t;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new DataTable();
			}
			finally
			{
				if (xconn != null) { xconn.Close(); xconn.Dispose(); }
				if (t.Rows.Count == 0) { t.Dispose(); }
			}
		}

		/// <summary> IMPORTS THE COLUMNS OF THE GIVEN FILE
		/// </summary>
		/// <param name="fileName"></param>
        /// <param name="tablename"></param>
		/// <returns></returns>
		public static DataTable Excel_GetColumns(string fileName, string tablename)
		{
			DataTable t = new DataTable();
			OleDbConnection xconn = null;
			try
			{
                if (fileName.Trim().EndsWith(".xlsx"))
                {
                    xconn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", fileName));
                }
                else if (fileName.Trim().EndsWith(".xls"))
                {
                    xconn = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", fileName));
                } 
                xconn.Open();
				t = xconn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tablename, null });
				return t;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new DataTable();
			}
			finally
			{
				if (xconn != null) { xconn.Close(); xconn.Dispose(); }
				if (t.Rows.Count == 0) { t.Dispose(); }
			}
		}

	}
}
