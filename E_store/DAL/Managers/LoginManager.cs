using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Managers
{
    public class LoginManager
    {
        E_storeEntities db = new E_storeEntities();
        public User Login(string Email, string password)
        {
            return db.Users.Where(e => e.Email == Email  && e.Password == password && e.Status != "D").SingleOrDefault();

        }
    }
}
