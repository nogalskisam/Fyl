using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Landlord.Site.Helpers
{
    public interface ICustomFormControl<TModel, TValue> : IHtmlString
    {
        string RenderInput();

        string RenderLabel();

        string RenderValidation();
    }
}
