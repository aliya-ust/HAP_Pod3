using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string ErrorField { get; set; }
        public string ErrorMessage { get; set; }

        public static ServiceResult Ok()
        {
            return new ServiceResult { Success = true };
        }

        public static ServiceResult Fail(string field, string message)
        {
            return new ServiceResult
            {
                Success = false,
                ErrorField = field,
                ErrorMessage = message
            };
        }
    }
}