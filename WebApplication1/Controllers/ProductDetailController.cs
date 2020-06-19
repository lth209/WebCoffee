using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index()
        {
            ViewData["cart"] = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
            return View();
        }
        [Route("ProductDetail/{id:int}")]
        public IActionResult Detail(int id)
        {
            ViewData["cart"] = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
            using (Context context = new Context())
            {
                ViewData["products"] = context.Sanpham.ToList();
                return View(context.Sanpham.FirstOrDefault(a => a.Masp == id));
            }
        }
        
        public IActionResult AnchorTagHelper(int id)
        {
            var product = new Sanpham
            {
                Masp = id
            };

            return View(product);
        }
    }
}