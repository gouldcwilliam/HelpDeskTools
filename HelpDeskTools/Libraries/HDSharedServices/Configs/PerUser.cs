using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace Shared.Config
{
	/// <summary> Config containing user specifig settings
	/// </summary>
	public class PerUser
	{
		/// <summary> Relative path to config
		/// </summary>
		public const string configPath = @"user.config";


		// MIGRATE - Replace the settings.default versions of these configs
		


		public System.Drawing.Point FormStart { get; set; }
		public System.Drawing.Size FormSize { get; set; }
		public bool ShownInAgentStatus { get; set; }
		public bool ShowLoggedOutUsers { get; set; }
		public bool AutoReady { get; set; }
		public bool AutoLogin { get; set; }


		/// <summary> Read config file into class
		/// </summary>
		/// <returns></returns>
		public static PerUser Load()
		{
			XmlSerializer xs = new XmlSerializer(typeof(PerUser));
			using (StreamReader sr = new StreamReader(configPath))
			{
				return (PerUser)xs.Deserialize(sr);
			}
		}

		/// <summary> Writes the config to file
		/// </summary>
		public void Save()
		{
			XmlSerializer xs = new XmlSerializer(typeof(PerUser));
			using (StreamWriter sw = new StreamWriter(configPath))
			{
				xs.Serialize(sw, this);
			}
		}
	}
}
