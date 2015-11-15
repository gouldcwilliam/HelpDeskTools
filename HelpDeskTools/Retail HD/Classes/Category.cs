using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD.Classes
{
	/// <summary>
	/// holds SQL Category Information
	/// </summary>
	public class Category
	{
		/// <summary>
		/// Call Wrap up category
		/// </summary>
		public Category()
		{
			_id = 0;
			_category = "";
		}
		/// <summary>
		/// Call Wrap up category
		/// </summary>
		/// <param name="id">SQL unique id</param>
		/// <param name="category">name of the category</param>
		public Category(int id, string category)
		{
			_id = id; _category = category;
		}
		/// <summary>
		/// Call Wrap up category
		/// </summary>
		/// <param name="category">name of the category</param>
		/// <param name="id">SQL unique id</param>
		public Category(string category, int id)
		{
			_id = id; _category = category;
		}
		/// <summary>
		/// SQL unique id
		/// </summary>
		public int _id;
		/// <summary>
		/// name of the category
		/// </summary>
		public string _category;
	}
}
