using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbConnection
    {
        public SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-P1BN3VG\SQLEXPRESS;Initial Catalog=tour_manager;Integrated Security=True";
            conn.Open();
            return conn;
        }
    }
}
