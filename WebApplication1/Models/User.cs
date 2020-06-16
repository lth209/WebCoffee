using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class User
    {
        public int id { get; set; }
        public string tentk { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Password tối thiểu 4 kí tự")]
        public string password { get; set; }
        
    }
}
