using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class DangNhapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(Users model)
        {
            if (model.Tentk == null && model.Password == null)
            {
                ViewBag.error = "Đăng nhập không thành công";
                return View();
            }
            if (ModelState.IsValid)
            {
                //xu ly password
                MD5 mh = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(model.Password);
                byte[] hash = mh.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                string pass = sb.ToString();
                var dbContext = new Context();
                var taikhoan = (from Users in dbContext.Users
                                where Users.Tentk == model.Tentk && Users.Password == pass
                                select Users);

                foreach (var item in taikhoan)
                {
                    if (item.Tentk == model.Tentk && item.Password == pass && item.Maquyen == 2)
                    {
                        HttpContext.Session.SetString("Tentk", model.Tentk);
                        return RedirectToAction("Index", "Home");
                        //return RedirectToAction("xacnhandathang", "sanpham");
                    }
                    if (item.Tentk == model.Tentk && item.Password == pass && item.Maquyen == 1)
                    {
                        HttpContext.Session.SetString("username", model.Tentk);
                        return RedirectToAction("Index", "Home");
                        //return RedirectToAction("XemDanhSachSanPham", "sanpham");
                    }

                }

                ViewBag.error = "Đăng nhập không thành công";
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}