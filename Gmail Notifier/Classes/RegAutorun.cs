using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Gmail_Notifier
{
    class RegAutorun
    {
        public static void SetAutorun(string applicationName, string applicationPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(applicationName, applicationPath);
        }
        public static void RemoveAutorun(string applicationName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue(applicationName, false);
        }
        public static bool AutorunExists(string applicationName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            return (key.GetValue(applicationName) != null);
        }
    }
}
