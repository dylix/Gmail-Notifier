using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Gmail_Notifier.Controls;

namespace Gmail_Notifier
{
    public partial class frmNotify : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        private List<Email> emails = new List<Email>();
        public frmNotify(List<Email> _emails)
        {
            // make the end rounded
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,20,20));
            emails = _emails;
            InitializeComponent();
        }
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
            private const int WS_EX_TOPMOST = 0x00000008;
    protected override CreateParams CreateParams
    {
       get
       {
          CreateParams createParams = base.CreateParams;
          createParams.ExStyle |= WS_EX_TOPMOST;
          return createParams;
       }
    }
        private void frmNotify_Load(object sender, EventArgs e)
        {
        	System.Threading.Thread.Sleep(3000);
            //this.TopMost = true;
            tmrTicker.Interval = Variables.NtfyInterval * 1000;
            updateTicker(lastTickerNum);
            this.Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height+5;
        }
        private int lastTickerNum = 0;
        private void updateTicker(int _index)
        {
            gmailFeedViewer1.email = emails[_index];
            gmailFeedViewer1.FeedItemIndex = lastTickerNum+1; //this.m_iCurrentFeedIndex + 1;
            gmailFeedViewer1.NumberOfFeedItems = emails.Count; //this.m_lastFeed.FeedItems.Count;
            lastTickerNum++;
        }
        private void tmrTicker_Tick(object sender, EventArgs e)
        {
            int emailCount = emails.Count;
            if (emailCount > lastTickerNum)
                updateTicker(lastTickerNum);
            else if (emailCount == lastTickerNum)
            {
                this.Close();
                //tmrTicker.Enabled = false;
            }
        }
        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            tmrDelay.Stop();
            tmrTicker.Start();
        }
        // System.Diagnostics.Process.Start(emails[lastTickerNum].link);
    }
}