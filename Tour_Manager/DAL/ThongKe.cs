using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class ThongKe
    {
        SqlConnection conn = new SqlConnection();
        public ThongKe()
        {
            conn = DbConnection.OpenConnection();
        }
        public DataTable GetAllDate()
        {
            string sql = "select DISTINCT CAST (OrderDate as date) AS date from dbo.Orders ";
        }
    }
}
