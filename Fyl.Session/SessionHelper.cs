using Fyl.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fyl.Session
{
    public class SessionHelper : ISessionHelper
    {
        private readonly IHttpContextHelper _httpContextHelper;
        private readonly IEncryptionHelper _encryptionHelper;

        public SessionHelper(IHttpContextHelper httpContextHelper, IEncryptionHelper encryptionHelper)
        {
            _httpContextHelper = httpContextHelper;
            _encryptionHelper = encryptionHelper;
        }

        public void SetSessionTicketCookie(Guid sessionId)
        {
            var sessionTicket = new SessionTicket
            {
                SessionId = sessionId,
            };

            var cookieData = SerialisationHelper.DataContractSerialise(sessionTicket);
            var encryptedCookieData = _encryptionHelper.Encrypt(cookieData, SessionDataKeys.SESSION_ENCRYPTION_KEY);

            var sessionTicketCookie = new HttpCookie(SessionDataKeys.SESSION_COOKIE_KEY, encryptedCookieData);
            sessionTicketCookie.HttpOnly = true;
            sessionTicketCookie.Secure = false;

            _httpContextHelper.SetHttpCookie(sessionTicketCookie);
        }

        public SessionTicket GetSessionTicketFromCookie()
        {
            var cookie = _httpContextHelper.GetHttpCookie(SessionDataKeys.SESSION_COOKIE_KEY);

            if (cookie == null)
            {
                return null;
            }
            else
            {
                var decrypted = _encryptionHelper.Decrypt(cookie.Value, SessionDataKeys.SESSION_ENCRYPTION_KEY);
                var deserialised = SerialisationHelper.DataContractDeserialise<SessionTicket>(decrypted);
                return deserialised;
            }
        }

        public void RemoveSessionTicketCookie()
        {
            _httpContextHelper.RemoveHttpCookie(SessionDataKeys.SESSION_COOKIE_KEY);
        }
    }
}
