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
        public static string _first { get; set; }
        public static string _second { get; set; }
        public static string _third { get; set; }
        public static string _lan1 { get; set; }
        public static string _gate1 { get; set; }
        public static string _lan2 { get; set; }
        public static string _gate2 { get; set; }
        public static string _lan3 { get; set; }
        public static string _gate3 { get; set; }
        public static string _lan4 { get; set; }
        public static string _gate4 { get; set; }
        public static string _cctv { get; set; }

		public static string mim 
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _lan4); }
        }
        public static string mim_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _gate4); }
        }
        public static string pos
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _lan1); }
        }
        public static string pos_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _gate1); }
        }

        public static string sensor
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _lan2); }
        }

        public static string sensor_gate
        {
            get { return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _gate2); }
        }

        public static string cctv
        {
            get
            {
                if (_cctv == null) { return string.Empty; }
                if (_cctv == string.Empty) { return string.Empty; }
                return string.Format("{0}.{1}.{2}.{3}", _first, _second, _third, _cctv);
            }
        }

        public static string email
        {
            get
            {
                if (store.ToString().Length < 4) { return "Store0" + store.ToString() + "@wwwinc.com"; }
                else { return "Store" + store.ToString() + "@wwwinc.com"; }
            }
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
        public static string rm { get; set; }
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

	}
}
