using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopgiayonline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public int AdID { get; set; }
        public string TenAdmin { get; set; }
        public string UserAdmin { get; set; }
        public string MatKhauAdmin { get; set; }
        public bool RememberMe { get; set; }
        
    }
}