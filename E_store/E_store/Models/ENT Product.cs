using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_store.Models
{
    public class ENT_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string lastModifiedBy { get; set; }
        public string lastModifiedDate { get; set; }


    }
}
    