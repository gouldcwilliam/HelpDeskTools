using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
	/// <summary>
	/// Provides container for LDAP Attribute Value pairs
	/// </summary>
	public class Result
	{
		/// <summary>
		/// Initializes a new instance of the LDAP.Property class using the specified
		/// attribute and value
		/// </summary>
		/// <param name="Attribute">Name of LDAP attribute</param>
		/// <param name="Value">Value of LDAP attribute</param>
		public Result(string Attribute, string Value)
		{
			attribute = Attribute;
			value = Value;
		}

		private string attribute { get; set; }
		private string value { get; set; }

		/// <summary>
		/// Gets or sets the name of the LDAP Property
		/// </summary>
		public string Attribute { get { return attribute; } }

		/// <summary>
		/// LDAP Property Value
		/// </summary>
		public string Value { get { return value; } }
	}
}