using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WebApp.Models
{
    public static class dbConnection
    {
        //private static string ConnectionString = "Server=tcp:iforest9dbserver.database.windows.net,1433;Initial Catalog=iForest9;Persist Security Info=False;User ID=iForest9DBadmin;Password=iForest9@2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //private static string ConnectionString = "Data Source=FYAIS-MASTER;Initial Catalog=iForest9;User ID=iForest9DBadmin;Password=password@123;";
        private static string ConnectionString = "server=localhost;user=root;database=tsd;port=3306;password=Asyrani92";
        private static MySqlConnection conn = new MySqlConnection(ConnectionString);
        public static string GetConnectionStatus { get { return conn.State.ToString(); } }
        public static void OpenConnection() { conn.Open(); }
        public static void CloseConnection() { conn.Close(); }
        public static MySqlConnection GetConnection { get { return conn; } }
    }
}
