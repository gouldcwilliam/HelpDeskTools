namespace CiscoFinesseNET
{
	public class CiscoSettings
    {
        public string s_AgentACD { get; set; }
        public string s_AgentPassword { get; set; }
        public string s_AgentUsername { get; set; }

        public CiscoSettings()
        {
            s_AgentACD = string.Empty;
            s_AgentPassword = string.Empty;
            s_AgentUsername = string.Empty;
        }
    }
}
