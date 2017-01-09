using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Gmail_Notifier
{
    class Utility
    {
        public static int UniqueApplicationID
        {
            get
            {
                return Application.ExecutablePath.GetHashCode();
            }
        }
    }
}
