namespace Gmail_Notifier
{
    partial class frmNotify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrTicker = new System.Windows.Forms.Timer(this.components);
            this.gmailFeedViewer1 = new Gmail_Notifier.Controls.gmailFeedViewer();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrTicker
            // 
            this.tmrTicker.Interval = 10000;
            this.tmrTicker.Tick += new System.EventHandler(this.tmrTicker_Tick);
            // 
            // gmailFeedViewer1
            // 
            this.gmailFeedViewer1.BackColor = System.Drawing.Color.Transparent;
            this.gmailFeedViewer1.email = null;
            this.gmailFeedViewer1.FeedItemIndex = 0;
            this.gmailFeedViewer1.Location = new System.Drawing.Point(0, 0);
            this.gmailFeedViewer1.Name = "gmailFeedViewer1";
            this.gmailFeedViewer1.NumberOfFeedItems = 0;
            this.gmailFeedViewer1.Size = new System.Drawing.Size(291, 112);
            this.gmailFeedViewer1.TabIndex = 0;
            // 
            // tmrDelay
            // 
            this.tmrDelay.Enabled = true;
            this.tmrDelay.Interval = 1000;
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // frmNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 114);
            this.Controls.Add(this.gmailFeedViewer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotify";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmNotify";
            this.Load += new System.EventHandler(this.frmNotify_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrTicker;
        private Gmail_Notifier.Controls.gmailFeedViewer gmailFeedViewer1;
        private System.Windows.Forms.Timer tmrDelay;
    }
}