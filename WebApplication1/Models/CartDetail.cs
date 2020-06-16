using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CartDetail
    {
        public CartDetail()
        {
        }

        public CartDetail(int cartId, int masp, int quantity)
        {
            CartId = cartId;
            Masp = masp;
            Quantity = quantity;
        }
        [Key]
        public int CartId { get; set; }
        public int Masp { get; set; }
        public int Quantity { get; set; }


    }
}
