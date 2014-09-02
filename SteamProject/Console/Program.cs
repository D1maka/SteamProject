using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SteamProject.Utils;
using SteamProject.DataObjects;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = HttpRequestUtils.GetValue("http://api.steampowered.com/ISteamApps/GetAppList/v0001/", string.Empty, 1000, null, null);
            Result result = JsonParseUtils<Result>.ParseAlone(response);
            Console.ReadKey();
        }
    }
}
