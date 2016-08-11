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
            textBoxPhones.Text = Info.phone;
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

            /*
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
            */

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
                
            }
            /*
                UPDATE MyTable SET FieldA=@FieldA WHERE Key=@Key
                IF @@ROWCOUNT = 0
                INSERT INTO MyTable(FieldA) VALUES(@FieldA)
            */
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("Changes Made: {0}", changesMade);
            }
        }

        private void textBox_Changed(object sender, EventArgs e)
        {
            changesMade = true;
        }

    }
}
