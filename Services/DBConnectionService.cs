using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace WebApp.Services
{
    public class DBConnectionService
    {
        public DBConnectionService()
        {

        }

        private static string ConnectionString = "server=localhost;user=root;database=tsd;port=3306;password=Asyrani92";

        private MySqlConnection conn = new MySqlConnection(ConnectionString);
        public ConnectionState GetConnectionStatus { get { return conn.State; } }
        public void OpenConnection() { conn.Open(); }
        public void CloseConnection() { conn.Close(); }
        public MySqlConnection GetConnection { get { return conn; } }
    }
}
