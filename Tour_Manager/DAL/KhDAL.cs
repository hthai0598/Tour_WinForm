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
                string query = @"select * from dbo.KhachHang where EmailKH = '"+email+"'";
                SqlCommand com = new SqlCommand(query, conn);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                KhachHang kh = null; 
                if (reader.Read())
                {
                kh = new KhachHang();
                    kh.EmailKH = (string)reader["EmailKH"];
                    kh.TenKH = (string)reader["TenKH"];
                    kh.PhoneKH = (int)reader["PhoneKH"];
                    return kh;
                }
                reader.Close();
                conn.Close();
                return kh;
        }


        public bool InsertKH(string id, string name, int phone)
        {
            bool result = true;
            try
            {
                string query = "INSERT INTO dbo.KhachHang(EmailKH,TenKH,PhoneKH) VALUES ('" + id + "','" + name + "'," + phone + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch(System.Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
