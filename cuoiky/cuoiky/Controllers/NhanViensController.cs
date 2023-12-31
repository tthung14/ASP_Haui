using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cuoiky.Models;

namespace cuoiky.Controllers
{
    public class NhanViensController : Controller
    {
        private Model1 db = new Model1();

        // GET: NhanViens
        public ActionResult Index()
        {
            var nhanVien = db.NhanVien.Include(n => n.Phong);
            return View(nhanVien.ToList());
        }

        [ChildActionOnly]
        public PartialViewResult CategoryMenu()
        {
            var list = db.Phong.ToList();
            return PartialView(list);

        }
        [Route("danhmuc/{Maphong}")]
        public ActionResult ListMenu(int Maphong)
        {
            var list = db.NhanVien.Where(n => n.Maphong == Maphong).ToList();
            return View(list);
        }

        // GET: NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.Maphong = new SelectList(db.Phong, "Maphong", "Tenphong");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nv)
        {
            try
            {
                db.NhanVien.Add(nv);
                db.SaveChanges();
                // Trả về xâu Json nếu result = true
                return Json(new { result = true, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                // Trả về xâu Json nếu result = false
                return Json(new { result = false, error = e.Message });
            }
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maphong = new SelectList(db.Phong, "Maphong", "Tenphong", nhanVien.Maphong);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manv,Hoten,Tuoi,Diachi,Luong,Maphong")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maphong = new SelectList(db.Phong, "Maphong", "Tenphong", nhanVien.Maphong);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanVien.Find(id);
            db.NhanVien.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
