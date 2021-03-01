using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.DAL;
using WindowsFormsApp.Models;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private RandomDataContext randomDataContext = new RandomDataContext();
        private delegate void SafeCallDelegate(string[] items);
        private static Random random = new Random();

        private Thread[] threads;
        private int[] threadsIDs;

        private List<String> logList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            bStop.Enabled = false;
            /*
            ListViewItem item1 = new ListViewItem("ThreadID", 0);
            ListViewItem item2 = new ListViewItem("GeneratedString", 1);
            for (int i = 0; i < 20; i++)
            {
                item1.SubItems.Add("");
                item2.SubItems.Add("");

            }
            lb_log.Columns.Add("ThreadID");
            lb_log.Columns.Add("GeneratedString");
            lb_log.Columns[0].Width = -1;
            lb_log.Columns[1].Width = -1;
             */

            //lb_log.View = "Details";
            lv_log.View = View.Details;
            lv_log.Columns.Add("ThreadID", 100);
            lv_log.Columns.Add("GeneratedString", 100);

        }
        private static int getStrLength()
        {
            return random.Next(5, 10);
        }
        private static int getTimeDelay()
        {
            return random.Next(500, 2000);
        }
        public void startThreads(int num)
        {
            threads = new Thread[num];
            threadsIDs = new int[num];
            for (int i = 0; i < num; i++)
            {
                Thread t = new Thread(threadMethod);
                threadsIDs[i] = t.ManagedThreadId;

                t.IsBackground = true;
                threads[i] = t;
                threads[i].Start();
            }
        }

        private int getThreadIndex(int threadid)
        {
            //numeris atšakos, kur numeruojama nuo 1
            for (int i = 0; i < threadsIDs.Length; i++)
            {
                if (threadsIDs[i] == threadid) return i+1;
            }
            return 0;
        }
        private static String getRandomString(int length)
        {
            const String chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()); 
        }
        private static int getTimedelay()
        {
            return random.Next(500, 2000);
        }
        public void threadMethod()
        {
            while (true)
            {
                int delay = getTimedelay();
                string[] row = new string[] { "" + (getThreadIndex(Thread.CurrentThread.ManagedThreadId)) + "", getRandomString(getStrLength()) };
                writeLogSafe(row);
                Thread.Sleep(delay);
            }
        }
        public void stopThreads()
        {
            foreach (var thread in threads)
            {
                thread.Abort();
            }
        }

        private void bLaunchTheads_Click(object sender, EventArgs e)
        {
            bStart.Enabled = false;
            tbThreadNum.Enabled = false;
            bStop.Enabled = true;
            int value;
            int.TryParse(tbThreadNum.Text, out value);
            lv_log.Clear();
            lv_log.View = View.Details;
            lv_log.Columns.Add("ThreadID", 100);
            lv_log.Columns.Add("GeneratedString", 100);
            startThreads(value);
        }

        private void tbThreadNum_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbThreadNum.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                tbThreadNum.Text = tbThreadNum.Text.Remove(tbThreadNum.Text.Length - 1);
            } else
            {
                int value;
                int.TryParse(tbThreadNum.Text, out value);
                if (!(value>1&&value<16))
                {
                    MessageBox.Show("Numbers must be from 2 to 15");
                }
            }
        }
        private void writeLogSafe(string[] items)
        {
            if (lv_log.InvokeRequired)
            {
                var d = new SafeCallDelegate(writeLogSafe);
                lv_log.Invoke(d, new object[] { items });
            }
            else
            {
                if(lv_log.Items.Count >20)
                {
                    lv_log.Items.RemoveAt(0);
                }
                ListViewItem lvi = new ListViewItem(items[0]);
                lvi.SubItems.Add(items[1]);
                lv_log.Items.Add(lvi);
                randomDataContext.RandomDataList.Add(new RandomData { ThreadID = Int32.Parse(items[0]), Data = items[1], Time = DateTime.Now });
                randomDataContext.SaveChanges();

            }
        }
        private void bStop_Click(object sender, EventArgs e)
        {
            bStart.Enabled = true;
            tbThreadNum.Enabled = true;
            bStop.Enabled = false;
            stopThreads();
        }
    }
}
