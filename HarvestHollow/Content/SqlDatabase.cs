using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HarvestHollow.Content.GameData
{
    internal abstract class SqlDatabase
    {
        protected SqlConnection Conn;
        protected void ConnectToDatabase(string serverName, string dbName, string userName, string pass)
        {
            try
            {
                // Attempt connection to database
                Conn = new SqlConnection();
                Conn.ConnectionString =
                    $"Data Source={serverName};" +
                    $"Initial Catalog={dbName};" +
                    $"User id={userName};" +
                    $"Password={pass};";
                Conn.Open();
            }
            catch (SqlException ex) {
                Console.WriteLine("Inner exception: " + ex.Message);
                Conn.Close();
            }
        }
        protected void CloseConnection() { Conn.Close(); }
        protected void Deconstruct()
        {
            CloseConnection();
        }
    }
}
