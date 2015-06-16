using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
	public static class Info
	{
		/*IP*/
        public static string first { get; set; }
        public static string second { get; set; }
        public static string third { get; set; }
        public static string lan1 { get; set; }
        public static string gate1 { get; set; }
        public static string lan2 { get; set; }
        public static string gate2 { get; set; }
        public static string lan3 { get; set; }
        public static string gate3 { get; set; }
        public static string lan4 { get; set; }
        public static string gate4 { get; set; }

		public static string mim 
        {
            get { return string.Format("{0}.{1}.{2}.{3}", first, second, third, lan4); }
        }
        public static string mim_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", first, second, third, gate4); }
        }
        public static string pos
        {
            get { return string.Format("{0}.{1}.{2}.{3}", first, second, third, lan1); }
        }
        public static string pos_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", first, second, third, gate1); }
        }

        public static string sensor
        {
            get { return string.Format("{0}.{1}.{2}.{3}", first, second, third, lan2); }
        }

        public static string sensor_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", first, second, third, gate2); }
        }


		/*Global*/
		public static int store { get; set; }
		public static List<Computer> computers = new List<Computer>();
		public static System.Data.DataTable recentCalls = new System.Data.DataTable();
		public static string cashier { get; set; }

		/*Information*/
		public static string address{ get; set; }
		public static string city{ get; set; }
		public static string dm { get; set; }
		public static string email{ get; set; }
		public static string manager{ get; set; }
		public static string MP{ get; set; }
		public static string name{ get; set; }
		public static string phone{ get; set; }
		public static string state{ get; set; }
		public static string type{ get; set; }
		public static string TZ{ get; set; }
		public static string zip{ get; set; }
		public static string income{ get; set; }
		public static string rank { get; set; }
		public static string BAMS { get; set; }
		public static string SVS { get; set; }
		public static string TID1 { get; set; }
		public static string TID2 { get; set; }
		public static string TID3 { get; set; }
		public static string TID4 { get; set; }

		public static bool infoFilled
		{
			get
			{
				return (
					address != string.Empty ||
					city != string.Empty ||
					dm != string.Empty ||
					email != string.Empty ||
					manager != string.Empty ||
					MP != string.Empty ||
					name != string.Empty ||
					phone != string.Empty ||
					state != string.Empty ||
					type != string.Empty ||
					TZ != string.Empty ||
					zip != string.Empty ||
					income != string.Empty ||
					rank != string.Empty
					);
			}
		}

		public static void Clear()	
		{
            first = string.Empty;
            second = string.Empty;
            third = string.Empty;
            lan1 = string.Empty;
            lan2 = string.Empty;
            lan3 = string.Empty;
            lan4 = string.Empty;
            gate1 = string.Empty;
            gate2 = string.Empty;
            gate3 = string.Empty;
            gate4 = string.Empty;

			store = 9999;
			computers.Clear();
			recentCalls.Clear();
			cashier = string.Empty;

			address = string.Empty;
			city = string.Empty;
			dm = string.Empty;
			email = string.Empty;
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

		}
		public static bool OneSelected()
		{
			return (computers.FindAll(x => x.selected == true).Count > 0);
		}

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

	}
}
