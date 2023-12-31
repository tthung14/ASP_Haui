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
    public class LoginController : Controller
    {
        private Model1 db = new Model1();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.tblUser.ToList());
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(db.tblUser.ToList());
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.tblUser.Where(u => u.username == username && u.password == password).FirstOrDefault();
            if (user != null)
            {
                Session["username"] = username;
                return RedirectToAction("Index", "NhanViens");
            }
            else
            {
                ViewBag.errMsg = "Dang nhap that bai";
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "NhanViens");
        }
        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUser.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,role")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUser.Add(tblUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUser);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUser.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,role")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUser);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUser.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tblUser = db.tblUser.Find(id);
            db.tblUser.Remove(tblUser);
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
