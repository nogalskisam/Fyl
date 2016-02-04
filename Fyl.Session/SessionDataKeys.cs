using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public static class SessionDataKeys
    {
        public static string USER_DISPLAY_NAME { get { return "UserDisplayName"; } }
        public static string USER { get { return "UserDto"; } }

        public static string SESSION_COOKIE_KEY { get { return "fyl-session-ticket"; } }
        public static string SESSION_ENCRYPTION_KEY { get { return "iQu0Mj4JV0v28cyV8A"; } }
    }
}