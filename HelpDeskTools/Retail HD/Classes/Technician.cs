using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD.Classes
{
	/// <summary>
	/// Contains properties of a technician
	/// </summary>
	public class Technician
	{
		/// <summary>
		/// Initialize blank
		/// </summary>
		public Technician()
		{
			_id = 0; _technician = "";_full_name = ""; _initials = "";
		}
		/// <summary>
		/// Initialize and set properties of Technician
		/// </summary>
		/// <param name="id">sql unique id</param>
		/// <param name="technician">network logon name (IN UPPERCAE)</param>
		/// <param name="full_name">tech's first and last name</param>
		/// <param name="initials">no explain</param>
		public Technician(int id, string technician, string full_name, string initials)
		{
			_id = id;
			_technician = technician;
			_full_name = full_name;
			_initials = initials;
		}
		/// <summary>
		/// SQL unique id
		/// </summary>
		public int _id;
		/// <summary>
		/// network logon name (IN UPPERCAE)
		/// </summary>
		public string _technician
		{
			get { return technician.ToUpper(); }
			set { technician = value.ToUpper(); }
		}
		string technician;
		/// <summary>
		/// tech's first and last name
		/// </summary>
		public string _full_name;
		/// <summary>
		/// no explain
		/// </summary>
		public string _initials;
	}
}
