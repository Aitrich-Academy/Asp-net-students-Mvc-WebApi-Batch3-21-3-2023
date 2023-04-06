using JWT_sample.DTOs;
using JWT_sample.Managers;
using JWT_sample.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace JWT_sample.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        [HttpGet]
        [Route("products")]
        public HttpResponseMessage Get()
        {
            AuthenticationHeaderValue authorization = Request.Headers.Authorization;
            UsersDTO usersDTO = TokenManager.ValidateToken(authorization.Parameter);
            if (usersDTO.Id != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new string[] { "value1", "value2" });
             //   return new string[] { "value1", "value2" };

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    message = "Please Login"
                });
            }
        }

      

        // POST: api/Login
        [HttpPost]
        public HttpResponseMessage Login(UsersDTO userDTO)
        {
            if (userDTO != null && ModelState.IsValid)
            {
                var username = userDTO.Email;
                var password = userDTO.Password;

                AccountBL account = new AccountBL();
                ResponseDataDTO dto = account.LoginUser(username, password);
                UsersDTO usersDTO = (UsersDTO)dto.Data;
                if (dto != null && dto.Result)
                {
                   

                    //LogManager.WriteLog("otp generated " + oTPDTO.OTP);

                    string token = TokenManager.GenerateToken(usersDTO);
                  
                    
                        LoginResponseDTO responseDTO = new LoginResponseDTO
                        {
                            Id = usersDTO.Id,
                            Role = usersDTO.Role,
                            Status = usersDTO.Status,
                           
                            Token = token,
                           
                            Name = usersDTO.name

                        };

                        return Request.CreateResponse(HttpStatusCode.OK, responseDTO);
                    //}
                    //else
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.BadRequest, bo);
                    //}
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        Message = dto.Message
                    });
                }
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

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
