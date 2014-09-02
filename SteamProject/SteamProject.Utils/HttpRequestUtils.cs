using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SteamProject.Utils
{
    public static class HttpRequestUtils
    {
        private static HttpWebRequest GetRequest(string xmlUrl, string proxy, int timeOut)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xmlUrl);

            if (!string.IsNullOrEmpty(proxy))
            {
                WebProxy wp = new WebProxy();

                Uri url = new Uri(proxy);
                wp.Address = url;

                request.Proxy = wp;
            }

            if (timeOut < 100)
                timeOut = 100;

            request.Timeout = timeOut;

            return request;
        }

        public static string GetValue(string url, string proxy, int timeOut, string userLogin, string userPassword)
        {
            try
            {
                HttpWebRequest request = GetRequest(url, proxy, timeOut);

                if (!string.IsNullOrEmpty(userLogin))
                {
                    request.Credentials = new NetworkCredential(userLogin, userPassword);
                }

                string result;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Encoding encode = GetCodingRequest(response, proxy, timeOut, userLogin, userPassword);
                        using (Stream ResponseStream = response.GetResponseStream())
                        {
                            using (StreamReader ReadStream = new StreamReader(ResponseStream))
                            {
                                result = ReadStream.ReadToEnd();
                            }
                        }
                    }
                    else
                        throw new Exception(string.Format("Ошибка соединения! Код ошибки - {0} описание ошибки {1}", response.StatusCode, response.StatusDescription));
                }

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
