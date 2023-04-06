using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Managers
{
  public  class ProductManager
    {
        E_storeEntities context = new E_storeEntities();

        public string InsertProduct(Product obj)
        {
            int result = 0;
            var objUser = context.Products.Where(e => e.Id == obj.Id && e.Status != "D").SingleOrDefault();

            if (objUser == null)
            {
                obj.Status = "A";
                context.Products.Add(obj);
                result = context.SaveChanges();
            }
            else
            {
                objUser.Name = obj.Name;
                objUser.CategoryId = obj.CategoryId;
                objUser.Description = obj.Description;
                objUser.Stock = obj.Stock;
                objUser.Image = obj.Image;
                objUser.Price = obj.Price;
                objUser.Status = obj.Status;
                objUser.CreatedBy = obj.CreatedBy;
                objUser.CreatedDate = obj.CreatedDate;
                objUser.LastModifiedBy = obj.LastModifiedBy;
                objUser.LastModifiedDate = obj.LastModifiedDate;
                objUser.Status = "A";
                context.Entry(objUser).State = EntityState.Modified;
                result = context.SaveChanges();

            }

            if (result > 0)
            {
                return obj.Name.ToString();
            }
            else
            {
                return "Error";
            }
        }

        //public HttpResponseMessage InsertProduct(Product tbl_Obj)
        //{
        //    throw new NotImplementedException();
        //}


        //public void InsertProduct(Products tbl_Obj)
        //{
        //    throw new NotImplementedException();
        //}

        // if (search != "")
        //    {
        //        List<Products> _list = context.Products.Where(e => e.Name.Contains(search) && e.Status != "D").ToList();

        //    }
        //}

        public List<Product> searchproduct(string proname)
        {
            try
            {
                return context.Products.Where(o => o.Name.Contains(proname)  && o.Status != "D").ToList();

            }

            catch (Exception e)
            {
                throw;
            }
        }




        public string UpdateProduct(Product obj)
        {
            int result = 0;
            var objUser = context.Products.Where(e => e.Id == obj.Id && e.Status != "D").SingleOrDefault();

            if (objUser != null)
            {

                objUser.Id = obj.Id;
                objUser.Name = obj.Name;
                objUser.CategoryId = obj.CategoryId;
                objUser.Description = obj.Description;
                objUser.Stock = obj.Stock;
                objUser.Image = obj.Image;
                objUser.Price = obj.Price;
                objUser.Status = obj.Status;
                objUser.CreatedBy = obj.CreatedBy;
                objUser.CreatedDate = obj.CreatedDate;
                objUser.LastModifiedBy = obj.LastModifiedBy;
                objUser.LastModifiedDate = obj.LastModifiedDate;
                objUser.Status = "A";
                context.Entry(objUser).State = EntityState.Modified;
                result = context.SaveChanges();

            }
            if (result > 0)
            {
                return obj.Name.ToString();
            }
            else
            {
                return "Error";
            }
        }

        public List<Product> listproduct()
        {
            return context.Products.Where(e => e.Status != "D").ToList();
        }

        public List<Product> listproductbyid(int Id)
        {
            return context.Products.Where(e => e.Id == Id & e.Status != "D").ToList();
        }

        public void DeleteProduct(int id)
        {
            var objUser = context.Products.Where(e => e.Id == id && e.Status != "D").SingleOrDefault();
            context.Products.Remove(objUser);
            context.SaveChanges();
        }
    }
}


   
