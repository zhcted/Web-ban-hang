using shopgiayonline.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopgiayonline.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        QLShoesEntities db = new QLShoesEntities();
        public ActionResult XemThongTin()
        {
            return View(db.KHACHHANGs.ToList());
        }

    }
}