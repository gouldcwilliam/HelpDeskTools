using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
	/// <summary>
	/// Container for ldap Attribute Value pairs
	/// </summary>
	class LDAPInfo
	{
		public LDAPInfo(string attribute, string value)
		{
			this._attribute = attribute;
			this._value = value;
		}

		string _attribute;
		string _value;

		public string Attribute
		{
			get { return this._attribute; }
		}
		public string Value
		{
			get { return this._value; }
		}
	}
}
