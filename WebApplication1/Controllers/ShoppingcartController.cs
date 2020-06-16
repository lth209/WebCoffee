using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Others;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class ShoppingcartController : Controller
    {
        private int userid;

        // GET: /<controller>/
        public IActionResult Index()
        {
            Cart a = new Cart();
            if (HttpContext.Request.Cookies["user_id"] != null)
            {
                userid = int.Parse(HttpContext.Request.Cookies["user_id"]);

                a = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
                ViewData["items"] = getCartDetail(a.CartId);
                Console.WriteLine("yo");
            }
            ViewData["cart"] = a;
            return View();
        }

        public List<Sanpham> getCartDetail(int cartid)
        {
            using (Context context = new Context())
            {
                List<Sanpham> products = new List<Sanpham>();
                var cd = context.CartDetail.Where(p => p.CartId == cartid).ToList();
                foreach (var c in cd)
                {
                    products.Add(context.Sanpham.Where(p => p.Masp == c.Masp).Single());
                }
                return products;
            }
        }

        [HttpPost]
        public IActionResult AddToCart(int masp, int quantity)
        {
            String useridstring = HttpContext.Request.Cookies["user_id"];
            if (useridstring != null)
            {
                int userid = int.Parse(useridstring);
                Cart a = AddCartToDb(userid, masp, quantity);
                String stat = "success";
                if(a == null) { stat = "fail"; }
                var mess = new
                {
                    status = stat,
                    cart = a
                };

                Console.WriteLine(mess);
                return Json(mess);
            }
            var mess1 = new
            {
                status = "not signin",
                cart = ""
            };
            return Json(mess1);
        }

        public Cart AddCartToDb(int userid, int masp, int quantity)
        {
            using (Context context = new Context())
            {
                var product = context.Sanpham.Where(p => p.Masp == masp).FirstOrDefault();
                var cart = context.Cart.Where(p => p.Matk == userid).FirstOrDefault();
                int cartid = 0;
                if (cart != null)
                {
                    cart.Amount += quantity;
                    cart.Total += product.Gia * quantity;
                }
                else
                {
                    Cart c = new Cart(userid);
                    c.Amount = quantity;
                    c.Total = product.Gia * quantity;
                    context.Cart.Add(c);
                }
                int rows = context.SaveChanges();
                if (rows > 0)
                {
                    var newcart = context.Cart.Where(p => p.Matk == userid).FirstOrDefault();
                    cartid = newcart.CartId;
                    AddCartDetail(cartid, masp, quantity);
                    return cart;
                }
                else return null;
            }
        }
        public void AddCartDetail(int cartid, int masp, int quantity)
        {
            using(Context context = new Context())
            {
                var product = context.CartDetail.Where(p => p.CartId == cartid && p.Masp == masp).FirstOrDefault();
                if (product != null)
                {
                    product.Quantity += quantity;
                }
                else
                {
                    CartDetail cd = new CartDetail(cartid, masp, quantity);
                    var cartdetail = context.CartDetail.Add(cd);
                }
                
                int rows = context.SaveChanges();
                if (rows > 0)
                {
                    Console.WriteLine("Thêm sp vào cart thành công!");
                }
            }
        }
    }
}
