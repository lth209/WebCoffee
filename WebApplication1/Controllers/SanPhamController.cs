using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult XemDanhSachSanPham()
        {
            var dbContext = new Context();
            var sanpham = (from sp in dbContext.Sanpham


                           select new
                           {
                               Masp = sp.Masp,
                               Tensp = sp.Tensp,
                               Mota = sp.Mota,
                               Gia = sp.Gia,
                               Hinhanh = sp.Hinhanh,

                           });
            List<Sanpham> List = new List<Sanpham>();
            foreach (var item in sanpham)
            {
                Sanpham sp = new Sanpham();
                sp.Masp = item.Masp;
                sp.Tensp = item.Tensp;
                sp.Mota = item.Mota;
                sp.Gia = item.Gia;

                sp.Hinhanh = item.Hinhanh;
                List.Add(sp);
            }
            ViewBag.sanpham = List;

            return View();
        }

        public IActionResult ThemSanPham(string success, string error)
        {
            var dbContext = new Context();
            ViewBag.success = success;
            ViewBag.error = error;
            return View();
        }

        [HttpPost]
        public IActionResult ThemSanPham(Sanpham model, string TenAnh)
        {
            var dbContext = new Context();
            if (ModelState.IsValid)
            {

                //// thêm ảnh vào table hinhanh
                var hinhanh = new Sanpham()
                {
                    Hinhanh = TenAnh
                };
                dbContext.Sanpham.Add(hinhanh);
                dbContext.SaveChanges();
                //lấy id của ảnh
                var anh = (from ha in dbContext.Sanpham
                           where ha.Hinhanh == TenAnh
                           select ha).ToList();
                //thêm sản phẩm
                var sanpham = new Sanpham()
                {
                    Tensp = model.Tensp,
                    Mota = model.Mota,
                    Gia = model.Gia,
                    Giakm = model.Giakm,
                    Dvt = model.Dvt,
                    Moi = model.Moi,
                    Hinhanh = model.Hinhanh
                };
                dbContext.Sanpham.Add(sanpham);
                dbContext.SaveChanges();
                return RedirectToAction("Themsanpham", "sanpham", new { success = "Thêm sản phẩm thành công" });
            }
            return RedirectToAction("Themsanpham", "sanpham", new { error = "Thêm sản phẩm không thành công" });

        }


        public IActionResult SuaSanPham(int id, string success, string err)
        {
            var dbContext = new Context();
            //lấy sản phẩm cần sửa
            var sanPham = (from sp in dbContext.Sanpham
                           where sp.Masp == id
                           select sp).ToList();
            ViewBag.sanpham = sanPham;

            ViewBag.err = err;
            ViewBag.success = success;
            return View();
        }

        [HttpPost]
        public IActionResult SuaSanPham(Sanpham model, string TenAnh)
        {
            var dbContext = new Context();
            if (ModelState.IsValid)
            {
                // kiểm tra hình ảnh đã có trong database chưa
                var dsHinhAnh = (from dsha in dbContext.Sanpham
                                 where dsha.Hinhanh == TenAnh
                                 select dsha).ToList();
                //  thêm ảnh vào table hinhanh
                if (dsHinhAnh.Count != 0)
                {
                    var sanpham1 = new Sanpham()
                    {
                        Hinhanh = TenAnh
                    };
                    dbContext.Sanpham.Add(sanpham1);
                    dbContext.SaveChanges();
                }

                //lấy id của ảnh
                var anh = (from ha in dbContext.Sanpham
                           where ha.Hinhanh == TenAnh
                           select ha).ToList();
                //sua sản phẩm
                var sanpham = dbContext.Sanpham.First(a => a.Masp == model.Masp);
                sanpham.Tensp = model.Tensp;
                sanpham.Mota = model.Mota;
                sanpham.Gia = model.Gia;
                sanpham.Hinhanh = model.Hinhanh;
                dbContext.SaveChanges();
                //thêm kích thước vào bảng kichthuoc              


                return RedirectToAction("Suasanpham", "sanpham", new { id = model.Masp, success = "Sửa sản phẩm thành công" });
            }
            return RedirectToAction("Suasanpham", "sanpham", new { id = model.Masp, error = "Sửa sản phẩm không thành công" });
        }
    }
}
