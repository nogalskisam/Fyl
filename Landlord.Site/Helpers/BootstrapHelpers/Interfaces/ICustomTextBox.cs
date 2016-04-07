using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landlord.Site.Helpers
{
    public interface ICustomTextBox<TModel, TValue> : ICustomFormControl<TModel, TValue>
    {
        ICustomTextBox<TModel, TValue> Password(bool enabled = true);

        ICustomTextBox<TModel, TValue> Placeholder(bool enabled = true, string value = null);

        ICustomTextBox<TModel, TValue> Label(bool enabled = true);

        ICustomTextBox<TModel, TValue> Validation(bool enabled = true);

        ICustomTextBox<TModel, TValue> Tooltip(string value);

        ICustomTextBox<TModel, TValue> InputAttributes(object htmlAttributes);

        ICustomTextBox<TModel, TValue> Icon(string iconClass);
    }
}