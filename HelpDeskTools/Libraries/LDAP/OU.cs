using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
	/// <summary>
	/// Active Directory query parameters
	/// </summary>
	public class OU
	{
		/// <summary>
		/// Initializes a new instance of the LDAP.OU class using
		/// the specified search root and store range low and high values
		/// </summary>
		/// <param name="baseOU">Store type's base LDAP root</param>
		/// <param name="ComputerOU">Computer LDAP root</param>
		/// <param name="UserOU">User LDAP root</param>
		/// <param name="Lower">lower bound store number range</param>
		/// <param name="Upper">upper bound store number range</param>
		public OU(string baseOU, string ComputerOU, string UserOU, int Lower, int Upper)
		{
			baseOU = BaseOU;
			computerOU = ComputerOU;
			userOU = UserOU;
			lower = Lower;
			upper = Upper;
		}
        /// <summary>
        /// Initializes a new instance of the LDAP.OU class using
        /// the specified search root and store range low and high values
        /// </summary>
        /// <param name="Name">Common name of OU</param>
        /// <param name="baseOU">Store type's base LDAP root</param>
        /// <param name="ComputerOU">Computer LDAP root</param>
        /// <param name="UserOU">User LDAP root</param>
        /// <param name="Lower">lower bound store number range</param>
        /// <param name="Upper">upper bound store number range</param>
        public OU(string Name,string baseOU, string ComputerOU, string UserOU, int Lower, int Upper)
        {
            name = Name;
            baseOU = BaseOU;
            computerOU = ComputerOU;
            userOU = UserOU;
            lower = Lower;
            upper = Upper;
        }
        private string name { get; set; }
		private string baseOU { get; set; }
		private string computerOU { get; set; }
		private string userOU { get; set; }
		private int lower { get; set; }
		private int upper { get; set; }

        /// <summary>
        /// Common name of OU
        /// </summary>
        public string Name { get { return name; } }

		/// <summary>
		/// Gets the store types base LDAP search root
		/// </summary>
		public string BaseOU { get { return baseOU; } }

		/// <summary>
		/// Gets the computer LDAP search root
		/// </summary>
		public string ComputerOU { get { return computerOU; } }

		/// <summary>
		/// Gets the user LDAP search root
		/// </summary>
		public string UserOU { get { return userOU; } }

		/// <summary>
		/// Gets lower bound of store number range
		/// </summary>
		public int Lower { get { return lower; } }

		/// <summary>
		/// Gets upper bound of store number range
		/// </summary>
		public int Upper { get { return upper; } }
	}
}