using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD.Classes
{
    /// <summary>
    /// Cisco settings object
    /// </summary>
    public class CiscoSettings
    {
        /// <summary>
        /// ACD
        /// </summary>
        public string s_AgentACD { get; set; }
        /// <summary>
        /// password
        /// </summary>
        public string s_AgentPassword { get; set; }
        /// <summary>
        /// domain username
        /// </summary>
        public string s_AgentUsername { get; set; }
        /// <summary>
        /// create's new object
        /// </summary>
        public CiscoSettings()
        {
            s_AgentACD = string.Empty;
            s_AgentPassword = string.Empty;
            s_AgentUsername = string.Empty;
        }
    }

}
