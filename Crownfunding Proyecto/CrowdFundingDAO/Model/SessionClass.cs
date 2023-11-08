using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public static class SessionClass
    {
        public static int SessionId = 0;
        public static string SessionName = "";
        public static string SessionLastName = "";
        public static string SessionUserName = "";
        public static string SessionPassword = "";
        public static string SessionRole = "";
        public static string SessionEmail = "";
        public static string SessionUserId = "";
        public static DateTime registerDate = DateTime.Now;
        public static byte SessionPasswordChange;
        public static bool SessionStart = false;
        public static bool IsChange = false;
    }
}
