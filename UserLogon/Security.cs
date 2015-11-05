using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZOV.Tools
{
    public static class Security
    {
        public static int ZOVReminderUsersID { get; set; }
        public static string UserName { get; set; }
        public static int Permissions { get; set; }
        public static bool IsAdmin { get; set; }
        public static bool ReadOnly { get; set; }
    }
}
