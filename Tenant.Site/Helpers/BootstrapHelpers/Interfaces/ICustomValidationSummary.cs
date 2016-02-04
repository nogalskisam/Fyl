using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tenant.Site.Helpers
{
    public interface ICustomValidationSummary : IHtmlString
    {
        /// <summary>
        /// Sets whether to exclude property specific error messages from the
        /// validation summary, showing only general model errors. Can avoid
        /// duplication in the case where each input field has seperate validation
        /// </summary>
        ICustomValidationSummary PropertyErrors(bool value = true);
    }
}
