using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Phanhoi
    {
        public uint Maph { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }
        public string Vande { get; set; }
        public string Noidung { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime Ngayph { get; set; }
    }
}
