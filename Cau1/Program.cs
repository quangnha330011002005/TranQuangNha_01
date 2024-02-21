using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1
{
    class NhanVien
    {
        private string maso;
        private string hoten;
        private int luongcung;

        public NhanVien()
        {
        }
        public NhanVien(string maso, string hoten, int luongcung)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.luongcung = luongcung;
        }
        public string Maso
        {
            set { this.maso = value; }
            get { return this.maso; }
        }
        public string Hoten
        {
            set { this.hoten = value; }
            get { return this.hoten; }
        }
        public int Luongcung
        {
            set { this.luongcung = value; }
            get { return this.luongcung; }
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap ma so:");
            this.maso = Console.ReadLine();
            Console.Write("Nhap ho ten:");
            this.hoten = Console.ReadLine();
            Console.Write("Luong cung:");
            this.luongcung = int.Parse(Console.ReadLine());
        }
        public virtual int TinhLuong()
        {
            return 0;
        }
        class NhanVienBC : NhanVien
        {
            private string mucxeploai;
            public NhanVienBC() : base()
            {

            }
            public NhanVienBC(string maso, string hoten, int luongcung, string mucxephang) : base(maso, hoten, luongcung)
            {
                this.mucxeploai = mucxeploai;
            }
            public string Mucxeploai
            {
                set { mucxeploai = value; }
                get { return mucxeploai; }
            }
            public override void Nhap()
            {
                base.Nhap();
                Console.Write("Nhap muc xep loai:");
                this.mucxeploai = Console.ReadLine();
            }
            public override int TinhLuong()
            {
                int thuong = 0;
                switch (mucxeploai)
                {
                    case "A":
                        thuong = (int)(1.8 * Luongcung);
                        break;
                    case "B":
                        thuong = (int)(1.2 * Luongcung);
                        break;
                    case "C":
                        thuong = (int)(0.8 * Luongcung);
                        break;
                }
                return Luongcung + thuong;
            }
            class NhanVienHD : NhanVien
            {
                private int doanhthu;
                public NhanVienHD()
                {
                }
                public NhanVienHD(string maso, string hoten, int luongcung, int doanhthu) : base(maso, hoten, luongcung)
                {
                    this.doanhthu = doanhthu;
                }
                public int Doanhthu
                {
                    set { doanhthu = value; }
                    get { return doanhthu; }
                }
                public override void Nhap()
                {
                    base.Nhap();
                    Console.Write("Nhap doanh thu:");
                    this.doanhthu = int.Parse(Console.ReadLine());
                }
                public override int TinhLuong()
                {
                    return Luongcung + (int)(0.05 * Doanhthu);
                }
                public class QuanLyNV
                {
                    private List<NhanVien> dsnv;
                    public QuanLyNV()
                    {
                        dsnv = new List<NhanVien>();
                    }
                    public void NhapDS()
                    {
                        string tieptuc = "y";
                        int chon;
                        NhanVien nv;
                        do
                        {
                            Console.Write("Chon loai nhan vien [1:nvbc,2:nvhd]:");
                            chon = int.Parse(Console.ReadLine());
                            switch (chon)
                            {
                                case 1:
                                    nv = new NhanVienBC();
                                    nv.Nhap();
                                    dsnv.Add(nv);
                                    break;
                                case 2:
                                    nv = new NhanVienHD();
                                    nv.Nhap();
                                    dsnv.Add(nv);
                                    break;
                                default:
                                    Console.WriteLine("Ban chon sai.vui long chon 1 hoac 2.");
                                    break;
                            }
                            Console.Write("Ban co muon tiep tuc khong?Y/N:");
                            tieptuc = Console.ReadLine();
                        } while (tieptuc.ToLower() == "y");
                    }



                    public void XuatDS()
                    {
                        Console.WriteLine("Danh sach nhan vien:");
                        foreach (NhanVien nv in dsnv)
                        {
                            if (nv is NhanVienBC)
                            {
                                NhanVienBC nvbc = nv as NhanVienBC;
                                Console.WriteLine("Ma so:" + nvbc.Maso);
                                Console.WriteLine("Ho ten:" + nvbc.Hoten);
                                Console.WriteLine("Muc xep loai:" + nvbc.Mucxeploai);
                                Console.WriteLine("Luong thuc lanh:" + nvbc.TinhLuong());
                            }
                            else
                            {
                                NhanVienHD nvhd = nv as NhanVienHD;
                                Console.WriteLine("Ma so:" + nvhd.Maso);
                                Console.WriteLine("Ho ten:" + nvhd.Hoten);
                                Console.WriteLine("Muc xep loai:" + nvhd.Doanhthu);
                                Console.WriteLine("Luong thuc lanh:" + nvhd.TinhLuong());
                            }
                        }
                        {

                        }
                    }
                    public int TinhTongLuong()
                    {
                        int tongluong = 0;
                        foreach (NhanVien nv in dsnv)
                        {
                            tongluong += nv.TinhLuong();
                        }
                        return tongluong;
                    }
                    public double TinhLuongTrungBinh()
                    {
                        return (double)TinhTongLuong() / dsnv.Count;
                    }
                    class Program
                    {

                        static void Main(string[] args)
                        {
                            menu();
                        }

                        static void menu()
                        {
                            QuanLyNV ql = new QuanLyNV();
                            int chon = 0;
                            do
                            {
                                Console.WriteLine("******** CHUONG TRINH  QUAN LY NHAN VIEN ******");
                                Console.WriteLine("-----------------------------------------------");
                                Console.WriteLine("1. Nhap danh sach nhan vien.");
                                Console.WriteLine("2. Xuat thong tin nhan vien.");
                                Console.WriteLine("3. Thong ke tong tien luong nhan vien.");
                                Console.WriteLine("0. Ket thuc chuong trinh");
                                Console.WriteLine("--------------------------------");
                                Console.Write("Ban chon chuc nang:");
                                chon = int.Parse(Console.ReadLine());

                                switch (chon)
                                {
                                    case 1:
                                        ql.NhapDS();
                                        break;

                                    case 2:
                                        ql.XuatDS();
                                        break;
                                    case 3:
                                        Console.WriteLine($"Tong tien luong phai tra cho nhan vien: {ql.TinhTongLuong():#,##0 vnd}");
                                        break;
                                    case 0:
                                        Console.WriteLine("Tam biet.");
                                        Console.ReadLine();
                                        break;
                                }

                            } while (chon != 0);
                        }
                    }
                }
            }
        }
    }
}
   

