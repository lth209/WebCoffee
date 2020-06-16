using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Hoadon
    {
        public uint Mahd { get; set; }
        public int? Makh { get; set; }
        public DateTime? Ngaythanhtoan { get; set; }
        public float? Tongtien { get; set; }
        public string Httt { get; set; }
        public string Ghichu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
