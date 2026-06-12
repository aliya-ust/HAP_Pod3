using System.Web.Mvc;
using HealthCare.Web;

namespace HealthCare.Web
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalExceptionFilterAttribute());
        }
    }
}
