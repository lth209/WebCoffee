using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Cart
    {
        public Cart()
        {
        }

        public Cart(int cartId, int matk)
        {
            CartId = cartId;
            Matk = matk;
        }

        [Key]
        public int CartId { get; set; }
        public int Matk { get; set; }
    }
}
