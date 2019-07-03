using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopgiayonline.Models;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Reflection;
using PagedList;
using shopgiayonline.Framework;

namespace shopgiayonline.Controllers
{
    public class IndexController : Controller
    {
        private QLShoesEntities db = new QLShoesEntities();
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public ActionResult SearchItem(int? size, int? page, string sortProperty, string sortOrder, string searchItem)
        {
            var count = db.SANPHAMs.ToList().Count;
            ViewBag.count = count;



            // 1. Tạo biến viewbag gồm sortOrder, searchValue, sortProgerty và Page
            ViewBag.NamesortOrder = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.searchValue = searchItem;
            ViewBag.sortProperty = sortProperty;
            ViewBag.page = page;

            // 2. Tạo danh sách chọn số trang
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });

            //2.1. Thiết lập số trang đang chọn vào danh sách List<SelectListItem> items
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            ViewBag.size = items;
            ViewBag.currentSize = size;

            // 3. Lấy tất cả tên thuộc tính của lớp sản phẩm (LinkID, LinkName, LinkURL,...)
            var properties = typeof(SANPHAM).GetProperties();
            List<Tuple<string, bool, int>> list = new List<Tuple<string, bool, int>>();
            foreach (var item in properties)
            {
                int order = 999;
                var isVirtual = item.GetAccessors()[0].IsVirtual;

                if (item.Name == "GIA") order = 2;
                if (item.Name == "TenSP") order = 1;
                if (item.Name == "MaSP") continue;
                if (item.Name == "TRANGTHAI") continue;
                if (item.Name == "Mota") continue;
                if (item.Name == "Motachitiet") continue;
                if (item.Name == "ChatLieu") continue;
                if (item.Name == "HINHTONGHOP") continue;
                if (item.Name == "HINHANH") continue;
                if (item.Name == "DacDiem") continue;// Không hiển thị cột này
                Tuple<string, bool, int> t = new Tuple<string, bool, int>(item.Name, isVirtual, order);
                list.Add(t);
            }
            list = list.OrderBy(x => x.Item3).ToList();

            
            var links = from l in db.SANPHAMs
                        select l;

            // 5. Tạo thuộc tính sắp xếp mặc định là "Tên sản phẩm"
            if (String.IsNullOrEmpty(sortProperty)) sortProperty = "TenSP";

            // 5. Sắp xếp tăng/giảm bằng phương thức OrderBy sử dụng trong thư viện Dynamic LINQ
            if (sortOrder == "desc") links = links.OrderBy(sortProperty + " desc");
            else if (sortOrder == "asc") links = links.OrderBy(sortProperty);
            else links = links.OrderBy("TenSP");

            // 5.1. Thêm phần tìm kiếm
            if (!String.IsNullOrEmpty(searchItem))
            {
                links = links.Where(s => s.TenSP.Contains(searchItem));
            }
            // 5.2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 5.3. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            ViewBag.pageSize = pageSize;

            // 6. Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber. --- dammio.com
            int pageNumber = (page ?? 1);

            // 6.2 Lấy tổng số record chia cho kích thước để biết bao nhiêu trang
            int checkTotal = (int)(links.ToList().Count / pageSize) + 1;
            // Nếu trang vượt qua tổng số trang thì thiết lập là 1 hoặc tổng số trang
            if (pageNumber > checkTotal) pageNumber = checkTotal;

            // 7. Trả về các Link được phân trang theo kích thước và số trang.

            if (sortOrder == "name_desc")
            {
                links = links.OrderByDescending(s => s.TenSP);
            }
            else
            {
                links = links.OrderBy(s => s.TenSP);
            }
            //switch (sortOrder)
            //{
            //    // 3.1 Nếu biến sortOrder sắp giảm thì sắp giảm theo LinkName
            //    case "name_desc":
            //        links = links.OrderByDescending(s => s.TenSP);
            //        break;

            //    // 3.2 Mặc định thì sẽ sắp tăng
            //    default:
            //        links = links.OrderBy(s => s.TenSP);
            //        break;
            //}
            return View("SearchItem",links.ToPagedList(pageNumber, pageSize));
            //var searchName = from i in db.SANPHAMs select i;
            //if (!String.IsNullOrEmpty(searchItem))
            //{
            //    searchName = db.SANPHAMs.Where(i => i.TenSP.Contains(searchItem));
            //}
            //ViewBag.search = searchItem;
            //return View(searchName);
        }

        public ActionResult DetailProduct(int ma)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(x => x.MaSP == ma);
            return View(sp);
        }
    }
}