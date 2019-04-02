using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Persistence;
namespace TestDAL
{
    [TestClass]
    public class TestTourDAL
    {
        TourDAL tourDAL = new TourDAL();
        [TestMethod]
        public void TestInsertTour()
        {

            var tour = tourDAL.InsertTour("Ha Long Bay", "Di Xa Lam", "Di xa", 2, "30/05/2019",10,1000);
            Assert.IsTrue(tour);
        }


        [TestMethod]
        public void TestDeleteTour()
        {

            var tour = tourDAL.DeleteTour(1);
            Assert.IsTrue(tour);
        }

        [TestMethod]
        public void TestUpdateTour()
        {

            var tour = tourDAL.EditTour(2,"Ha Long", "Di X", "Di", 10, "30/02/2019", 2);
            Assert.IsTrue(tour);
        }
    }
}
