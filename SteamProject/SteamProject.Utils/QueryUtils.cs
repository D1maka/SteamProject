using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;

namespace SteamProject.Utils
{
    public static class QueryUtils
    {
        public const string keyFilter = "Manitou.Helper.QueryUtils";

        public static NameValueCollection QueryString
        {
            get
            {
                if (HttpContext.Current == null)
                    return new NameValueCollection();

                if (HttpContext.Current.Items.Contains(keyFilter))
                    return (NameValueCollection)HttpContext.Current.Items[keyFilter];

                return HttpContext.Current.Request.QueryString;
            }

            set
            {
                HttpContext.Current.Items[keyFilter] = value;
            }
        }

        public static string GetFullQuery
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                NameValueCollection q = QueryString;

                foreach (string key in q.AllKeys)
                {
                    sb.Append(key);
                    sb.Append("=");
                    sb.Append(q[key]);
                    sb.Append("&");
                }

                return sb.ToString().TrimEnd(new char[] { '&' });
            }
        }

        public static string GetFullUrl
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}Default.aspx", WebUtils.GetRootHTTP());

                string query = GetFullQuery;

                sb.AppendFormat("{0}{1}", string.IsNullOrEmpty(query) ? "" : "?", query);

                return sb.ToString();
            }
        }

        public static string GetValue(string value, string key)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            value = value.TrimStart('?');
            if (value.Length > 0)
            {
                foreach (string parameters in value.Split('&'))
                {
                    string[] keyVal = parameters.Split('=');
                    if (keyVal[0] == key)
                        return keyVal[1];
                }
            }

            return "";
        }
    }
}
