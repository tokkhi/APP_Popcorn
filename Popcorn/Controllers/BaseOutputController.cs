using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Popcorn.Controllers
{
    public class BaseOutput
    {
        public string return_code;
        public string return_message;
        //public int total_page;
        //public int total_rows;
        //public string 

        public BaseOutput()
        {
            this.SetValue(ResultCode.InternalError);
        }


        public static class ResultCode
        {

            public const string Success = "0000";
            public const string ErrorParameter = "1001";
            public const string InvalidUserToken = "9001";
            public const string InvalidUserLogin = "9002";
            public const string DataNotFound = "9997";
            public const string JsonFormatError = "9998";
            public const string InternalError = "9999";
            public const string TokenExpired = "9900";

        }

        public void SetValue(string code)
        {
            this.return_code = code;
            this.return_message = this.GetDescription(code);
        }

        public void SetValue(string code, string moreText)
        {
            this.return_code = code;
            this.return_message = string.Format("{0} {1}", this.GetDescription(code), moreText);
        }

        public string GetDescription(string code)
        {
            switch (code)
            {
                case ResultCode.Success:
                    return "Success";
                case ResultCode.ErrorParameter:
                    return "Some required parameter is invalid";
                case ResultCode.InvalidUserToken:
                    return "Invalid user token";
                case ResultCode.InvalidUserLogin:
                    return "Invalid user login.";
                case ResultCode.JsonFormatError:
                    return "JSON format error";
                case ResultCode.InternalError:
                    return "Internal error";
                case ResultCode.DataNotFound:
                    return "Data not found";
                case ResultCode.TokenExpired:
                    return "Token Expired";

                default:
                    return code;
            }
        }
    }
}