using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SteamProjectConnectionString"].ToString()))
            {
                sqlCon.Open();
            }            
        }
    }
}
