﻿using System;
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
    public class KhBL
    {
        KhDAL khDAL = new KhDAL();
        public KhachHang CheckKH(string email)
        {
            return khDAL.CheckKhachHang(email);
        }
        public bool InsertKH(string id, string name,int phone)
        {
            return khDAL.InsertKH(id, name, phone);
        }
        public bool UpdateKH(string email, string name, int phone)
        {
            return khDAL.UpdateKH(email, name, phone);
        }
        public bool DeleteKH(string email)
        {
            return khDAL.DeleteKH(email);
        }
        public DataTable GetKH()
        {
            return khDAL.GetKH();
        }
        


    }
}
