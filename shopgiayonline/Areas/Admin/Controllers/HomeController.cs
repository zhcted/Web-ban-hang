using shopgiayonline.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopgiayonline.Framework;

namespace shopgiayonline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        QLShoesEntities db = new QLShoesEntities();
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList());
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemSanPham(SANPHAM sp)
        {
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index","Home","Admin");
        }
        
        public ActionResult XoaSanPham(int ma)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(x => x.MaSP == ma);
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index","Home","Admin");
        }

        [HttpGet]
        public ActionResult SuaSanPham(int ma)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(x => x.MaSP == ma);
            return View(sp);
        }

        [HttpPost]
        public ActionResult SuaSanPham(SANPHAM sp)
        {
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home", "Admin");
        }

        
    }
}