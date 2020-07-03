using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Donhang
    {
        public Donhang(int makh, DateTime ngaydat, float tongtien, string httt, string ghichu, DateTime createdAt)
        {
            Makh = makh;
            Ngaydat = ngaydat;
            Tongtien = tongtien;
            Httt = httt;
            Ghichu = ghichu;
            CreatedAt = createdAt;
        }

        [Key]
        public int Madh { get; set; }
        public int Makh { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaydat { get; set; }
        public float Tongtien { get; set; }
        public string Httt { get; set; }
        public string Ghichu { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Tttt { get; set; }
    }
}
