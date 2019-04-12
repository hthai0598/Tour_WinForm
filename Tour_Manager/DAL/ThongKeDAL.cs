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
    public class ThongKeDAL
    {
        SqlConnection conn = new SqlConnection();
        public ThongKeDAL()
        {
            conn = DbConnection.OpenConnection();
        }
        public List<OrderTour> InsertThongKe()
        {
            
           
            OrderTourDAL orderTourDAL = new OrderTourDAL();

            List<OrderTour> list = new List<OrderTour>();
            try
            {
               
              
                OrderTour orderTour = new OrderTour();
                SqlCommand command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM dbo.OrderTour";
                SqlDataReader reader;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    list.Add(orderTourDAL.ReaderOrder(reader));
                }
                reader.Close();
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
            return list;
        }
        public bool ss()
        {
            bool result = true;
            try
            {
                result = true;
                string query;
                SqlCommand command;
                var list = InsertThongKe();
                foreach(var l in list)
                {
                    query = "INSERT INTO dbo.ThongKe(OrderId) Values (" + l.OrderID + ")";
                    command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }
            }
            catch(System.Exception)
            {
                result = false;
            }
            return result;
                
        }

       
    }
}
