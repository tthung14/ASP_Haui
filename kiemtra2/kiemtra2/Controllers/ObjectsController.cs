using kiemtra2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace kiemtra2.Controllers
{
    public class ObjectsController : Controller
    {
        QLSanPhamDB db = new QLSanPhamDB();

        // GET: Objects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Xemdanhsach(string SearchString)
        {
            var sp = db.Product.Select(p => p);
            if (!String.IsNullOrEmpty(SearchString))
            {
                decimal x = decimal.Parse(SearchString);
                sp = sp.Where(m => m.Price >= x);
            }
            return View(sp.ToList());
        }

        [HttpGet]
        public ActionResult Themdulieu()
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogy, "CatalogyID", "CatalogyName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Themdulieu([Bind(Include = "ProductID,ProductName,Price,CatalogyID,Image")] Product product)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    product.Image = "";
                    var f = Request.Files["ImageUrl"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        product.Image = FileName;
                    }
                    db.Product.Add(product);
                    db.SaveChanges();

                }
                return RedirectToAction("Xemdanhsach");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                ViewBag.CatalogyID = new SelectList(db.Catalogy, "CatalogyID", "CatalogyName", product.CatalogyID);
                return View(product);
            }
        }


        [HttpGet]
        public ActionResult Xoadulieu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Xoadulieu")]
        [ValidateAntiForgeryToken]
        public ActionResult Xacnhanxoa(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Xemdanhsach");
        }
    }
}