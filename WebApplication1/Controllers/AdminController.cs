using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*---------------Mc lam` :>----------------*/
        public IActionResult ProductManager()
        {
            return View(); //ProductManager.cshtml
        }

        public IActionResult CustomerManager()
        {
            return View(); //CustomerManager.cshtml
        }

        public IActionResult AccountManager()
        {
            return View(); //AccountManager.cshtml
        }
    }
}