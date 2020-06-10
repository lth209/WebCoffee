using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Tintuc
    {
        public int Matt { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public string Hinhanh { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
