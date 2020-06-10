using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Khachhang
    {
        public uint Makh { get; set; }
        public string Hoten { get; set; }
        public string Gioitinh { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Sodt { get; set; }
        public string Ghichu { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? Matk { get; set; }
    }
}
