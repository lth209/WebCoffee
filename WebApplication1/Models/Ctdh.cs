using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Ctdh
    {
        public uint MaCtdh { get; set; }
        public int Madh { get; set; }
        public int Masp { get; set; }
        public int Soluong { get; set; }
        public double Gia { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
