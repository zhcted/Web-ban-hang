using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopgiayonline.Common
{
    [Serializable]
    public class UserLogin
    {
        public string TenAdmin { get; set; }
        public string UserAdmin { get; set; }
    }
}