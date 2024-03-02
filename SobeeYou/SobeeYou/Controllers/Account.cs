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
        // Enhanced to handle already logged-in users and direct them based on their role.
        public ActionResult Index()
        {
            // Check if user is already logged in
            if (User.Identity.IsAuthenticated)
            {
                // Assuming you have a method to get the user's role ID based on their identity
                // int userRoleId = GetUserRole(User.Identity.Name);

                // Use the same role ID definitions as before
                const int AdminRoleId = 1; // Example role ID for Admin
                const int CustomerRoleId = 2; // Example role ID for Customer

                // Direct the user based on their role
                /*
                if (userRoleId == AdminRoleId)
                {
                    // Redirect to Admin view if the user is an admin
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                else if (userRoleId == CustomerRoleId)
                {
                    // Redirect to Customer profile view if the user is a customer
                    return RedirectToAction("CustomerProfile", "Account");
                }
                // Optionally, handle other roles or lack thereof
                */
            }

            // If not logged in, or if the user role is not handled above, show the login view
            return View();
        }

        // Implement or reference your authentication and user role management logic here
        // This includes methods to authenticate users, check if they are authenticated, and retrieve their roles
    }
}
