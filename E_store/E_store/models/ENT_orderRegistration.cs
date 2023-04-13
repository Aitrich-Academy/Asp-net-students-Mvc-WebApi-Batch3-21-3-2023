using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_store.models
{
    public class ENT_orderRegistration
    {
        public int Id { get; set; }
        public int User_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int CategoryId { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedDate { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}