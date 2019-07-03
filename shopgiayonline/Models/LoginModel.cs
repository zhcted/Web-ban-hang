using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopgiayonline.Models
{
    public class LoginModel
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn chưa nhập tài khoản !")]
        public string EmailKH { get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu !")]
        public string MatKhauKH { get; set; }
    }
}