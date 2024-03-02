using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            // Check if user is already logged in
            if (User.Identity.IsAuthenticated)
            {
                // Direct user based on role
                // Your role redirection logic here...
            }

            // If not logged in, show the login view
            return View();
        }

        // POST: Login
        [HttpPost]

        public ActionResult Login(string email, string password)
        {
            // Your authentication logic here...
            // If successful:
            // Redirect user based on role
            // If not successful:
            // Show error and return to login view
            return View();
        }
    }
}
