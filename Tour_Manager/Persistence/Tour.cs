﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Tour
    {
        public int IdTour { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public int SoNgay { get; set; }
        public DateTime NgayDi { get; set; }
        public string KhuyenMai { get; set; }
    }
}
