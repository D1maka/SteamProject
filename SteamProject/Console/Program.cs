using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SteamProject.Utils;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = HttpRequestUtils.GetValue("http://api.steampowered.com/ISteamApps/GetAppList/v0001/", string.Empty, 1000, null, null);
            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
