using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class KhachHangController : Controller
    {


        public IActionResult KhachHang()
        {
            string id = HttpContext.Request.Cookies["user_id"];
            var dbContext = new Context();
            var kh = dbContext.Khachhang.Where(p => p.Matk == int.Parse(id)).Single();
            ViewData["kh"] = kh as Khachhang;
            return View();
        }

        public IActionResult DonHang()
        {
            string id = HttpContext.Request.Cookies["user_id"];
            var dbContext = new Context();
            var dh = dbContext.Donhang.Where(p=> p.Madh== int.Parse(id)).Single();
            ViewData["dh"] = dh as Donhang;
            return View();
        }
        public IActionResult DanhSachKhachHang()
        {
            var dbContext = new Context();
            var khachhang = (from KhachHang in dbContext.Khachhang
                             select KhachHang).ToList();
            ViewBag.khachhang = khachhang;
            return View();
        }

        public IActionResult SuaKhachHang(int id, string err, string success)
        {
            var dbContext = new Context();
            var khachhang = (from Khachhang in dbContext.Khachhang
                             where Khachhang.Makh == id
                             select Khachhang).ToList();
            ViewBag.kh = khachhang;
            ViewBag.err = err;
            ViewBag.success = success;
            return View();
        }

        [HttpPost]
        public IActionResult SuaKhachHang(Khachhang model)
        {
            var dbContext = new Context();
            if (ModelState.IsValid)
            {
                var khachhang = dbContext.Khachhang.First(a => a.Makh == model.Makh);
                khachhang.Hoten = model.Hoten;
                khachhang.Sodt = model.Sodt;
                khachhang.Diachi = model.Diachi;
                khachhang.Email = model.Email;
                dbContext.SaveChanges();
                return RedirectToAction("suakhachhang","khachhang", new { id = model.Makh, success = "Sửa thông tin khách hàng thành công" });
            }
            return RedirectToAction("suakhachhang", "khachhang", new { id = model.Makh, err = "Sửa thông tin khách hàng không thành công" });
        }
    }
}
