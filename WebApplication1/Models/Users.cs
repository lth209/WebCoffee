using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Users
    {
        public Users()
        {
        }
        [Key]
        public int Id { get; set; }
        public string Tentk { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Maquyen { get; set; }
        public int Ttdn { get; set; }
        public string Hinhanh { get; set; }
    }
}
