using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_Notifier
{
    class Variables
    {
        public static string Username;
        public static string Password;
        public static int ChkInterval;
        public static int NtfyInterval;
        public static bool settingsOpened = false;
        public static bool aboutOpened = false;
        private bool _aboutOpened
        {
            get
            {
                return aboutOpened;
            }
            set
            {
                aboutOpened = value;
            }
        }
        private bool _settingsOpened
        {
            get
            {
                return settingsOpened;
            }
            set
            {
                settingsOpened = value;
            }
        }
        private string _Username
        {
            get
            {
                return Username;
            }
            set
            {
                Username = value;                
            }
        }
        private string _Password
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
            }
        }
        private int _ChkInterval
        {
            get
            {
                return ChkInterval;
            }
            set
            {
                ChkInterval = value;
            }
        }
        private int _NtfyInterval
        {
            get
            {
                return NtfyInterval;
            }
            set
            {
                NtfyInterval = value;
            }
        }
    }
}
