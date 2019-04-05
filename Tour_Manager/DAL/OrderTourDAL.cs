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
    public class OrderTourDAL
    {
        SqlConnection conn = new SqlConnection();
        public OrderTourDAL()
        {
            conn = DbConnection.OpenConnection();
        }
      

        public bool CreateOrder(string email,string tour_id, OrderTour order)
        {
            
            bool result = true;
            SqlCommand command = conn.CreateCommand();
            command.Connection = conn;
            SqlDataReader reader;

            try
            {
     
                //Lấy ra mã Khách Hàng
                command.CommandText = "SELECT * FROM dbo.KhachHang WHERE EmailKH = '" + email + "'  ";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.KH_Order.EmailKH = (string)reader["EmailKH"];
                        order.KH_Order.TenKH = (string)reader["TenKH"];
                        order.KH_Order.PhoneKH = (int)reader["PhoneKH"];
                    }
                }
                
                //Lấy ra mã Tour

                command.CommandText = "SELECT * FROM dbo.Tour WHERE IDTour = '" + tour_id + "' ";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.Tour_Order.IdTour = (string)reader["IDTour"];
                        order.Tour_Order.Gia = (int)reader["Gia"];
                        order.Tour_Order.KhuyenMai = (int)reader["KhuyenMai"];
                    }
                }
               
                
                ////Thêm Bảng Order
                command.CommandText = "INSERT INTO dbo.OrderTour( EmailKH ,IDTour,TrangThai ,NgayTao ,SoKH ,SoTreEm ,SoNguoiLon)VALUES  ( '" + order.KH_Order.EmailKH + "' , '" + order.Tour_Order.IdTour + "', 'Active' ,GETDATE() , " + order.SoKH + " , " + order.SoTreEm + " ," + order.SoNguoiLon + ")";
                command.ExecuteNonQuery();
                command.CommandText = "SELECT MAX(OrderID) AS OrderID FROM dbo.OrderTour";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.OrderID = (int)reader["OrderID"];
                    }
                   
                }
                command.CommandText = "SELECT * FROM dbo.OrderTour INNER JOIN dbo.Tour ON Tour.IDTour = OrderTour.IDTour WHERE OrderID = " + order.OrderID + " ";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        order.Tour_Order.Gia = (int)reader["Gia"];
                    }

                }
                command.CommandText = "UPDATE dbo.OrderTour SET Tong = (("+order.Tour_Order.Gia+ "-(" + order.Tour_Order.Gia + "*("+order.Tour_Order.KhuyenMai+ "*0.01)))*" + order.SoTreEm + " + (" + order.SoNguoiLon+"*"+order.Tour_Order.Gia+")) WHERE OrderID = " + order.OrderID +" "; 
                command.ExecuteNonQuery();
                result = true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            finally
            {
               
               
                conn.Close();
            }


            return result;
            


        }

        public bool DeleteOrder(int id)
        {
            bool result = true;
            try
            {
                result = true;
                string query = "UPDATE dbo.OrderTour SET Tong = 0.2%100*Tong, TrangThai='Cancel' WHERE OrderID =" + id + "";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();

            }
            catch
            {
                result = false;
            }
            return result;
        }


        public int Gia;
        public int KhuyenMai;
        public bool UpdateOrder(int songuoi,int sotreem,int songuoilon, string room, int id)
        {
            bool result = true;
            
            
            try
            {
             
               
                OrderTour order = new OrderTour();
                SqlDataReader reader;
                result = true;
                string query = "UPDATE dbo.OrderTour SET SoKH ="+songuoi+",SoTreEm = "+sotreem+",SoNguoiLon = "+songuoilon+", IDTour = '"+room+"' WHERE OrderID = "+id+"";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                string query2 = "SELECT * FROM dbo.Tour WHERE IDTour= '"+room+"'";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                using (reader = cmd2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.Tour_Order = new Tour();
                        order.Tour_Order.Gia = (int)reader["Gia"];
                        order.Tour_Order.KhuyenMai = (int)reader["KhuyenMai"];
                    }
                    
                }
                string query1 = "UPDATE dbo.OrderTour SET Tong = ((" + order.Tour_Order.Gia + "-(" + order.Tour_Order.Gia + "*(" + order.Tour_Order.KhuyenMai + "*0.01)))*" + sotreem + " + (" + songuoilon + "*" + order.Tour_Order.Gia + ")) WHERE OrderID = " + id+"";
                SqlCommand command1 = new SqlCommand(query1, conn);
                command1.ExecuteNonQuery();
                result = true;
                

            }
            catch(System.Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }
        public DataTable GetAllOrderActive()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.OrderTour WHERE TrangThai = 'Active' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public OrderTour ReaderOrder(string id)
        {
            OrderTour order = null;
            SqlDataReader reader;
            string sql = "SELECT * FROM dbo.OrderTour WHERE TrangThai='Active' AND EmailKH='"+id+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                order = new OrderTour();
                order.KH_Order = new KhachHang();
                order.Tour_Order = new Tour();
                order.OrderID = (int)reader["OrderID"];
                order.KH_Order.EmailKH = (string)reader["EmailKH"];
                order.Tour_Order.IdTour = (string)reader["IDTour"];
                order.Tong = (int)reader["Tong"];
                order.SoKH = (int)reader["SoKh"];
                order.SoNguoiLon = (int)reader["SoNguoiLon"];
                order.SoTreEm = (int)reader["SoTreEm"];
                return order;
            }
            reader.Close();
            conn.Close();
            return order;

        }
    }
}
