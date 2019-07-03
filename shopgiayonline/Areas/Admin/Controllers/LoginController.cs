
using shopgiayonline.Areas.Admin.Models;
using shopgiayonline.Common;
using shopgiayonline.ForgetPassword;
using shopgiayonline.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopgiayonline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var results = new AccountModels().Login(model.UserAdmin, model.MatKhauAdmin);
            if (results)
            {
                var user = new AccountModels().GetById(model.UserAdmin);
                var userSession = new UserLogin();
                userSession.UserAdmin = user.UserAdmin;
                userSession.TenAdmin = user.TenAdmin;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng !");
            }
            return View(model);
        }

        QLShoesEntities db = new QLShoesEntities();
        [HttpGet]
        public ActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterAdmin(QUANTRI Register, FormCollection form)
        {
            Register.MatKhauAdmin = clsMaHoa.EncryptPassword(Register.MatKhauAdmin);
            db.QUANTRIs.Add(Register);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session["TenAdmin"] = null;
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ChangePasswordAdmin(string ma)
        {
            QUANTRI ad = db.QUANTRIs.SingleOrDefault(x => x.TenAdmin == ma);
            return View(ad);
        }

        [HttpPost]
        public ActionResult ChangePasswordAdmin(QUANTRI ad)
        {
            db.Entry(ad).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}