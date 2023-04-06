using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_store.Models
{
    public class ENT_Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedDate { get; set; }
    }
}