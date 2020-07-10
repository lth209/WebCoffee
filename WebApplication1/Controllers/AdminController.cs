using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }
        public Boolean CheckRole()
        {
            string uid = HttpContext.Request.Cookies["user_id"];
            if (uid != null)
            {
                int id = int.Parse(uid);
                using (Context context = new Context())
                {
                    Users currentuser = context.Users.Where(p => p.Id == id).Single();
                    if (currentuser.Maquyen == 2)   //Admin
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public IActionResult Index()
        {
            if (CheckRole())
            {
                return RedirectToAction("OrderManager", "Admin");
            }
            return View("Views/Shared/UnauthorizedAccess.cshtml");
        }

        [Route("OrderDetail/{id:int}")]
        public IActionResult OrderDetail(int id)
        {
            if (!CheckRole())
            {
                return View("Views/Shared/UnauthorizedAccess.cshtml");
            }
            Donhang order= GetOrderFromDb(id);
            ViewData["order"] = order;
            ViewData["cus"] = GetCustomer(order.Makh);
            ViewData["products"] = GetSanphams();
            ViewData["ods"] = GetOrderDetails(id);
            return View(GetOrderFromDb(id));

        }

        public IActionResult OrderManager()
        {
            if (!CheckRole())
            {
                return View("Views/Shared/UnauthorizedAccess.cshtml");
            }
            ViewData["orders"] = GetOrdersFromDb();

            return View();
        }
        [HttpPost]
        public IActionResult AddOrderDetail(int id,int product, int quantity)
        {
            if (!CheckRole())
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            List<Sanpham> p = GetSanphams();
            ViewData["ods"] = GetOrderDetails(id);
            ViewData["products"] = p;
            using (Context context = new Context())
            {
                Ctdh od = new Ctdh();
                od.Madh = id;
                od.Masp = product;
                od.Soluong = quantity;
                od.Gia = p.Find(p => p.Masp == product).Gia * quantity;
                context.Ctdh.Add(od);
                var order = context.Donhang.Where(p => p.Madh == od.Madh).Single();
                order.Tongtien += (float) od.Gia;
                int row = context.SaveChanges();
                return RedirectToAction("OrderDetail", "Admin", new { id = id });
            }
        }

        [HttpPost]
        public IActionResult RemoveOrderDetail(int mactdh)
        {
            if (!CheckRole())
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            using (Context context = new Context())
            {
                var od = context.Ctdh.Where(p => p.MaCtdh == mactdh).Single();
                Donhang o = UpdateOrder(od.Madh, od.Gia);
                context.Ctdh.Remove(od);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    var mess = new
                    {
                        order = o,
                        Status = "success"
                    };
                    return Json(mess);
                }
                return Json("fail");
            }
        }

        [HttpPost]
        public IActionResult EditOrder(int id, String hoten, String sdt, String diachi, int tt, String shipper)
        {
            if (!CheckRole())
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            List<Sanpham> p = GetSanphams();
            ViewData["ods"] = GetOrderDetails(id);
            ViewData["products"] = p;

            using (Context context = new Context())
            {
                var o = context.Donhang.Where(p => p.Madh == id).Single();
                o.Hoten = hoten;
                o.Sdt = sdt;
                o.Shipper = shipper;
                o.Diachi = diachi;
                o.Tttt = tt;
                context.SaveChanges();
                return RedirectToAction("OrderDetail", "Admin", new { id = id });
            }
        }

        public async Task<IActionResult> AddProduct(List<IFormFile> files, Sanpham sp)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath,"img");
                    uploadsFolder = Path.Combine(uploadsFolder, "product");
                    string filePath = Path.Combine(uploadsFolder, formFile.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                    }
                    sp.Hinhanh = formFile.FileName;
                    AddNewProduct(sp);
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return RedirectToAction("ProductManager", "Admin");
        }
        [HttpPost]
        public IActionResult RemoveProduct(int masp)
        {
            using (Context context = new Context())
            {
                var sp = context.Sanpham.Where(p => p.Masp == masp).Single();
                context.Sanpham.Remove(sp);
                int row = context.SaveChanges();
                if (row > 0)
                {
                    return Json("success");
                }
                return Json("fail");
            }
        }
        public IActionResult ProductManager()
        {
            if (!CheckRole())
            {
                return View("Views/Shared/UnauthorizedAccess.cshtml");
            }
            ViewData["product"] = GetSanphams();
            ViewData["loaisp"] = GetLoaiSp();
            return View(); //ProductManager.cshtml
        }

        public IActionResult EditCustomer(Users user)
        {
            using(Context context = new Context())
            {
                var u = context.Users.Where(p => p.Id == user.Id).Single();
                u.Maquyen = user.Maquyen;
                context.SaveChanges();
                return RedirectToAction("CustomerManager", "Admin");
            }
        }
        public IActionResult EditProduct(Sanpham model)
        {
            ViewData["product"] = GetSanphams();
            using (Context context = new Context())
            {
                var sp = context.Sanpham.Where(p => p.Masp == model.Masp).Single();
                sp.Tensp = model.Tensp;
                sp.Mota = model.Mota;
                sp.Gia = model.Gia;
                context.SaveChanges();
                return RedirectToAction("ProductManager", "Admin");
            }
        }
        public IActionResult CustomerManager()
        {
            ViewData["khs"] = GetCustomers();
            ViewData["accs"] = GetAccounts();
            return View(); //CustomerManager.cshtml
        }
        public IActionResult RemoveAccount(int id)
        {
            using (Context context = new Context())
            {
                var u = context.Users.Where(p => p.Id == id).Single();
                context.Users.Remove(u);
                int row = context.SaveChanges();
                if (row > 0)
                {
                    return Json("success");
                }
                return Json("fail");
            }
        }

        public void AddNewProduct(Sanpham sp)
        {
            using (Context context = new Context())
            {
                sp.CreatedAt = DateTime.Now;
                context.Sanpham.Add(sp);
                context.SaveChanges();
            }
        }

        public List<Donhang> GetOrdersFromDb()
        {
            using (Context context = new Context())
            {
                var orders = context.Donhang.ToList();
                return orders;
            }
        }
        public List<Loaisanpham> GetLoaiSp()
        {
            using(Context context = new Context())
            {
                var a = context.Loaisanpham.ToList();
                return a;
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
        public Donhang GetOrderFromDb(int orderid)
        {
            using (Context context = new Context())
            {
                var order = context.Donhang.Where(p=>p.Madh == orderid).Single();
                return order;
            }
        }

        public List<Ctdh> GetOrderDetails(int orderid)
        {
            using (Context context = new Context())
            {
                var ods = context.Ctdh.Where(p => p.Madh == orderid).ToList();
                return ods;
            }
        }

        public Donhang UpdateOrder(int madh, double tong)
        {
            using(Context context = new Context())
            {
                var o = context.Donhang.Where(p => p.Madh == madh).Single();
                o.Tongtien -= (float) tong;
                context.SaveChanges();
                return o;
            }
        }

        public List<Users> GetAccounts()
        {
            using (Context context = new Context())
            {
                var cus = context.Users.ToList();
                return cus;
            }
        }

        public List<Khachhang> GetCustomers()
        {
            using (Context context = new Context())
            {
                var cus = context.Khachhang.ToList();
                return cus;
            }
        }
        public Khachhang GetCustomer(int id)
        {
            using (Context context = new Context())
            {
                var cus = context.Khachhang.Where(p => p.Makh == id).Single();
                return cus;
            }
        }

        /*CHART*/
        public IActionResult ChartAtOrder()
        {
            return View("Views/Admin/Chart/OrderChart.cshtml");
        }
        public IActionResult ChartAtProduct()
        {
            return View("Views/Admin/Chart/ProductChart.cshtml");
        }
        [HttpPost]
        public IActionResult ProductChart()
        {
            if (!CheckRole())
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            using (Context context = new Context())
            {
                ArrayList sp = new ArrayList();
                ArrayList data = new ArrayList();
                List<Sanpham> sps = GetSanphams();
                var query = context.Ctdh
                    .Where(p => p.CreatedAt.Year ==2020)
                   .GroupBy(p => p.CreatedAt.Month)
                   .Select(g => new { sp = g.Key, sum = g.Sum(x => x.Soluong) })
                   .OrderBy(g => g.sp).ToList();
                foreach (var q in query)
                {
                    sp.Add(q.sp);
                    data.Add(q.sum);
                }
                var mess = new
                {
                    sp = sp,
                    Data = data
                };
                return Json(mess);
            }
        }
        [HttpPost]
        public IActionResult OrderChart()
        {
            if (!CheckRole())
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            using (Context context = new Context())
            {
                ArrayList years = new ArrayList();
                ArrayList data = new ArrayList();
                var query = context.Donhang
                   .Where(p => p.Ngaydat.Year == 2020)
                   .GroupBy(g => g.Ngaydat.Month)
                   .Select(g => new { years = g.Key, sum = g.Sum(x => x.Tongtien) })
                   .OrderBy(g => g.years).ToList();
                foreach (var q in query)
                {
                    years.Add(q.years);
                    data.Add(q.sum);
                }
                var mess = new
                {
                    Years = years,
                    Data = data
                };
                return Json(mess);
            }
        }
        public IActionResult OrderCountChart()
        {
            if (!CheckRole())
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            using (Context context = new Context())
            {
                ArrayList years = new ArrayList();
                ArrayList data = new ArrayList();
                var query = context.Donhang
                    .Where(p => p.Ngaydat.Year == 2020)
                   .GroupBy(p => p.Ngaydat.Month)
                   .Select(g => new { years = g.Key, count = g.Count() })
                   .OrderBy(g => g.years).ToList();
                foreach (var q in query)
                {
                    years.Add(q.years);
                    data.Add(q.count);
                }
                var mess = new
                {
                    Years = years,
                    Data = data
                };
                return Json(mess);
            }
        }
    }
}