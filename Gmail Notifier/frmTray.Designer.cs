namespace Gmail_Notifier
{
    partial class frmTray
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
            this.ntfyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrCheckMail = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ntfyIcon
            // 
            this.ntfyIcon.Icon = global::Gmail_Notifier.Properties.Resources.nomail;
            this.ntfyIcon.Text = "No new messages";
            this.ntfyIcon.Visible = true;
            this.ntfyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfyIcon_MouseDoubleClick);
            // 
            // tmrCheckMail
            // 
            this.tmrCheckMail.Interval = 300000;
            this.tmrCheckMail.Tick += new System.EventHandler(this.tmrCheckMail_Tick);
            // 
            // frmTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(130, 34);
            this.ControlBox = false;
            this.Name = "frmTray";
            this.Text = "frmTray";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTray_FormClosed);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.NotifyIcon ntfyIcon;
        private System.Windows.Forms.Timer tmrCheckMail;
    }
}