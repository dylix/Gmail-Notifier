namespace Gmail_Notifier
{
    partial class frmSettings
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictBoxLogo = new System.Windows.Forms.PictureBox();
            this.cmbFreq = new System.Windows.Forms.ComboBox();
            this.lblFreq = new System.Windows.Forms.Label();
            this.chkAutorun = new System.Windows.Forms.CheckBox();
            this.cmbNtfyFreq = new System.Windows.Forms.ComboBox();
            this.lblNtfyFreq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(221, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(221, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(184, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(221, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(184, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(160, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(160, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictBoxLogo
            // 
            this.pictBoxLogo.Image = global::Gmail_Notifier.Properties.Resources.logo;
            this.pictBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictBoxLogo.Name = "pictBoxLogo";
            this.pictBoxLogo.Size = new System.Drawing.Size(133, 58);
            this.pictBoxLogo.TabIndex = 6;
            this.pictBoxLogo.TabStop = false;
            // 
            // cmbFreq
            // 
            this.cmbFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFreq.Location = new System.Drawing.Point(221, 69);
            this.cmbFreq.Name = "cmbFreq";
            this.cmbFreq.Size = new System.Drawing.Size(184, 23);
            this.cmbFreq.TabIndex = 3;
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.Location = new System.Drawing.Point(160, 69);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(57, 13);
            this.lblFreq.TabIndex = 8;
            this.lblFreq.Text = "Frequency";
            // 
            // chkAutorun
            // 
            this.chkAutorun.AutoSize = true;
            this.chkAutorun.Location = new System.Drawing.Point(12, 133);
            this.chkAutorun.Name = "chkAutorun";
            this.chkAutorun.Size = new System.Drawing.Size(117, 17);
            this.chkAutorun.TabIndex = 5;
            this.chkAutorun.Text = "Start with Windows";
            this.chkAutorun.UseVisualStyleBackColor = true;
            // 
            // cmbNtfyFreq
            // 
            this.cmbNtfyFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNtfyFreq.DropDownWidth = 184;
            this.cmbNtfyFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNtfyFreq.FormattingEnabled = true;
            this.cmbNtfyFreq.Location = new System.Drawing.Point(221, 99);
            this.cmbNtfyFreq.Name = "cmbNtfyFreq";
            this.cmbNtfyFreq.Size = new System.Drawing.Size(184, 23);
            this.cmbNtfyFreq.TabIndex = 4;
            // 
            // lblNtfyFreq
            // 
            this.lblNtfyFreq.AutoSize = true;
            this.lblNtfyFreq.Location = new System.Drawing.Point(160, 99);
            this.lblNtfyFreq.Name = "lblNtfyFreq";
            this.lblNtfyFreq.Size = new System.Drawing.Size(60, 13);
            this.lblNtfyFreq.TabIndex = 9;
            this.lblNtfyFreq.Text = "Notification";
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 161);
            this.Controls.Add(this.lblNtfyFreq);
            this.Controls.Add(this.cmbNtfyFreq);
            this.Controls.Add(this.chkAutorun);
            this.Controls.Add(this.lblFreq);
            this.Controls.Add(this.cmbFreq);
            this.Controls.Add(this.pictBoxLogo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Gmail_Notifier.Properties.Resources.nomail;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gmail Notifier Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictBoxLogo;
        private System.Windows.Forms.ComboBox cmbFreq;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.CheckBox chkAutorun;
        private System.Windows.Forms.ComboBox cmbNtfyFreq;
        private System.Windows.Forms.Label lblNtfyFreq;
    }
}

