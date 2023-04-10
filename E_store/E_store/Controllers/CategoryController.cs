using DAL.Manager;
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

namespace E_store.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {


        [System.Web.Http.AcceptVerbs("POST", "PUT")]
        [System.Web.Http.HttpGet]
        [Route("Category_Insert")]
        [HttpPost]
        [HttpPut]
        //api/Category/Category_Insert
        public string Category_Insert(ENT_Category obj)
        {
            AuthenticationHeaderValue authorization = Request.Headers.Authorization;
            if (authorization != null)
            {

                User usersDTO = TokenManager.ValidateToken(authorization.Parameter);
                if (usersDTO.Id != null && usersDTO.Role == "Admin")
                {
                    Category_Manager obj_Manager = new Category_Manager();
                    Category obj_category = new Category();
                    ENT_Category obj_ENT = obj;
                    obj_category.Id = obj_ENT.Id;
                    obj_category.Name = obj_ENT.Name;
                    obj_category.Description = obj_ENT.Description;
                    obj_category.Image = obj_ENT.Image;
                    obj_category.Status = obj_ENT.Status;
                    obj_category.CreatedBy = obj_ENT.CreatedBy;
                    obj_category.CreatedDate = obj_ENT.CreatedDate;
                    obj_category.LastModifiedBy = obj_ENT.LastModifiedBy;
                    obj_category.LastModifiedDate = obj_ENT.LastModifiedDate;
                    return obj_Manager.Category_insert(obj_category);
                }
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Please Login");
        }




        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("deletebyId")]
        [HttpPost]
        [HttpDelete]
        //api/Category/deletebyId?Id=1
        public string delete(string Id)
        {

            Category_Manager obj_Manager = new Category_Manager();
            return obj_Manager.delete(Convert.ToInt32(Id));

        }

    }
}

