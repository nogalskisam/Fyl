using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Tenant.Site.Helpers
{
    public class CustomTextBox<TModel, TValue> : CustomFormControl<TModel, TValue>, ICustomTextBox<TModel, TValue>
    {
        private bool _isPassword;
        private bool _hasPlaceholder;
        private string _placeholderText;
        private bool _hasIcon;
        private string _iconClass;
        private RouteValueDictionary _inputAttributes = new RouteValueDictionary();

        public CustomTextBox(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> valueExpression)
        {
            _valueExpression = valueExpression;
            _htmlHelper = htmlHelper;
        }

        public override string RenderInput()
        {
            var metadata = ModelMetadata.FromLambdaExpression(_valueExpression, _htmlHelper.ViewData);

            StringBuilder sb = new StringBuilder();

            if (_hasIcon)
            {
                // Begin an input group and add icon
                sb.Append("<div class=\"input-group\">");
                sb.Append(string.Format("<span class=\"input-group-addon\"><i class=\"{0}\"></i></span>", _iconClass));
            }

            if (_hasPlaceholder)
            {
                // If no explicit placeholder is set, Try and resolve the placeholder text from the model metadata 
                // which may consist of the localised display property of the model property, or the simple property name
                string placeholderText = _placeholderText ?? metadata.DisplayName ?? metadata.PropertyName ?? string.Empty;
                UpdateAttributeCollection(_inputAttributes, "placeholder", placeholderText);
            }

            UpdateAttributeCollection(_inputAttributes, "class", "form-control");

            if (_isPassword)
            {
                sb.Append(_htmlHelper.PasswordFor(_valueExpression, _inputAttributes));
            }
            else
            {
                sb.Append(_htmlHelper.TextBoxFor(_valueExpression, _inputAttributes));
            }

            if (_hasIcon)
            {
                // End input group
                sb.Append("</div>");
            }

            return sb.ToString();
        }

        public ICustomTextBox<TModel, TValue> Password(bool enabled = true)
        {
            _isPassword = enabled;
            return this;
        }

        public ICustomTextBox<TModel, TValue> Placeholder(bool enabled = true, string value = null)
        {
            _hasPlaceholder = enabled;
            _placeholderText = value;
            return this;
        }

        public ICustomTextBox<TModel, TValue> Label(bool enabled = true)
        {
            _hasLabel = enabled;
            return this;
        }

        public ICustomTextBox<TModel, TValue> Validation(bool enabled = true)
        {
            _hasValidation = enabled;
            return this;
        }

        public ICustomTextBox<TModel, TValue> Tooltip(string value)
        {
            _hasTooltip = !string.IsNullOrEmpty(value);
            _tooltipText = value;
            return this;
        }

        public ICustomTextBox<TModel, TValue> InputAttributes(object htmlAttributes)
        {
            // Replace this with a better implementation - extension method on RouteValueDictionary?
            HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes).ToList().ForEach(e => UpdateAttributeCollection(_inputAttributes, e.Key, e.Value));
            return this;
        }


        public ICustomTextBox<TModel, TValue> Icon(string iconClass)
        {
            _hasIcon = true;
            _iconClass = iconClass;
            return this;
        }
    }
}
