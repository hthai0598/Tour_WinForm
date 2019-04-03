using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using DAL;

namespace TestDAL
{
    [TestClass]
    public class TestOrderDAL
    {
        
        [TestMethod]
        public void Test_CreateOrder()
        {
            OrderTourDAL orderTourDAL = new OrderTourDAL();
       
            
            OrderTour orderTour = new OrderTour();

            orderTour.KH_Order = new KhachHang();
            orderTour.Tour_Order = new Tour();
            
            orderTour.SoKH = 12;
            orderTour.SoTreEm = 6;
            orderTour.SoNguoiLon = 6;
            Assert.IsTrue(orderTourDAL.CreateOrder("thaimeo@gmai.com", "s", orderTour));
            
        }
    }
}
