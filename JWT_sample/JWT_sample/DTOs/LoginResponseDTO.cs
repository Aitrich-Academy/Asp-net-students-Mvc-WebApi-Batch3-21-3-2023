using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT_sample.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
       
    }
}