﻿using System;
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
            Assert.IsNotNull(khdal.CheckKhachHang("hihi@gmail.com"));
        }


        [TestMethod]
        public void TestInsertKH()
        {
            Assert.IsTrue(khdal.InsertKH("hihi@gmail.com", "Long", 0904296456));
        }
        [TestMethod]
        public void TestUpdateKH()
        {
            Assert.IsTrue(khdal.UpdateKH("thaimeo@gmail.com","hanh",9999));
        }
        [TestMethod]
        public void TestDeleteKH()
        {
            Assert.IsTrue(khdal.DeleteKH("thaimeo@gmail.com"));
        }
    }
}
