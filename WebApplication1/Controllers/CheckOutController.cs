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
            int madh = AddToOrder(user.Makh, ngaydat, ghichu);
            sendMail(madh, hoten, country, tenduong, diachi, sdt, email, ghichu);
            ViewData["cart"] = new Cart();
            return View();        
        }
         public int AddToOrder(int makh, DateTime ngaydat, string ghichu)
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
                    Console.WriteLine(o.Madh);
                    AddOrderDetail(a.CartId, o.Madh);
                }
                return o.Madh;
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
                if (row > 0)
                {
                    deleteCart(cartid);
                }
            }
        }

        public void deleteCart(int cartid)
        {
            using(Context context = new Context())
            {
                var cds = context.CartDetail.Where(p => p.CartId == cartid);
                context.CartDetail.RemoveRange(cds);
                context.SaveChanges();
                var cart = context.Cart.Where(p => p.CartId == cartid).Single();
                context.Cart.Remove(cart);
                context.SaveChanges();
            }
        }
        public void sendMail(int madh, string hoten, string country, string tenduong, string diachi, string sdt, string email, string ghichu)
        {
            //_emailSender.Send(toAddress, subject, body);
            string headerbody = "<table align=\"center\" bgcolor=\"#dcf0f8\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"margin:0;padding:0;background-color:#f2f2f2;width:100%!important;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\" width=\"100%\"> <tbody> <tr> <td align=\"center\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\" valign=\"top\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"margin-top:15px\" width=\"600\"> <tbody> <tr style=\"background:#fff\"> <td align=\"left\" height=\"auto\" style=\"padding:15px\" width=\"600\"> <table> <tbody> <tr> <td> <h1 style=\"font-size:17px;font-weight:bold;color:#444;padding:0 0 5px 0;margin:0\">Cảm ơn quý khách " + hoten + " đã đặt hàng tại Feel Coffee,</h1> <p style=\"margin:4px 0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\">Feel Coffee rất vui thông báo đơn hàng #" + madh + " của quý khách đã được tiếp nhận và đang trong quá trình xử lý. Feel Coffee sẽ thông báo đến quý khách ngay khi hàng chuẩn bị được giao.</p> <h3 style=\"font-size:13px;font-weight:bold;color:#02acea;text-transform:uppercase;margin:20px 0 0 0;border-bottom:1px solid #ddd\">Thông tin đơn hàng #" + madh + " <span style=\"font-size:12px;color:#777;text-transform:none;font-weight:normal\">("+DateTime.Now+")</span></h3> </td> </tr> <tr> <td style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <thead> <tr> <th align=\"left\" style=\"padding:6px 9px 0px 9px;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;font-weight:bold\" width=\"50%\">Thông tin thanh toán</th> <th align=\"left\" style=\"padding:6px 9px 0px 9px;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;font-weight:bold\" width=\"50%\"> Địa chỉ giao hàng </th> </tr> </thead> <tbody> <tr> <td style=\"padding:3px 9px 9px 9px;border-top:0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\" valign=\"top\"><span style=\"text-transform:capitalize\">" + hoten + "</span><br> <a href=\"mailto:"+email+"\" target=\"_blank\">" + email + "</a><br> "+sdt+"</td> <td style=\"padding:3px 9px 9px 9px;border-top:0;border-left:0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\" valign=\"top\"><span style=\"text-transform:capitalize\">"+hoten+"</span><br> <a href=\"mailto:\" target=\"_blank\">" + email + "</a><br>"+tenduong+" "+ diachi+" "+ country +"<br> Phone: " + sdt + "</td> </tr> <tr> <td colspan=\"2\" style=\"padding:7px 9px 0px 9px;border-top:0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444\" valign=\"top\"> <p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\"><strong>Phương thức thanh toán: </strong> Thanh toán khi nhận hàng<br> <strong>Phí vận chuyển: </strong> 0 ₫<br> </p> </td> </tr> </tbody> </table> </td> </tr> <tr> <td> <p style=\"margin:4px 0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\"><i>Lưu ý: Đối với đơn hàng đã được thanh toán trước, nhân viên giao nhận có thể yêu cầu người nhận hàng cung cấp CMND / giấy phép lái xe để chụp ảnh hoặc ghi lại thông tin.</i></p> </td> </tr> <tr> <td> <h2 style=\"text-align:left;margin:10px 0;border-bottom:1px solid #ddd;padding-bottom:5px;font-size:13px;color:#02acea\">CHI TIẾT ĐƠN HÀNG</h2> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"background:#f5f5f5\" width=\"100%\"> <thead> <tr> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Sản phẩm</th> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Đơn giá</th> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Số lượng</th> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Giảm giá</th> <th align=\"right\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Tổng tạm</th> </tr> </thead> <tbody bgcolor=\"#eee\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\">";
             //load chi tiet don
            List<Sanpham> products = GetSanphams();
            string chitiet = "";
            using(Context context = new Context())
            {
                var dh = context.Donhang.Where(p => p.Madh == madh).Single();
                var ctdh = context.Ctdh.Where(p => p.Madh == madh).ToList();
                foreach (var ct in ctdh)
                {
                    Sanpham p = products.Find(p => p.Masp == ct.Masp);
                    chitiet += "<tr> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span> " + p.Tensp + "</span><br> </td> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span>" + p.Gia + " ₫</span></td> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\">" + ct.Soluong + "</td> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span>0 ₫</span></td> <td align=\"right\" style=\"padding:3px 9px\" valign=\"top\"><span>" + p.Gia * ct.Soluong + " ₫</span></td> </tr>";
                }
                headerbody += chitiet;
                headerbody += "</tbody> <tfoot style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\"> <tr> <td align=\"right\" colspan=\"4\" style=\"padding:5px 9px\">Tổng tạm tính</td> <td align=\"right\" style=\"padding:5px 9px\"><span>" + dh.Tongtien + " ₫</span></td> </tr> <tr> <td align=\"right\" colspan=\"4\" style=\"padding:5px 9px\">Giảm giá</td> <td align=\"right\" style=\"padding:5px 9px\"><span>0 ₫</span></td> </tr> <tr> <td align=\"right\" colspan=\"4\" style=\"padding:5px 9px\">Phí vận chuyển</td> <td align=\"right\" style=\"padding:5px 9px\"><span>0 ₫</span></td> </tr> <tr bgcolor=\"#eee\"> <td align=\"right\" colspan=\"4\" style=\"padding:7px 9px\"><strong><big>Tổng giá trị đơn hàng</big> </strong></td> <td align=\"right\" style=\"padding:7px 9px\"><strong><big><span>" + dh.Tongtien + " ₫</span> </big> </strong></td> </tr> </tfoot> </table> </td> </tr> <tr> <td>  <p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0;line-height:18px;color:#444;font-weight:bold\">Một lần nữa Feel Coffee cảm ơn quý khách.</p> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table>";
            }
            _emailSender.Send(email, "Xác nhận đơn hàng", headerbody);
        }
    }
}