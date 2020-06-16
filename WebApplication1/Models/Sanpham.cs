using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Sanpham
    {
        [Key]
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public int Maloaisp { get; set; }
        public string Mota { get; set; }
        public float Gia { get; set; }
        public float Giakm { get; set; }
        public string Hinhanh { get; set; }
        public string Dvt { get; set; }
        public int Moi { get; set; }
        public int Sellquantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
