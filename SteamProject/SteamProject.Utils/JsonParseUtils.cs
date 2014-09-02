using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using SteamProject.DataObjects;

namespace SteamProject.Utils
{
    public static class JsonParseUtils
    {
        public static T ParseAlone<T>(string json)
        {
            JObject jobj = JObject.Parse(json);

            T result = jobj.ToObject<T>();
            return result;
        }

        public static List<T> ParseArr<T>(string json)  
        {
            JArray jarr = JArray.Parse(json);

            List<T> result = null;

            foreach (var item in jarr)
            {
                result.Add(item.ToObject<T>());
            }
            return result;
        }
    }
}
