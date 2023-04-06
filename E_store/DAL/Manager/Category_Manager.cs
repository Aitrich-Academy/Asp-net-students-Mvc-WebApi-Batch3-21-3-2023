using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class Category_Manager
    {
        E_storeEntities context = new E_storeEntities();

        public string Category_insert(Category obj_cat)
        {
            int result = 0;
            var dummy = context.Categories.Where(e => e.Id == obj_cat.Id && e.Status != "D").SingleOrDefault();
            if (dummy == null)
            {
                obj_cat.Status = "A";
                context.Categories.Add(obj_cat);
                result = context.SaveChanges();

            }
            else
            {


                dummy.Name = obj_cat.Name;
                dummy.Description = obj_cat.Description;
                dummy.Image = obj_cat.Image;
                dummy.CreatedBy = obj_cat.CreatedBy;
                dummy.CreatedDate = obj_cat.CreatedDate;
                dummy.LastModifiedBy = obj_cat.LastModifiedBy;
                dummy.LastModifiedDate = obj_cat.LastModifiedDate;
                dummy.Status = "A";
                context.Entry(dummy).State = System.Data.Entity.EntityState.Modified;
                result = context.SaveChanges();
            }
            if (result > 0)
            {
                return obj_cat.Id.ToString();

            }
            else
            {
                return "ERROR";
            }


        }



        public string delete(int Id)
        {
            Category obj_cat = new Category();

            var dummy = context.Categories.FirstOrDefault(e => e.Id == Id && e.Status != "D");
            if (dummy == null)
            {
                return "ERROR";
            }
            else
            {
                context.Categories.Remove(dummy);
                context.SaveChanges();
                return "SUCESS";

            }
        }
    }
}
