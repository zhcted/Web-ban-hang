using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using shopgiayonline.Framework;

namespace shopgiayonline.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        QLShoesEntities db = new QLShoesEntities();
        public ActionResult XemThongTin()
        {
            return View(db.DONHANGs.ToList());
        }


        public ActionResult XoaDonHang(int ma)
        {
            DONHANG dh = db.DONHANGs.SingleOrDefault(x => x.MaDH == ma);
            db.DONHANGs.Remove(dh);
            db.SaveChanges();
            return RedirectToAction("XemThongTin", "DonHang", "Admin");
        }

        public ActionResult XemChiTiet(int ma)
        {

                var ct = db.v_CTHD.First(x => x.MaDH == ma);

                List<v_CTHD> cthd = db.v_CTHD.Where(x => x.MaDH == ma).ToList();
                ViewBag.cthd = cthd;
                return View(ct);
                
        }

        public ActionResult XoaChiTiet(int ma)
        {
            v_CTHD cthd = db.v_CTHD.SingleOrDefault(x => x.MaDH == ma);
            db.v_CTHD.Remove(cthd);
            db.SaveChanges();
            return View();
        }
    }
}