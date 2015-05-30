using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoFinesseNET
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Queues
    {

        private QueuesQueue[] queueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Queue")]
        public QueuesQueue[] Queue
        {
            get
            {
                return this.queueField;
            }
            set
            {
                this.queueField = value;
            }
        }
    }

    public class QueuesQueue
    {
        private string _uri;

        public string uri 
        {
            get
            {
                return _uri;
            }
            set
            {
                string[] tmp = value.Split('/');
                id = tmp[tmp.Length - 1];
                _uri = value;
            }
        }
        public string id { get; set; }
        public string name { get; set; }
        public Statistics statistics { get; set; }
    }

    public class Statistics
    {
        public int callsInQueue { get; set; }
        public string startTimeOfLongestCallInQueue { get; set; }
        public int agentsReady { get; set; }
        public int agentsNotReady { get; set; }
        public int agentsTalkingInbound { get; set; }
        public int agentsTalkingOutbound { get; set; }
        public int agentsTalkingInternal { get; set; }
        public int agentsWrapUpNotReady { get; set; }
        public int agentsWrapUpReady { get; set; }
    }
}
