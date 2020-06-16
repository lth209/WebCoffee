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
            ViewData["cart"] = Function.GetCartOfCurrentUser(HttpContext.Request.Cookies["user_id"]);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
