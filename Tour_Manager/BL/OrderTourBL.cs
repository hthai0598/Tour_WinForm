using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class OrderTourBL
    {
        OrderTourDAL orderTourDAL = new OrderTourDAL();
        public bool Create_Order(string email,string id, OrderTour order)
        {
            return orderTourDAL.CreateOrder(email, id, order);
        }
        public bool DeleteOrder(int id)
        {
            return orderTourDAL.DeleteOrder(id);
        }
        public DataTable GetAllOrderActive()
        {
            return orderTourDAL.GetAllOrderActive();
        }
        public OrderTour ReaderOrder(string id)
        {
            return orderTourDAL.ReaderOrder(id);
        }
        public bool UpdateOrder(int songuoi, int sotreem, int songuoilon, string room, int id)
        {
            return orderTourDAL.UpdateOrder(songuoi, sotreem, songuoilon, room, id);
        }
    }
}
