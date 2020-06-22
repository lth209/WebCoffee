using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebApplication1.Models;
using WebApplication1.Others;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CheckOutController : Controller
    {
        private int Userid;
        private int Cartid;
        private Cart a;
        private Khachhang user;
        private List<CartDetail> cds;
        private IEmailSender _emailSender;


        public CheckOutController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies["user_id"] != null)
            {
                Userid = int.Parse(HttpContext.Request.Cookies["user_id"]);
                a = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
                cds = GetCartDetail(a.CartId);
                user = Function.getCurrentUser(Userid);
                ViewData["products"] = GetSanphams();
                ViewData["cds"] = cds;
                ViewData["user"] = user;
                Cartid = a.CartId;
                Console.WriteLine("yo");
            }
            ViewData["cart"] = a;
            return View();
        }

        public List<CartDetail> GetCartDetail(int cartid)
        {
            using (Context context = new Context())
            {
                var cds = context.CartDetail.Where(p => p.CartId == cartid).ToList();
                return cds;
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

        [HttpPost]
        public IActionResult PlaceOrder(string hoten, string country, string tenduong, string diachi, string sdt, string email, string ghichu)
        {
            Userid = int.Parse(HttpContext.Request.Cookies["user_id"]);
            user = Function.getCurrentUser(Userid);
            DateTime ngaydat = DateTime.Now;
            AddToOrder(user.Makh, ngaydat, ghichu);
            Console.WriteLine(user.Makh);
            return View();        
        }
         public void AddToOrder(int makh, DateTime ngaydat, string ghichu)
        {
            a = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
            cds = GetCartDetail(a.CartId);
            using (Context context = new Context())
            {
                Donhang o = new Donhang(makh, ngaydat, a.Total, "ATM", ghichu, ngaydat);
                context.Donhang.Add(o);
                int row = context.SaveChanges();
                if (row > 0)
                {
                    AddOrderDetail(a.CartId, o.Madh);
                }
            }
        }
        public void AddOrderDetail(int cartid ,int madh)
        {
            cds = GetCartDetail(cartid);
            List<Sanpham> products = GetSanphams();
            using (Context context = new Context())
            {
                foreach (var cd in cds)
                {
                    Ctdh od = new Ctdh();
                    od.Madh = madh;
                    od.Masp = cd.Masp;
                    od.Soluong = cd.Quantity;
                    od.Gia = cd.Quantity * products.Find(p => p.Masp == cd.Masp).Gia;
                    od.CreatedAt = DateTime.Now;
                    context.Ctdh.Add(od);
                }
                int row = context.SaveChanges();
            }
        }
        public void sendMail()
        {
            //_emailSender.Send(toAddress, subject, body);
        }
    }
}