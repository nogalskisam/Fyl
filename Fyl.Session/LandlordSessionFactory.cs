using Fyl.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fyl.Session
{
    public static class LandlordSessionFactory
    {
        public static ISessionDetails GetSession()
        {
            var service = DependencyResolver.Current.GetService<ILandlordService>();
            var sessionHelper = DependencyResolver.Current.GetService<ISessionHelper>();
            var sessionTicket = sessionHelper.GetSessionTicketFromCookie();

            if (sessionTicket != null)
            {
                // Validate session ID
                var session = service.GetValidSession(sessionTicket.SessionId);

                if (session != null)
                {
                    return new SessionDetails()
                    {
                        User = session.User
                    };
                }
            }

            // Return empty (invalid) session
            return new SessionDetails();
        }
    }
}
