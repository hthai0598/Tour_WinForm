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
    public class TourBL
    {
        TourDAL tourDAL = new TourDAL();
        public DataTable GetAllTour()
        {
            return tourDAL.GetAllTour();
        }
        public bool InsertTour(string id,string name, string mota, string ghichu, int songay, DateTime ngaydi, int khuyenmai, int gia)
        {
            return tourDAL.InsertTour(id,name, mota, ghichu, songay, ngaydi, khuyenmai, gia);
        }
        public bool DeleteTour(int id)
        {
            return tourDAL.DeleteTour(id);
        }
        public bool EditTour(int id, string name, string mota, string ghichu, int songay, string ngaydi, int khuyenmai,int gia)
        {
            return tourDAL.EditTour(id,name, mota, ghichu, songay, ngaydi, khuyenmai, gia);
        }
    }
}
