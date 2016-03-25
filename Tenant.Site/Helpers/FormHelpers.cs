using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Tenant.Site.Helpers
{
    public static class FormHelpers
    {
        public static MvcHtmlString FylDisplay<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> valueExpression, object additionalViewData = null, string specifyLabel = null)
        {
            var displayFor = html.DisplayFor(valueExpression, additionalViewData);
            return FylDisplayCustom(html, valueExpression, displayFor, specifyLabel);
        }

        public static MvcHtmlString FylDisplayCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> valueExpression, MvcHtmlString customDisplay, string specifyLabel = null)
        {
            StringBuilder sb = new StringBuilder();
            var metadata = ModelMetadata.FromLambdaExpression(valueExpression, html.ViewData);

            sb.Append("<div class=\"row control-group display-group\">");

            sb.Append("<div class=\"col-md-4\">");
            sb.Append("<strong>");
            sb.Append(specifyLabel ?? metadata.GetDisplayName());
            sb.Append("</strong>");
            sb.Append("</div>");

            sb.Append("<div class=\"col-md-8\">");
            sb.Append(customDisplay);
            sb.Append("</div>");

            sb.Append("</div>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}