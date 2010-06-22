using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using com.amazon.s3;

namespace s3
{
    public partial class Progress : Form
    {
        public static Progress instance = null;
        static bool shown = false;

        public Progress()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            AWSAuthConnection.progress += new progressHandler(reportProgressInternal);
        }

        public static void reportProgress(string description, long bytesDone, long bytesTotal)
        {
            if (instance != null)
                instance.reportProgressInternal(description, bytesDone, bytesTotal);
        }

        private void reportProgressInternal(string description, long bytesDone, long bytesTotal)
        {
            if (!shown)
            {
                s.Release();
                shown = true;
            }

            if (bytesTotal == 0)
            {
                if (bytesDone == bytesTotal)
                    addHistory(string.Format("{0} (skipped)", description));
                setText(description);
                setProgress(100);
            }
            else
            {
                if (bytesDone == bytesTotal)
                    addHistory(string.Format("{0} ({1})", description, Utils.FormatFileSize(bytesTotal)));
                setText(string.Format("{0} ({1} of {2})",
                    description, Utils.FormatFileSize(bytesDone), Utils.FormatFileSize(bytesTotal)));
                setProgress((int)(100.0 * bytesDone / bytesTotal));
            }
        }

        Semaphore s = new Semaphore(0, 1);

        public static void showProgressWindow()
        {
            if (Environment.UserInteractive)
            {
                instance = new Progress();
                DateTime start = DateTime.Now;
                instance.s.WaitOne(); // wait for first call to reportProgress()

                while (DateTime.Now < start.AddSeconds(3))
                    Thread.Sleep(500);

                instance.ShowDialog();
            }
        }

        delegate void SetTextDelegate(string s);
        void setText(string s)
        {
            if (lblCurrent.InvokeRequired)
                Invoke(new SetTextDelegate(setText), new object[] { s });
            else
                lblCurrent.Text = s;
        }

        delegate void SetProgressDelegate(int p);
        void setProgress(int p)
        {
            if (progressBar.InvokeRequired)
                Invoke(new SetProgressDelegate(setProgress), new object[] { p });
            else
                progressBar.Value = p;
        }

        delegate void AddHistoryDelegate(string s);
        void addHistory(string s)
        {
            if (lstHistory.InvokeRequired)
                Invoke(new AddHistoryDelegate(addHistory), new object[] { s });
            else
                lstHistory.Items.Insert(0, s);
        }
    }
}
