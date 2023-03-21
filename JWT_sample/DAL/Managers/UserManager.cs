using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Managers
{
    public class UserManager
    {
        public UserManager() { }

        public Users LoginUser(string username, string password)
        {
           return new Users(1,"yadhu","yadhu.aitrich","9633508643","address","680006","mypass","Admin",null);
        }
    }
}
