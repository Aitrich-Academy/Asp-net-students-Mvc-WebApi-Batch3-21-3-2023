using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JWT_sample.DTOs
{
    public class UsersDTO
    {
        public int Id { get; set; }
     
        public string name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

        public UsersDTO(Users user)
        {
            this.Id = user.id;
            this.name = user.name;
            this.Email=user.email;
            this.Password = user.password;
            this.Role = user.role;
            this.Status = user.status;
        }
        public UsersDTO()
        {

        }
    }
}