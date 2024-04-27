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
using SobeeYou.Classes;

namespace SobeeYou.Controllers {
    public class AccountController : Controller {
        // GET: Login
        public ActionResult Index() {
            if (Session["UserID"] != null && Session["UserRoleID"] != null) {
                // Check user role and redirect accordingly
                int userRoleId = (int)Session["UserRoleID"];

                if (userRoleId == 1) {
                    return RedirectToAction("CustomerAccount", "Account");
                }
                else if (userRoleId == 2) {
                    //need to create AdminDashBoard model where we get all necessary info for admin dashboard
                    //get all orders, users, products, etc from method in TableModels named GetAdminDashBoardInfo
                    return RedirectToAction("AdminDashBoard", "Account");
                }
            }
            // If no session exists, or role is not recognized, show the login view
            return View();
        }


        public ActionResult AdminDashBoard() {
            var adminDashBoard = GetAdminDashBoardInfo();
            return View(adminDashBoard);
        }
        public AdminDashboardViewModel GetAdminDashBoardInfo()
        {
            var websiteTraffic = new List<WebsiteTrafficData>
    {
        new WebsiteTrafficData { Month = "January", Visitors = 5000 },
        new WebsiteTrafficData { Month = "February", Visitors = 6200 },
        new WebsiteTrafficData { Month = "March", Visitors = 7500 },
        new WebsiteTrafficData { Month = "April", Visitors = 8100 },
        new WebsiteTrafficData { Month = "May", Visitors = 9300 },
        new WebsiteTrafficData { Month = "June", Visitors = 10500 },
        new WebsiteTrafficData { Month = "July", Visitors = 11200 },
        new WebsiteTrafficData { Month = "August", Visitors = 10800 },
        new WebsiteTrafficData { Month = "September", Visitors = 9800 },
        new WebsiteTrafficData { Month = "October", Visitors = 8900 },
        new WebsiteTrafficData { Month = "November", Visitors = 7800 },
        new WebsiteTrafficData { Month = "December", Visitors = 9200 }
    };

            using (var context = new TableModels())
            {
                var lowInventoryProductsCount = context.TProducts
                    .AsEnumerable()
                    .Count(p => Convert.ToInt64(p.strStockAmount) < 10);

                var reviews = context.TReviews.AsEnumerable();
                var avgProductRating = reviews.Any() ? reviews.Average(r => Convert.ToDecimal(r.strRating)) : 0;



                var thirtyDaysAgo = DateTime.Now.AddDays(-30);
                var lastWeek = DateTime.Today.AddDays(-7);
                var lastMonth = DateTime.Today.AddMonths(-1);

                var totalSales = context.TOrderItems
                    .GroupBy(oi => oi.TProduct.strName)
                    .Select(g => new ProductSalesData
                    {
                        ProductName = g.Key,
                        TotalSales = g.Sum(oi => oi.intQuantity * oi.monPricePerUnit)
                    })
                    .ToList();

                var lastWeekSales = context.TOrderItems
                    .Where(oi => oi.TOrder.dtmOrderDate >= lastWeek)
                    .GroupBy(oi => oi.TProduct.strName)
                    .Select(g => new ProductSalesData
                    {
                        ProductName = g.Key,
                        TotalSales = g.Sum(oi => oi.intQuantity * oi.monPricePerUnit)
                    })
                    .ToList();

                var lastMonthSales = context.TOrderItems
                    .Where(oi => oi.TOrder.dtmOrderDate >= lastMonth)
                    .GroupBy(oi => oi.TProduct.strName)
                    .Select(g => new ProductSalesData
                    {
                        ProductName = g.Key,
                        TotalSales = g.Sum(oi => oi.intQuantity * oi.monPricePerUnit)
                    })
                    .ToList();


                var adminDashBoard = new AdminDashboardViewModel
                {
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
                    RecentSupportRequests = context.TCustomerServiceTickets.Count(t => t.dtmTimeOfSubmission >= thirtyDaysAgo),                 
                    WebsiteTraffic = websiteTraffic,
                    TotalSales = totalSales,
                    LastWeekSales = lastWeekSales,
                    LastMonthSales = lastMonthSales
                };

                return adminDashBoard;
            }
        }
    



        public ActionResult Login(string email, string password) {
            using (var context = new TableModels()) {
                var TUser = context.TUsers.FirstOrDefault(u => u.strEmail == email && u.strPassword == password);

                if (TUser != null) {
                    // Store TUser details in Session to keep them available across the user's session
                    Session["UserID"] = TUser.intUserID;
                    Session["UserRoleID"] = TUser.intUserRoleID;

                    // Redirect to the appropriate view based on role
                    if (TUser.intUserRoleID == 1) {
                        return RedirectToAction("CustomerAccount", "Account");
                    }
                    else if (TUser.intUserRoleID == 2) {
                        return RedirectToAction("AdminDashBoard", "Account");
                    }
                }
                else {
                    ModelState.AddModelError("", "Can't find an account with those credentials.");
                    ViewBag.ErrorMessage = "Can't find an account with those credentials.";
                }
            }

            // If user not found, or if no role matches, redirect back to the login page (or return an appropriate view).
            return View("Index");
        }


        public ActionResult CustomerAccount() {
            if (Session["UserID"] != null && Session["UserRoleID"] != null) {
                int userId = (int)Session["UserID"];
                int userRoleId = (int)Session["UserRoleID"];

                if (userRoleId == 1) {
                    using (var context = new TableModels()) {
                        // Retrieve the user from the database, including their orders
                        var user = context.TUsers.Include("TOrders").FirstOrDefault(u => u.intUserID == userId);

                        if (user != null) {
                            // Pass the user model to the view
                            return View(user);
                        }
                    }
                }
            }

            // If the user is not logged in or the user is not found, redirect to the login page
            return RedirectToAction("Index", "Account");
        }


        //// GET: ResetPassword
        //public ActionResult ResetPassword(int userId) {
        //    // Retrieve the user model based on the userId
        //    TUser userModel = GetUserById(userId);

        //    if (userModel != null) {
        //        // Store the user model in TempData
        //        TempData["TUser"] = userModel;

        //        // Redirect to the CustomerAccount view
        //        return RedirectToAction("CustomerAccount", "Account");
        //    }
        //    else {
        //        // Handle the case when the user is not found
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

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

    

        // Forgot password link sender 
        private void newEmailThing(string userEmail, string verificationcode) {
            string workEmail = "sobeeyoubusiness@gmail.com";
            string fromPassword = "yplu kfwq wufa jpjp";



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
            mailMessage.Body = "Here is the code requested to reset your password: " + verificationcode;

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

        private TUser GetUserByEmail(string email)
        {
            try
            {
                using (var context = new TableModels())
                {
                    return context.TUsers.FirstOrDefault(u => u.strEmail == email);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // Example: Log.Error("Error retrieving user by email", ex);
                return null;
            }
        }

        private bool RegisterUser(string firstName, string lastName, string email, string password) {
            using (var context = new TableModels()) {
                var maxUserID = context.TUsers.Max(u => u.intUserID);
                var newUserID = maxUserID + 1;

                var currentDateTime = DateTime.Now;

                var newUser = new TUser {
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
        public ActionResult Logout() {
            Session.Clear();  // Clears all session data
            return RedirectToAction("Index", "Home");  // Redirect to home or login page
        }
        [HttpPost]
        public ActionResult SendDiscountEmail() {
            using (var context = new TableModels()) {
                DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);
                var inactiveUsers = context.TUsers
                    .Where(u => u.strLastLoginDate < thirtyDaysAgo)
                    .ToList();

                string workEmail = "eyassu.million@gmail.com"; // replace with sobee email
                string fromPassword = "nkum abbn kcyz cvxs"; // replace with sobee app password

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(workEmail, fromPassword);

                foreach (var user in inactiveUsers) {
                    // Create the discount email
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(workEmail);
                    mailMessage.To.Add(user.strEmail);
                    mailMessage.Subject = "We Miss You! Here's a Special Discount";
                    mailMessage.Body = "Dear " + user.strFirstName + ",<br><br>" +
                                      "We miss you! As a special offer, we're giving you a discount on your next purchase. " +
                                      "Use the code COMEBACK10 to get 10% off.<br><br>" +
                                      "Best regards,<br>The SoBee You Team";
                    mailMessage.IsBodyHtml = true;

                    try {
                        // Send the email
                        smtpClient.Send(mailMessage);
                    }
                    catch (Exception ex) {
                        // Handle any exceptions that occur during email sending
                        // You can log the error or take appropriate action
                        // For example:
                        // Log.Error("Error sending discount email to user " + user.strEmail, ex);
                    }
                }
            }

            return RedirectToAction("AdminDashboard");
        }
        // ...

       

        private string GenerateVerificationCode()
        {
            // Generate a random verification code
            return new Random().Next(100000, 999999).ToString();
        }

     

   

        //public ActionResult ResetPassword(string email)
        //{
        //    // Pass the email to the view
        //    ViewBag.Email = email;
        //    return View();
        //}

   
        private void UpdateUser(TUser user)
        {
            using (var context = new TableModels())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        // ...



        // POST: ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            // Check if the email exists in the TUsers table
            TUser userModel = GetUserByEmail(email);

            if (userModel != null)
            {
                // Generate a verification code
                string verificationCode = GenerateVerificationCode();

                // Store the verification code in the session
                Session["VerificationCode"] = verificationCode;
                Session["UserEmail"] = userModel.strEmail;

                // Send the verification code email
                newEmailThing(userModel.strEmail, verificationCode);

                // Redirect to the code verification view
                return RedirectToAction("VerifyCode");
            }
            else
            {
                // Display an error message if the email doesn't exist
                ViewBag.ErrorMessage = "The provided email address does not exist in our records.";
            }

            return View();
        }

        public ActionResult VerifyCode()
        {
            // Pass the email to the view
            ViewBag.Email = Session["UserEmail"] as string;
            return View();
        }

        [HttpPost]
        public ActionResult VerifyCode(string code)
        {
            string storedCode = Session["VerificationCode"] as string;
            string userEmail = Session["UserEmail"] as string;

            if (code == storedCode)
            {
                // Redirect to the reset password view
                return RedirectToAction("ResetPassword");
            }
            else
            {
                // Display an error message if the code doesn't match
                ViewBag.ErrorMessage = "Invalid verification code.";
            }

            ViewBag.Email = userEmail;
            return View();
        }

        public ActionResult ResetPassword()
        {
            // Pass the email to the view
            ViewBag.Email = Session["UserEmail"] as string;
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string password, string confirmPassword)
        {
            string userEmail = Session["UserEmail"] as string;

            if (password == confirmPassword)
            {
                // Retrieve the user model based on the email
                TUser userModel = GetUserByEmail(userEmail);

                if (userModel != null)
                {
                    // Update the user's password
                    userModel.strPassword = password;
                    UpdateUser(userModel);

                    // Clear the session variables
                    Session.Remove("VerificationCode");
                    Session.Remove("UserEmail");

                    // Redirect to the account page
                    return RedirectToAction("Index", "Account");
                }
            }
            else
            {
                // Display an error message if the passwords don't match
                ViewBag.ErrorMessage = "Passwords do not match.";
            }

            ViewBag.Email = userEmail;
            return View();
        }


    }
}