using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadedApplication101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeWorker();
        }

        #region delegates multi threading
        private delegate void DisplayCountDelegate(int i);
        private delegate void EnableButtonDelegate(bool enable);
        private void DisplayCount(int i)
        {
            textBox1.Text = i.ToString();
        }
        private void EnableButton(bool enable)
        {
            button2.Enabled = enable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
                for(int i=0;i<10;i++)
                {
                    textBox1.Invoke(new DisplayCountDelegate(DisplayCount), i );
                    Thread.Sleep(500);
                }
                button2.Invoke(new EnableButtonDelegate(EnableButton), true);
            });
            thread.IsBackground = true;

            // This will cause an issue if we close the main application 
            // before the thread has ended, as there would be no handler
            //thread.IsBackground = false;

            thread.Start();
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // This will cause
            // Cross - thread operation not valid:
            // Control 'textBox1' accessed from a thread other than the thread it was created on.
            try {
                var thread = new Thread(() =>
                {
                    try
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            textBox1.Text = i.ToString();

                            Thread.Sleep(500);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
                thread.IsBackground = false;
                thread.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion delegates multi threading

        #region backgroundworker
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private void InitializeWorker()
        {
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
            button3.Enabled = false;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button3.Enabled = true;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.Text = e.ProgressPercentage.ToString();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = (BackgroundWorker)sender;
            for(int i=0;i<=10;i++)
            {
                bgWorker.ReportProgress(i);
                Thread.Sleep(200);
            }
        }
        #endregion backgroundworker

        
    }
}
