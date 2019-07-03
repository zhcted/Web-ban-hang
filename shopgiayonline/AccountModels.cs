using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopgiayonline.Framework;
using shopgiayonline.ForgetPassword;

namespace shopgiayonline
{
    public class AccountModels
    {
        QLShoesEntities db = null;
        public AccountModels()
        {
            db = new QLShoesEntities();
        }

        public QUANTRI GetById(string username)
        {
            return db.QUANTRIs.SingleOrDefault(x => x.UserAdmin == username);
        }
        public bool Login(string username, string password)
        {
            string mahoa = clsMaHoa.EncryptPassword(password);
            var results = db.QUANTRIs.Count(x => x.UserAdmin == username && x.MatKhauAdmin == mahoa);
            if(results > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
