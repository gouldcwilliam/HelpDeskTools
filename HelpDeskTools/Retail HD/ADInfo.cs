using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
    public class LDAPInfo
    {
        private string psAttribute;
        private string psValue;

        public string sAttribute
        {
            get { return psAttribute; }
            set { psAttribute = value; }
        }
        public string sValue {
            get { return psValue; }
            set { psValue = value; }
        }

        public LDAPInfo()
        {
            this.sAttribute = string.Empty;
            this.sValue = string.Empty;
        }

        public LDAPInfo(string attribute, string value)
        {
            this.sAttribute = attribute;
            this.sValue = value;
        }
    }

}
