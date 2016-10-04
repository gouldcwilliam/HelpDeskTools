using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
    public partial class StoreInfoAddEdit : Form
    {
        bool changesMade;
        bool newStore;
        public StoreInfoAddEdit()
        {
            
            InitializeComponent();
            textBoxName.Text = Info.name;
            textBoxStore.Text = Info.store.ToString();
            textBoxStore.ReadOnly = true;
            textBoxAddress.Text = Info.address;
            textBoxCity.Text = Info.city;
            textBoxState.Text = Info.state;
            comboBoxTimeZone.Text = Info.TZ;
            textBoxFirst.Text = Info._first;
            textBoxSecond.Text = Info._second;
            textBoxThird.Text = Info._third;
            textBoxPOS.Text = Info._lan1;
            textBoxSensor.Text = Info._lan2;
            textBoxLAN3.Text = Info._lan3;
            textBoxMIM.Text = Info._lan4;
            textBoxPOSGate.Text = Info._gate1;
            textBoxSensorGate.Text = Info._gate2;
            textBoxLan3Gate.Text = Info._gate3;
            textBoxMIMGate.Text = Info._gate4;
            textBoxGTT.Text = Info.MP;
            textBoxSVS.Text = Info.SVS;
            textBoxBAMS.Text = Info.BAMS;
            textBoxTID1.Text = Info.TID1;
            textBoxTID2.Text = Info.TID2;
            textBoxTID3.Text = Info.TID3;
            textBoxTID4.Text = Info.TID4;
            textBoxCCTV1.Text = Info.cctv;
            textBoxType.Text = Info.type;
            textBoxManager.Text = Info.manager;
            textBoxDM.Text = Info.dm;
            textBoxRM.Text = Info.rm;


            System.Data.DataTable dt = Shared.SQL.Select("select * from stores where store=" + Info.store.ToString());
            if (dt.Rows.Count > 0)
            {
                Text += " - Edit Store";
                newStore = false;

            }
            else
            {
                Text += " - New Store";
                newStore = true;
                if (Info.store != 0) { textBoxStore.Text = Info.store.ToString(); }
            }
            //textBoxPhones.Text = Info.phone;
            dt = Shared.SQL.Select("select * from phones where store=" + Info.store.ToString() + " order by [line]");
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    textBoxPhones.Text += dr[0].ToString()+Environment.NewLine;
                }
            }

            // Debug info
            if (System.Diagnostics.Debugger.IsAttached)
            {
                //Console.WriteLine("New Store: {0}", newStore);
            }
            changesMade = false;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (changesMade)
            {
                string sql = "";
                if(newStore)
                {
                    sql = string.Format("insert into [Stores] ([name],[store],[address],[city],[state],[TZ],[1st],[2nd],[3rd],[lan1],[lan2],[lan3],[lan4],[gate1],[gate2],[gate3],[gate4],[MP],[SVS],[BAMS],[TID1],[TID2],[TID3],[TID4],[cctv],[type],[manager],[dm],[rm]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}')",
                        textBoxName.Text, textBoxStore.Text, textBoxAddress.Text, textBoxCity.Text, textBoxState.Text, comboBoxTimeZone.Text, textBoxFirst.Text, textBoxSecond.Text,textBoxThird.Text,textBoxPOS.Text,textBoxSensor.Text,textBoxLAN3.Text,
                        textBoxMIM.Text,textBoxPOSGate.Text,textBoxSensorGate.Text,textBoxLan3Gate.Text,textBoxMIMGate.Text,textBoxGTT.Text, textBoxSVS.Text, textBoxBAMS.Text,textBoxTID1.Text,textBoxTID2.Text,textBoxTID3.Text,textBoxTID4.Text,
                        textBoxCCTV1.Text, textBoxType.Text, textBoxManager.Text,textBoxDM.Text,textBoxRM.Text
                        );
                    //Console.WriteLine(sql);
                    Console.WriteLine(Shared.SQL.Insert(sql));
                    //foreach (string phone in textBoxPhones.Text.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                    //{
                    //    Shared.SQL.Insert(string.Format("insert into [Phones]([phone],[store]) values ('{0}','{1}')", textBoxStore.Text, phone));
                    //    Console.WriteLine(phone);
                    //}
                }
                else
                {
                    sql = string.Format("update [Stores] set [name]='{0}',[address]='{2}',[city]='{3}',[state]='{4}',[TZ]='{5}',[1st]='{6}',[2nd]='{7}',[3rd]='{8}',[lan1]='{9}',[lan2]='{10}',[lan3]='{11}',[lan4]='{12}',[gate1]='{13}',[gate2]='{14}',[gate3]='{15}',[gate4]='{16}',[MP]='{17}',[SVS]='{18}',[BAMS]='{19}',[TID1]='{20}',[TID2]='{21}',[TID3]='{22}',[TID4]='{23}',[cctv]='{24}',[type]='{25}',[manager]='{26}',[dm]='{27}',[rm]='{28}' where store='{1}'",
                        textBoxName.Text, textBoxStore.Text, textBoxAddress.Text, textBoxCity.Text, textBoxState.Text, comboBoxTimeZone.Text, textBoxFirst.Text, textBoxSecond.Text, textBoxThird.Text, textBoxPOS.Text, textBoxSensor.Text, textBoxLAN3.Text,
                        textBoxMIM.Text, textBoxPOSGate.Text, textBoxSensorGate.Text, textBoxLan3Gate.Text, textBoxMIMGate.Text, textBoxGTT.Text, textBoxSVS.Text, textBoxBAMS.Text, textBoxTID1.Text, textBoxTID2.Text, textBoxTID3.Text, textBoxTID4.Text,
                        textBoxCCTV1.Text, textBoxType.Text, textBoxManager.Text, textBoxDM.Text, textBoxRM.Text
                        );
                    //Console.WriteLine(sql);
                    Console.WriteLine(Shared.SQL.Insert(sql));
                    //Shared.SQL.Delete(string.Format("delete from [phones] where [store]='{0}'", textBoxStore.Text));
                    //foreach (string phone in textBoxPhones.Text.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                    //{
                    //    Shared.SQL.Insert(string.Format("insert into [Phones]([phone],[store]) values ('{0}','{1}')", textBoxStore.Text, phone));
                    //    Console.WriteLine(phone);
                    //}
                }
            }
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("Changes Made: {0}", changesMade);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox_Changed(object sender, EventArgs e)
        {
            changesMade = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
