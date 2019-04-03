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
        public DataTable GetAllTours()
        {
            return tourDAL.GetAllTours();
        }

        public bool InsertTour(string id,string name, string mota, string ghichu, int songay, DateTime ngaydi, int khuyenmai, int gia,string trangthai)
        {
            return tourDAL.InsertTour(id,name, mota, ghichu, songay, ngaydi, khuyenmai, gia,trangthai);
        }
        public bool DeleteTour(string id)
        {
            return tourDAL.DeleteTour(id);
        }
        public bool EditTour(string id, string name, string mota, string ghichu, int songay, DateTime ngaydi, int khuyenmai,int gia,string trangthai)
        {
            return tourDAL.EditTour(id,name, mota, ghichu, songay, ngaydi, khuyenmai, gia,trangthai);
        }
    }
}
