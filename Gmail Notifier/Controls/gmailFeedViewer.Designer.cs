namespace Gmail_Notifier.Controls
{
    partial class gmailFeedViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(46, 39);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(250, 39);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "[MESSAGE]";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.Teal;
            this.lblFrom.Location = new System.Drawing.Point(46, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(250, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "[FROM]";
            this.lblFrom.Click += new System.EventHandler(this.lblFrom_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(46, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(250, 26);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "[SUBJECT]";
            this.lblSubject.Click += new System.EventHandler(this.lblSubject_Click);
            // 
            // gmailFeedViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblSubject);
            this.Name = "gmailFeedViewer";
            this.Size = new System.Drawing.Size(305, 114);
            this.Click += new System.EventHandler(this.gmailFeedViewer_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblSubject;
    }
}
