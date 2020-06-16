using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Dknt
    {
        public uint Id { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime Ngaydk { get; set; }
    }
}
