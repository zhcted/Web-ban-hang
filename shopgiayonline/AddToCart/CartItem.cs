using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using shopgiayonline.Framework;

namespace shopgiayonline.AddToCart
{
    public class CartItem
    {
        [Key]
        public string HINHANH { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int GIA { get; set; }
        public int Soluong { get; set; }
        public int ThanhTien
        {
            get
            {
                return GIA * Soluong;
            }
        }
    }
}