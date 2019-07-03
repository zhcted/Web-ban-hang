using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopgiayonline.AddToCart;
using shopgiayonline.ForgetPassword;
using shopgiayonline.Framework;

namespace shopgiayonline.Controllers
{
    public class GioHangController : Controller
    {
        private QLShoesEntities db = new QLShoesEntities();
        // GET: GioHang
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        public RedirectToRouteResult ThemVaoGio(int MaSP)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.MaSP == MaSP) == null) // ko co sp nay trong gio hang
            {
                SANPHAM sp = db.SANPHAMs.Find(MaSP);  // tim sp theo sanPhamID

                CartItem newItem = new CartItem()
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    Soluong = 1,
                    HINHANH = sp.HINHANH,
                    GIA = Convert.ToInt32(sp.GIA)

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = giohang.FirstOrDefault(m => m.MaSP == MaSP);
                cardItem.Soluong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("SearchItem","Index");
        }

        public RedirectToRouteResult SuaSoLuong(int MaSP, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.MaSP == MaSP);
            if (itemSua != null)
            {
                itemSua.Soluong = soluongmoi;
            }
            return RedirectToAction("Index");

        }
        public RedirectToRouteResult XoaKhoiGio(int MaSP)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.MaSP == MaSP);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session["giohang"];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

     

        [HttpGet]
        public ActionResult Order()
        {
            if(Session["TenKH"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }
            else
            {
                 //QUANTRI ad = (QUANTRI)Session["TenAdmin"];
                KHACHHANG kh = (KHACHHANG)Session["TenKH"];
                List<CartItem> giohang = Session["giohang"] as List<CartItem>;
                DONHANG dh = new DONHANG();
                dh.MaKH = kh.MaKH;
                //dh.AdID = ad.AdID;
                dh.NGAYDH = DateTime.Now;
                dh.TongTien = giohang.Sum(m => m.ThanhTien).ToString();
                
                return View(dh);
            }
        }

        [HttpPost]
            public ActionResult Order(DONHANG dh)
        {
            KHACHHANG kh = (KHACHHANG)Session["TenKH"];
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            var Nguoimua = kh.TenKH;

            dh.MaKH = kh.MaKH;
            dh.NGAYDH = DateTime.Now;
            dh.TongTien = giohang.Sum(m => m.ThanhTien).ToString();
            var TongTien = dh.TongTien;
            string chiTiet = "";
            chiTiet += "<ul>";

            //thêm hoá đơn và chi tiết hoá đơn dùng Transaction
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                    db.DONHANGs.Add(dh);
                    db.SaveChanges();

                    //lấy ra mã hoá đơn vừa thêm
                    int MaHD = db.DONHANGs.OrderByDescending(x => x.MaDH)
                        .Select(x => x.MaDH).Take(1).Single();

                    //thêm các chi tiết đơn hàng
                    foreach (var item in giohang)
                    {
                        CTHD hdct = new CTHD();
                        hdct.MaDH = MaHD;
                        hdct.MaSP = item.MaSP;
                        hdct.Soluong = (short)item.Soluong;
                        hdct.Gia = item.GIA;

                        db.CTHDs.Add(hdct);
                        db.SaveChanges();

                        chiTiet += "<li>" + item.TenSP + " x <font color = 'blue'><b>" + item.Soluong + " SP </b ></font> = " + String.Format("{0:0,0} VND", item.ThanhTien) + "</li>";
                    }

                    //xoá giỏ hàng
                    Session["GioHang"] = null;

                    //dùng cho email
                    chiTiet += "</ul>";

                    dbContextTransaction.Commit();
            }
            //gửi email
            clsSendEmail email = new clsSendEmail();

            string kq = email.SendMail("dkniken0601@gmail.com", "Khách hàng " + Nguoimua + " đã mua hàng của shop chúng tôi vào" + DateTime.Now, 
                "Cám ơn quý khách đã mua hàng của shop Giày chúng em. Sản phẩm quý khách bao gồm: <br> " + chiTiet + "<br>Vui lòng chuẩn bị " +
                String.Format("{0:0,0} VNĐ", TongTien) + " cho shop chúng em nhé. <br>Nếu hài lòng hãy quay lại mua thêm nhé!!! <br> Kính chào quý khách hàng (^o*)", true);

            
                return RedirectToAction("SearchItem", "Index");

            //db.DONHANGs.Add(dh);
            // db.SaveChanges();

            //Session["giohang"] = null;
            //return RedirectToAction("SearchItem","Index");
        }
    }
}