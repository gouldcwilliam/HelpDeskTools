using System;
using System.Collections.Generic;
using System.Linq;

namespace CompareCSVtoAD
{
	class CompareCSVtoAD
	{
		[STAThread]
		static void Main(string[] args)
		{
			System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
			ofd.DefaultExt = ".csv";
			ofd.FileName = "";
			if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
			if (!System.IO.File.Exists(ofd.FileName)) { return; }

			string[,] fuckingCSV = CSVRead(ofd.FileName);

			List<string> listCSV = new List<string>();

			for (int i = 0; i < fuckingCSV.GetLength(0); i++)
			{
				listCSV.Add(fuckingCSV[i, 0].Replace("\"", "").Split('.')[0].ToLower());
			}

			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
				LDAP.ObjectClasses.Computer,
				LDAP.ObjectAttribute.ComputerName);

			List<string> listAD = new List<string>();

            LDAP.OU ou = LDAP.RetailOUs.All;

            string sStore = "";

            List<LDAP.Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName);

            if (tempResults != null)
            {
                if (tempResults.Count > 0)
                {
                    for (int i = ou.Lower; i < ou.Upper + 1; i++)
                    {
                        sStore = i.ToString();

                        while (sStore.Length < 4) { sStore = "0" + sStore; }

                        foreach (LDAP.Result item in tempResults.FindAll(x => x.Value.Contains(sStore)))
                        {
                            listAD.Add(item.Value.ToLower());
                        }
                    }
                }
            }


			List<string> InADonly = listAD.Except(listCSV).ToList();
			List<string> InCSVonly = listCSV.Except(listAD).ToList();

			System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
			sfd.DefaultExt = ".csv";
			//sfd.Filter = "*.csv | Comma Seperated Values";
			sfd.FileName = "SCOTT SAVE ME SOMEWHERE.csv";

			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using(System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
				{
					//write the random shit to file here using sw.Write & sw.writeline()
					sw.WriteLine("IN AD ONLY");
					sw.WriteLine("=========================================");
					sw.WriteLine();
					foreach (string tmp in InADonly)
					{
						sw.WriteLine(tmp);
					}

					sw.WriteLine();
					sw.WriteLine();

					sw.WriteLine("IN CSV ONLY");
					sw.WriteLine("=========================================");
					sw.WriteLine();

					foreach (string tmp in InCSVonly)
					{
						sw.WriteLine(tmp);
					}
				}
			}
		}

		public static string[,] CSVRead(string filename)
		{
			string[] tmp;
			try
			{
				string[,] retVal;
				if (System.IO.File.Exists(filename))
				{
					using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
					{
						List<string> linebyline = new List<string>();

						do
						{
							linebyline.Add(sr.ReadLine());
						} while (!sr.EndOfStream);

						int wideCount = System.Text.RegularExpressions.Regex.Split(linebyline[0], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").Length;

						retVal = new string[(linebyline.Count - 1), wideCount];

						for (int i = 1; i < linebyline.Count; i++)
						{
							tmp = System.Text.RegularExpressions.Regex.Split(linebyline[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

							for (int j = 0; j < tmp.Length; j++)
							{
								retVal[(i - 1), j] = tmp[j];
							}
						}

						return retVal;
					}
				}
				else return null;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
