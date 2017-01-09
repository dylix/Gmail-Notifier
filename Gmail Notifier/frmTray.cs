using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Gmail_Notifier
{

    public partial class frmTray : Form
    {
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuCheckNow;
        private System.Windows.Forms.MenuItem menuTellMeAgain;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuLine;
        private System.Windows.Forms.MenuItem menuLine2;
        private System.Windows.Forms.MenuItem menuLine3;
        private System.Windows.Forms.MenuItem menuAbout;
        private int numMail = 0;
        private int numMailprev = 0;
        public static bool shown = false;
        public List<Email> emails = new List<Email>();

        [System.Runtime.InteropServices.DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);
        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004,
            SND_ALIAS = 65536
        }
        internal class FullscreenCheck
        {
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            private static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            private static extern IntPtr GetShellWindow();
            [DllImport("user32.dll", SetLastError = true)]
            private static extern int GetWindowRect(IntPtr hwnd, out RECT rc);

            // I hope this handles never changes
            private static IntPtr hndlDesktop = GetDesktopWindow();
            private static IntPtr hndlShell = GetShellWindow();

            public static bool IsFullscreen()
            {
                var hndlForeground = GetForegroundWindow();
                if (hndlForeground == null || hndlForeground == IntPtr.Zero || hndlForeground == hndlDesktop || hndlForeground == hndlShell)
                {
                    return false;
                }

                RECT appBounds;
                GetWindowRect(hndlForeground, out appBounds);
                var screenBounds = System.Windows.Forms.Screen.FromHandle(hndlForeground).Bounds;

                return ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width);
            }
        }
        public frmTray()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuLine = new System.Windows.Forms.MenuItem();
            this.menuLine2 = new System.Windows.Forms.MenuItem();
            this.menuLine3 = new System.Windows.Forms.MenuItem();
            this.menuCheckNow = new System.Windows.Forms.MenuItem();
            this.menuTellMeAgain = new System.Windows.Forms.MenuItem();
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuCheckNow, this.menuTellMeAgain,this.menuLine, this.menuSettings, this.menuLine2, this.menuAbout,this.menuLine3, this.menuExit });

            // Initialize menuCheckNow
            this.menuCheckNow.Index = 0;
            this.menuCheckNow.Text = "Check Now";
            this.menuCheckNow.Click += new System.EventHandler(this.menuCheckNow_Click);
            // Initialize menuTellMeAgain
            this.menuTellMeAgain.Index = 1;
            this.menuTellMeAgain.Text = "Tell Me Again";
            this.menuTellMeAgain.Click += new System.EventHandler(this.menuTellMeAgain_Click);
            // Initialize menuLine
            this.menuLine.Index = 2;
            this.menuLine.Text = "-";
            // Initialize menuSettings
            this.menuSettings.Index = 3;
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // Initialize menuLine
            this.menuLine2.Index = 4;
            this.menuLine2.Text = "-";
            // Initialize menuSettings
            this.menuAbout.Index = 5;
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // Initialize menuLine
            this.menuLine3.Index = 6;
            this.menuLine3.Text = "-";
            // Initialize menuExit 
            this.menuExit.Index = 7;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // Set up how the form should be displayed. 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Notify Icon";
            ntfyIcon.ContextMenu = this.contextMenu1;

            byte[] passwordEnc = null;
            try
            {
                Microsoft.Win32.RegistryKey gmailRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\GmailNotifier");
                using (gmailRegKey)
                {
                    Variables.Username = (string)gmailRegKey.GetValue("Username");
                    passwordEnc = (byte[])gmailRegKey.GetValue("Password");
                    if (passwordEnc != null)
                        Variables.Password = UTF8Encoding.UTF8.GetString(ProtectedData.Unprotect(passwordEnc, null, DataProtectionScope.CurrentUser));
                    Variables.ChkInterval = (int)gmailRegKey.GetValue("ChkInterval");
                    Variables.NtfyInterval = (int)gmailRegKey.GetValue("NtfyInterval");
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                MessageBox.Show("Incomplete settings detected. This is not a fatal error. Please update your preferances accordingly.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //return;
                if (Variables.Username == null)
                    Variables.Username = String.Empty;
                if (passwordEnc == null)
                    Variables.Password = String.Empty;
                Variables.ChkInterval = 5;
                Variables.NtfyInterval = 5;
                frmSettings _frmSettings = new frmSettings();
                _frmSettings.Show();
                Variables.settingsOpened = true;
            }
            if (Variables.Username == String.Empty || Variables.Password == String.Empty)
            {
                if (Variables.settingsOpened != true)
                {
                    frmSettings _frmSettings = new frmSettings();
                    _frmSettings.Show();
                    Variables.settingsOpened = true;
                }
            }
            else
                checkMail();
            tmrCheckMail.Interval = _ChkInterval(Variables.ChkInterval);
            tmrCheckMail.Enabled = true;
        }
        public void updateTimer()
        {
            tmrCheckMail.Enabled = false;
            tmrCheckMail.Interval = _ChkInterval(Variables.ChkInterval);
            tmrCheckMail.Enabled = true;
        }
        private int _ChkInterval(int minutes)
        {
            return minutes * 1000 * 60;
        }
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }
        private void ntfyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gmail.com/");
        }
        private void menuCheckNow_Click(object Sender, EventArgs e)
        {
            checkMail();
        }
        private void menuTellMeAgain_Click(object Sender, EventArgs e)
        {
            if (emails.Count != 0)
                showNotification();
        }
        private void menuSettings_Click(object Sender, EventArgs e)
        {
            if (!Variables.settingsOpened)
            {
                frmSettings _frmSettings = new frmSettings();
                _frmSettings.Show();
                Variables.settingsOpened = true;
            }
            else
            {
                (System.Windows.Forms.Application.OpenForms["frmSettings"] as frmSettings).BringToFront();
            }
        }
        private void menuAbout_Click(object Sender, EventArgs e)
        {
            if (!Variables.aboutOpened)
            {
                frmAbout _frmAbout = new frmAbout();
                _frmAbout.Show();
                Variables.aboutOpened = true;
            }
            else
            {
                (System.Windows.Forms.Application.OpenForms["frmAbout"] as frmAbout).BringToFront();
            }
        }
        private void menuExit_Click(object Sender, EventArgs e)
        {
            ntfyIcon.Dispose();
            Application.ExitThread();
        }
        private void frmTray_FormClosed(object sender, FormClosedEventArgs e)
        {
            ntfyIcon.Dispose();
        }
        private int GetNumberOfMail(string userName, string passWord)
        {
            XmlDocument xmldoc = GetGmailFeed(userName, passWord);
            // debug crap
            //XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load("C:\\Documents and Settings\\Admin\\Desktop\\atom.xml");
            XmlNodeList parentNode = xmldoc.SelectNodes("//*[local-name()='feed']/*[local-name()='entry']");
            foreach (XmlNode node in parentNode)
            {
                Email email = new Email();
                foreach (XmlNode entryNode in node.ChildNodes)
                {
                    switch (entryNode.Name)
                    {
                        case "title":
                            email.title = entryNode.InnerText;
                            break;
                        case "summary":
                            email.summary = entryNode.InnerText;//HttpUtility.HtmlDecode(entryNode.InnerText);
                            break;
                        case "link":
                            email.link = entryNode.Attributes["href"].InnerText; //gmailLink = new GMailFeedLink(entryNode.Attributes["rel"].InnerText,entryNode.Attributes["href"].InnerText,entryNode.Attributes["type"].InnerText);
                            break;
                        case "modified":
                            DateTime.TryParse(entryNode.InnerText, out email.modified);
                            break;
                        case "issued":
                            DateTime.TryParse(entryNode.InnerText, out email.issued);
                            break;
                        case "id":
                            email.id = entryNode.InnerText;
                            break;
                        case "author":
                            foreach (XmlNode authorNode in entryNode.ChildNodes)
                            {
                                switch (authorNode.Name)
                                {
                                    case "name":
                                        email.author = authorNode.InnerText;
                                        break;

                                    case "email":
                                        email.email = authorNode.InnerText;
                                        break;
                                }
                            }
                            break;
                    }
                }
                emails.Add(email);
            }
            //XmlNodeList count = xmldoc.GetElementsByTagName("fullcount");
            //return int.Parse(count[0].InnerText);
            return emails.Count;
        }
        private static XmlDocument GetGmailFeed(string userName, string password)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://mail.google.com/mail/feed/atom/");
            req.Method = "GET";
            req.Credentials = new NetworkCredential(userName, password);
            XmlDocument response = new XmlDocument();
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    XmlTextReader reader = new XmlTextReader(resp.GetResponseStream());
                    response.Load(reader);
                    reader.Close();
                }
                resp.Close();
            }
            catch (Exception e)
            {
                
                if (!shown)
                {
                    shown = true;
                    DialogResult result;
                    result = MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        shown = false;
                    }
                }
            }
            return response;
        }
        private void tmrCheckMail_Tick(object sender, EventArgs e)
        {
            checkMail();
        }
        private void checkMail()
        {
            // clear any emails from list. new list is generated anyways
            emails.Clear();
            try
            {
                numMail = GetNumberOfMail(Variables.Username, Variables.Password);
                if (numMail > numMailprev)
                {
                    newMail();
                    menuTellMeAgain.Enabled = true;
                }
                else if (numMail == 0)
                {
                    ntfyIcon.Icon = Gmail_Notifier.Properties.Resources.nomail;
                    ntfyIcon.Text = "No new messages";
                    menuTellMeAgain.Enabled = false;
                }
                numMailprev = numMail;
            }
            catch (Exception e)
            {
                if (!shown)
                {
                    shown = true;
                    DialogResult result;
                    result = MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        shown = false;
                    }
                }
            }
        }
        private void newMail()
        {
            showNotification();
            ntfyIcon.Icon = Gmail_Notifier.Properties.Resources.newmail;
            ntfyIcon.Text = numMail.ToString() + " new message(s)";
            //ntfyIcon.ShowBalloonTip(5, "Gmail Notifier", "You have " + numMail.ToString() + " new emails", System.Windows.Forms.ToolTipIcon.Info );
            PlaySound("MailBeep", new System.IntPtr(), PlaySoundFlags.SND_NODEFAULT | PlaySoundFlags.SND_ALIAS);
        }
        private void showNotification()
        {
            // check if something is running fullscreen. if it is, do not show form and steal focus!
            if (!FullscreenCheck.IsFullscreen())
            {
                frmNotify frmNot = new frmNotify(emails);
                frmNot.Show();
            }
        }
    }
}