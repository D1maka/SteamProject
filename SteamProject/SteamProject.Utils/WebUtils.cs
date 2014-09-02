using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SteamProject.Utils
{
    public static class WebUtils
    {
        public static string GetRootHTTP()
        {
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                if (!HttpContext.Current.Items.Contains("WebUtils.RootHTTP"))
                {
                    string value = (string.Format("{0}://{1}{2}/", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath)).Replace("//", "/").Replace(":/", "://");
                    HttpContext.Current.Items["WebUtils.RootHTTP"] = value;

                    return value;
                }
                else
                    return (string)HttpContext.Current.Items["WebUtils.RootHTTP"];
            }
            else
            {
                return "/";
            }
        }

        public static bool IsRequestIsNotNull(HttpRequest Request, string value)
        {
            return Request != null && QueryUtils.QueryString != null && QueryUtils.QueryString[value] != null && QueryUtils.QueryString[value] != String.Empty;
        }

        public static int? GetRequestParamValueInt32Nullable(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToInt32Nullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        public static int GetRequestParamValueInt32(HttpRequest Request, string paramName)
        {
            return GetRequestParamValueInt32(Request, paramName, false);
        }

        public static int GetRequestParamValueInt32(HttpRequest Request, string paramName, bool isZero)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToInt32(QueryUtils.QueryString[paramName], isZero);
            }

            return isZero ? 0 : -1;
        }

        public static short GetRequestParamValueInt16(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToInt16(QueryUtils.QueryString[paramName]);
            }

            return -1;
        }

        public static short? GetRequestParamValueInt16Nullable(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToInt16Nullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        public static byte GetRequestParamValueByte(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToByte(QueryUtils.QueryString[paramName]);
            }

            return 0;
        }

        public static byte? GetRequestParamValueByteNullable(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToByteNullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        public static bool GetRequestParamValueBoolean(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToBoolean(QueryUtils.QueryString[paramName]);
            }

            return false;
        }

        public static bool? GetRequestParamValueBooleanNullable(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToBooleanNullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        public static string GetRequestParamValueString(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Converter.ToStringNullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        //public static DateTime GetRequestParamValueDateTime(HttpRequest Request, string year, string month, string day)
        //{
        //    return GetRequestParamValueDateTime(Request, year, month, day, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
        //}

        //public static DateTime GetRequestParamValueDateTime(HttpRequest Request, string year, string month, string day, DateTime defaultValue)
        //{
        //    int yearInt = 0;
        //    int monthInt = 0;
        //    int dayInt = 0;
        //    if (IsRequestIsNotNull(Request, year))
        //        yearInt = Converter.ToInt32(QueryUtils.QueryString[year]);
        //    else
        //        yearInt = defaultValue.Year;

        //    if (IsRequestIsNotNull(Request, month))
        //        monthInt = DateTimeUtils.GetMonthEnglishToInt(Converter.ToString(QueryUtils.QueryString[month])) ?? defaultValue.Month;
        //    else
        //        monthInt = defaultValue.Month;

        //    if (IsRequestIsNotNull(Request, day))
        //        dayInt = Converter.ToInt32(QueryUtils.QueryString[day]);
        //    else
        //        dayInt = defaultValue.Day;

        //    return Converter.ToDateTime(
        //        yearInt,
        //        monthInt,
        //        dayInt);
        //}
    }
}
