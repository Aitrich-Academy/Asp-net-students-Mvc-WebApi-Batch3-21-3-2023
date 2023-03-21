using E_store.DTOs;
using E_store.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace E_store.Controllers
{
      //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/public")]
    public class PublicController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(UsersDTO userDTO)
        {
            if (userDTO != null && ModelState.IsValid)
            {
                var username = userDTO.Email;
                var password = userDTO.Password;
                // create manager class object and check if login exist and return data
                return Request.CreateResponse(HttpStatusCode.OK, "");

            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    Errors = Utils.Utils.GetErrorListFromModelState(ModelState)
                });
            }
        }
    }
}