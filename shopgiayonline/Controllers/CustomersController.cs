using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using shopgiayonline.ForgetPassword;
using shopgiayonline.Framework;
using shopgiayonline.Models;

namespace shopgiayonline.Controllers
{
    public class CustomersController : Controller
    {
        QLShoesEntities db = new QLShoesEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string EmailKH, string MatKhauKH)
        {

            string mahoa = clsMaHoa.EncryptPassword(MatKhauKH);
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(x => x.EmailKH == EmailKH && x.MatKhauKH == mahoa);
                if(kh == null)
            {
                string res = "Tên đăng nhập hoặc mật khẩu không đúng !!";
                ViewBag.res = res;
                return View();
            }
            else
            {
                Session["TenKH"] = kh;
                return RedirectToAction("Index", "Index");
            }
               
        }

        public ActionResult Logout()
        {
            Session["TenKH"] = null;
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult RegisterCustomers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomers(KHACHHANG Register,string EmailKH, FormCollection form)
        {
            Register.MatKhauKH = clsMaHoa.EncryptPassword(Register.MatKhauKH);
            var email = db.KHACHHANGs.SingleOrDefault(c => c.EmailKH == EmailKH);
          
            
                
                db.KHACHHANGs.Add(Register);
                db.SaveChanges();
            

            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword(int ma)
        {
            KHACHHANG sp = db.KHACHHANGs.SingleOrDefault(x => x.MaKH == ma);
            return View(sp);
        }

        [HttpPost]
        public ActionResult ChangePassword(KHACHHANG sp)
        {
            sp.MatKhauKH = clsMaHoa.EncryptPassword(sp.MatKhauKH);
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Index");
            
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ForgetPassword(KHACHHANG kh, QUANTRI ad, string ma)
        {
            
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, true));
            builder.Append(RandomNumber(100, 999));
            builder.Append(RandomString(2, false));
            string random = Convert.ToString(builder);
            clsSendEmail guiThu = new clsSendEmail();
            //guiThu.SmtpMailFrom = "dkniken0601@gmail.com";
            
            KHACHHANG mk = db.KHACHHANGs.SingleOrDefault(x => x.EmailKH == kh.EmailKH);
            mk.MatKhauKH = clsMaHoa.EncryptPassword(random);
            db.SaveChanges();
            //guiThu.SendMail(ad.EmailAdmin, "Gửi lại mã", clsMaHoa.Key, false);
            guiThu.SendMail(kh.EmailKH, "Quên mật khẩu", "Mật khẩu mới của bạn là : \n" + random , true);
            return View();
        }


        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public ActionResult History()
        {
            List<v_CTHD> ctdh = db.v_CTHD.ToList();
            return View(ctdh);
        }
    }
}