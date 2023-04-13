using DAL.Manager;
using DAL.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using E_store.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_store.Controllers
{
    public class orderController : ApiController
    {
        [RoutePrefix("api/sample")]  // Url creation Route
        public class SampleController : ApiController
        {

            #region order insert

            //api/sample/orderinsert
            [System.Web.Http.AcceptVerbs("GET", "POST", "PUT")]
            [System.Web.Http.HttpGet]
            [Route("orderinsert")]   // Url creation Route
            [HttpPost]
            [HttpPut]
            public string orderinsert(ENT_orderRegistration Obj)
            {
                order_manager mngr = new order_manager();
                ENT_orderRegistration objorder = Obj;
                // Orders tbl_Obj = new Orders();
                DAL.Models.Users us = new DAL.Models.Users();

                //tbl_Obj.Id = objorder.Id;
                //tbl_Obj.User_ID = objorder.User_ID;
                //tbl_Obj.Product_ID = objorder.Product_ID;
                //tbl_Obj.Quantity = objorder.Quantity;
                //tbl_Obj.TotalPrice = objorder.TotalPrice;
                //tbl_Obj.CreatedBy = objorder.CreatedBy;
                //tbl_Obj.CreatedDate = objorder.CreatedDate;
                //tbl_Obj.LastModifiedBy = objorder.LastModifiedBy;
                //tbl_Obj.LastModifiedDate = objorder.LastModifiedDate;
                // return mngr.orderinsert(tbl_Obj);

                //sendEmail(objorder.Email, subject, body);
                us.Id = objorder.Id;
                us.Name = objorder.Name;
                us.Address = objorder.Address;
                us.Phone = objorder.Phone;
                us.Email = objorder.Email;
                us.Role = objorder.Role;
                us.Password = objorder.Password;
                us.CreatedBy = objorder.CreatedBy;
                us.CreatedDate = objorder.CreatedDate;
                us.LastModifiedBy = objorder.LastModifiedBy;
                us.LastModifiedDate = objorder.LastModifiedDate;
                //tbl_Obj.createdDate = DateTime.Now;
                //tbl_Obj.lastModified = DateTime.Now;

                return mngr.userinsert(us);
            }




            #endregion

            #region All order details

            //api/sample/allorders
            [System.Web.Http.AcceptVerbs("GET")]
            [System.Web.Http.HttpGet]
            [Route("allorders")]
            public List<ENT_orderRegistration> allorders()
            {
                order_manager mngr = new order_manager();
                List<ENT_orderRegistration> return_List = new List<ENT_orderRegistration>();
                List<Orders> tbl_obj = mngr.allorders();
                List<DAL.Models.Users> tbl_us = mngr.allusers();

                if (tbl_obj.Count != 0)
                {
                    if (tbl_us.Count != 0)
                    {

                        foreach (var obj in tbl_obj)
                        {
                            return_List.Add(new ENT_orderRegistration
                            {
                                Id = obj.Id,
                                User_ID = obj.User_ID,
                                Product_ID = obj.Product_ID,
                                Quantity = obj.Quantity,
                                TotalPrice = (float)obj.TotalPrice,
                                CreatedBy = obj.CreatedBy,
                                CreatedDate = obj.CreatedDate,
                                LastModifiedBy = obj.LastModifiedBy,
                                LastModifiedDate = obj.LastModifiedDate,
                                Status = obj.Status,
                            });
                        }
                        foreach (var obj in tbl_us)
                        {
                            return_List.Add(new ENT_orderRegistration
                            {
                                Name = obj.Name,
                                Address = obj.Address,
                                Phone = obj.Phone,
                                Email = obj.Email,



                            });
                        }
                    }
                }
                return return_List;
            }

            #endregion

            //#region Get order details by id

            ////api/sample/orderDetailsByID?id=1
            //[System.Web.Http.AcceptVerbs("GET", "POST")]
            //[System.Web.Http.HttpGet]
            //[Route("orderDetailsByID")]
            //[HttpPost]
            //[HttpPut]


            //public ENT_orderRegistration orderDetailsByID(string id)
            //{
            //    order_manager mngr = new order_manager();
            //    ENT_orderRegistration return_Obj = new ENT_orderRegistration();
            //    Orders tbl_obj = mngr.orderDetails(Convert.ToInt32(id));
            //    //Users us = mngr.userDetails(Convert.ToInt32(id));

            //    if (tbl_obj != null)
            //    {
            //        //if (us != null)
            //        //{
            //        //return_Obj.Id = tbl_obj.Id;
            //        return_Obj.User_ID = tbl_obj.User_ID;
            //        return_Obj.Product_ID = tbl_obj.Product_ID;
            //        return_Obj.Quantity = tbl_obj.Quantity;
            //        return_Obj.TotalPrice = (float)tbl_obj.TotalPrice;
            //        return_Obj.CreatedBy = tbl_obj.CreatedBy;
            //        return_Obj.CreatedDate = tbl_obj.CreatedDate;
            //        return_Obj.LastModifiedBy = tbl_obj.LastModifiedBy;
            //        return_Obj.LastModifiedDate = tbl_obj.LastModifiedDate;
            //        //return_Obj.Name = us.Name;
            //        //return_Obj.Address = us.Address;
            //        //return_Obj.Phone = us.Phone;
            //        //return_Obj.Email = us.Email;
            //        //return_Obj.createdDate = Convert.ToDateTime(tbl_obj.createdDate).ToShortDateString();
            //        //return_Obj.lastModified = Convert.ToDateTime(tbl_obj.lastModified).ToShortDateString();
            //        return_Obj.Status = tbl_obj.Status;
            //        //}

            //    }
            //    return return_Obj;
            //}

            //#endregion

            #region delete by id

            //api/sample/deleteByID?id=1
            [System.Web.Http.AcceptVerbs("DELETE")]
            [System.Web.Http.HttpGet]
            [Route("deleteByID")]
            [HttpDelete]


            public string orderdelete(string id)
            {
                order_manager mngr = new order_manager();
                return mngr.Deleteid(Convert.ToInt32(id));



                #endregion

            }
        }
    }
}

