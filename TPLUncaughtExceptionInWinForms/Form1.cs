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

namespace TPLUncaughtExceptionInWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartTask_Click(object sender, EventArgs e)
        {
            Task<List<int>> taskWithFactoryAndState = new Task<List<int>>((stateObj) =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < (int)stateObj; i++)
                {
                    ints.Add(i);
                    if (i > 100)
                    {
                        InvalidOperationException ex = new InvalidOperationException("Yikes!!!");
                        ex.Source = "taskWithFactoryAndState";
                        throw ex;
                    }
                }
                return ints;
            }, 2000);

            try
            {
                taskWithFactoryAndState.Start();
                taskWithFactoryAndState.Wait();
                if (!taskWithFactoryAndState.IsFaulted)
                {
                    lstResults.DataSource = taskWithFactoryAndState.Result;
                }
            }
            catch(AggregateException taskEx)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception ex in taskEx.InnerExceptions)
                {
                    sb.AppendLine(string.Format("Caught Exception '{0}'", ex.Message));
                }
                MessageBox.Show(sb.ToString());
            }
            //taskWithFactoryAndState.Dispose();
        }
    }
}
