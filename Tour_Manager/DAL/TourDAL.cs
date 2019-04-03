using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Persistence;

namespace DAL
{
    public class TourDAL
    {
        SqlConnection conn = new SqlConnection();
        public TourDAL()
        {
            conn = DbConnection.OpenConnection();
        }
        public DataTable GetAllTour()
        {
            string sql = "SELECT * FROM dbo.Tour WHERE TrangThai='Active'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable GetAllTours()
        {
            string sql = "SELECT * FROM dbo.Tour";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public Tour GetTourById(string id)
        {
            SqlDataReader reader;
            Tour tour = new Tour();
            string query = "SELECT * FROM dbo.Tour WHERE IDTour= '" + id + "' ";
            SqlCommand command = new SqlCommand(query, conn);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                tour.IdTour = (string)reader["IDTour"];
                tour.TenTour = (string)reader["TenTour"];
                tour.MoTa = (string)reader["MoTa"];
                tour.GhiChu = (string)reader["GhiChu"];
                tour.SoNgay = (int)reader["SoNgay"];
                tour.NgayDi = (DateTime)reader["NgayDi"];
                tour.KhuyenMai = (int)reader["KhuyenMai"];
                tour.Gia = (int)reader["Gia"];
            }
            reader.Close();
            conn.Close();
            return tour;

        }
        public bool InsertTour(string id,string name, string mota, string ghichu, int songay, DateTime ngaydi, int khuyenmai, int gia, string trangthai)
        {
            bool result = true;
           
        
            try
            {
                string query = "INSERT INTO dbo.Tour(IDTour,TenTour ,Mota , GhiChu , SoNgay , NgayDi ,KhuyenMai,Gia,TrangThai)VALUES  ( '"+id+"','" + name + "' , '" + mota + "' ,'" + ghichu + "' , " + songay + " , '" + ngaydi + "' , " + khuyenmai + "," + gia + ",'"+trangthai+"')";
                SqlCommand com = new SqlCommand(query, conn);
                com.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }

        


        public bool DeleteTour(string id)
        {
            bool result = true;
            try
            {
                string query = "UPDATE dbo.Tour SET TrangThai='NoActive' where IDTour = '" + id + "';";
                SqlCommand com = new SqlCommand(query, conn);
                com.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                result = false;
            }
            return result;
        }
        public bool EditTour(string id, string name, string mota, string ghichu, int songay, DateTime ngaydi, int khuyenmai, int gia,string trangthai)
        {
            bool result = true;
            try
            {
                string query = "UPDATE dbo.Tour SET IDTour='"+id+"',TenTour = '" + name + "', Mota='" + mota + "',GhiChu='" + ghichu + "',SoNgay= " + songay + ",NgayDi='" + ngaydi + "',KhuyenMai=" + khuyenmai + ",Gia= "+gia+",TrangThai='"+trangthai+"' WHERE IDTour = '"+id+"' ";
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

    }
}
