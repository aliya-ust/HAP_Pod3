using HealthAppWeb;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace HealthAppWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Runs on every request — rebuilds the role principal from the
        // FormsAuth ticket so User.IsInRole() works throughout the app
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return;

            FormsAuthenticationTicket ticket;
            try
            {
                ticket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch
            {
                return;
            }

            if (ticket == null || ticket.Expired)
                return;

            // userData format: "Role|FullName|UserId"
            string[] parts = ticket.UserData.Split('|');
            if (parts.Length != 3)
                return;

            string role = parts[0];

            var identity = new FormsIdentity(ticket);
            var principal = new GenericPrincipal(identity, new[] { role });

            Context.User = principal;
        }
    }
}