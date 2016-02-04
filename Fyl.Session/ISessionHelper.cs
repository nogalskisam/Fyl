using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public interface ISessionHelper
    {
        void SetSessionTicketCookie(Guid sessionId);

        SessionTicket GetSessionTicketFromCookie();

        void RemoveSessionTicketCookie();
    }
}
