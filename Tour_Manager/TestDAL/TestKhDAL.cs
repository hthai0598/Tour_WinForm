using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using DAL;

namespace TestDAL
{
    [TestClass]
    public class TestKhDAL
    {
        KhDAL khdal = new KhDAL();
        
        [TestMethod]
        public void TestCheckKh()
        {
            
            KhachHang kh = new KhachHang();
            kh.EmailKH = "thaimeo@gmail.com";
            Assert.IsNull(khdal.CheckKhachHang(kh.EmailKH));
        }
    }
}
