using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.DirectoryServices.AccountManagement;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;


namespace Shared
{
    /// <summary> Globaly Shared Functions
    /// </summary>
    public static class Functions
    {
        #region AD functions

        /// <summary>
        /// Resets AD password
        /// </summary>
        /// <param name="username">sAMAccountName</param>
        /// <param name="newPassword">Yep</param>
        /// <returns></returns>
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

        /// <summary>
        /// Determine lockout status
        /// </summary>
        /// <param name="username">sAMAccountName</param>
        /// <returns></returns>
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

        /// <summary>
        /// Determine if account is disabled
        /// </summary>
        /// <param name="username">sAMAccountName</param>
        /// <returns></returns>
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

        /// <summary>
        /// Unlock a locked AD account
        /// </summary>
        /// <param name="username">sAMAccountName</param>
        /// <returns></returns>
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

        #endregion




        #region EMAIL


        /// <summary> Send an email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static bool SendEmail(string to, string body, string subject)
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
        public static bool SendEmail(string to, string body, string subject, FileInfo attachement)
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
        public static bool SendEmail(System.Collections.Specialized.StringCollection to, string body, string subject)
        {
            List<string> toL = new List<string>();
            foreach (string s in to)
            {
                toL.Add(s);
            }
            return SendEmail(toL, body, subject);
        }
        /// <summary> Send an email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static bool SendEmail(List<string> to, string body, string subject)
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
        public static bool SendEmail(List<string> to, string body, string subject, List<FileInfo> attachement)
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


        /// <summary>
        /// Send mail using WWINC Domain settings
        /// </summary>
        /// <param name="From">Sender</param>
        /// <param name="To">Receiver</param>
        /// <param name="Subject">Subject of message</param>
        /// <param name="Body">Body of message</param>
        /// <param name="Attachments">List of files to attach</param>
        /// <param name="HTML">Boolean to enable HTML in body</param>
        /// <returns>on success</returns>
        public static bool SendMail(string From, string To, string Subject, string Body, string[] Attachments, bool HTML)
        {
            // new mail message container
            MailMessage message = new MailMessage(From, To);
            // add subject line
            message.Subject = Subject;
            // add body
            message.Body = Body;
            // use HTML in body
            message.IsBodyHtml = HTML;
            //
            message.ReplyToList.Add("ITRetailHelpdeskDL@wwwinc.com");
            // add attachments
            foreach (string path in Attachments)
            {
                if (File.Exists(path))
                {
                    message.Attachments.Add(new Attachment(path));
                }
            }
            // our domain specific settings
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
            // use network credentials
            client.UseDefaultCredentials = true;


            try { client.Send(message); }
            catch { return false; }
            return true;
        }
        /// <summary>
        /// Send mail using WWINC Domain settings
        /// </summary>
        /// <param name="From">Sender</param>
        /// <param name="To">Receiver</param>
        /// <param name="Subject">Subject of message</param>
        /// <param name="Body">Body of message</param>
        /// <param name="Attachments">List of files to attach</param>
        /// <returns></returns>
        public static bool SendMail(string From, string To, string Subject, string Body, string[] Attachments)
        {
            return SendMail(From, To, Subject, Body, Attachments, false);
        }
        /// <summary>
        /// Send mail using WWINC Domain settings
        /// </summary>
        /// <param name="From">Sender</param>
        /// <param name="To">Receiver</param>
        /// <param name="Subject">Subject of message</param>
        /// <param name="Body">Body of message</param>
        /// <param name="HTML">Boolean to enable HTML in body</param>
        /// <returns>on success</returns>
        public static bool SendMail(string From, string To, string Subject, string Body, bool HTML)
        {
            return SendMail(From, To, Subject, Body, new string[] { }, HTML);
        }
        /// <summary>
        /// Send mail using WWINC Domain settings
        /// </summary>
        /// <param name="From">Sender</param>
        /// <param name="To">Receiver</param>
        /// <param name="Subject">Subject of message</param>
        /// <param name="Body">Body of message</param>
        /// <param name="Attachment">file to attach</param>
        /// <returns>on success</returns>
        public static bool SendMail(string From, string To, string Subject, string Body, string Attachment)
        {
            return SendMail(From, To, Subject, Body, new string[] { Attachment }, false);
        }
        /// <summary>
        /// Send mail using WWINC Domain settings
        /// </summary>
        /// <param name="From">Sender</param>
        /// <param name="To">Receiver</param>
        /// <param name="Subject">Subject of message</param>
        /// <param name="Body">Body of message</param>
        /// <returns>on success</returns>
        public static bool SendMail(string From, string To, string Subject, string Body)
        {
            return SendMail(From, To, Subject, Body, new string[] { }, false);
        }


        #endregion




        #region Remote Commands



        /// <summary>
        /// Launches an instance of another program/executable
        /// </summary>
        /// <param name="ExecutableFile">Name of program or path to EXE</param>
        /// <param name="Arguments">Arguments given to the EXE</param>
        /// <param name="Interactive">Show the program running</param>
        /// <param name="Wait">Pause all other processing until process completes</param>
        /// <returns></returns>
        public static int ExecuteCommand(string ExecutableFile, string Arguments, bool Interactive, bool Wait)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ExecutableFile;
            startInfo.Arguments = Arguments;
            startInfo.CreateNoWindow = (!Interactive);
            startInfo.UseShellExecute = Interactive;
            Process process = Process.Start(startInfo);
            if (Wait) {; process.WaitForExit(); return process.ExitCode; }
            return 0;
        }
        /// <summary>
        /// Launches an instance of another program/executable
        /// </summary>
        /// <param name="ExecutableFile">Name of program or path to EXE</param>
        /// <param name="Arguments">Arguments given to the EXE</param>
        /// <param name="Interactive">Show the program running</param>
        /// <param name="Title">Change the title of the program (only tested on batch files)</param>
        /// <param name="Wait">Pause all other processing until process completes</param>
        /// <returns></returns>
        public static int ExecuteCommand(string ExecutableFile, string Arguments, bool Interactive, string Title, bool Wait)
        {
            return ExecuteCommand("CMD", string.Format("/C TITLE {0} && {1} {2}", Title, ExecutableFile, Arguments), Interactive, Wait);
        }
        /// <summary>
        /// Launches an instance of another program/executable
        /// </summary>
        /// <param name="ExecutableFile">Name of program or path to EXE</param>
        /// <param name="Interactive">Show the program running</param>
        /// <returns></returns>
        public static int ExecuteCommand(string ExecutableFile, bool Interactive)
        {
            return ExecuteCommand(ExecutableFile, string.Empty, Interactive);
        }
        /// <summary>
        /// Launches an instance of another program/executable
        /// </summary>
        /// <param name="ExecutableFile">Name of program or path to EXE</param>
        /// <param name="Arguments">Arguments given to the EXE</param>
        /// <param name="Interactive">Show the program running</param>
        /// <returns></returns>
        public static int ExecuteCommand(string ExecutableFile, string Arguments, bool Interactive)
        {
            return ExecuteCommand(ExecutableFile, Arguments, Interactive, true);
        }



        /// <summary>
        /// Opens a command prompt to the remote computer
        /// </summary>
        /// <param name="SelectedComputers"></param>
        public static void RemoteCMD(List<Computer> SelectedComputers)
        {
            foreach (Computer computer in SelectedComputers)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "CMD";
                startInfo.Arguments = string.Format("/C TITLE Remote CMD on: {0} && WINRS -d:C:\\ -r:{0} CMD", computer.name);
                Process process = Process.Start(startInfo);
            }
        }


        /// <summary>
        /// Opens a cmd window on the remote machine
        /// </summary>
        /// <param name="computer">computer name as string</param>
        public static void LocalCMD(string computer)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Shared.Settings.Default._TempPath + "PSEXEC";
            startInfo.Arguments = string.Format(@"\\{0} -s -d -i CMD", computer);
            Process process = Process.Start(startInfo);
        }
        /// <summary>
        /// Opens a cmd window on the remote machine
        /// </summary>
        /// <param name="computer">computer object</param>
        public static void LocalCMD(Computer computer)
        {
            LocalCMD(computer.name);
        }
        /// <summary>
        /// Opens a cmd window on the remote machine(s)
        /// </summary>
        /// <param name="SelectedComputers">computer list</param>
        public static void LocalCMD(List<Computer> SelectedComputers)
        {
            foreach (Computer computer in SelectedComputers)
            {
                LocalCMD(computer.name);
            }
        }


        /// <summary>
        /// Opens the epson printer utility
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="Interactive"></param>
        /// <param name="Wait"></param>
        public static void OpenBA500IIUTL(string computer, bool Interactive = true, bool Wait = false)
        {
            string args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\EPSON\\BA-T500II Software\\BA500IIUTL\\BA500IIUTL.EXE\"", computer);
            ExecuteCommand(Shared.Settings.Default._TempPath + "PSEXEC", args, Interactive, Wait);
        }
        /// <summary>
        /// Opens the OPOS configuration utility
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="Interactive"></param>
        /// <param name="Wait"></param>
        public static void OpenOPOS(string computer,bool Interactive=true, bool Wait=false)
        {
            string args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\OPOS\\Epson2\\SetupPOS.exe\"", computer);
            ExecuteCommand(Shared.Settings.Default._TempPath + "PSEXEC", args, Interactive, Wait);
        }


        /// <summary>
        /// Opens the SEP installer from \temp
        /// </summary>
        /// <param name="computer"></param>
        public static void SEPRunInstall(string computer)
        {
            ExecuteCommand("psexec", string.Format(@"\\{0} -s -d -i \temp\Symantec_Endpoint_Protection_12.1.6_MP5_Win32-bit_Client_EN.exe", computer), true, false);
        }
        /// <summary>
        /// Opens the SEP GUI
        /// </summary>
        /// <param name="computer"></param>
        public static void SEPOpenGUI(string computer)
        {
            ExecuteCommand("psexec", string.Format("\\\\{0} -s -d -i \"\\Program Files\\Symantec\\Symantec Endpoint Protection\\smc\" -showgui", computer), true, false);
        }
        /// <summary>
        /// Updates and imports the SEP Comms xml
        /// </summary>
        /// <param name="computer"></param>
        public static void SEPUpdateComms(string computer)
        {
            string comms = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\SEP\SEPComms.xml";
            if (System.IO.File.Exists(comms)) { System.IO.File.Copy(comms, string.Format(@"\\{0}\c$\temp\SEPComms.xml", computer), true); }
            string args = string.Format("-r:{0} \"c:\\Program Files\\Symantec\\Symantec Endpoint Protection\\smc\" -importsylink C:\\temp\\SEPComms.xml", computer);
            ExecuteCommand("WINRS", args, true, true);
        }
        /// <summary>
        /// Updates and imports the SEP config xml
        /// </summary>
        /// <param name="computer"></param>
        public static void SEPUpdateConfig(string computer)
        {
            string config = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\SEP\SEPConfig.xml";
            if (System.IO.File.Exists(config)) { System.IO.File.Copy(config, string.Format(@"\\{0}\c$\temp\SEPConfig.xml", computer), true); }
            string args = string.Format("-r:{0} \"c:\\Program Files\\Symantec\\Symantec Endpoint Protection\\smc\" -importconfig C:\\temp\\SEPConfig.xml", computer);
            ExecuteCommand("WINRS", args, true, true);
        }

        /// <summary>
        /// Activates Windows
        /// </summary>
        /// <param name="computer"></param>
        public static void ActivateWindows(string computer)
        {
            ExecuteCommand("WINRS", string.Format("-r:{0} SLMGR.VBS /IPK FJ82H-XT6CR-J8D7P-XQJJ2-GPDD4 && SLMGR /ATO", computer), true, false);
        }
        /// <summary>
        /// Disables startup repair from opening when POS loses power
        /// </summary>
        /// <param name="computer"></param>
        /// <returns></returns>
        public static int DisableStartupRepair(string computer)
        {
            return ExecuteCommand("WINRS", string.Format("-r:{0} ", computer) + "bcdedit /set {default} recoveryenabled no && bcdedit /set {default} bootstatuspolicy ignoreallfailures", true, true);
        }

        /// <summary>
        /// Kills the POS application
        /// </summary>
        /// <param name="computer"></param>
        public static void KillPOS(string computer)
        {
            string args = string.Format("-r:{0} TASKKILL /F /IM POSW.EXE", computer);
            Shared.Functions.ExecuteCommand("WINRS", args, false, false);
        }
        #endregion




        #region Remote Files



        /// <summary>
        /// Writes a string to a file
        /// </summary>
        /// <param name="Contents">Text to put in file</param>
        /// <param name="FileLocation">Location to write file to</param>
        /// <returns></returns>
        public static bool WriteFile(string Contents, string FileLocation)
        {
            try { File.WriteAllText(FileLocation, Contents); Console.WriteLine("Wrote {0}", FileLocation); }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contents"></param>
        /// <param name="FileLocation"></param>
        /// <returns></returns>
        public static bool CheckForFiles(string Contents, string FileLocation)
        {
            try
            {
                if (!File.Exists(FileLocation)) { return WriteFile(Contents, FileLocation); }
            }
            catch (Exception) { return WriteFile(Contents, FileLocation); }

            return true;
        }


        /// <summary>
        /// Copies a local file to the same directory on a remote machine
        /// </summary>
        /// <param name="ComputerName">Name of remote machine</param>
        /// <param name="FileLocation">Location of file to copy</param>
        /// <param name="verbose">turn off console messages</param>
        /// <returns></returns>
        public static bool CopyFileRemote(string ComputerName, string FileLocation, bool verbose = true)
        {
            try
            {
                string Destination = string.Format(@"\\{0}\C$\{1}", ComputerName, FileLocation.Substring(3));
                if (verbose) { Console.WriteLine(Destination); }
                File.Copy(FileLocation, Destination, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ComputerName"></param>
        /// <param name="verbose">turn off console messages</param>
        /// <returns></returns>
        public static bool CopyArgsXML(string ComputerName, bool verbose = true)
        {
            try
            {
                string Destination = string.Format(@"\\{0}\C$\Program Files\VeriFone\MX915\vfQueryUpdate\args.xml", ComputerName);
                if (verbose) Console.WriteLine(Destination);
                System.IO.File.Copy(Shared.Settings.Default._TempPath + "args.xml", Destination, true);
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// Places PSTools into the windows path
        /// <param name="verbose">turn off console messages</param>
        /// </summary>
        public static void InstallPSTools(bool verbose = true)
        {
            try
            {
                if (!File.Exists(Shared.Settings.Default._TempPath + "PsExec.exe"))
                {
                    if (verbose) { Console.WriteLine(@"PsExec not found, copying to: {0}", Shared.Settings.Default._TempPath + "PsExec.exe"); }
                    File.Copy(Shared.Settings.Default._NetworkShare + @"\Software\PsExec.exe",
                        Shared.Settings.Default._TempPath + "PsExec.exe",
                        true);
                }
            }
            catch (Exception ex) { if (verbose) { Console.WriteLine("{0}\n\t{1}", ex.Source, ex.Message); } }
        }


        /// <summary>
        /// Creates the Temp Path
        /// <param name="verbose">turn off console messages</param>
        /// </summary>
        public static void CreateTempFolder(bool verbose = false)
        {
            if (!Directory.Exists(Shared.Settings.Default._TempPath))
            {
                if (verbose) { Console.WriteLine("Creating temporary directory: " + Shared.Settings.Default._TempPath); }
                Directory.CreateDirectory(Shared.Settings.Default._TempPath);
            }
            else if (verbose) { Console.WriteLine("Found temporary directory: " + Shared.Settings.Default._TempPath); }
        }


        /// <summary>
        /// Updates local versions of bat files
        /// </summary>
        /// <param name="verbose"></param>
        public static bool UpdateLocalBatFiles(bool verbose = true)
        {
            System.Collections.Specialized.StringDictionary batFiles = new System.Collections.Specialized.StringDictionary();

            batFiles.Add(Settings.Default._BatServices, GlobalResources.batServices);
            batFiles.Add(Settings.Default._BatUnlock, GlobalResources.batUnlock);
            batFiles.Add("args.xml", GlobalResources.argsXML);
            batFiles.Add(Settings.Default._BatZip, GlobalResources.Zip_Logs);
            batFiles.Add(Settings.Default._PSZip, GlobalResources.Zipper);
            batFiles.Add(Settings.Default._WSAdmin, GlobalResources.batWSAdmin);

            foreach (System.Collections.DictionaryEntry de in batFiles)
            {
                try
                {
                    WriteFile((string)de.Value, Settings.Default._TempPath + de.Key);
                    if (verbose) { Console.WriteLine("Updated local file: {0}", de.Key); }
                }
                catch (Exception) { return false; }

            }
            return true;
        }
        /// <summary>
        /// Updates local versions of bat files
        /// </summary>
        /// <param name="Computer">remote computer name</param>
        /// <param name="verbose"></param>
        public static bool UpdateLocalBatFiles(string Computer, bool verbose = true)
        {
            System.Collections.Specialized.StringDictionary batFiles = new System.Collections.Specialized.StringDictionary();

            batFiles.Add(Settings.Default._BatServices, GlobalResources.batServices);
            batFiles.Add(Settings.Default._BatUnlock, GlobalResources.batUnlock);
            batFiles.Add("args.xml", GlobalResources.argsXML);
            batFiles.Add(Settings.Default._BatZip, GlobalResources.Zip_Logs);
            batFiles.Add(Settings.Default._PSZip, GlobalResources.Zipper);
            batFiles.Add(Settings.Default._WSAdmin, GlobalResources.batWSAdmin);

            foreach (System.Collections.DictionaryEntry de in batFiles)
            {
                string path = Settings.Default._TempPath.Replace("C:", "");
                path = string.Format(@"\\{0}\c${1}\{2}", Computer, path, de.Key);
                if (!WriteFile((string)de.Value, path)) { return false; }
                /*
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    try
                    {
                        if (sr.ReadToEnd() != (string)de.Value)
                        {
                            if (!WriteFile((string)de.Value, path)) { return false; }
                            if (verbose) { Console.WriteLine("Updated local file: {0}", de.Key); }
                        }
                        else { if (verbose) { Console.WriteLine("Currently up to date: {0}", de.Key); } }
                    }
                    catch (Exception) { return false; }
                }
                else
                {
                    if (!WriteFile((string)de.Value, path)) { return false; }
                }
                */
            }
            return true;
        }



        /// <summary>
        /// Copies log file to local temp path
        /// </summary>
        /// <param name="pathToLog"></param>
        /// <returns></returns>
        public static bool CopyTempLog(string pathToLog)
        {
            try
            {
                File.Copy(pathToLog, Settings.Default._TempPath + "tmp.log", true);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
        /// <summary>
        /// Copies log file to destination
        /// </summary>
        /// <param name="pathToLog"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool CopyTempLog(string pathToLog, string destination)
        {
            try
            {

                File.Copy(pathToLog, destination, true);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }



        /// <summary>
        /// Search tmp log for given string
        /// </summary>
        /// <param name="version"></param>
        /// <param name="verbose">turn off console messages</param>
        /// <returns></returns>
        public static bool FindInLog(string version, bool verbose = true)
        {
            try
            {
                return File.ReadAllText(Settings.Default._TempPath + "tmp.log").Contains(version);
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool FindInLog(System.Collections.Specialized.StringCollection versions, bool verbose = true)
        {
            try
            {
                foreach (string version in versions)
                {
                    if (File.ReadAllText(Settings.Default._TempPath + "tmp.log").Contains(version)) { return true; }

                }
                return false;
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Search log for a given string
        /// </summary>
        /// <param name="version">version to search for</param>
        /// <param name="logLocation">path to log file</param>
        /// <param name="verbose">show debug info</param>
        /// <returns></returns>
        public static bool FindInLog(string version, string logLocation, bool verbose = true)
        {
            try
            {
                return File.ReadAllText(logLocation).Contains(version);
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Get the latest file in the path searching with the find
        /// </summary>
        /// <param name="path">where to look</param>
        /// <param name="find">filename to find</param>
        /// <returns></returns>
        public static string LatestFile(string path, string find)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
                System.IO.FileInfo[] files = dir.GetFiles(find).OrderByDescending(p => p.CreationTime).ToArray();
                Console.WriteLine(files[0].FullName);
                return files[0].FullName;
            }
            catch (Exception) { return ""; }
        }
        /// <summary>
        /// Get the latest multi file
        /// </summary>
        /// <param name="path">where to look</param>
        /// <returns></returns>
        public static string LatestMulti(string path, bool verbose = false)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
                System.IO.FileInfo[] files = dir.GetFiles("multi_*.log").OrderByDescending(p => p.CreationTime).ToArray();
                if (verbose) { Console.WriteLine(files[0].FullName); }
                return files[0].FullName;
            }
            catch (Exception) { return ""; }
        }



        /// <summary>
        /// Search multi log for the specified versions
        /// </summary>
        /// <param name="versions"></param>
        /// <returns></returns>
        public static bool MultiLog(System.Collections.Specialized.StringCollection versions, bool verbose = true)
        {
            try
            {
                string logFileAsString = File.ReadAllText(Settings.Default._TempPath + "tmp.log");
                foreach (string version in versions)
                {
                    if (logFileAsString.Contains(version)) { return true; }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool MultiLog(string version, bool verbose = true)
        {
            try
            {
                string logFileAsString = File.ReadAllText(Settings.Default._TempPath + "tmp.log");
                if (logFileAsString.Contains(version)) { return true; }
                return false;
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Find in Verifone Log
        /// </summary>
        /// <param name="computer">name of computer to search</param>
        /// <param name="version">verifone version to find</param>
        /// <returns></returns>
        public static string VFLog(string computer, string version)
        {
            try
            {
                string logFileAsString = File.ReadAllText(string.Format(@"\\{0}\c$\Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml", computer));
                if (logFileAsString.Contains("MX915"))
                {
                    if (logFileAsString.Contains(version))
                    {
                        return "True";
                    }
                    else return "False";
                }

                else return "Error";
            }
            catch (Exception) { return "Error"; }
        }
        /// <summary>
        /// Find in Verifone Log
        /// </summary>
        /// <param name="computer">name of computer to search</param>
        /// <param name="versions">list of versions to check for</param>
        /// <returns></returns>
        public static string VFLog(string computer, System.Collections.Specialized.StringCollection versions)
        {
            try
            {
                string logFileAsString = File.ReadAllText(string.Format(@"\\{0}\c$\Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml", computer));
                foreach (string version in versions)
                {
                    if (logFileAsString.Contains(version)) { return "True"; }
                }
                if (logFileAsString.Contains("Error")) { return "Error"; }
                return "False";

            }
            catch (Exception) { return "Error"; }
        }



        #endregion




        #region Programs/Utilities


        /// <summary>
        /// Runs my tool that updates our list of computers in SQL
        /// </summary>
        public static void UpdateComputersFromAD()
        {
            Process.Start(@".\UpdateComputerList.exe");
        }


      /// <summary>
        /// Opens an explorer window on the remote machines C:
        /// </summary>
        /// <param name="Computer">Name of remote machine</param>
        /// <param name="Suffix">Remote path to browse relative to C:</param>
        public static void BrowseComputer(string Computer, string Suffix)
        {
            Suffix = Suffix.ToLower().Replace("c:", "");
            if (Suffix != "" && Suffix.Substring(0, 1) != "\\") { Suffix = "\\" + Suffix; }
            Process explore = Process.Start("EXPLORER", string.Format(@"\\{0}\c${1}", Computer, Suffix));
        }
        /// <summary>
        /// Opens an explorer window on the remote machines C:
        /// </summary>
        /// <param name="Computer">Name of remote machine</param>
        public static void BrowseComputer(string Computer)
        {
            BrowseComputer(Computer, "");
        }
        /// <summary>
        /// Opens an explorer window on the remote machines C:
        /// </summary>
        /// <param name="Computers">List of Computers to browse</param>
        public static void BrowseComputer(List<Computer> Computers)
        {
            foreach (Computer Computer in Computers)
            {
                BrowseComputer(Computer.name);
            }
        }
        /// <summary>
        /// Opens an explorer window on the remote machines C:
        /// </summary>
        /// <param name="Computers">List of strings to browse</param>
        public static void BrowseComputer(List<string> Computers)
        {
            foreach (string computer in Computers)
            {
                BrowseComputer(computer);
            }
        }



        /// <summary>
        /// Use dameware mini remote to connect to specified computer(s)
        /// </summary>
        /// <param name="computer">name of computer</param>
        public static void ConnectWithDW(string computer)
        {
            if (File.Exists(@"C:\Program Files (x86)\SolarWinds\DameWare Remote Support\dwrcc.exe"))
            {
                Process altiris = Process.Start(@"C:\Program Files (x86)\SolarWinds\DameWare Remote Support\dwrcc.exe", @"-c: -h: -a:1 -x: -m:" + computer);
            }
            else if (File.Exists(@"C:\Program Files\SolarWinds\DameWare Remote Support\dwrcc.exe"))
            {
                Process altiris = Process.Start(@"C:\Program Files\SolarWinds\DameWare Remote Support\dwrcc.exe", @"-c: -h: -a:1 -x: -m:" + computer);
            }
            else if (File.Exists(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe"))
            {
                Process altiris = Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", @"-c: -h: -a:1 -x: -m:" + computer);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Unable to launch DameWare Remote Control Center\nVerify that it is installed and using the default instalation path", "DameWare Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            // System.Threading.Thread.Sleep(2500);
            Console.WriteLine("Launched DameWare on: " + computer);
        }
        /// <summary>
        /// Use dameware mini remote to connect to specified computer(s)
        /// </summary>
        /// <param name="computer">computer</param>
        public static void ConnectWithDW(Computer computer)
        {
            ConnectWithDW(computer.name);
        }
        /// <summary>
        /// Use dameware mini remote to connect to specified computer(s)
        /// </summary>
        /// <param name="SelectedComputers">List of computers</param>
        public static void ConnectWithDW(List<Computer> SelectedComputers)
        {
            foreach (Computer computer in SelectedComputers)
            {
                ConnectWithDW(computer.name);
            }
        }



        /// <summary>
        /// Opens multi on remote machine
        /// </summary>
        /// <param name="computer"></param>
        public static void Multi(string computer)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Shared.Settings.Default._TempPath + "PSEXEC";
            startInfo.Arguments = string.Format(@"\\{0} -s -d -i \HELPDESK\multi.bat", computer);
            Process process = Process.Start(startInfo);
        }
        /// <summary>
        /// Opens multi on remote machine
        /// </summary>
        /// <param name="computer"></param>
        public static void Multi(Computer computer)
        {
            Multi(computer.name);
        }



        #endregion




        #region Network


        /// <summary>
        /// Opens cmd window with a constant ping to the specified computer/ip
        /// </summary>
        /// <param name="item">computer/ip</param>
        /// <param name="title">title of cmd window</param>
        public static void Pinger(string item, string title = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "CMD";
            if (title.Trim() == string.Empty)
            {
                startInfo.Arguments = string.Format("/C PING -t {0}", item);
            }
            else
            {
                startInfo.Arguments = string.Format("/C TITLE PING: {0} && PING -t {1}", title, item);
            }
            Process.Start(startInfo);
        }
        /// <summary>
        /// Opens cmd window with a constant ping to the specified computers
        /// </summary>
        /// <param name="Computers"></param>
        public static void Pinger(List<Computer> Computers)
        {
            foreach (string computer in Computers)
            {
                if (DnsLookup(computer,false)) { Pinger(computer, computer); }
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "CMD";
                    int wait = 5;
                    startInfo.Arguments = string.Format("/C ECHO No DNS entry for {0} && PING -n {1} localhost > nul", computer, wait);
                    Process.Start(startInfo);
                }
            }
        }


		/// <summary>
		/// Test network connection to remote machine
		/// </summary>
		/// <param name="computer"></param>
		/// <returns></returns>
		public static bool CheckNetwork(string computer)
		{
			try
			{
				int echo = 0;
				for (int i = 0; i < 6; i++)
				{

					Ping ping = new Ping();
					byte[] buffer = new byte[32];
					int timeout = 1000;
					PingOptions options = new PingOptions();
					PingReply reply = ping.Send(computer, timeout, buffer, options);
					if (reply.Status == IPStatus.Success)
					{
						echo++;
					}
				}
				if (echo >= 3) { return true; }
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
        
        /// <summary> Search for DNS entry by hostname
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="warn">shows a dialog warning message on fail</param>
        /// <returns></returns>
        public static bool DnsLookup(string hostname, bool warn=true)
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
                if (warn)
                {
                    System.Windows.Forms.MessageBox.Show("DNS lookup failed on: " + hostname + "\nTry flushing your DNS cache: IPCONFIG /FLUSHDNS", "DNS Lookup Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                return false;
            }
            if (host == null || host.AddressList.GetLength(0) == 0)
            {
                Console.WriteLine("No addresses availible for the hostname");
                if (warn)
                {
                    System.Windows.Forms.MessageBox.Show("DNS lookup failed on: " + hostname + "\nTry flushing your DNS cache: IPCONFIG /FLUSHDNS", "DNS Lookup Failed", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                return false;
            }
            return true;
        }




        #endregion




        #region Data Handlers


        /// <summary>
        /// Adds store to list of ignored ignores
        /// </summary>
        /// <param name="ignores"></param>
        /// <returns></returns>
        public static List<string> GetIgnoreList(string[] ignores)
        {
            List<string> value = new List<string>();
            if (ignores.Length == 0) { return value; }

            Console.Write("Stores to ignore: ");
            for (int i = 0; i < ignores.Length; i++)
            {
                string add = string.Empty;
                int store = 0;

                if (int.TryParse(ignores[i].Trim(), out store))
                {
                    add = store.ToString() + "SAP";
                    if (add.Length < 7) { add = "0" + add; }
                    Console.Write(add + " ");
                    value.Add(add);
                }
            }
            Console.WriteLine();
            return value;
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

        /// <summary>
        /// Gets datetime from string input
        /// </summary>
        /// <param name="_input">datetime as string</param>
        /// <returns></returns>
        public static DateTime GenerateDateFromString(string _input)
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




        #region EXCEL





        /// <summary> FUNCTION FOR EXPORT TO EXCEL
        /// </summary>
        /// <param name="dataTable">data to put into file</param>
        /// <param name="worksheetName">name of worksheet</param>
        /// <param name="saveAsLocation">file path to save</param>
        /// <param name="ReportType">does nothing</param>
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

        #endregion




    }
}
