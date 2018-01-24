using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Popcorn.Models;
using System.Configuration;

namespace Popcorn.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public JsonResult Index(User_Model.regis_input input)
        {
            DataClass.Users User = new DataClass.Users();

            User_Model.Output_Regis output = new User_Model.Output_Regis();
           
           
            using (DataClass.DataClasses1DataContext db = new DataClass.DataClasses1DataContext(ConfigurationManager.AppSettings["dbConnPopcorn"]))
            {
               
                var result = db.Users.FirstOrDefault(X => X.Email == input.Email);

                if (result != null)
                {
                    output.message = "Email is already";
                    output.error = true;


                    return Json(output, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (input.Email == null)
                    {
                        output.message = "Email null";
                    }
                    else
                    {
                        User.Password = input.Password;
                        User.Name = input.Name;
                        User.Email = input.Email;
                        //userDB.Date_regis = DateTime.Now.ToString();
                        User.Type = input.type;
                        User.Phone = input.Phone;
                        db.Users.InsertOnSubmit(User);
                        db.SubmitChanges();

                        output.message = "success";

                    }
                 

                    return Json(output, JsonRequestBehavior.AllowGet);
                }


                
            }
        }
    }
}