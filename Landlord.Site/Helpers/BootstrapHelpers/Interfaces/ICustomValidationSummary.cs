using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landlord.Site.Helpers
{
    public interface ICustomValidationSummary : IHtmlString
    {
        ICustomValidationSummary PropertyErrors(bool value = true);
    }
}