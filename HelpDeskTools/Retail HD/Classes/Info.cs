using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Shared;

namespace Retail_HD
{
    /// <summary>
    /// Store information object
    /// </summary>
	public static class Info
	{

        #region Basic Info

        /// <summary>
        /// store number
        /// </summary>
        public static int store { get; set; }
        /// <summary>
        /// cashier number
        /// </summary>
		public static string cashier { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string email
		{
			get
			{
				if (store.ToString().Length < 4) { return "Store0" + store.ToString() + "@wwwinc.com"; }
				else { return "Store" + store.ToString() + "@wwwinc.com"; }
			}
		}
        /// <summary>
        /// 
        /// </summary>
		public static string address{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string city{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string dm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string rm { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string manager{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string MP{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string name{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string phone{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string state{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string type{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string TZ{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string zip{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string income{ get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string BAMS { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string SVS { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string TID1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string TID2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public static string TID3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string TID4 { get; set; }

        #endregion

        #region Raw SQL IP Info

        /// <summary>
        /// first octet
        /// </summary>
        public static string _first { get; set; }
        /// <summary>
        /// second octet
        /// </summary>
        public static string _second { get; set; }
        /// <summary>
        /// third octet
        /// </summary>
        public static string _third { get; set; }
        /// <summary>
        /// POS' lan 4th octet
        /// </summary>
        public static string _lan1 { get; set; }
        /// <summary>
        /// POS' gateway 4th octet
        /// </summary>
        public static string _gate1 { get; set; }
        /// <summary>
        /// Traffic counter lan 4th octet
        /// </summary>
        public static string _lan2 { get; set; }
        /// <summary>
        /// Traffic counter gateway 4th octet
        /// </summary>
        public static string _gate2 { get; set; }
        /// <summary>
        /// Unused lan 4th octet
        /// </summary>
        public static string _lan3 { get; set; }
        /// <summary>
        /// Unused gateway 4th octet
        /// </summary>
        public static string _gate3 { get; set; }
        /// <summary>
        /// Handheld lan 4th octet
        /// </summary>
        public static string _lan4 { get; set; }
        /// <summary>
        /// Handheld gateway 4th octet
        /// </summary>
        public static string _gate4 { get; set; }

        #endregion


        #region Constructed IP Info

        /// <summary>
        /// ip string
        /// </summary>
        public static string mim
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _lan4); }
        }
        /// <summary>
        /// ip string
        /// </summary>
        public static string mim_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _gate4); }
        }
        /// <summary>
        /// ip string
        /// </summary>
        public static string pos
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _lan1); }
        }
        /// <summary>
        /// ip string
        /// </summary>
        public static string pos_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}.", _first, _second, _third, _gate1); }
        }
        /// <summary>
        /// ip string
        /// </summary>
        public static string sensor
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _lan2); }
        }
        /// <summary>
        /// ip string
        /// </summary>
        public static string sensor_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _gate2); }
        }
        /// <summary>
        /// ip string
        /// </summary>
		public static string cctv { get; private set; }
        /// <summary>
        /// ip string
        /// </summary>
        public static string lan3
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _gate3); }
        }

        #endregion


        #region Store Information Lists

        /// <summary>
        /// Store's computers
        /// </summary>
        public static List<Computer> computers = new List<Computer>();
        /// <summary>
        /// Selected computers
        /// </summary>
		public static List<Computer> selectedComputers
		{
			get
			{
				// set list to all selected computers
				List<Computer> selectedList = Info.computers.FindAll(x => x.selected == true);

				// if no computers are selected
				if (selectedList.Count == 0)
				{
					// single computer
					if (Info.computers.Count == 1) { selectedList = Info.computers; }
					else
					{
						// confirmation form for multiple registers
						Forms.Confirm confirm = new Forms.Confirm("Perform on all computers?", "No computers selected", true);
						// all computers if ok is clicked
						if (confirm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { selectedList = Info.computers; }
						// no computers
						else { selectedList = new List<Computer>(); }
					}
				}

				
				return selectedList;
			}
		}
		/// <summary>
		/// Wrap up categories
		/// </summary>
		public static List<Classes.Category> categories = new List<Classes.Category>();
		/// <summary>
		/// Wrap up topics
		/// </summary>
		public static List<Classes.Topic> topics = new List<Classes.Topic>();
		/// <summary>
		/// Technicians
		/// </summary>
		public static List<Classes.Technician> technicians = new List<Classes.Technician>();
		/// <summary>
		/// Store's call history
		/// </summary>
		public static System.Data.DataTable recentCalls = new System.Data.DataTable();
        /// <summary>
        /// Stores persistant notes
        /// </summary>
		public static System.Data.DataTable notes = new System.Data.DataTable();

        #endregion

        /************************************************************************************/



        /// <summary>
        /// Clears all Info
        /// </summary>
        public static void Clear()	
		{
            _first = string.Empty;
            _second = string.Empty;
            _third = string.Empty;
            _lan1 = string.Empty;
            _lan2 = string.Empty;
            _lan3 = string.Empty;
            _lan4 = string.Empty;
            _gate1 = string.Empty;
            _gate2 = string.Empty;
            _gate3 = string.Empty;
            _gate4 = string.Empty;

			store = 9999;
			computers.Clear();
			recentCalls.Clear();
			cashier = string.Empty;

			address = string.Empty;
			city = string.Empty;
			dm = string.Empty;
			manager = string.Empty;
			MP = string.Empty;
			name = string.Empty;
			phone = string.Empty;
			state = string.Empty;
			type = string.Empty;
			TZ = string.Empty;
			zip = string.Empty;
			income = string.Empty;
			rank = string.Empty;

			BAMS = string.Empty;
			SVS = string.Empty;
			TID1 = string.Empty;
			TID2 = string.Empty;
			TID3 = string.Empty;
			TID4 = string.Empty;

			categories = new List<Classes.Category>();
		}


		/// <summary>
		/// Returns true if at least one is selected
		/// </summary>
		/// <returns></returns>
		public static bool OneSelected()
		{
			return (computers.FindAll(x => x.selected == true).Count > 0);
		}


		/// <summary>
		/// Returns register 1 from the list
		/// </summary>
		public static string reg1
		{
			get
			{
				try
				{
					return Info.computers.Find(x => x.name.Contains("SAP1")).name;
				}
				catch (Exception)
				{
					return string.Empty;
				}
			}
		}


		/// <summary>
		/// Prints all of the info
		/// </summary>
        public static void Debug()
        {
			string computer = "";
            for (int i = 0; i < computers.Count; i++)
            {
                computer += " | computer " + (i + 1).ToString() + " : " + computers[i].name;
            }
            Console.WriteLine(
            " | store: " + store +
            computer +
            " | cashier: " + cashier + "\n" +

            " | address: " + address +
            " | city: " + city +
            " | state: " + state +
            " | zip: " + zip +
            " | TZ: " + TZ + "\n" +
            " | phone: " + phone +
            " | email: " + email +
            " | name: " + name +
            " | type: " + type + "\n" +
            " | dm: " + dm +
            " | manager: " + manager +
            " | MP: " + MP +
            " | income: " + income +
            " | rank: " + rank + "\n" +

            " | BAMS: " + BAMS +
            " | SVS: " + SVS +
            " | TID1: " + TID1 +
            " | TID2: " + TID2 +
            " | TID3: " + TID3 +
            " | TID4: " + TID4 + "\n" +
            " | first: " + _first +
            " | second: " + _second +
            " | third: " + _third +
            " | lan1: " + _lan1 +
            " | lan2: " + _lan2 +
            " | lan3: " + _lan3 +
            " | lan4: " + _lan4 +
            " | gate1: " + _gate1 +
            " | gate2: " + _gate2 +
            " | gate3: " + _gate3 +
            " | gate4: " + _gate4 + "\n"
            );
        }


		/// <summary>
		/// Retrieve store's information
		/// </summary>
		/// <returns></returns>
		public static bool GetStoreInfo()
		{
			try
			{
				foreach (System.Data.DataRow dr in Shared.SQL.dt_SelectStore(Info.store).Rows)
				{
					Info.phone = dr["phone"].ToString();
					Info.address = dr["address"].ToString();
					Info.city = dr["city"].ToString();
					Info.state = dr["state"].ToString();
					Info.zip = dr["zip"].ToString();
					Info.TZ = dr["TZ"].ToString();
					Info.dm = dr["dm"].ToString();
					Info.rm = dr["rm"].ToString();
					Info.manager = dr["manager"].ToString();
					Info.MP = dr["MP"].ToString();
					Info.name = dr["name"].ToString();
					Info.type = dr["type"].ToString();

					Info._first = dr["1st"].ToString();
					Info._second = dr["2nd"].ToString();
					Info._third = dr["3rd"].ToString();

					Info._lan1 = dr["lan1"].ToString();
					Info._lan2 = dr["lan2"].ToString();
					Info._lan3 = dr["lan3"].ToString();
					Info._lan4 = dr["lan4"].ToString();

					Info._gate1 = dr["gate1"].ToString();
					Info._gate2 = dr["gate2"].ToString();
					Info._gate3 = dr["gate3"].ToString();
					Info._gate4 = dr["gate4"].ToString();

					Info.cctv = dr["cctv"].ToString();

					Info.income = dr["income"].ToString();
					Info.rank = dr["rank"].ToString();

					Info.BAMS = dr["BAMS"].ToString();
					Info.SVS = dr["SVS"].ToString();

					Info.TID1 = dr["TID1"].ToString();
					Info.TID2 = dr["TID2"].ToString();
					Info.TID3 = dr["TID3"].ToString();
					Info.TID4 = dr["TID4"].ToString();

				}
			}
			catch (Exception ex) { Console.WriteLine("fillStoreInfo : Store Info query\n" + ex.Message + ex.InnerException); return false; }

			return true;
		}


		/// <summary>
		/// Retrieve store's computer list
		/// </summary>
		/// <returns></returns>
		public static bool GetComputers()
		{
			try
			{
				foreach (System.Data.DataRow dr in Shared.SQL.dt_SelectComputers(Info.store).Rows)
				{
					Info.computers.Add(new Computer(dr["computer"].ToString().ToUpper()));
				}
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}


		/// <summary>
		/// Retrive store's recent calls
		/// </summary>
		/// <returns></returns>
		public static bool GetRecentCalls()
		{
			List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
			parameters.Add(new System.Data.SqlClient.SqlParameter("@store", store.ToString()));

            try { recentCalls = Shared.SQL.Select(Shared.SQLSettings.Default._RecentCallsByStore, parameters); return true; }
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}


		/// <summary>
		/// Retrive list of wrap up categories
		/// </summary>
		/// <returns></returns>
		public static bool GetCategories()
		{
			foreach (System.Data.DataRow dr in Shared.SQL.Select("select * from [Categories]").Rows)
			{
				categories.Add(new Classes.Category((int)dr[0], dr[1].ToString()));
			}
			return (categories.Count > 0);
		}


		/// <summary>
		/// Retrive list of wrap up topics
		/// </summary>
		/// <returns></returns>
		public static bool FillTopics()
		{
			foreach(System.Data.DataRow dr in Shared.SQL.Select("select * from [Topics]").Rows)
			{
				Info.topics.Add(new Classes.Topic((int)dr["id"], dr["topic"].ToString(), (int)dr["catID"], (bool)dr["mandatory"], (bool)dr["active"]));
			}
			return (topics.Count > 0);
		}


		/// <summary>
		/// Retrive list of technician names 
		/// </summary>
		/// <returns></returns>
		public static bool FillTechnicians()
		{
			foreach (System.Data.DataRow dr in Shared.SQL.Select("select * from [Technicians]").Rows)
			{
				technicians.Add(new Classes.Technician((int)dr["id"], dr["technician"].ToString(), dr["full_name"].ToString(), dr["initials"].ToString()));
			}
			return (technicians.Count > 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool FillNotes()
		{
			List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
			parameters.Add(new System.Data.SqlClient.SqlParameter("@store", store.ToString()));

			try { notes = Shared.SQL.Select("Select * from [Notes] where store=@STORE order by resolved", parameters);return true; }
			catch(Exception ex) { Console.WriteLine(ex.Message);return false; }
		}
	}
}
