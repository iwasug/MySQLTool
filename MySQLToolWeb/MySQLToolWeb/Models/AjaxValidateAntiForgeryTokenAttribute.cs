/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MySQLToolWeb.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest()) // if it is ajax request.
                {
                    this.ValidateRequestHeader(filterContext.HttpContext.Request); // run the validation.
                }
                else
                {
                    AntiForgery.Validate();
                }
            }
            catch (HttpAntiForgeryException)
            {
                throw new HttpAntiForgeryException("Anti forgery token not found");
            }
        }

        private void ValidateRequestHeader(HttpRequestBase request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;
            string tokenValue = request.Headers["VerificationToken"]; // read the header key and validate the tokens.
            if (!string.IsNullOrEmpty(tokenValue))
            {
                string[] tokens = tokenValue.Split(',');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }

            AntiForgery.Validate(cookieToken, formToken); // this validates the request token.
        }
    }
}