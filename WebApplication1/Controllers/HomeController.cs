using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyConnection;
using MySql.Data.MySqlClient;
using WebApplication1.Models;
using WebApplication1.Others;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MySqlConnection conn;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            conn = ConnectData.GetConnection();
        }

        public IActionResult Index()
        {
            ReadAllProducts();
            ReadAllProductTypes();
            ViewData["kh"] = Function.getCurrentUser(HttpContext.Request.Cookies["user_id"]);
            ViewData["cart"] = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
            ViewData["sp"] = getSanphamGiaRe();
            return View();
        }

        [HttpPost]
        public String getPdf(Donhang o)
        {
            //_emailSender.Send(toAddress, subject, body);
            string headerbody = "<table align=\"center\" bgcolor=\"#dcf0f8\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"margin:0;padding:0;background-color:#f2f2f2;width:100%!important;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\" width=\"100%\"> <tbody> <tr> <td align=\"center\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\" valign=\"top\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"margin-top:15px\" width=\"600\"> <tbody> <tr style=\"background:#fff\"> <td align=\"left\" height=\"auto\" style=\"padding:15px\" width=\"600\"> <table> <tbody> <tr> <td> <h1 style=\"font-size:17px;font-weight:bold;color:#444;padding:0 0 5px 0;margin:0\">Cảm ơn quý khách " + o.Hoten + " đã đặt hàng tại Feel Coffee,</h1> <p style=\"margin:4px 0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\">Feel Coffee rất vui thông báo đơn hàng #" + o.Madh + " của quý khách đã được tiếp nhận và đang trong quá trình xử lý. Feel Coffee sẽ thông báo đến quý khách ngay khi hàng chuẩn bị được giao.</p> <h3 style=\"font-size:13px;font-weight:bold;color:#02acea;text-transform:uppercase;margin:20px 0 0 0;border-bottom:1px solid #ddd\">Thông tin đơn hàng #" + o.Madh + " <span style=\"font-size:12px;color:#777;text-transform:none;font-weight:normal\">(" + DateTime.Now + ")</span></h3> </td> </tr> <tr> <td style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <thead> <tr> <th align=\"left\" style=\"padding:6px 9px 0px 9px;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;font-weight:bold\" width=\"50%\">Thông tin thanh toán</th> <th align=\"left\" style=\"padding:6px 9px 0px 9px;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;font-weight:bold\" width=\"50%\"> Địa chỉ giao hàng </th> </tr> </thead> <tbody> <tr> <td style=\"padding:3px 9px 9px 9px;border-top:0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\" valign=\"top\"><span style=\"text-transform:capitalize\">" + o.Hoten + "</span><br> " + o.Sdt + "</td> <td style=\"padding:3px 9px 9px 9px;border-top:0;border-left:0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\" valign=\"top\"><span style=\"text-transform:capitalize\">" + o.Hoten + "</span><b<br>"  + o.Diachi  + "<br> Phone: " +o.Sdt + "</td> </tr> <tr> <td colspan=\"2\" style=\"padding:7px 9px 0px 9px;border-top:0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444\" valign=\"top\"> <p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\"><strong>Phương thức thanh toán: </strong> Thanh toán khi nhận hàng<br> <strong>Phí vận chuyển: </strong> 0 ₫<br> </p> </td> </tr> </tbody> </table> </td> </tr> <tr> <td> <p style=\"margin:4px 0;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px;font-weight:normal\"><i>Lưu ý: Đối với đơn hàng đã được thanh toán trước, nhân viên giao nhận có thể yêu cầu người nhận hàng cung cấp CMND / giấy phép lái xe để chụp ảnh hoặc ghi lại thông tin.</i></p> </td> </tr> <tr> <td> <h2 style=\"text-align:left;margin:10px 0;border-bottom:1px solid #ddd;padding-bottom:5px;font-size:13px;color:#02acea\">CHI TIẾT ĐƠN HÀNG</h2> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"background:#f5f5f5\" width=\"100%\"> <thead> <tr> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Sản phẩm</th> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Đơn giá</th> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Số lượng</th> <th align=\"left\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Giảm giá</th> <th align=\"right\" bgcolor=\"#02acea\" style=\"padding:6px 9px;color:#fff;font-family:Arial,Helvetica,sans-serif;font-size:12px;line-height:14px\">Tổng tạm</th> </tr> </thead> <tbody bgcolor=\"#eee\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\">";
            //load chi tiet don
            List<Sanpham> products = GetSanphams();
            string chitiet = "";
            using (Context context = new Context())
            {
                var dh = context.Donhang.Where(p => p.Madh == o.Madh).Single();
                var ctdh = context.Ctdh.Where(p => p.Madh == o.Madh).ToList();
                foreach (var ct in ctdh)
                {
                    Sanpham p = products.Find(p => p.Masp == ct.Masp);
                    chitiet += "<tr> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span> " + p.Tensp + "</span><br> </td> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span>" + p.Gia + " ₫</span></td> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\">" + ct.Soluong + "</td> <td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span>0 ₫</span></td> <td align=\"right\" style=\"padding:3px 9px\" valign=\"top\"><span>" + p.Gia * ct.Soluong + " ₫</span></td> </tr>";
                }
                headerbody += chitiet;
                headerbody += "</tbody> <tfoot style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#444;line-height:18px\"> <tr> <td align=\"right\" colspan=\"4\" style=\"padding:5px 9px\">Tổng tạm tính</td> <td align=\"right\" style=\"padding:5px 9px\"><span>" + dh.Tongtien + " ₫</span></td> </tr> <tr> <td align=\"right\" colspan=\"4\" style=\"padding:5px 9px\">Giảm giá</td> <td align=\"right\" style=\"padding:5px 9px\"><span>0 ₫</span></td> </tr> <tr> <td align=\"right\" colspan=\"4\" style=\"padding:5px 9px\">Phí vận chuyển</td> <td align=\"right\" style=\"padding:5px 9px\"><span>0 ₫</span></td> </tr> <tr bgcolor=\"#eee\"> <td align=\"right\" colspan=\"4\" style=\"padding:7px 9px\"><strong><big>Tổng giá trị đơn hàng</big> </strong></td> <td align=\"right\" style=\"padding:7px 9px\"><strong><big><span>" + dh.Tongtien + " ₫</span> </big> </strong></td> </tr> </tfoot> </table> </td> </tr> <tr> <td>  <p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0;line-height:18px;color:#444;font-weight:bold\">Một lần nữa Feel Coffee cảm ơn quý khách.</p> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table>";
            }
            return headerbody;
        }
        public IActionResult HuyDon(int id)
        {
            using (Context context = new Context())
            {
                var o = context.Donhang.Where(p => p.Madh == id).Single();
                o.Tttt = 4;
                context.SaveChanges();
                return RedirectToAction("DonHang", "KhachHang");
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UnauthorizedAccess()
        {
            return View("Views/Shared/UnauthorizedAccess.cshtml");
        }

        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("user_id");
            return RedirectToAction("Index");
        }
        public void loadNameProduct()
        {

            
            string sql = "SELECT tensp FROM sanpham";
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                //Console.WriteLine($"{rdr.GetName(0)}\t{rdr.GetName(1)}"); //lấy tên field

                //ViewData["product"] = new ArrayList();
                ArrayList a = new ArrayList();

                while (rdr.Read())
                {
                    a.Add(rdr.GetString(0));
                    //Console.WriteLine($"{rdr.GetInt16(0)}\t{rdr.GetString(1)}");
                    Console.WriteLine($"{rdr.GetString(0)}");
                }
                ViewData["product"] = a;
            }
           
        }

        public List<Sanpham> getSanphamGiaRe()
        {
            using (Context context = new Context())
            {
                var sp = context.Sanpham.OrderBy(x => x.Gia).ToList();
                return sp;
            }
        }
        public void ReadAllProducts()
        {
            using (Context context = new Context())
            {
                // Lấy List các sản phẩm từ DB
                /* var products = context.Product.ToList();
                 Console.WriteLine("Tất cả sản phẩm");
                 foreach (var product in products)
                 {
                     Console.WriteLine($"{product.ProductId,2} {product.Name,10} - {product.Provider}");
                 }
                 Console.WriteLine();
                 Console.WriteLine();
                 */
                var products = context.Sanpham.ToList();

                ViewData["product"] = products;

                products.Sort((x, y) => y.Sellquantity.CompareTo(x.Sellquantity));
                List<Sanpham> bestseller = new List<Sanpham>();
                for (int i=0; i < 6; i++)
                {
                    bestseller.Add(products[i]);
                }

                ViewData["bestsellers"] = bestseller;
                //Sử dụng LINQ trên DbSet (products)
                /*
                var products =  (from p in context.Product
                                      //where (p.ProductId == 1)
                                      select p
                                    ).ToList();
    
                Console.WriteLine("Sản phẩm CTY A");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductId,2} {product.Name,10} - {product.Provider}");
                }
                */
            }
        }

        public void ReadAllProductTypes()
        {
            using (Context context = new Context())
            {
                var productTypes = context.Loaisanpham.ToList();

                ViewData["producttypes"] = productTypes;
            }
        }
       
    }
}
