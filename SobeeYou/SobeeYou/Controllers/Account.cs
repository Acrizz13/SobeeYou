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
                    //need to create AdminDashBoard model where we get all necessary info for admin dashboard
                    //get all orders, users, products, etc from method in TableModels named GetAdminDashBoardInfo
                    return RedirectToAction("AdminDashBoard", "Account");
                }
            }
            // If no session exists, or role is not recognized, show the login view
            return View();
        }


        public ActionResult AdminDashBoard()
        {
            var adminDashBoard = GetAdminDashBoardInfo();
            return View(adminDashBoard);
        }
        public AdminDashboardViewModel GetAdminDashBoardInfo()
        {
            using (var context = new TableModels())
            {
                //I should probably just make these columns integers rather than strings in the database
                // Load the product stock amounts into memory (consider efficiency here!)
                var lowInventoryProductsCount = context.TProducts
                    .AsEnumerable() // This will execute the query and bring the results into memory
                    .Count(p => Convert.ToInt64(p.strStockAmount) < 10);
                // Calculate average product rating in-memory
                var reviews = context.TReviews.AsEnumerable();
                var avgProductRating = reviews.Any() ? reviews.Average(r => Convert.ToDecimal(r.strRating)) : 0;

                var thirtyDaysAgo = DateTime.Now.AddDays(-30);

                var adminDashBoard = new AdminDashboardViewModel
                {
                    //need to make total customers coincide with orders where there is a unique customer id
                    //need to make totalusers coincide with total customer accounts
                    TotalCustomers = context.TUsers.Count(u => u.intUserRoleID != 2),
                    NewCustomers = context.TUsers.Count(u => u.strDateCreated >= thirtyDaysAgo && u.intUserRoleID != 2),
                    ActiveCustomers = context.TUsers.Count(u => u.strLastLoginDate >= thirtyDaysAgo && u.intUserRoleID != 2),
                    TotalUsers = context.TUsers.Count(u => u.intUserRoleID == 2),
                    TotalOrders = context.TOrders.Count(u => u.strOrderStatus == "Pending"),
                    RecentRevenue = context.TOrders.Where(o => o.dtmOrderDate >= thirtyDaysAgo).Sum(o => o.decTotalAmount),
                    TotalProducts = context.TProducts.Count(),
                    LowInventoryProducts = lowInventoryProductsCount,
                    AvgProductRating = avgProductRating,
                    AdminUsers = context.TUsers.Count(u => u.intUserRoleID == 2),
                    RecentSupportRequests = context.TCustomerServiceTickets.Count(t => t.dtmTimeOfSubmission >= thirtyDaysAgo)
                };

                return adminDashBoard;
            }
        }



        public ActionResult Login(string email, string password)
        {
            using (var context = new TableModels())
            {
                var TUser = context.TUsers.FirstOrDefault(u => u.strEmail == email && u.strPassword == password);

                if (TUser != null)
                {
                    // Store TUser details in Session to keep them available across the user's session
                    Session["UserID"] = TUser.intUserID;
                    Session["UserRoleID"] = TUser.intUserRoleID;

                    // Redirect to the appropriate view based on role
                    if (TUser.intUserRoleID == 1)
                    {
                        return RedirectToAction("CustomerAccount", "Account");
                    }
                    else if (TUser.intUserRoleID == 2)
                    {
                        return RedirectToAction("AdminDashBoard", "Account");
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
            if (Session["UserID"] != null && Session["UserRoleID"] != null)
            {
                int userId = (int)Session["UserID"];
                int userRoleId = (int)Session["UserRoleID"];

                if (userRoleId == 1)
                {
                    using (var context = new TableModels())
                    {
                        // Retrieve the user from the database, including their orders
                        var user = context.TUsers.Include("TOrders").FirstOrDefault(u => u.intUserID == userId);

                        if (user != null)
                        {
                            // Pass the user model to the view
                            return View(user);
                        }
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

        private bool RegisterUser(string firstName, string lastName, string email, string password)
        {
            using (var context = new TableModels())
            {
                var maxUserID = context.TUsers.Max(u => u.intUserID);
                var newUserID = maxUserID + 1;

                var currentDateTime = DateTime.Now;

                var newUser = new TUser
                {
                    intUserID = newUserID,
                    intUserRoleID = 1,
                    strFirstName = firstName,
                    strLastName = lastName,
                    strEmail = email,
                    strPassword = password,
                    strLastLoginDate = currentDateTime,
                    strDateCreated = currentDateTime
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