using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project
{
    class Database
    {
        public static SqlConnection ConnectDB()
        {
            string connectionString = @"Server=LAPTOP-LSE8ACET\SQL_SERVER;Database=TransportReservation;User Id=sa;Password=12345;";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
