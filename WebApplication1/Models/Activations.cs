using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Activations
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string Code { get; set; }
        public sbyte Completed { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
