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
    /// <summary>
    /// "Splash image"
    /// </summary>
    public partial class Splash : Form
    {
        /// <summary>
        /// <see cref="Splash"/>
        /// </summary>
        public Splash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// <see cref="Splash"/>
        /// </summary>
        /// <param name="bitmap"></param>
        public Splash(Bitmap bitmap)
        {
            InitializeComponent();
            pictureBox1.Image = bitmap;
        }
        

        private void timer()
        {
            Cursor oCursor = Cursor;
            Cursor = Cursors.AppStarting;
            System.Threading.Thread.Sleep(15000);
            this.Close();
        }



        private void Splash_Shown(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 2500;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
