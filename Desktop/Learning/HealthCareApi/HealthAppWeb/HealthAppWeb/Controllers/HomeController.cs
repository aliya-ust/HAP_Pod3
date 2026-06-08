using System;
using System.Web.Mvc;

namespace HealthAppWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("List", "Patient");

            if (User.IsInRole("Doctor"))
                return RedirectToAction("Schedule", "Appointment");

            if (User.IsInRole("Patient"))
                return RedirectToAction("Book", "Appointment");

            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult LoginAs(string role)
        {
            string email;
            string fullName;
            int userId;

            switch (role)
            {
                case "Admin":
                    email = "admin@hospital.com";
                    fullName = "Admin User";
                    userId = 1;
                    break;

                case "Doctor":
                    email = "doctor@hospital.com";
                    fullName = "Dr. Smith";
                    userId = 2;
                    break;

                case "Patient":
                    email = "patient@hospital.com";
                    fullName = "John Doe";
                    userId = 3;
                    break;

                default:
                    return HttpNotFound();
            }

            string userData = role + "|" + fullName + "|" + userId;

            var ticket = new System.Web.Security.FormsAuthenticationTicket(
                1,
                email,
                DateTime.Now,
                DateTime.Now.AddHours(8),
                false,
                userData
            );

            string encrypted = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new System.Web.HttpCookie(
                System.Web.Security.FormsAuthentication.FormsCookieName, encrypted
            ));

            return RedirectToAction("Index", "Home");
        }
    }
}