using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Shared.Config
{
	/// <summary> Config containing user specifig settings
	/// </summary>
	public class PerUser
	{

		// MIGRATE - Replace the settings.default versions of these configs


		/// <summary> Public initializer to ensure defaults are set
		/// </summary>
		public PerUser()
		{
			FormStart = _FormStart;
			FormSize = _FormSize;
			ShownInAgentStatus = _ShownInAgentStatus;
			ShowLoggedOutUsers = _ShowLoggedOutUsers;
			AutoReady = _AutoReady;
			AutoLogin = _AutoLogin;
		}


		/// <summary> Relative path to config
		/// </summary>
		public const string configPath = @"user.config";


		private static System.Drawing.Point _FormStart = new System.Drawing.Point(200, 200);
		private static System.Drawing.Size _FormSize = new System.Drawing.Size(764, 477);
		private static bool _ShownInAgentStatus = true;
		private static bool _ShowLoggedOutUsers = false;
		private static bool _AutoReady = true;
		private static bool _AutoLogin = true;


		/// <summary> Starting point of the forms location
		/// </summary>
		public System.Drawing.Point FormStart { get; set; }
		/// <summary> Start size of the form
		/// </summary>
		public System.Drawing.Size FormSize { get; set; }
		/// <summary> user in status
		/// </summary>
		public bool ShownInAgentStatus { get; set; }
		/// <summary> logged out ppl in status
		/// </summary>
		public bool ShowLoggedOutUsers { get; set; }
		/// <summary> change state to ready after calls
		/// </summary>
		public bool AutoReady { get; set; }
		/// <summary> log in to finesse on load
		/// </summary>
		public bool AutoLogin { get; set; }




		/// <summary> Read config file into class
		/// </summary>
		/// <returns></returns>
		public static PerUser Load()
		{
			if (!File.Exists(configPath)) 
			{
				PerUser newPerUser = new PerUser();
				newPerUser.Save();
			}

			XmlSerializer xs = new XmlSerializer(typeof(PerUser));
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(configPath);
				return (PerUser)xs.Deserialize(sr);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Unable to load " + configPath + ", reverting to defaults", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Console.WriteLine(ex.Message);
				return new PerUser(); 
			}
			finally 
			{
				if (sr != null) { sr.Close(); sr.Dispose(); }
			}
		}

		/// <summary> Writes the config to file
		/// </summary>
		public bool Save()
		{
			XmlSerializer xs = new XmlSerializer(typeof(PerUser));
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(configPath);
				xs.Serialize(sw, this);
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Unable to save " + configPath + ", check file name/path", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Console.WriteLine(ex.Message);
				return false;
			}
			finally
			{
				if (sw != null) { sw.Close(); sw.Dispose(); }
			}
		}
	}
}
