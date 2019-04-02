using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
namespace TestDAL
{
    [TestClass]
    public class TestDbConnection
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(DbConnection.OpenConnection());
        }
    }
}
