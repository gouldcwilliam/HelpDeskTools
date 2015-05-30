using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CiscoFinesseNET
{
    public static class Init
    {
        //https://rocucccxp01:8445/desktop/container/?locale=en_US
        private const string connectURIHTTPS = "https://{0}/finesse/api/{1}";
        private const string connectURIHTTP = "http://{0}/finesse/api/{1}";

        public static Settings mainSettings = new Settings();
        private static CookieContainer cookieJar = new CookieContainer();
        private static bool isLoaded = false;

        private static System.IO.StreamWriter _sw;

        /// <summary>
        /// Loads settings for connections and the local user from disk.
        /// </summary>
        /// <returns>Pass/Fail for loading</returns>
        internal static bool LoadSettings()
        {
            try
            {
                using (StreamReader sr = new StreamReader(mainSettings.GetSaveLocation(true)))
                {
                    XmlSerializer cereal = new XmlSerializer(typeof(Settings));
                    mainSettings = cereal.Deserialize(sr) as Settings;
                }

                if (!Directory.Exists(mainSettings.GetSaveLocation(false) + @"WEBLOGGING"))
                {
                    Directory.CreateDirectory(mainSettings.GetSaveLocation(false) + @"WEBLOGGING");
                }

                isLoaded = true;
            }
            catch (Exception)
            {
                throw new ConfigurationNotCompletedException();
            }
            return isLoaded;
        }

        /// <summary>
        /// Saves settings for connections and local user to disk.
        /// </summary>
        /// <returns>Pass/Fail for saving</returns>
        public static bool SaveSettings()
        {
            try
            {
                if (!Directory.Exists(mainSettings.GetSaveLocation(false)))
                {
                    Directory.CreateDirectory(mainSettings.GetSaveLocation(false));
                }

                if (!Directory.Exists(mainSettings.GetSaveLocation(false) + @"WEBLOGGING"))
                {
                    Directory.CreateDirectory(mainSettings.GetSaveLocation(false) + @"WEBLOGGING");
                }

                using (StreamWriter sw = new StreamWriter(mainSettings.GetSaveLocation(true), false))
                {
                    XmlSerializer cereal = new XmlSerializer(typeof(Settings));
                    cereal.Serialize(sw, mainSettings);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets up Global HD specific variables and values, this should only be done ONCE per launch
        /// </summary>
        /// <returns>Success</returns>
        internal static bool GlobalHDInit()
        {
            try
            {
                //get and store the wrap up codes and reason codes
                string NRReasonCodes = PerformAPIOperation(HTTPOperation.GET, string.Format("User/{0}/ReasonCodes?category=NOT_READY", mainSettings.userName), mainSettings.loginString);
                string LOReasonCodes = PerformAPIOperation(HTTPOperation.GET, string.Format("User/{0}/ReasonCodes?category=LOGOUT", mainSettings.userName), mainSettings.loginString);
                string WUReasonCodes = PerformAPIOperation(HTTPOperation.GET, string.Format("User/{0}/WrapUpReasons", mainSettings.userName), mainSettings.loginString);

                XmlSerializer _s = new XmlSerializer(typeof(ReasonCodes));

                using (System.IO.TextReader _tr = new System.IO.StringReader(NRReasonCodes))
                {
                    Helper.NotReadyReasonCodes = _s.Deserialize(_tr) as ReasonCodes;
                }

                using (System.IO.TextReader _tr = new System.IO.StringReader(LOReasonCodes))
                {
                    Helper.LogOutReasonCodes = _s.Deserialize(_tr) as ReasonCodes;
                }

                _s = new XmlSerializer(typeof(WrapUpReasons));

                using (System.IO.TextReader _tr = new System.IO.StringReader(WUReasonCodes))
                {
                    Helper.WrapUpCodes = _s.Deserialize(_tr) as WrapUpReasons;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Performs operations on Finesse server, and returns the resulting XML.
        /// </summary>
        /// <param name="operation">HTTP Operation to perform</param>
        /// <param name="uriP2">URI portion following /api/</param>
        /// <param name="xmlData">XML Information to send</param>
        /// <returns>XML string returned by server for this operation.</returns>
        public static string PerformAPIOperation(HTTPOperation operation, string uriP2, string xmlData, string postData = "")
        {
            try
            {
                if (uriP2.ToLower().Contains("/finesse/api/"))
                {
                    //trim off the parts we are already expecting
                    uriP2 = uriP2.Split(new string[] { "/finesse/api/" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                //create webrequest, using https if set
                HttpWebRequest request = WebRequest.Create((mainSettings.useHTTPS) ? string.Format(connectURIHTTPS, mainSettings.FQDN, uriP2) : string.Format(connectURIHTTP, mainSettings.FQDN, uriP2)) as HttpWebRequest;
                request.CookieContainer = cookieJar;
                request.Method = operation.ToString();

                if (postData != string.Empty)
                {
                    //request.Headers.Add(postData);
                    request.Headers.Add("Authorization", "Basic " + postData);
                }

                if (operation != HTTPOperation.GET)
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        char[] reqData = xmlData.ToCharArray();
                        byte[] byteStream = Encoding.UTF8.GetBytes(reqData);

                        request.ContentType = "application/xml";
                        stream.Write(byteStream, 0, byteStream.Length);
                    }
                }

                //NetworkCredential credz = new NetworkCredential(mainSettings.userName, mainSettings.password);
                //request.Credentials = credz;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                HttpWebResponse resp2 = ((WebException)ex).Response as HttpWebResponse;
                string response = string.Empty;
                using(StreamReader sr = new StreamReader(resp2.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }
                using (_sw = new StreamWriter(mainSettings.GetSaveLocation(false) + @"WEBLOGGING\error.log", true))
                {
                    _sw.WriteLine(System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString());
                    _sw.WriteLine(response);
                    _sw.WriteLine();
                }

                return response;
            }
        }

        /// <summary>
        /// Performs operations on Finesse server, and returns the resulting XML.
        /// </summary>
        /// <param name="operation">HTTP Operation to perform</param>
        /// <param name="uriP2">URI portion following /api/</param>
        /// <param name="xmlData">XML Information to send</param>
        /// <returns>XML string returned by server for this operation.</returns>
        public static string PerformAPIOperation(HTTPOperation operation, string uriP2, string xmlData, out HttpWebResponse response, string postData = "")
        {
            try
            {
                if (uriP2.ToLower().Contains("/finesse/api/"))
                {
                    //trim off the parts we are already expecting
                    uriP2 = uriP2.Split(new string[] { "/finesse/api/" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                //create webrequest, using https if set
                HttpWebRequest request = WebRequest.Create((mainSettings.useHTTPS) ? string.Format(connectURIHTTPS, mainSettings.FQDN, uriP2) : string.Format(connectURIHTTP, mainSettings.FQDN, uriP2)) as HttpWebRequest;
                request.CookieContainer = cookieJar;
                request.Method = operation.ToString();

                if (postData != string.Empty)
                {
                    //request.Headers.Add(postData);
                    request.Headers.Add("Authorization", "Basic " + postData);
                }

                if (operation != HTTPOperation.GET)
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        char[] reqData = xmlData.ToCharArray();
                        byte[] byteStream = Encoding.UTF8.GetBytes(reqData);

                        request.ContentType = "application/xml";
                        stream.Write(byteStream, 0, byteStream.Length);
                    }
                }

                //NetworkCredential credz = new NetworkCredential(mainSettings.userName, mainSettings.password);
                //request.Credentials = credz;

                response = request.GetResponse() as HttpWebResponse;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                response = ((WebException)ex).Response as HttpWebResponse;
                string _response = string.Empty;
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    _response = sr.ReadToEnd();
                }
                using (_sw = new StreamWriter(mainSettings.GetSaveLocation(false) + @"WEBLOGGING\error.log", true))
                {
                    _sw.WriteLine(System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString());
                    _sw.WriteLine(response);
                    _sw.WriteLine();
                }

                return _response;
            }
        }
    }

    public enum HTTPOperation
    {
        GET,
        PUT,
        POST,
        DELETE
    }
}
