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
      

        public bool CreateOrder(string email,int tour_id, OrderTour order)
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

                command.CommandText = "SELECT * FROM dbo.Tour WHERE IDTour = " + tour_id + " ";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.Tour_Order.IdTour = (int)reader["IDTour"];
                        order.Tour_Order.Gia = (int)reader["Gia"];
                        order.Tour_Order.KhuyenMai = (int)reader["KhuyenMai"];
                    }
                }
               
                
                ////Thêm Bảng Order
                command.CommandText = "INSERT INTO dbo.OrderTour( EmailKH ,IDTour,TrangThai ,NgayTao ,SoKH ,SoTreEm ,SoNguoiLon)VALUES  ( '" + order.KH_Order.EmailKH + "' , " + order.Tour_Order.IdTour + ", 'Active' ,GETDATE() , " + order.SoKH + " , " + order.SoTreEm + " ," + order.SoNguoiLon + ")";
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
                command.CommandText = "UPDATE dbo.OrderTour SET Tong = ((" + order.Tour_Order.Gia + "-(" + order.Tour_Order.Gia + "-" + order.Tour_Order.KhuyenMai + ")*" + order.SoTreEm + ")+(" + order.SoNguoiLon + "*" + order.Tour_Order.Gia + "))";
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
    }
}
