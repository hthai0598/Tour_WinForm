using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Persistence;
using System.Data;
using System.Data.SqlClient;

namespace TestDAL
{
    [TestClass]
    public class TestTourDAL
    {
        TourDAL tourDAL = new TourDAL();
        [TestMethod]
        public void TestInsertTour()
        {
            DateTime a;
            string b = "2018/07/05";
            a = Convert.ToDateTime(b);
            var tour = tourDAL.InsertTour("kk","Ha Long Bay", "Di Xa Lam", "Di xa", 2, a,10,1000);
            Assert.IsTrue(tour);
        }


        [TestMethod]
        public void TestDeleteTour()
        {

            var tour = tourDAL.DeleteTour("");
            Assert.IsTrue(tour);
        }

        [TestMethod]
        public void TestUpdateTour()
        {
            DateTime a;
            string b = "2018/08/05";
            a = Convert.ToDateTime(b);
            var tour = tourDAL.EditTour("s","sng", "Di X", "Di", 10, a, 2,10000);
            Assert.IsTrue(tour);
        }

        [TestMethod]
        public void TestGetAllTour()
        {
 
            Assert.IsNotNull(tourDAL.GetAllTour());
        }

        [TestMethod]
        public void TestReaderTour()
        {

            Assert.IsNotNull(tourDAL.GetTourById("s"));
        }
    }
}
