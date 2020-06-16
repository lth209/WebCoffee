using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public RedirectResult DangNhap(String name, String password)
        {
            var dbContext = new Context();
            var taikhoan = (from tk in dbContext.Users
                            where tk.Tentk == name && tk.Password == password
                            select tk) as List<Users>;
            /*Tự cấp vì chức năng dưới xài ko đc*/
            HttpContext.Response.Cookies.Append("user_id", "22");
           
            if (taikhoan != null )
            {
                foreach (var item in taikhoan)
                {
                    //Mã quyền = 1 là admin, = 2 là khách hàng á
                    //voo team nch ha, microsoft teams hả Thảo
                 
                    if (item.Tentk == name && item.Password == password && item.Maquyen == 1)
                    {
                        HttpContext.Response.Cookies.Append("user_id", item.Id.ToString());
                        return Redirect("~/");
                    }
                    if (item.Tentk == name && item.Password == password && item.Maquyen == 2)
                    {
                        HttpContext.Response.Cookies.Append("user_id", item.Id.ToString());

                        return Redirect("~/");
                    }
                }
            }
            else
            {
                var Error1 = "Email hoặc password không đúng error1!";
                ViewBag.Error = Error1;
                return Redirect("/DangNhap");
            }
           // var Error = "Email hoặc password không đúng!";
          //  ViewBag.Error = Error;

                return Redirect("/DangNhap");
            //  return RedirectToAction("Index", "Home");
        }
        public IActionResult LietKeUser()
        {
            
            // var s = (from sp in dbContext.Sanpham select sp).ToList();
            // ViewBag.sanpham = s;
            var dbContext = new Context();
            var taikhoan = (from tk in dbContext.Users
                            select tk).ToList();
            ViewBag.ListUser = taikhoan;
            return View("LietKeUser");
        }
    }
}