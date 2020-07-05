using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
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
                return View();
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
        public IActionResult EditOrder(int id, String hoten, String sdt, String diachi, int tt)
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
                o.Diachi = diachi;
                o.Tttt = tt;
                context.SaveChanges();
                return RedirectToAction("OrderDetail", "Admin", new { id = id });
            }
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
        /*--------------------------------------------*/

        public List<Donhang> GetOrdersFromDb()
        {
            using (Context context = new Context())
            {
                var orders = context.Donhang.ToList();
                return orders;
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
                   .GroupBy(p => p.Ngaydat.Year)
                   .Select(g => new { years = g.Key, sum = g.Sum(x => x.Tongtien) }).ToList();
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
                   .GroupBy(p => p.Ngaydat.Year)
                   .Select(g => new { years = g.Key, count = g.Count() }).ToList();
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