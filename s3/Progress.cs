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
            if (bytesTotal == 0)
            {
                if (bytesDone == bytesTotal)
                    lstHistory.Items.Insert(0, string.Format("{0} (skipped)", description));
                lblCurrent.Text = description;
                progressBar.Value = 100;
            }
            else
            {
                if (bytesDone == bytesTotal)
                    lstHistory.Items.Insert(0, string.Format("{0} ({1})", description, Utils.FormatFileSize(bytesTotal)));
                lblCurrent.Text = string.Format("{0} ({1} of {2})",
                    description, Utils.FormatFileSize(bytesDone), Utils.FormatFileSize(bytesTotal));
                progressBar.Value = (int)(100.0 * bytesDone / bytesTotal);
            }
        }

        public static void showProgressWindow()
        {
            (instance = new Progress()).ShowDialog();
        }
    }
}
