using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoFinesseNET
{
    public class Team
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public List<User> users { get; set; }
    }
}
