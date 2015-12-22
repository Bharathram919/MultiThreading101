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

namespace TPLSynchronizationContextInWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInvokeRequired_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                for(int i=0;i<100;i++)
                {
                    if(lstBox.InvokeRequired)
                    {
                        lstBox.Invoke((MethodInvoker)delegate
                        {
                            lstBox.Items.Add(i);
                        });
                    }
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        private void btnSyncContext_Click(object sender, EventArgs e)
        {
            Task taskWithFactoryAndState = Task.Factory.StartNew<List<int>>((stateObj) =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < (int)stateObj; i++)
                {
                    ints.Add(i);
                    Thread.Sleep(1);
                }
                return ints;
            }, 20000).ContinueWith(ant =>
            {
                lstBox.DataSource = ant.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
