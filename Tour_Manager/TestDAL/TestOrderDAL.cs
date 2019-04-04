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

        [TestMethod]
        public void Test_DeleteOrder()
        {
            OrderTourDAL orderTourDAL = new OrderTourDAL();
            Assert.IsTrue(orderTourDAL.DeleteOrder(2));
        }

        [TestMethod]
        public void Test_Reader()
        {
            OrderTourDAL orderTourDAL = new OrderTourDAL();
            Assert.IsNotNull(orderTourDAL.ReaderOrder("thaimeoo@gmail.com"));
        }

        [TestMethod]
        public void Test_Update()
        {
            OrderTourDAL orderTourDAL = new OrderTourDAL();
            Assert.IsTrue(orderTourDAL.UpdateOrder(3, 2, 1, "TD101", 8));
        }
    }
}
