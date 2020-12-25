using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Ctdh
    {
        public Ctdh()
        {
        }

        public Ctdh(int madh, int masp, int soluong, double gia, DateTime? createdAt, DateTime? updatedAt)
        {
            Madh = madh;
            Masp = masp;
            Soluong = soluong;
            Gia = gia;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [Key]
        public int MaCtdh { get; set; }
        public int Madh { get; set; }
        public int Masp { get; set; }
        public int Soluong { get; set; }
        public double Gia { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
