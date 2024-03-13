using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class AccountController : Controller {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["UserRoleID"] != null)
            {
                // Check user role and redirect accordingly
                int userRoleId = (int)Session["UserRoleID"];
                if (userRoleId == 1)
                {
                    return RedirectToAction("CustomerAccount", "Account");
                }
                else if (userRoleId == 2)
                {
                    return RedirectToAction("AdminDashBoard", "Account");
                }
            }
            // If no session exists, or role is not recognized, show the login view
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            using (var context = new TableModels())
            {
                var TUser = context.TUsers.FirstOrDefault(u => u.strEmail == email && u.strPassword == password);

                if (TUser != null)
                {
                    // Store TUser details in Session to keep them available across the user's session
                    Session["TUser"] = TUser;
                    Session["UserID"] = TUser.intUserID;
                    Session["UserRoleID"] = TUser.intUserRoleID;

                    // Redirect to the appropriate view based on role
                    if (TUser.intUserRoleID == 1)
                    {
                        return RedirectToAction("CustomerAccount", "Account");
                    }
                    else if (TUser.intUserRoleID == 2)
                    {
                        return RedirectToAction("Admin", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Can't find an account with those credentials.");
                    ViewBag.ErrorMessage = "Can't find an account with those credentials.";
                }
            }
            // If user not found, or if no role matches, redirect back to the login page (or return an appropriate view).
            return View("Index");
        }


        public ActionResult CustomerAccount()
        {
            var TUser = Session["TUser"] as TUser;

            if (TUser != null)
            {
                using (var context = new TableModels())
                {
                    // Retrieve the user from the database, including their orders
                    var user = context.TUsers.Include("TOrders").FirstOrDefault(u => u.intUserID == TUser.intUserID);

                    if (user != null)
                    {
                        // Pass the user model to the view
                        return View(user);
                    }
                }
            }

            // If the user is not logged in or the user is not found, redirect to the login page
            return RedirectToAction("Index", "Account");
        }



        // GET: ResetPassword
        public ActionResult ResetPassword(int userId) {
            // Retrieve the user model based on the userId
            TUser userModel = GetUserById(userId);

            if (userModel != null) {
                // Store the user model in TempData
                TempData["TUser"] = userModel;

                // Redirect to the CustomerAccount view
                return RedirectToAction("CustomerAccount", "Account");
            }
            else {
                // Handle the case when the user is not found
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: ForgotPassword
        public ActionResult ForgotPassword() {
            // Simply return the view for now
            return View();
        }
        private TUser GetUserById(int userId) {
            using (var context = new TableModels()) {
                return context.TUsers
                    .FirstOrDefault(u => u.intUserID == userId);
            }
        }

        // POST: ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(string email) {
            // Check if the email exists in the TUsers table
            TUser userModel = GetUserByEmail(email);

            if (userModel != null) {
                // Generate a password reset link with the user ID
                string resetLink = Url.Action("ResetPassword", "Account", new { userId = userModel.intUserID }, Request.Url.Scheme);

                // Send the password reset email
                SendPasswordResetEmail(userModel.strEmail, resetLink);

                // Display a success message to the user
                ViewBag.SuccessMessage = "An email with password reset instructions has been sent to your email address.";
            }
            else {
                // Display an error message if the email doesn't exist
                ViewBag.ErrorMessage = "The provided email address does not exist in our records.";
            }

            return View();
        }

        private void SendPasswordResetEmail(string email, string resetLink) {
            // Implement your email sending logic here
            // You can use an email library like System.Net.Mail or a third-party email service

            // Example using System.Net.Mail:
            using (var mail = new System.Net.Mail.MailMessage()) {
                mail.From = new System.Net.Mail.MailAddress("noreply@sobeeyou.com");
                mail.To.Add(email);
                mail.Subject = "Forgot Password - SoBee You!";
                mail.Body = "Here is the link you requested to reset your password and any other of your profile information:<br><br>";
                mail.Body += resetLink;
                mail.IsBodyHtml = true;

                using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com")) {
                    //need to change this to the correct email and password when I get the correct email from the girls
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("sobeeyoutesting@gmail.com", "Soren1492");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        // GET: Register
        public ActionResult Register() {
            // Simply return the view for registering a new user
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TUser model) {
            if (ModelState.IsValid) {
                bool isRegistrationSuccessful = RegisterUser(model.strFirstName, model.strLastName, model.strEmail, model.strPassword);

                if (isRegistrationSuccessful) {
                    // Retrieve the registered user's details from the database
                    TUser registeredUser = GetUserByEmail(model.strEmail);

                    if (registeredUser != null) {
                        // Store the user model in TempData
                        TempData["TUser"] = registeredUser;

                        // Redirect to the "CustomerAccount" action
                        return RedirectToAction("CustomerAccount", "Account");
                    }
                    else {
                        // Handle the case when the registered user is not found in the database
                        ModelState.AddModelError("", "Unable to retrieve the registered user's details.");
                    }
                }
                else {
                    // Registration failed
                    ModelState.AddModelError("", "Registration failed. Please complete all fields.");
                }
            }

            // If we got this far, something failed, redisplay the form
            return View(model);
        }

        private TUser GetUserByEmail(string email) {
            using (var context = new TableModels()) {
                return context.TUsers
                    .FirstOrDefault(u => u.strEmail == email);
            }
        }

        private bool RegisterUser(string firstName, string lastName, string email, string password) {
            using (var context = new TableModels()) {
                var maxUserID = context.TUsers.Max(u => u.intUserID);
                var newUserID = maxUserID + 1;

                var newUser = new TUser {
                    intUserID = newUserID,
                    intUserRoleID = 1,
                    strFirstName = firstName,
                    strLastName = lastName,
                    strEmail = email,
                    strPassword = password
                };

                context.TUsers.Add(newUser);
                context.SaveChanges();
            }

            return true;
        }

        private int GetUserRoleId() {
            // Get the user's role from the database or session
            TUser userModel = TempData["TUser"] as TUser;

            if (userModel != null) {
                return userModel.intUserRoleID;
            }


            // Return a default role if the user's role cannot be determined
            return 1; // Or any other default value you prefer
        }

        [HttpPost]
        public ActionResult UpdateProfile(int userID, Dictionary<string, string> updatedData) {
            using (var context = new TableModels()) {
                var user = context.TUsers.FirstOrDefault(u => u.intUserID == userID);

                if (user != null) {
                    foreach (var field in updatedData) {
                        var property = typeof(TUser).GetProperty(field.Key);
                        if (property != null && property.CanWrite) {
                            property.SetValue(user, field.Value);
                        }
                    }

                    context.SaveChanges();

                    return Json(new { success = true });
                }
                else {
                    return Json(new { success = false, message = "User not found" });
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();  // Clears all session data
            return RedirectToAction("Index", "Home");  // Redirect to home or login page
        }








    }
}