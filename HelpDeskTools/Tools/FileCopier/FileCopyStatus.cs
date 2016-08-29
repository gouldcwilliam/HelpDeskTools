using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopier
{
    public partial class FileCopyStatus : Form
    {

        public string _computer { get { return this.textBoxComputer.Text; } set { this.textBoxComputer.Text = value; } }
        public FileCopyStatus()
        {
            InitializeComponent();
        }
    }
}
