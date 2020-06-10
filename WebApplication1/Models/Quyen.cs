using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Quyen
    {
        public uint Maquyen { get; set; }
        public string Tenquyen { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
