using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class ShoppingcartController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Console.WriteLine("yo");
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int Id)
        {
            if(HttpContext.Session.Get("username") != null)
            {
                string mess = "success!";
                Console.WriteLine(mess);
                return Json(mess);
            }
            return Json("fail");
        }
    }
}
