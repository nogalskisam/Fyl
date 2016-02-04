using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fyl.Utilities
{
    public interface IHttpContextHelper
    {
        string GetVisitorIpAddress();

        void SetHttpCookie(HttpCookie cookie);

        HttpCookie GetHttpCookie(string name);

        void RemoveHttpCookie(string name);
    }
}
