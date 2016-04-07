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
        private readonly HttpContextBase _httpContext;

        public HttpContextHelper(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetVisitorIpAddress()
        {
            if (_httpContext.Request != null)
            {
                return _httpContext.Request.UserHostAddress;
            }
            else
            {
                return "";
            }
        }

        public void SetHttpCookie(HttpCookie cookie)
        {
            if (_httpContext.Request != null)
            {
                _httpContext.Response.Cookies.Set(cookie);
            }
        }

        public HttpCookie GetHttpCookie(string name)
        {
            if (_httpContext.Request != null)
            {
                return _httpContext.Request.Cookies[name];
            }
            else
            {
                return new HttpCookie(name);
            }
        }

        public void RemoveHttpCookie(string name)
        {
            if (_httpContext.Request != null)
            {
                _httpContext.Request.Cookies.Remove(name);
            }
        }
    }
}
