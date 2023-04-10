using DAL.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class order_manager
    {
        model_order mod = new model_order();
        public string orderinsert(Orders Obj)
        {

            int result = 0;
            var objorder = mod.Orders.Where(e => e.Id == Obj.Id && e.Status != "D").SingleOrDefault();


            if (objorder == null)
            {


                Obj.Status = "A";
                mod.Orders.Add(Obj);
                result = mod.SaveChanges();



            }
            else
            {

                objorder.User_ID = Obj.User_ID;
                objorder.Product_ID = Obj.Product_ID;
                objorder.Quantity = Obj.Quantity;
                objorder.TotalPrice = Obj.TotalPrice;
                objorder.CreatedBy = Obj.CreatedBy;
                objorder.CreatedDate = Obj.CreatedDate;
                objorder.LastModifiedBy = Obj.LastModifiedBy;
                objorder.LastModifiedDate = Obj.LastModifiedDate;
                objorder.Status = "A";
                mod.Entry(objorder).State = EntityState.Modified;
                result = mod.SaveChanges();
            }

            if (result > 0)
            {
                return Obj.Id.ToString();
            }
            else
            {
                return "Error";
            }

        }
        private void sendEmail(string email, string subject, string body)
        {
            var host = "smtp.gmail.com";
            var port = 587;

            var username = "tripping.manage.official@gmail.com"; // get from Mailtrap
            var password = "athbirwmszunyunm"; // get from Mailtrap

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Admin", "tripping.manage.official@gamil.com"));
            message.To.Add(new MailboxAddress("Admin", email));
            message.Subject = "Thanks for choosing";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<p>Thanks for registering with our website <b>.</p>";
            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();

            client.Connect(host, port, SecureSocketOptions.Auto);
            client.Authenticate(username, password);

            client.Send(message);
            client.Disconnect(true);

        }

        public string userinsert(Users Obj)
        {

            int result = 0;
            var objuser = mod.Users.Where(e => e.Id == Obj.Id && e.Status != "D").SingleOrDefault();

            if (objuser == null)
            {


                Obj.Status = "A";
                mod.Users.Add(Obj);
                result = mod.SaveChanges();
                string subject = "Welcome to our website";
                string body = "Dear " + Obj.Name + ",\n\nThank you for registering with our website.";
                sendEmail(Obj.Email, subject, body);

            }
            else
            {

                objuser.Name = Obj.Name;
                objuser.Address = Obj.Address;
                objuser.Phone = Obj.Phone;
                objuser.Email = Obj.Email;
                //objorder.Quantity = Obj.Quantity;
                //objorder.TotalPrice = Obj.TotalPrice;
                ////objorder.location = Obj.location;
                //objorder.CreatedBy = Obj.CreatedBy;
                //objorder.CreatedDate = Obj.CreatedDate;
                //objorder.LastModifiedBy = Obj.LastModifiedBy;
                //objorder.LastModifiedDate = Obj.LastModifiedDate;
                //objorder.Status = "A";
                mod.Entry(objuser).State = EntityState.Modified;
                result = mod.SaveChanges();
                string subject = "Welcome to our website";
                string body = "Dear " + Obj.Name + ",\n\nThank you for registering with our website.";
                sendEmail(Obj.Email, subject, body);
            }

            if (result > 0)
            {
                return Obj.Id.ToString();
            }
            else
            {
                return "Error";
            }

        }
        public List<Orders> allorders()
        {
            return mod.Orders.Where(e => e.Status != "D").ToList();
        }
        public List<Users> allusers()
        {
            return mod.Users.Where(e => e.Status != "D").ToList();
        }
        public Orders orderDetails(int Id)
        {
            Orders return_Obj = new Orders();
            return return_Obj = mod.Orders.Where(e => e.Id == Id && e.Status != "D").SingleOrDefault();
        }
        //public Users userDetails(int Id)
        //{
        //    Users return_Obj = new Users();
        //    return return_Obj = mod.Users.Where(e => e.Id == Id && e.Status != "D").SingleOrDefault();
        //}
        public List<Orders> allorderDetails(int id = 0)
        {
            if (id != 0)
            {
                return mod.Orders.Where(e => e.Id == id && e.Status != "D").ToList();
            }
            else
            {
                return mod.Orders.Where(e => e.Status != "D").ToList();
            }
        }



        public string Deleteid(int id)
        {

            Orders Obj = new Orders();
            //Obj.Id = id;
            //mod.Orders.Status = "D";

            var dummy = mod.Orders.FirstOrDefault(e => e.Id == id && e.Status != "D");


            //mod.SaveChanges();
            if (dummy == null)
            {

                return "Error";
            }
            else
            {
                mod.Orders.Remove(dummy);
                //mod.Orders.Status = "D";
                mod.SaveChanges();
                return "success";
            }

        }


    }

}
