using System;
using System.Net;
using System.Web.Mvc;

namespace HealthCare.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class GlobalExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            var exception = filterContext.Exception;

            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Something went wrong.";

            // Custom handling
            if (exception.Message.Contains("not found"))
            {
                statusCode = (int)HttpStatusCode.NotFound;
                message = "The requested resource was not found.";
            }
            else if (exception.Message.Contains("already booked"))
            {
                message = exception.Message;
            }

            filterContext.Result = new ViewResult
            {
                ViewName = statusCode == 404 ? "NotFound" : "Error",
                ViewData = new ViewDataDictionary
                {
                    { "ErrorMessage", message }
                }
            };

            filterContext.HttpContext.Response.StatusCode = statusCode;
            filterContext.ExceptionHandled = true;
        }
    }
}