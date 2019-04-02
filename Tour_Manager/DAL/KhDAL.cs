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
    public class KhDAL
    {
        SqlConnection conn = new SqlConnection();
        public KhDAL()
        {
            conn = DbConnection.OpenConnection();
        }
        public KhachHang CheckKhachHang(string email)
        {
            KhachHang kh = new KhachHang();
            kh = null;
            SqlDataReader reader;
            string query = "SELECT * FROM dbo.KhachHang WHERE EmailKH = '" + email + "'  ";
            SqlCommand com = new SqlCommand(query, conn);
            reader = com.ExecuteReader();
            if (reader.Read())
            {
                kh.EmailKH = (string)reader["EmailKH"];
                kh.TenKH = (string)reader["TenKK"];
                kh.PhoneKH = (int)reader["PhoneKH"];
            }
            reader.Close();
            conn.Close();
            return kh;
        }
    }
}
