using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fyl.Utilities
{
    public class HttpContextHelper : IHttpContextHelper
    {
        private HttpContextBase _httpContext;

        public HttpContextHelper()
        {
            _httpContext = new HttpContextWrapper(HttpContext.Current);
        }

        public string GetVisitorIpAddress()
        {
            return _httpContext.Request.UserHostAddress;
        }

        public void SetHttpCookie(HttpCookie cookie)
        {
            _httpContext.Response.Cookies.Set(cookie);
        }

        public HttpCookie GetHttpCookie(string name)
        {
            return _httpContext.Request.Cookies[name];
        }

        public void RemoveHttpCookie(string name)
        {
            _httpContext.Request.Cookies.Remove(name);
        }
    }
}
