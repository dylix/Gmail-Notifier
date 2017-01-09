using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Gmail_Notifier.Controls
{
    public partial class gmailFeedViewer : UserControl
    {
        private Email m_email = null;
        private int m_intNumberOfFeeds = 0;
        private int m_intFeedIndex = 0;
        public gmailFeedViewer()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }
        public Email email
        {
            get { return this.m_email; }
            set
            {
                this.m_email = value;
                this.Invalidate();
            }
        }
        public int NumberOfFeedItems
        {
            get { return this.m_intNumberOfFeeds; }
            set { this.m_intNumberOfFeeds = value; }
        }
        public int FeedItemIndex
        {
            get { return this.m_intFeedIndex; }
            set { this.m_intFeedIndex = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            string feedDate = "00.00.0000";
            string feedTime = "00:00:00";

            if (this.m_email != null)
            {
                feedDate = this.m_email.issued.ToShortDateString();
                feedTime = this.m_email.issued.ToLongTimeString();
                lblSubject.Text = this.m_email.title;
                lblMessage.Text = this.m_email.summary + ".. [click to read more]";
                lblFrom.Text = this.m_email.author;// +" [" + this.m_email.email + "]";
            }

            //first part of the subject gradient
            g.FillRectangle(
                new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, (lblMessage.Top - lblSubject.Top) / 2),
                    Color.FromArgb(40, Color.Black),
                    Color.FromArgb(90, Color.Black)),
                new Rectangle(
                    0,
                    0,
                    this.Width,
                    (lblMessage.Top - lblSubject.Top) / 2));

            //second part of the subject gradient
            g.FillRectangle(
                new LinearGradientBrush(
                    new Point(0, lblSubject.Top + (lblMessage.Top - lblSubject.Top) / 2 - 1),
                    new Point(0, lblMessage.Top),
                    Color.FromArgb(90, Color.Black),
                    Color.FromArgb(40, Color.Black)),
                new Rectangle(
                    0,
                    lblSubject.Top + (lblMessage.Top - lblSubject.Top) / 2,
                    this.Width,
                    (lblMessage.Top - lblSubject.Top) / 2 + 1));



            /*//first part of the subject gradient
            g.FillRectangle(
                new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, lblMessage.Top),
                    Color.FromArgb(40, Color.Black),
                    Color.FromArgb(70, Color.Black)),
                new Rectangle(
                    0,
                    0,
                    this.Width,
                    lblMessage.Top));

            //second part of the subject gradient
            g.FillRectangle(
                new LinearGradientBrush(
                    new Point(0, lblSubject.Top + (lblMessage.Top - lblSubject.Top) / 2),
                    new Point(0, lblMessage.Top),
                    Color.FromArgb(60, Color.Black),
                    Color.FromArgb(0, Color.Black)),
                new Rectangle(
                    0,
                    lblSubject.Top + (lblMessage.Top - lblSubject.Top) / 2,
                    this.Width,
                    (lblMessage.Top - lblSubject.Top) / 2));*/



            //Left black border
            g.FillRectangle(
                new SolidBrush(Color.Black),
                new RectangleF(
                    0,
                    0,
                    lblMessage.Left,
                    this.Height));


            if (lblMessage.Top < this.Height)
            {
                //Gradient of the message text
                g.FillRectangle(
                    new LinearGradientBrush(
                        new PointF(lblMessage.Left, lblMessage.Top),
                        new Point(lblMessage.Left, this.Height),
                        Color.Transparent,
                        Color.FromArgb(20, Color.Black)),
                    new Rectangle(
                        lblMessage.Left,
                        lblMessage.Top,
                        lblMessage.Width,
                        this.Height - lblMessage.Top));

                //Horizontal Line
                g.DrawLine(
                    new Pen(Color.White),
                    new Point(0, lblMessage.Top),
                    new Point(lblMessage.Left - 1, lblMessage.Top));

                g.DrawLine(
                    new Pen(Color.Black),
                    new Point(lblMessage.Left, lblMessage.Top),
                    new Point(this.Width, lblMessage.Top));


                //Draw feed diagonal line and feed numbers
                g.DrawLine(
                    new Pen(Color.White),
                    new Point(lblMessage.Left - 1, 0),
                    new Point(0, lblMessage.Top));

                //TODO: evtl. noch solange verkleinern bis string komplett in die box passt
                StringFormat formatNumber = new StringFormat();
                formatNumber.Alignment = StringAlignment.Far;
                formatNumber.LineAlignment = StringAlignment.Far;

                g.DrawString(
                    this.m_intFeedIndex.ToString(),
                    this.Font,
                    new SolidBrush(Color.White),
                    new RectangleF(0, 0, lblMessage.Left / 2, lblMessage.Top / 2),
                    formatNumber);


                formatNumber = new StringFormat();
                formatNumber.Alignment = StringAlignment.Near;
                formatNumber.LineAlignment = StringAlignment.Near;

                g.DrawString(
                    this.m_intNumberOfFeeds.ToString(),
                    this.Font,
                    new SolidBrush(Color.White),
                    new RectangleF(lblMessage.Left / 2, lblMessage.Top / 2, lblMessage.Left / 2, lblMessage.Top / 2),
                    formatNumber);

                //Time & Date
                StringFormat formatDate = new StringFormat(StringFormatFlags.DirectionVertical);

                float topPosDateTime = lblMessage.Top + 5;

                SizeF measuredString = g.MeasureString(
                    feedTime,
                    this.Font,
                    new PointF(0, topPosDateTime),
                    formatDate);

                g.DrawString(
                    feedTime,
                    this.Font,
                    new SolidBrush(Color.White),
                    new RectangleF(0, topPosDateTime, measuredString.Width, this.Height),
                    formatDate);

                SizeF newMeasuredString = g.MeasureString(
                    feedDate,
                    this.Font,
                    new PointF(0, topPosDateTime),
                    formatDate);

                g.DrawString(
                    feedDate,
                    this.Font,
                    new SolidBrush(Color.White),
                    new RectangleF(measuredString.Width, topPosDateTime, newMeasuredString.Width, this.Height),
                    formatDate);
            }

            e.Graphics.DrawImage(bmp, new Point(0, 0));

            //base.OnPaint(e);
        }
        private void lblSubject_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
        private void lblMessage_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
        private void gmailFeedViewer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(m_email.link);
        }
        private void lblFrom_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("mailto:" + m_email.email);
            base.OnClick(e);
        }
    }
}
