using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class KhachHangController : Controller
    {
        public IActionResult Index()
        {
            Khachhang user = Function.getCurrentUser(HttpContext.Request.Cookies["user_id"]);
            ViewData["kh"] = user;
            return View();
        }

        public IActionResult DonHang()
        {
            Khachhang user = Function.getCurrentUser(HttpContext.Request.Cookies["user_id"]);
            ViewData["kh"] = user;
            String uid = HttpContext.Request.Cookies["user_id"];
            int id = int.Parse(uid);
            List<Donhang> ods = GetOrderFromDb(user.Makh);
            ViewData["products"] = GetSanphams();
            ViewData["ods"] = ods;
            ViewData["ctdh"] = GetOrderDetails(user.Makh);
            return View();
        }
        [HttpPost]
        public IActionResult UpdateKh(Khachhang u)
        {
            String uid = HttpContext.Request.Cookies["user_id"];
            int id = int.Parse(uid);
            using (Context context = new Context())
            {
                var kh = context.Khachhang.Where(p => p.Matk == id).Single();
                kh.Sodt = u.Sodt;
                kh.Hoten = u.Hoten;
                kh.Diachi = u.Diachi;
                kh.Email = u.Email;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public List<Sanpham> GetSanphams()
        {
            using (Context context = new Context())
            {
                var products = context.Sanpham.ToList();
                return products;
            }
        }
        public List<Donhang> GetOrderFromDb(int makh)
        {
            using (Context context = new Context())
            {
                var order = context.Donhang.Where(p => p.Makh == makh).ToList();
                return order;
            }
        }

        public List<Ctdh> GetOrderDetails(int makh)
        {
            using (Context context = new Context())
            {
                var ct = (from o in context.Donhang
                          join c in context.Ctdh on o.Madh equals c.Madh
                          where o.Makh == makh
                          select c).ToList();
                return ct;
            }
            
        }

    }
}