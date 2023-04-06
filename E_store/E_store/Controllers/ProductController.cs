using DAL.Managers;
using DAL.Models;
using E_store.Models;
using E_store.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
namespace E_store.Controllers
{
    [System.Web.Http.RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {

        // GET: Default

        [HttpPost]
        [System.Web.Http.Route("InsertProduct")]
        public HttpResponseMessage InsertProduct(ENT_Product obj)
        {
            AuthenticationHeaderValue authorization = Request.Headers.Authorization;
            if (authorization != null)
            {
                //User usersDTO = TokenManager.ValidateToken(authorization.Parameter);

                //if (usersDTO.Id != null && usersDTO.Role == "Admin")
                {
                    ProductManager mngr = new ProductManager();
                    ENT_Product objUser = obj;
                    Product tbl_Obj = new Product();

                    tbl_Obj.Name = objUser.Name;
                    tbl_Obj.CategoryId = objUser.CategoryId;
                    tbl_Obj.Description = objUser.Description;
                    tbl_Obj.Stock = objUser.Stock;
                    tbl_Obj.Image = objUser.Image;
                    tbl_Obj.Price = objUser.Price;
                    tbl_Obj.Status = "A";
                    tbl_Obj.CreatedBy = "system";
                    tbl_Obj.CreatedDate = DateTime.Now.ToString();
                    tbl_Obj.LastModifiedBy = "system";
                    tbl_Obj.LastModifiedDate = DateTime.Now.ToString();



                    return Request.CreateResponse(HttpStatusCode.OK, mngr.InsertProduct(tbl_Obj));
                }

            }

                return Request.CreateResponse(HttpStatusCode.Unauthorized, "please login");

            }

        
            // GET: api/Product
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET: api/Product/5
            public string Get(int id)
            {
                return "value";
            }

            // POST: api/Product
            public void Post([FromBody] string value)
            {
            }

            [System.Web.Http.HttpPut]
            [System.Web.Http.Route("updateProduct")]
            public HttpResponseMessage UpdateProduct(ENT_Product obj)
            {
                ProductManager mngr = new ProductManager();
                ENT_Product objUser = obj;
                Product tbl_Obj = new Product();
                tbl_Obj.Id = objUser.Id;
                tbl_Obj.Name = objUser.Name;
                tbl_Obj.CategoryId = objUser.CategoryId;
                tbl_Obj.Description = objUser.Description;
                tbl_Obj.Stock = objUser.Stock;
                tbl_Obj.Image = objUser.Image;
                tbl_Obj.Price = objUser.Price;
                tbl_Obj.Status = "A";
                tbl_Obj.CreatedBy = "system";
                tbl_Obj.CreatedDate = DateTime.Now.ToString();
                tbl_Obj.LastModifiedBy = "system";
                tbl_Obj.LastModifiedDate = DateTime.Now.ToString();
                mngr.UpdateProduct(tbl_Obj);
                return Request.CreateResponse(HttpStatusCode.OK, "updated sucessfully");




                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, " updated sucessfully");

                }

                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "error");
                }
            }


            [HttpGet]
            [Route("productSearch")]
            public List<ENT_Product> productSearch(string proname)
            {
                ProductManager mngr = new ProductManager();
                List<ENT_Product> list = new List<ENT_Product>();
                List<Product> tbl_Obj = mngr.searchproduct(proname);


                foreach (var obj in tbl_Obj)
                {
                    list.Add(new ENT_Product
                    {
                        Id = obj.Id,
                        Name = obj.Name,
                        CategoryId = obj.CategoryId,
                        Description = obj.Description,
                        Stock = obj.Stock,
                        Image = obj.Image,
                        Price = Convert.ToInt32(obj.Price),
                        Status = obj.Status,
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = obj.CreatedDate,
                        lastModifiedBy = obj.LastModifiedBy,
                        lastModifiedDate = obj.LastModifiedDate
                    });
                }
                return list;
            }

            [System.Web.Http.HttpDelete]
            [System.Web.Mvc.Route("ProductDelete")]
            public HttpResponseMessage ProductDelete(int id)
            {
                ProductManager mngr = new ProductManager();
                mngr.DeleteProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, "product deleted sucessfully");
            }
            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("ListProduct")]
            public List<ENT_Product> ListProduct()
            {
                ProductManager mngr = new ProductManager();
                List<ENT_Product> list = new List<ENT_Product>();

                List<Product> tbl_Obj = mngr.listproduct();
                foreach (var obj in tbl_Obj)
                {
                    list.Add(new ENT_Product
                    {
                        Id = obj.Id,
                        Name = obj.Name,
                        CategoryId = obj.CategoryId,
                        Description = obj.Description,
                        Stock = obj.Stock,
                        Image = obj.Image,
                        Price = Convert.ToInt32(obj.Price),
                        Status = obj.Status,
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = obj.CreatedDate,
                        lastModifiedBy = obj.LastModifiedBy,
                        lastModifiedDate = obj.LastModifiedDate,
                    });

                }
                return list;
            }
            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("listproductbyid")]
            public List<ENT_Product> listproductbyid(int Id)
            {
                ProductManager mngr = new ProductManager();
                List<ENT_Product> list = new List<ENT_Product>();

                List<Product> tbl_Obj = mngr.listproductbyid(Id);
                foreach (var obj in tbl_Obj)
                {
                    list.Add(new ENT_Product
                    {
                        Id = obj.Id,
                        Name = obj.Name,
                        CategoryId = obj.CategoryId,
                        Description = obj.Description,
                        Stock = obj.Stock,
                        Image = obj.Image,
                        Price = Convert.ToInt32(obj.Price),
                        Status = obj.Status,
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = obj.CreatedDate,
                        lastModifiedBy = obj.LastModifiedBy,
                        lastModifiedDate = obj.LastModifiedDate,
                    });

                }
                return list;
            }
        }
    }
    // DELETE: api/Product/5





    
