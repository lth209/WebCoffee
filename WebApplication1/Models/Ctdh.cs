using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Ctdh
    {
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
