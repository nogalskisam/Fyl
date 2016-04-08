using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tenant.Site.Helpers
{
    public class CustomValidationSummary : ICustomValidationSummary
    {
        private HtmlHelper _htmlHelper;

        private bool _showPropertyErrors;

        public CustomValidationSummary(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public string ToHtmlString()
        {
            // Applicable model errors are all errors in the case where property errors are included, or
            // only those errors with no key, which are errors applying to the whole error rather than properties.
            // Errors applying to the whole model are ordered to be shown first as they are likely custom errors of
            // higher importance
            var applicableModelErrors = _htmlHelper.ViewData.ModelState
                .Where(w => string.IsNullOrEmpty(w.Key) || _showPropertyErrors)
                .OrderBy(o => o.Key);

            if (applicableModelErrors.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class=\"alert alert-danger\" role=\"alert\">");

                foreach (string errorMessage in applicableModelErrors.SelectMany(s => s.Value.Errors).Select(s => s.ErrorMessage))
                {
                    sb.Append(string.Format("<p><i class=\"fa fa-fw fa-exclamation-circle\" aria-hidden=\"true\"></i>{0}</p>",
                        _htmlHelper.Encode(errorMessage)));
                }

                sb.Append("</div>");

                return sb.ToString();
            }

            return string.Empty;
        }

        public ICustomValidationSummary PropertyErrors(bool value = true)
        {
            _showPropertyErrors = value;
            return this;
        }
    }
}