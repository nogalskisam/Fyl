using Fyl.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public class LandlordSessionFactory : ISessionFactory
    {
        private readonly ILandlordService _landlordService;
        private readonly ISessionHelper _sessionHelper;

        public LandlordSessionFactory(ISessionHelper sessionHelper, ILandlordService landlordService)
        {
            _landlordService = landlordService;
            _sessionHelper = sessionHelper;
        }

        public ISessionDetails GetSession()
        {
            var sessionTicket = _sessionHelper.GetSessionTicketFromCookie();

            if (sessionTicket != null)
            {
                // Validate session ID
                var session = _landlordService.GetValidSession(sessionTicket.SessionId);

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
