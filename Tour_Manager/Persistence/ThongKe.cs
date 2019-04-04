using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Persistence
{
    public class ThongKe
    {
        public int IdThongKe { get; set; }
        public List<OrderTour> ListOrder { get; set; }
        public float Tong { get; set; }
        public DateTime NgayXuat { get; set; }
    }
}
