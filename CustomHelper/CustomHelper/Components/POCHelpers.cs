using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CustomHelper.Components
{
    public static class POCHelpers
    {
        public enum Html5InputTypes
        {
            text,
            color,
            date,
            datetime,
            email,
            month,
            number,
            password,
            range,
            search,
            tel,
            time,
            url,
            week
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper argHtmlHelper, string argButtonText, object argHTMLAttributes = null)
        {
            return SubmitButton(argHtmlHelper, argButtonText, null, false, null, argHTMLAttributes);
        }


        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id, bool isDisabled, string btnClass, object htmlAttributes = null)
        {
            string html = string.Empty;
            string disable = string.Empty;

            if (string.IsNullOrEmpty(id))
                id = buttonText;
            if (string.IsNullOrEmpty(btnClass))
                btnClass = "btn-primary";

            // Ensure ID is a valid identifier
            id = id.Replace(" ", "").Replace("-", "_");

            html = "<input type='submit' class='btn {3}{1}' title='{0}' value='{0}' id='{2}' {4} />";
            if (isDisabled)
                disable = " disabled";

            html = string.Format(html, buttonText, disable,
                                id, btnClass,
                                GetHtmlAttributes(htmlAttributes));
            html = html.Replace("'", "\"");

            return new MvcHtmlString(html);
        }

        public static MvcHtmlString TextBox5For<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return TextBox5For(htmlHelper, expression, Html5InputTypes.text, string.Empty, string.Empty, false, false, htmlAttributes);
        }

        public static MvcHtmlString TextBox5For<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,Expression<Func<TModel, TValue>> expression,Html5InputTypes type,string title,string placeholder,bool isRequired,bool isAutoFocus,object htmlAttributes = null)
        {
            MvcHtmlString html = default(MvcHtmlString);
            Dictionary<string, object> attr = new Dictionary<string, object>();

            if (htmlAttributes != null)
            {
                var attributes =
                  HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    attr.Add(item.Key, item.Value);
                }
            }

            attr.Add("type", type.ToString());
            attr.Add("class", "form-control");
            if (!string.IsNullOrEmpty(title))
            {
                attr.Add("title", title);
            }
            if (!string.IsNullOrEmpty(placeholder))
            {
                attr.Add("placeholder", placeholder);
            }
            if (isAutoFocus)
            {
                attr.Add("autofocus", "autofocus");
            }
            if (isRequired)
            {
                attr.Add("required", "required");
            }

            html = InputExtensions.TextBoxFor(htmlHelper,
                                              expression,
                                              attr);

            return html;
        }

        private static string GetHtmlAttributes(object htmlAttributes)
        {
            string ret = string.Empty;

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    ret += " " + item.Key + "=" + "'" + item.Value + "'";
                }
            }

            return ret;
        }
    }
}