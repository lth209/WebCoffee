using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Loaisanpham
    {
        public Loaisanpham()
        {
        }

        public Loaisanpham(int maloaisp, string tenloaisp)
        {
            Maloaisp = maloaisp;
            Tenloaisp = tenloaisp;
        }

        public Loaisanpham(int maloaisp, string tenloaisp, string mota, string hinhanh)
        {
            Maloaisp = maloaisp;
            Tenloaisp = tenloaisp;
            Mota = mota;
            Hinhanh = hinhanh;
        }

        [Key] public int Maloaisp { get; set; }
        public String Tenloaisp { get; set; }
        public String Mota { get; set; }
        public String Hinhanh { get; set; }


    }
}
