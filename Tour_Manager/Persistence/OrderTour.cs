using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class OrderTour
    {
        public int OrderID { get; set; }
        public KhachHang KH_Order { get; set; }
        public Tour Tour_Order { get; set; }
        public string NgayTao { get; set; }
        public int Tong { get; set; }
        public int SoKH { get; set; }
        public int SoTreEm { get; set; }
        public int SoNguoiLon { get; set; }
    }
}
