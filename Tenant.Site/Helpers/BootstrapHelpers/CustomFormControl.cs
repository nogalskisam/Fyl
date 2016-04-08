using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Tenant.Site.Helpers
{
    public abstract class CustomFormControl<TModel, TValue> : ICustomFormControl<TModel, TValue>
    {
        // Basics
        internal Expression<Func<TModel, TValue>> _valueExpression;
        internal HtmlHelper<TModel> _htmlHelper;

        // Customisation
        internal bool _hasLabel = true;
        internal bool _hasValidation = true;
        internal bool _hasTooltip = false;
        internal string _tooltipText;

        public string ToHtmlString()
        {
            StringBuilder sb = new StringBuilder();

            // Begin form group
            sb.Append("<div class=\"form-group\">");

            // Render control elements
            sb.Append(RenderLabel());
            sb.Append(RenderInput());
            sb.Append(RenderValidation());

            // End form group
            sb.Append("</div>");

            return sb.ToString();
        }

        public abstract string RenderInput();

        public string RenderLabel()
        {
            if (_hasLabel)
            {
                return _htmlHelper.LabelFor(_valueExpression, new { @class = "control-label" }).ToHtmlString();
            }

            return string.Empty;
        }

        public string RenderValidation()
        {
            if (_hasValidation)
            {
                return "<div>" + _htmlHelper.ValidationMessageFor(_valueExpression).ToHtmlString() + "</div>";
            }

            return string.Empty;
        }

        internal void UpdateAttributeCollection(RouteValueDictionary collection, string key, object value, bool replace = false)
        {
            var matching = collection.SingleOrDefault(s => s.Key == key);

            collection.Remove(key);

            var toAdd = new KeyValuePair<string, object>(key, (matching.Key != null && !replace) ? matching.Value + " " + value : value);

            collection.Add(toAdd.Key, toAdd.Value);
        }
    }
}