using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Login.Models;

namespace WebApplication1.Others
{
    public class Context : DbContext
    {
      
        //private const string connectionString = "Data Source=localhost,1433;Initial Catalog=mydata;User ID=SA;Password=Password123";

        //private const string connectionString = "server=localhost;uid=root;password=;database=myproduct";

        private const string connectionString = "server=localhost;port=3306;database=coffee3;uid=root;password=; convert zero datetime=True";

        //internal object products;

        //private const string connectionString = "";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(connectionString);

        }

        public virtual DbSet<Activations> Activations { get; set; }
        public virtual DbSet<Ctdh> Ctdh { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetail> CartDetail { get; set; }
        public virtual DbSet<Cthd> Cthd { get; set; }
        public virtual DbSet<Dknt> Dknt { get; set; }
        public virtual DbSet<Donhang> Donhang { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanpham { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Phanhoi> Phanhoi { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<Reminders> Reminders { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Tintuc> Tintuc { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartDetail>(entity => {
                entity.ToTable("cartdetail");
                entity.HasKey(c => new { c.CartId, c.Masp});
            });
            modelBuilder.Entity<Cart>(entity => {
                entity.HasKey(e => e.CartId);
                entity.ToTable("cart");
            });
            modelBuilder.Entity<Activations>(entity =>
            {
                entity.ToTable("activations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Completed)
                    .HasColumnName("completed")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CompletedAt)
                    .HasColumnName("completed_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Ctdh>(entity =>
            {
                entity.HasKey(e => e.MaCtdh);

                entity.ToTable("ctdh");

                entity.Property(e => e.MaCtdh).HasColumnName("ma_ctdh");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.Madh)
                    .HasColumnName("madh")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Masp)
                    .HasColumnName("masp")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Soluong)
                    .HasColumnName("soluong")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<Cthd>(entity =>
            {
                entity.HasKey(e => e.MaCthd);

                entity.ToTable("cthd");

                entity.Property(e => e.MaCthd).HasColumnName("ma_cthd");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.Mahd)
                    .HasColumnName("mahd")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Masp)
                    .HasColumnName("masp")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Soluong)
                    .HasColumnName("soluong")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<Dknt>(entity =>
            {
                entity.ToTable("dknt");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Ngaydk)
                    .HasColumnName("ngaydk")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.HasKey(e => e.Madh);

                entity.ToTable("donhang");

                entity.Property(e => e.Madh).HasColumnName("madh");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Ghichu)
                    .HasColumnName("ghichu")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Httt)
                    .HasColumnName("httt")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Makh)
                    .HasColumnName("makh")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ngaydat)
                    .HasColumnName("ngaydat")
                    .HasColumnType("date");

                entity.Property(e => e.Tongtien).HasColumnName("tongtien");

                entity.Property(e => e.Tttt)
                    .HasColumnName("tttt")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd);

                entity.ToTable("hoadon");

                entity.Property(e => e.Mahd).HasColumnName("mahd");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Ghichu)
                    .HasColumnName("ghichu")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Httt)
                    .HasColumnName("httt")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Makh)
                    .HasColumnName("makh")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ngaythanhtoan)
                    .HasColumnName("ngaythanhtoan")
                    .HasColumnType("date");

                entity.Property(e => e.Tongtien).HasColumnName("tongtien");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("khachhang");

                entity.Property(e => e.Makh).HasColumnName("makh");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("diachi")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("ghichu")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasColumnName("gioitinh")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("hoten")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Matk)
                    .HasColumnName("matk")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Sodt)
                    .IsRequired()
                    .HasColumnName("sodt")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.HasKey(e => e.Maloaisp);

                entity.ToTable("loaisanpham");

                entity.Property(e => e.Maloaisp).HasColumnName("maloaisp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("hinhanh")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Tenloaisp)
                    .IsRequired()
                    .HasColumnName("tenloaisp")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Phanhoi>(entity =>
            {
                entity.HasKey(e => e.Maph);

                entity.ToTable("phanhoi");

                entity.Property(e => e.Maph).HasColumnName("maph");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("hoten")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Ngayph)
                    .HasColumnName("ngayph")
                    .HasColumnType("date");

                entity.Property(e => e.Noidung)
                    .IsRequired()
                    .HasColumnName("noidung")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Vande)
                    .IsRequired()
                    .HasColumnName("vande")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.HasKey(e => e.Maquyen);

                entity.ToTable("quyen");

                entity.Property(e => e.Maquyen).HasColumnName("maquyen");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Tenquyen)
                    .IsRequired()
                    .HasColumnName("tenquyen")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Reminders>(entity =>
            {
                entity.ToTable("reminders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Completed)
                    .HasColumnName("completed")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CompletedAt)
                    .HasColumnName("completed_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp);

                entity.ToTable("sanpham");

                entity.Property(e => e.Masp).HasColumnName("masp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Dvt)
                    .HasColumnName("dvt")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.Giakm).HasColumnName("giakm");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("hinhanh")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Maloaisp).HasColumnName("maloaisp");

                entity.Property(e => e.Moi)
                    .HasColumnName("moi")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Tensp)
                    .HasColumnName("tensp")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("slide");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hinhanh)
                    .IsRequired()
                    .HasColumnName("hinhanh")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.HasKey(e => e.Matt);

                entity.ToTable("tintuc");

                entity.Property(e => e.Matt)
                    .HasColumnName("matt")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("create_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Hinhanh)
                    .IsRequired()
                    .HasColumnName("hinhanh")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Noidung)
                    .IsRequired()
                    .HasColumnName("noidung")
                    .HasColumnType("text");

                entity.Property(e => e.Tieude)
                    .IsRequired()
                    .HasColumnName("tieude")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("update_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Maquyen)
                    .HasName("maquyen_2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("hinhanh")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Maquyen)
                    .HasColumnName("maquyen")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Tentk)
                    .IsRequired()
                    .HasColumnName("tentk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ttdn)
                    .HasColumnName("ttdn")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");
            });
        }
    }
}
