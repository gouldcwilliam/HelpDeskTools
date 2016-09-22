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
    public partial class WaitingTask : Form
    {

        List<string> _computers = new List<string>();
        List<string> _files = new List<string>();
        string _message = "";
        int _prog = 0;
        DateTime _startTime;
        string _body = Properties.Settings.Default._EmailHeader;


        public WaitingTask(List<string> Computers, List<string> Files, DateTime StartTime)
        {
            InitializeComponent();

            _computers = Computers;
            _files = Files;
            _startTime = StartTime;

            bgwFileCopy.WorkerSupportsCancellation = true;
            bgwFileCopy.WorkerReportsProgress = true;

            bgwFileCopy.RunWorkerAsync();

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (bgwFileCopy.WorkerSupportsCancellation == true)
            {
                bgwFileCopy.CancelAsync();
            }
        }


        private void backgroundWorkerTask_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            string start = DateTime.Now.ToString();
            Console.WriteLine(start);
            Console.WriteLine(_startTime);
            while (_startTime >= DateTime.Now)
            {
                if ((worker.CancellationPending == true)) { e.Cancel = true; break; }
                System.Threading.Thread.Sleep(500);
                _message = "Waiting until " + _startTime;
                if (textBox1.Text != _message)
                {
                    Console.WriteLine(_message);
                    worker.ReportProgress(0);
                }
            }

            Console.WriteLine("Begining");

            _body += DateTime.Now.ToString() + "<br>";
            _body += Properties.Settings.Default._EmailTableHead;


            if (_computers.Count() <= 0) { e.Cancel = true; return; }
            if (_files.Count() <= 0) { e.Cancel = true; return; }

            int total = (_computers.Count() * _files.Count());

            progressBar1.Maximum = total;

            for (int i = 0; i < _computers.Count(); i++)
            {
                // break loop if cancel is hit
                if ((worker.CancellationPending == true)) { e.Cancel = true; break; }

                string computer = _computers[i];

                // continue to the next element in the loop if network is down
                if (!Shared.Functions.CheckNetwork(computer))
                {
                    _body += string.Format(Properties.Settings.Default._EmailTableRow, computer, "Unable to ping", "");
                    _prog = (_prog + _files.Count());
                    continue;
                }

                // copy each of the file
                for (int j = 0; j < _files.Count(); j++)
                {
                    // break loop if cancel is hit
                    if ((worker.CancellationPending == true)) { e.Cancel = true; break; }

                    string file = System.IO.Path.GetFileName(_files[j]);
                    _message = string.Format("Copying {0} to {1}", file, computer);

                    // progress begin
                    worker.ReportProgress(_prog/total);

                    //System.Threading.Thread.Sleep(500);
                    try
                    {
                        string dest = string.Format(@"\\{0}\c$\temp\{1}", computer, file);
                        System.IO.File.Copy(_files[j], dest, true);
                        _body += string.Format(Properties.Settings.Default._EmailTableRow, computer, "Files Transfered", file);
                    }
                    catch (Exception)
                    {
                        _body += string.Format(Properties.Settings.Default._EmailTableRow, computer, "Failed to transfer file", file);
                    }

                    // progress end
                    _prog++;
                    worker.ReportProgress(_prog/total);
                }
                
            }
                        
        }



        private void backgroundWorkerTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if((e.Cancelled==true))
            {
                this.textBox1.Text = "Canceled!";
            }
            else if(!(e.Error == null))
            {
                this.textBox1.Text = ("Error: " + e.Error.Message);
            }
            else
            {
                this.textBox1.Text = "Done!";
            }
            _body += Properties.Settings.Default._EmailFooter;
            _body += DateTime.Now.ToString();

            Shared.Functions.SendEmail(Properties.Settings.Default._To, _body, Properties.Settings.Default._Subject);

            Close();
        }



        private void bgwFileCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.textBox1.Text = _message;
            this.progressBar1.Value = _prog;
            progressBar1.Update();

        }


        private void WaitingTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwFileCopy.IsBusy)
            {
                while (!bgwFileCopy.WorkerSupportsCancellation == true)
                {
                    System.Threading.Thread.Sleep(500);
                }
                bgwFileCopy.CancelAsync();
            }
        }


    }
}
