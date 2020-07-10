using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class DangKyController : Controller
    {
        public IActionResult DangKy()
        {
            return View("Views/DangKy/DangKy.cshtml");
        }
        [HttpPost]

        public IActionResult DangKy(Users model, string Country, string Tenduong, string Hoten, string Gioitinh, string Email, string Diachi, string sodt)
        {
            var dbContext = new Context();
            var taikhoan1 = (from Users in dbContext.Users where Users.Tentk == model.Tentk select Users).ToList();
            if (taikhoan1.Count > 0)
            {
                ModelState.AddModelError("Username", "Username da ton tai");
                ViewBag.errUsername = "Username da ton tai";
            }
            if (ModelState.IsValid)
            {

                //Tạo MD5 
                MD5 mh = MD5.Create();
                //Chuyển kiểu chuổi thành kiểu byte
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(model.Password);
                //mã hóa chuỗi đã chuyển
                byte[] hash = mh.ComputeHash(inputBytes);
                //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

                var taikhoan = new Users()
                {
                    Tentk = model.Tentk,
                    Password = sb.ToString(),
                    Email = model.Email,
                    //Hinhanh = "fghjk",
                    //Ttdn = 0,
                    Maquyen = 1,
                };
                dbContext.Users.Add(taikhoan);
                dbContext.SaveChanges();
                //xử lý tài khoản id
                /*var idTK = (from Users in dbContext.Users where Users.Tentk == model.Tentk select Users.Id);
                Users x = new Users();
                foreach (var item in idTK)
                {
                    x.Id = item;
                }*/


                Khachhang khachhang = new Khachhang();
                khachhang.Hoten = Hoten;
                khachhang.Gioitinh = Gioitinh;
                khachhang.Email = Email;
                khachhang.Sodt = sodt;
                khachhang.Country = "VietNam";
                khachhang.Tenduong = Tenduong;
                khachhang.Diachi = Diachi;

                khachhang.Matk = taikhoan.Id;
                dbContext.Khachhang.Add(khachhang);
                dbContext.SaveChanges();

                ViewBag.thongbao = "Đăng ký thành công";
            }
            else
            {
                return View();
            }
            return View();
        }


    }
}
