using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class AccountController : Controller {
        // GET: Login
        public ActionResult Index() {
            // Check if user is already logged in
            if (User.Identity.IsAuthenticated) {
                // Get the user's role
                int userRoleId = GetUserRoleId();

                // Direct user based on role
                if (userRoleId == 1) {
                    // Redirect to the customer account view
                    return RedirectToAction("CustomerAccount", "Account");
                }
                else if (userRoleId == 2) {
                    // Redirect to the admin view
                    return RedirectToAction("Admin", "Account");
                }
            }

            // If not logged in, show the login view
            return View();
        }

        // POST: Login
        public ActionResult Login(string email, string password) {
            using (var context = new TableModels()) {
                var TUser = context.TUsers
                    .FirstOrDefault(u => u.strEmail == email && u.strPassword == password);

                if (TUser != null) {
                    // User found, check their role
                    if (TUser.intUserRoleID == 1) {
                        // Store userModel in TempData before redirecting
                        TempData["TUser"] = TUser;
                        // Redirect to the customer account view
                        return RedirectToAction("CustomerAccount", "Account");
                    }
                    else if (TUser.intUserRoleID == 2) {
                        // Redirect to the admin view
                        return RedirectToAction("Admin", "Account");
                    }
                }
                else {
                    // User not found or password does not match
                    ModelState.AddModelError("", "Can't find an account with those credentials.");
                    ViewBag.ErrorMessage = "Can't find an account with those credentials.";
                }
            }

            return View("Index");
        }

        // GET: Customer Account View
        public ActionResult CustomerAccount() {
            var userModel = TempData["TUser"] as TUser;
            //do some SQL to get the user's orders, etc.

            return View(userModel);
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
                // SendPasswordResetEmail(userModel.strEmail, resetLink);
                newEmailThing(userModel.strEmail, resetLink);

                // Display a success message to the user
                ViewBag.SuccessMessage = "An email with password reset instructions has been sent to your email address.";
            }
            else {
                // Display an error message if the email doesn't exist
                ViewBag.ErrorMessage = "The provided email address does not exist in our records.";
            }

            return View();
        }

        // Forgot password link sender 
        private void newEmailThing(string userEmail, string resetLink) {
            string workEmail = "eyassu.million@gmail.com"; // replace with sobee email
            string fromPassword = "nkum abbn kcyz cvxs"; // replace with sobee app password

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(workEmail, fromPassword);

            // Create the password reset email
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(workEmail);
            mailMessage.To.Add(userEmail);
            mailMessage.Subject = "Forgot Password - SoBee You!";
            mailMessage.Body = "Here is the link you requested to reset your password and any other of your profile information:<br><br>";

            // Send the email
            smtpClient.Send(mailMessage);

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






    }
}