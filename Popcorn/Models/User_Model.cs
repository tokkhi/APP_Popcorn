using Popcorn.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Popcorn.Models
{
    public class User_Model
    {
        public class Login_input
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public Boolean active { get; set; }

        }
        public class regis_input
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string type { get; set; }
            public string Phone { get; set; }
            public Boolean active { get; set; }
        }
        public class Output_Login : BaseOutput
        {
            public string message { get; set; }
            public string Name { get; set; }
            public Boolean error { get; set; }
            public Boolean active { get; set; }
           

        }
        public class Output_Regis : BaseOutput
        {
            public string message { get; set; }
            public Boolean error { get; set; }
            
        }
        public class Detail
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
           
        }

        //public class status
        //{
        //    public string Sta_Regis { get; set; }

        //}
    }
}