using DAL.Managers;
using DAL.Models;
using JWT_sample.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JWT_sample.Managers
{
    public class AccountBL
    {
        UserManager userManager=new UserManager();
        public ResponseDataDTO LoginUser(string username, string password)
        {
            Users user = userManager.LoginUser(username, password);
            UsersDTO usersDTO=new UsersDTO();
            if (user != null)
            {
                 usersDTO = new UsersDTO(user);
                ResponseDataDTO dto = new ResponseDataDTO(true, "success", usersDTO);
                return dto;
            }
            ResponseDataDTO dto2 = new ResponseDataDTO(false, "failed", usersDTO);
            return dto2;

         
           
        }
    }
}