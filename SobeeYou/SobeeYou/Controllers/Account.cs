using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class AccountController : Controller {
        // GET: Login
        public ActionResult Index() {
            // Check if user is already logged in
            if (User.Identity.IsAuthenticated) {
                // Direct user based on role
                // Your role redirection logic here...
            }

            // If not logged in, show the login view
            return View();
        }

        // POST: Login
        public ActionResult Login(string email, string password) {
            TUser userModel = null;

            string connectionString = ConfigurationManager.AppSettings["AppDBConnect"];
            string query = "SELECT intUserID, strFirstName, strLastName, strEmail, strPassword, intUserRoleID FROM TUsers WHERE strEmail = @Email AND strPassword = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                try {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            userModel = new TUser();
                            {
                                // Assuming these are the properties of your UserModel
                                userModel.intUserID = (int)reader["intUserID"];
                                userModel.strFirstName = reader["strFirstName"].ToString();
                                userModel.strLastName = reader["strLastName"].ToString();
                                userModel.strEmail = reader["strEmail"].ToString();
                                userModel.strPassword = reader["strPassword"].ToString();
                                userModel.intUserRoleID = (int)reader["intUserRoleID"];
                            };
                        }
                    }
                }
                catch (Exception ex) {
                    // Handle any exceptions, log them, etc.
                    ModelState.AddModelError("", "An error occurred while processing your request.");
                    return View();
                }
            }

            if (userModel != null) {
                // User found, check their role
                if (userModel.intUserRoleID == 1) {  // Store userModel in TempData before redirecting
                    TempData["UserModel"] = userModel;
                    // Redirect to the customer account view
                    return RedirectToAction("CustomerAccount", "Account");
                }
                else if (userModel.intUserRoleID == 2) {
                    // Redirect to the admin view
                    return RedirectToAction("Admin", "Account");
                }
                else {
                    return View();
                }
            }
            else {
                // User not found or password does not match
                ModelState.AddModelError("", "Can't find an account with those credentials.");
                return View();
            }
        }

        // GET: Customer Account View
        public ActionResult CustomerAccount() {
            var userModel = TempData["UserModel"] as TUser;
            //do some SQL to get the user's orders, etc.


            return View(userModel);
        }


        // GET: ForgotPassword
        public ActionResult ForgotPassword() {
            // Simply return the view for now
            return View();
        }

        // GET: Register
        public ActionResult Register() {
            // Simply return the view for registering a new user
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Protect against CSRF attacks
        public ActionResult Register(TableModels usermdl) {
            if (ModelState.IsValid) {
                // Your code to handle registration, like adding the user to the database
            }

            // If we got this far, something failed, redisplay form
            return View(usermdl);
        }
    }
}
