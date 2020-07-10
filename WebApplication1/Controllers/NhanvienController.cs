using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
  
    public class NhanvienController : Controller
    {
      

        public IActionResult Xemthongtinnhanvien(string id, string err, string success)
        {
            var dbContext = new Context();
            var taikhoan = (from tk in dbContext.Users
                            where tk.Tentk== id
                            select tk).ToList();
            //var nhanvien = (from nv in dbContext.NhanVien where nv.Matk == taikhoan[0].Id select nv).ToList();
            ViewBag.tk = taikhoan;
            ViewBag.err = err;
            ViewBag.success = success;
            return View();
        }
    }
}