using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
//using Gmail_Notifier.Classes;

namespace Gmail_Notifier
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private readonly string UNIQUE_AUTORUN_NAME = Application.ProductName + "_" + Utility.UniqueApplicationID.ToString();
        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (Variables.Password != String.Empty || Variables.Username != String.Empty)
            {
                txtUsername.Text = Variables.Username;
                txtPassword.Text = Variables.Password;
            }
            Dictionary<int, string> dicFreq = new Dictionary<int, string>();
            dicFreq.Add(5, "5 minutes");
            dicFreq.Add(10, "10 minutes");
            dicFreq.Add(15, "15 minutes");
            dicFreq.Add(20, "20 minutes");
            dicFreq.Add(25, "25 minutes");
            dicFreq.Add(30, "30 minutes");
            dicFreq.Add(45, "45 minutes");
            dicFreq.Add(60, "60 minutes");
            dicFreq.Add(90, "1 hour 30 mins");
            dicFreq.Add(120, "2 hours");
            dicFreq.Add(180, "3 hours");
            dicFreq.Add(240, "4 hours");
            cmbFreq.DataSource = new BindingSource(dicFreq, null);
            cmbFreq.DisplayMember = "Value";
            cmbFreq.ValueMember = "Key";
            cmbFreq.SelectedValue = Variables.ChkInterval;

            Dictionary<int, string> dicChkFreq = new Dictionary<int, string>();
            dicChkFreq.Add(3, "3 seconds");
            dicChkFreq.Add(5, "5 seconds");
            dicChkFreq.Add(10, "10 seconds");
            dicChkFreq.Add(15, "15 seconds");
            dicChkFreq.Add(20, "20 seconds");
            dicChkFreq.Add(30, "30 seconds");
            cmbNtfyFreq.DataSource = new BindingSource(dicChkFreq, null);
            cmbNtfyFreq.DisplayMember = "Value";
            cmbNtfyFreq.ValueMember = "Key";
            cmbNtfyFreq.SelectedValue = Variables.NtfyInterval;

            if (RegAutorun.AutorunExists(UNIQUE_AUTORUN_NAME) == true)
                chkAutorun.Checked = true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Variables.Username = txtUsername.Text;
            Variables.Password = txtPassword.Text;
            Variables.ChkInterval = ((KeyValuePair<int, string>)cmbFreq.SelectedItem).Key;
            Variables.NtfyInterval = ((KeyValuePair<int, string>)cmbNtfyFreq.SelectedItem).Key;
            byte[] pass = ProtectedData.Protect(UTF8Encoding.UTF8.GetBytes(txtPassword.Text), null, DataProtectionScope.CurrentUser);
            Microsoft.Win32.RegistryKey gmailRegKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\GmailNotifier");
            using (gmailRegKey)
            {
                gmailRegKey.SetValue("Username", Variables.Username);
                gmailRegKey.SetValue("Password", pass);
                gmailRegKey.SetValue("ChkInterval", Variables.ChkInterval);
                gmailRegKey.SetValue("NtfyInterval", Variables.NtfyInterval);
            }
            if (System.Windows.Forms.Application.OpenForms["frmTray"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmTray"] as frmTray).updateTimer();
            }
            if (chkAutorun.Checked)
                RegAutorun.SetAutorun(UNIQUE_AUTORUN_NAME, Application.ExecutablePath);
            else
                RegAutorun.RemoveAutorun(UNIQUE_AUTORUN_NAME);
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Variables.settingsOpened = false;
        }
        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Variables.settingsOpened = false;
        }
    }
}