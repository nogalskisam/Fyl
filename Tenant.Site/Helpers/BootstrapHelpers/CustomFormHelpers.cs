using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Tenant.Site.Helpers;

namespace Tenant.Site.Helpers
{
    public static class CustomFormHelpers
    {
        public static ICustomTextBox<TModel, TValue> CustomTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> valueExpression)
        {
            return new CustomTextBox<TModel, TValue>(htmlHelper, valueExpression);
        }

        public static ICustomValidationSummary CustomValidationSummary(this HtmlHelper htmlHelper)
        {
            return new CustomValidationSummary(htmlHelper);
        }
    }
}