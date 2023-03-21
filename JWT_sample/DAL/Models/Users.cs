using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Users
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(500)]
        public string pincode { get; set; }

        public byte[] image { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public string role { get; set; }

        public DateTime? createdDate { get; set; }

        public DateTime? lastModified { get; set; }

        
        public string status { get; set; }

        public Users(int id, string name, string email, string phone, string address, string pincode, byte[] image, string password, DateTime? createdDate, DateTime? lastModified, string status)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.pincode = pincode;
            this.image = image;
            this.password = password;
            this.createdDate = createdDate;
            this.lastModified = lastModified;
            this.status = status;
        }
        public Users(int id, string name, string email, string phone, string address, string pincode, string password,string role, byte[] image = null)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.pincode = pincode;
            this.image = image;
            this.role=role;
            this.password = password;
            this.createdDate = DateTime.Now;
            this.lastModified = DateTime.Now;
            this.status = "A";
        }
    }
}
