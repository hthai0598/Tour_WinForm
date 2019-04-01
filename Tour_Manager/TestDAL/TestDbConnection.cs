using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
namespace TestDAL
{
    [TestClass]
    public class TestDbConnection
    {
        DbConnection conn = new DbConnection();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(conn.OpenConnection());
        }
    }
}
