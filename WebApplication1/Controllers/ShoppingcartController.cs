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
        private int Userid;
        private int Cartid;

        // GET: /<controller>/
        public IActionResult Index()
        {
            Cart a = new Cart();
            if (HttpContext.Request.Cookies["user_id"] != null)
            {
                Userid = int.Parse(HttpContext.Request.Cookies["user_id"]);

                a = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
                Cartid = a.CartId;
                ViewData["items"] = getListItemInCart(a.CartId);
                ViewData["cartdetails"] = getListOfCartDetail(a.CartId);
                Console.WriteLine("yo");
            }
            ViewData["cart"] = a;
            return View();
        }

        public List<Sanpham> getListItemInCart(int cartid)
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

        public List<CartDetail> getListOfCartDetail(int cartid)
        {
            using (Context context = new Context())
            {
                List<Sanpham> products = new List<Sanpham>();
                var cd = context.CartDetail.Where(p => p.CartId == cartid).ToList();
                return cd;
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

        [HttpPost]
        public IActionResult RemoveItem(int masp)
        {
            using (Context context = new Context())
            {
                Userid = int.Parse(HttpContext.Request.Cookies["user_id"]);
                Cart a = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
                var cd = context.CartDetail.Where(p => p.Masp == masp && p.CartId == a.CartId).Single();
                context.CartDetail.Remove(cd);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    a = UpdateCart(a.CartId);
                    var mess = new
                    {
                        cart = a,
                        Status= "success"
                    }; 
                    return Json(mess);
                }
                return Json("fail");
            }
        }

        public Cart UpdateCart(int cartid)
        {
            using (Context context = new Context())
            {
                var cart = context.Cart.Where(p => p.CartId == cartid).Single();
                var cds = context.CartDetail.Where(p => p.CartId == cartid).ToList();
                List<Sanpham> items = getListItemInCart(cartid);
                int newQuantity = 0;
                float newTotal = 0;
                foreach (var cd in cds)
                {
                    newQuantity += cd.Quantity;
                    newTotal += cd.Quantity * items.Find(p => p.Masp == cd.Masp).Gia;
                }
                cart.Amount = newQuantity;
                cart.Total = newTotal;
                context.SaveChanges();
                return cart;
            }
        }

        [HttpPost]
        public IActionResult UpdateCartDetail(int quantity, int masp)
        {
            Userid = int.Parse(HttpContext.Request.Cookies["user_id"]);
            Cart a = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
            using (Context context = new Context())
            {
                var cd = context.CartDetail.Where(p => p.CartId == a.CartId && p.Masp == masp).Single();
                cd.Quantity = quantity;
                int res = context.SaveChanges();
                if (res > 0)
                {
                    a = UpdateCart(a.CartId);
                    var mess = new
                    {
                        cart = a,
                        Status = "success"
                    };
                    return Json(mess);
                }
                return Json("fail");
            }
        }
    }
}
