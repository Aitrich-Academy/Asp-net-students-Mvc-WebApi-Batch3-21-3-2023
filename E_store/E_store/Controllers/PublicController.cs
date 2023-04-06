using E_store.DTOs;
using E_store.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DAL.Managers;
using DAL.Models;

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
                string username = userDTO.Email;
                string password = userDTO.Password;
                // create manager class object and check if login exist and return data
                LoginManager loginManager=new LoginManager();
                User user= loginManager.Login(username, password);
                if (user != null)
                {
                    string token = TokenManager.GenerateToken(user);
                    LoginResponseDto loginresponse = new LoginResponseDto();
                    loginresponse.Status = "True";
                    loginresponse.Token = token;
                    loginresponse.Name = user.Name;
                    loginresponse.Role = user.Role  ;


                    return Request.CreateResponse(HttpStatusCode.OK, loginresponse);
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Login failed");

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