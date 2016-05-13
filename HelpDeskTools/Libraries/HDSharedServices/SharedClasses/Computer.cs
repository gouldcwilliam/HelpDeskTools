using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	/// <summary>
	/// String bool object
	/// </summary>
	public class Computer
	{
		/// <summary>
		/// Creates new computer object
		/// </summary>
		/// <param name="name"></param>
		/// <param name="selected"></param>
		public Computer(string name, bool selected = false)
		{
			this.name = name;
			this.selected = selected;
		}

		/// <summary>
		/// name of computer
		/// </summary>
		public string name { get; set; }
		/// <summary>
		/// bool of selected
		/// </summary>
		public bool selected { get; set; }

		/// <summary>
		/// allow casting of Computer as a string
		/// </summary>
		/// <param name="c"></param>
		public static implicit operator string(Computer c)
		{
			return c.name;
		}
		/// <summary>
		/// allow casting of string as a Computer
		/// </summary>
		/// <param name="c"></param>
		public static implicit operator Computer(string c)
		{
			return new Computer(c);
		}

	}
}
