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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
