using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD.Classes
{
	/// <summary>
	/// Holds SQL Topic Information
	/// </summary>
	public class Topic
	{
		/// <summary>
		/// Call Wrap up Topic
		/// </summary>
		public Topic()
		{
			_id = 0;
			_topic = "";
			_catId = 0;
			_mandatory = false;
			_active = false;
		}
		/// <summary>
		/// Call Wrap up Topic
		/// </summary>
		/// <param name="id">SQL unique id</param>
		/// <param name="topic">name of the topic</param>
		/// <param name="catId">SQL category id of owner</param>
		/// <param name="mandatory">Are details needed during wrap up</param>
		/// <param name="active">Is this topic in use</param>
		public Topic(int id, string topic, int catId, bool mandatory, bool active)
		{
			_id = id;
			_topic = topic;
			_catId = catId;
			_mandatory = mandatory;
			_active = active;
		}
		/// <summary>
		/// SQL unique id
		/// </summary>
		public int _id;
		/// <summary>
		/// name of the topic
		/// </summary>
		public string _topic;
		/// <summary>
		/// SQL category id of owner
		/// </summary>
		public int _catId;
		/// <summary>
		/// Are details needed during wrap up
		/// </summary>
		public bool _mandatory;
		/// <summary>
		/// Is this topic in use
		/// </summary>
		public bool _active;
	}
}
