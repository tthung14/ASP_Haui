using kiemtra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kiemtra1.Controllers
{
    public class QuanlyNhanvienController : Controller
    {
        List<NhanVien> danhsach = new List<NhanVien>();
        List<NhanVien> list1 = new List<NhanVien>();
        List<NhanVien> list2 = new List<NhanVien>();

        public QuanlyNhanvienController()
        {
            danhsach.Add(new NhanVien("Nv01", "Nguyễn Vân Anh", "Hà Nội", 15, 200000));
            danhsach.Add(new NhanVien("Nv02", "Lê Thu Hà", "Hải Phòng", 27, 250000));
            danhsach.Add(new NhanVien("Nv03", "Nguyễn Văn Hoàng", "Hà Nội", 18, 250000));
            danhsach.Add(new NhanVien("Nv04", "Trần Thu Hương", "Hải Phòng", 25, 190000));
            danhsach.Add(new NhanVien("Nv05", "Ngô Phương Thảo", "Quảng Ninh", 20, 180000));
        }

        public ActionResult Display()
        {
            foreach (var item in danhsach)
            {
                if (item.songaylam < 20)
                {
                    list1.Add(item);
                }
                if (item.luongngay > 190000)
                {
                    list2.Add(item);
                }
            }
            ViewBag.l1 = list1;
            ViewBag.l2 = list2;
            return View();
        }

        public ActionResult Input()
        {
            //ViewBag.manv = nv.manv;
            //ViewBag.hoten = nv.hoten;
            //ViewBag.diachi = nv.diachi;
            //ViewBag.songaylam = nv.songaylam;
            //ViewBag.luongngay = nv.luongngay;
            return View();
        }
        public ActionResult Output(NhanVien nv)
        {
            ViewBag.manv = nv.manv;
            ViewBag.hoten = nv.hoten;
            ViewBag.diachi = nv.diachi;
            ViewBag.songaylam = nv.songaylam;
            ViewBag.luongngay = nv.luongngay;
            ViewBag.tienluong = nv.tienluong;
            return View();
        }

        // GET: QuanlyNhanvien
        public ActionResult Index()
        {
            return View();
        }
    }
}