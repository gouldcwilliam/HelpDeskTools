using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
	public class Computer
	{
		public Computer(string name)
		{
			this.name = name;
			this.selected = false;
		}
		public Computer(string name, bool selected)
		{
			this.name = name;
			this.selected = selected;
		}

		public string name { get; set; }
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
