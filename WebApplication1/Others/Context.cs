using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Others
{
    public class Context : DbContext
    {
      
        //private const string connectionString = "Data Source=localhost,1433;Initial Catalog=mydata;User ID=SA;Password=Password123";

        //private const string connectionString = "server=localhost;uid=root;password=;database=myproduct";

        private const string connectionString = "server=localhost;port=3306;database=coffee;uid=root;password=20270907";

        //internal object products;

        //private const string connectionString = "";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(connectionString);

        }

        public DbSet<Sanpham> Sanpham { set; get; }   // Bảng Product trong DataBase, <Product> tên lớp
                                                      //public DbSet<>
        public DbSet<Loaisanpham> Loaisanpham { set; get; }

        public DbSet<Cart> Cart { set; get; }

        public DbSet<CartDetail> CartDetail { set; get; }

    }
}
