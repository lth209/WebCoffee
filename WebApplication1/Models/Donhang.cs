﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Donhang
    {
        public uint Madh { get; set; }
        public int? Makh { get; set; }
        public DateTime? Ngaydat { get; set; }
        public float? Tongtien { get; set; }
        public string Httt { get; set; }
        public string Ghichu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Tttt { get; set; }
    }
}
