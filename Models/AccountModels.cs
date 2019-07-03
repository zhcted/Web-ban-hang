using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class AccountModels
    {
        private ShopgiayonlineDbContext context = null;
        public AccountModels()
        {
            context = new ShopgiayonlineDbContext();
        }
        public bool Login(string USERNAME, string MATKHAU)
        {
            object[] sqlPara = {
                new SqlParameter("@USERNAME",USERNAME),
                new SqlParameter("@MATKHAU",MATKHAU)
            };
            var res = context.Database.SqlQuery<bool>("sp_Account_Login @USERNAME, @MATKHAU",sqlPara).SingleOrDefault();
            return res;
        }
    }
}
