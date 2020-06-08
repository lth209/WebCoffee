using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Sanpham
    {
        private int masp;
        private String tensp;
        private int maloaisp;
        private String mota;
        private float gia;
        private float giakm;
        private String hinhanh;
        private String dvt;
        private int moi;
        public int Sellquantity { get; set; }

        public Sanpham()
        {
        }

        public Sanpham(int masp, string tensp, int maloaisp, float gia)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.maloaisp = maloaisp;
            this.gia = gia;
        }

        public Sanpham(int masp, string tensp, int maloaisp, string mota, float gia, float giakm, string hinhanh, string dvt, int moi, Timestamp created_at, Timestamp updated_at, int sellquantity)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.maloaisp = maloaisp;
            this.mota = mota;
            this.gia = gia;
            this.giakm = giakm;
            this.hinhanh = hinhanh;
            this.dvt = dvt;
            this.moi = moi;
            this.Sellquantity = sellquantity;
        }
        [Key] public int Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public int Maloaisp { get => maloaisp; set => maloaisp = value; }
        public string Mota { get => mota; set => mota = value; }
        public float Gia { get => gia; set => gia = value; }
        public float Giakm { get => giakm; set => giakm = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public int Moi { get => moi; set => moi = value; }

    }
}
