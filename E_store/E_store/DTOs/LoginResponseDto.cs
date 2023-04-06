using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_store.DTOs
{
    public class LoginResponseDto
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}