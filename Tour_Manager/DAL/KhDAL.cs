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
                string query = "INSERT INTO dbo.KhachHang(EmailKH,TenKH,PhoneKH,Active) VALUES ('" + id + "','" + name + "'," + phone + ",'Active')";
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

        public bool UpdateKH(string email, string name, int phone)
        {
            bool result = true;
            try
            {
                result = true;
                string query = "UPDATE dbo.KhachHang SET TenKH = '" + name + "', PhoneKH=" + phone + " WHERE EmailKH='" + email + "';";
                SqlCommand com = new SqlCommand(query, conn);
                com.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;

        }
        public bool DeleteKH(string email)
        {
            bool result = true;
            try
            {
                result = true;
                string query = "UPDATE dbo.KhachHang SET Active='NoActive' WHERE EmailKH='" + email + "';";
                SqlCommand com = new SqlCommand(query, conn);
                com.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;

        }
        public DataTable GetKH()
        {
            string sql = "SELECT * FROM dbo.KhachHang WHERE Active='Active'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
