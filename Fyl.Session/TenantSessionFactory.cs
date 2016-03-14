using Fyl.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public class TenantSessionFactory : ISessionFactory
    {
        // CHANGE THIS TO FYL.SERVICE
        private readonly ITenantService _tenantService;
        private readonly ISessionHelper _sessionHelper;

        public TenantSessionFactory(ISessionHelper sessionHelper, ITenantService tenantService)
        {
            _tenantService = tenantService;
            _sessionHelper = sessionHelper;
        }

        public ISessionDetails GetSession()
        {
            var sessionTicket = _sessionHelper.GetSessionTicketFromCookie();

            if (sessionTicket != null)
            {
                // Validate session ID
                var session = _tenantService.GetValidSession(sessionTicket.SessionId);

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
