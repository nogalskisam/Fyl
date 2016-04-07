using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Landlord.Site.Helpers
{
    public static class BootstrapWidgetBuilderHelper
    {
        public static BootstrapWidgetBuilder<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> html)
        {
            return new BootstrapWidgetBuilder<TModel>(html);
        }

        public static BootstrapFormBuilder<TModel> Form<TModel>(this BootstrapWidgetBuilder<TModel> widgetBuilder, string actionName, string controllerName)
        {
            return new BootstrapFormBuilder<TModel>(widgetBuilder.HtmlHelper, actionName, controllerName);
        }
    }

    public class BootstrapWidgetBuilder<TModel>
    {
        public HtmlHelper<TModel> HtmlHelper;

        public BootstrapWidgetBuilder(HtmlHelper<TModel> html)
        {
            HtmlHelper = html;
        }
    }

    public class BootstrapFormBuilder<TModel> : IHtmlString
    {
        public BootstrapWidgetBuilder<TModel> WidgetBuilder;

        private string _actionName;
        private string _controllerName;
        private HtmlHelper<TModel> _htmlHelper;

        public BootstrapFormBuilder(HtmlHelper<TModel> htmlHelper, string actionName, string controllerName)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            _htmlHelper = htmlHelper;
        }

        public string ToHtmlString()
        {
            string formBegin = string.Format("<form action=\"{0}\" method=\"post\">", _htmlHelper.Action(_actionName, _controllerName).ToHtmlString());
            string formEnd = "</form>";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(formBegin);
            sb.AppendLine(formEnd);

            //return sb.ToString();
            return "";
        }
    }
}