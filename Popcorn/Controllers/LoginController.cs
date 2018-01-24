using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Popcorn.Models;
using System.Configuration;

namespace Popcorn.Controllers
{
    public class LoginController : Controller
    {

        [HttpPost]
        public JsonResult Index(User_Model.Login_input input)
        {
            User_Model.Output_Login output = new User_Model.Output_Login();


            using (DataClass.DataClasses1DataContext db = new DataClass.DataClasses1DataContext(ConfigurationManager.AppSettings["dbConnPopcorn"]))
            {
                if (ModelState.IsValid)
                {
                    //TODO: SubscribeUser(model.Email);

                
                }

                var result = db.Users.FirstOrDefault(x => x.Email == input.Email && x.Password == input.Password);
                //var status = result.status.ToString();
                if (result != null)
                {
                    output.Name = result.Name;
                    output.message = "Login Successfully";
                    output.active = true;
                    output.error = false;
                    output.SetValue(BaseOutput.ResultCode.Success);
                   
                }
                else
                {
                    output.error = true;

                    output.message = "Login fail";


                }
                    return Json(output, JsonRequestBehavior.AllowGet);

                }

            }

        }

    }
