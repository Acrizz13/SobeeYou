using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
                // Get the user's role
                int userRoleId = GetUserRoleId();

                // Direct user based on role
                if (userRoleId == 1)
                {
                    // Redirect to the customer account view
                    return RedirectToAction("CustomerAccount", "Account");
                }
                else if (userRoleId == 2)
                {
                    // Redirect to the admin view
                    return RedirectToAction("Admin", "Account");
                }
            }

            // If not logged in, show the login view
            return View();
        }

        // POST: Login
        public ActionResult Login(string email, string password)
        {
            UserModel userModel = null;
            string connectionString = ConfigurationManager.AppSettings["AppDBConnect"];
            string query = "SELECT intUserID, strFirstName, strLastName, strEmail, strPassword, intUserRoleID FROM TUsers WHERE strEmail = @Email AND strPassword = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userModel = new UserModel
                            {
                                // Assuming these are the properties of your UserModel
                                intUserID = (int)reader["intUserID"],
                                strFirstName = reader["strFirstName"].ToString(),
                                strLastName = reader["strLastName"].ToString(),
                                strEmail = reader["strEmail"].ToString(),
                                strPassword = reader["strPassword"].ToString(),
                                intUserRoleID = (int)reader["intUserRoleID"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, log them, etc.
                    ModelState.AddModelError("", "An error occurred while processing your request.");
                    return View("Index");
                }
            }

            if (userModel != null)
            {
                // User found, check their role
                if (userModel.intUserRoleID == 1)
                {
                    // Store userModel in TempData before redirecting
                    TempData["UserModel"] = userModel;
                    // Redirect to the customer account view
                    return RedirectToAction("CustomerAccount", "Account");
                }
                else if (userModel.intUserRoleID == 2)
                {
                    // Redirect to the admin view
                    return RedirectToAction("Admin", "Account");
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                // User not found or password does not match
                ModelState.AddModelError("", "Can't find an account with those credentials.");
                ViewBag.ErrorMessage = "Can't find an account with those credentials.";
                return View("Index");
            }
        }

        // GET: Customer Account View
        public ActionResult CustomerAccount()
        {
            var userModel = TempData["UserModel"] as UserModel;
            //do some SQL to get the user's orders, etc.

            return View(userModel);
        }

        // GET: ResetPassword
        public ActionResult ResetPassword(int userId)
        {
            // Retrieve the user model based on the userId
            UserModel userModel = GetUserById(userId);

            if (userModel != null)
            {
                // Store the user model in TempData
                TempData["UserModel"] = userModel;

                // Redirect to the CustomerAccount view
                return RedirectToAction("CustomerAccount", "Account");
            }
            else
            {
                // Handle the case when the user is not found
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: ForgotPassword
        public ActionResult ForgotPassword()
        {
            // Simply return the view for now
            return View();
        }
        private UserModel GetUserById(int userId)
        {
            UserModel userModel = null;
            string connectionString = ConfigurationManager.AppSettings["AppDBConnect"];
            string query = "SELECT intUserID, strFirstName, strLastName, strEmail, strPassword, intUserRoleID FROM TUsers WHERE intUserID = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userModel = new UserModel
                            {
                                intUserID = (int)reader["intUserID"],
                                strFirstName = reader["strFirstName"].ToString(),
                                strLastName = reader["strLastName"].ToString(),
                                strEmail = reader["strEmail"].ToString(),
                                strPassword = reader["strPassword"].ToString(),
                                intUserRoleID = (int)reader["intUserRoleID"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, log them, etc.
                    // You can add error handling or logging here
                }
            }

            return userModel;
        }
        // POST: ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            // Check if the email exists in the TUsers table
            UserModel userModel = GetUserByEmail(email);

            if (userModel != null)
            {
                // Generate a password reset link with the user ID
                string resetLink = Url.Action("ResetPassword", "Account", new { userId = userModel.intUserID }, Request.Url.Scheme);

                // Send the password reset email
                SendPasswordResetEmail(userModel.strEmail, resetLink);

                // Display a success message to the user
                ViewBag.SuccessMessage = "An email with password reset instructions has been sent to your email address.";
            }
            else
            {
                // Display an error message if the email doesn't exist
                ViewBag.ErrorMessage = "The provided email address does not exist in our records.";
            }

            return View();
        }

        private void SendPasswordResetEmail(string email, string resetLink)
        {
            // Implement your email sending logic here
            // You can use an email library like System.Net.Mail or a third-party email service

            // Example using System.Net.Mail:
            using (var mail = new System.Net.Mail.MailMessage())
            {
                mail.From = new System.Net.Mail.MailAddress("noreply@sobeeyou.com");
                mail.To.Add(email);
                mail.Subject = "Forgot Password - SoBee You!";
                mail.Body = "Here is the link you requested to reset your password and any other of your profile information:<br><br>";
                mail.Body += resetLink;
                mail.IsBodyHtml = true;

                using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
                {
                    //need to change this to the correct email and password when I get the correct email from the girls
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("sobeeyoutesting@gmail.com", "Soren1492");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        // GET: Register
        public ActionResult Register()
        {
            // Simply return the view for registering a new user
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                bool isRegistrationSuccessful = RegisterUser(model.strFirstName, model.strLastName, model.strEmail, model.strPassword);

                if (isRegistrationSuccessful)
                {
                    // Retrieve the registered user's details from the database
                    UserModel registeredUser = GetUserByEmail(model.strEmail);

                    if (registeredUser != null)
                    {
                        // Store the user model in TempData
                        TempData["UserModel"] = registeredUser;

                        // Redirect to the "CustomerAccount" action
                        return RedirectToAction("CustomerAccount", "Account");
                    }
                    else
                    {
                        // Handle the case when the registered user is not found in the database
                        ModelState.AddModelError("", "Unable to retrieve the registered user's details.");
                    }
                }
                else
                {
                    // Registration failed
                    ModelState.AddModelError("", "Registration failed. Please complete all fields.");
                }
            }

            // If we got this far, something failed, redisplay the form
            return View(model);
        }

        private UserModel GetUserByEmail(string email)
        {
            UserModel userModel = null;
            string connectionString = ConfigurationManager.AppSettings["AppDBConnect"];
            string query = "SELECT intUserID, strFirstName, strLastName, strEmail, strPassword, intUserRoleID FROM TUsers WHERE strEmail = @Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userModel = new UserModel
                            {
                                intUserID = (int)reader["intUserID"],
                                strFirstName = reader["strFirstName"].ToString(),
                                strLastName = reader["strLastName"].ToString(),
                                strEmail = reader["strEmail"].ToString(),
                                strPassword = reader["strPassword"].ToString(),
                                intUserRoleID = (int)reader["intUserRoleID"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, log them, etc.
                    // You can add error handling or logging here
                }
            }

            return userModel;
        }

        private bool RegisterUser(string firstName, string lastName, string email, string password)
        {
            string connectionString = ConfigurationManager.AppSettings["AppDBConnect"];
            string getMaxUserIDQuery = "SELECT MAX(intUserID) FROM TUsers";
            int newUserID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get the maximum existing user ID
                SqlCommand getMaxUserIDCmd = new SqlCommand(getMaxUserIDQuery, conn);
                object maxUserIDObj = getMaxUserIDCmd.ExecuteScalar();

                // Calculate the new user ID by adding 1 to the maximum existing user ID
                newUserID = maxUserIDObj != DBNull.Value ? (int)maxUserIDObj + 1 : 1;

                // Insert the new user
                string insertQuery = "INSERT INTO TUsers (intUserID, intUserRoleID, strFirstName, strLastName, strEmail, strPassword) " +
                                     "VALUES (@UserID, @UserRoleID, @FirstName, @LastName, @Email, @Password)";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@UserID", newUserID);
                cmd.Parameters.AddWithValue("@UserRoleID", 1); // Assuming new users are customers (role ID 1)
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email",email);
                cmd.Parameters.AddWithValue("@Password",password);
      

                cmd.ExecuteNonQuery();
            }
            // Implement your registration logic here
            // This could involve inserting the user's data into the database, sending a confirmation email, etc.

            // For simplicity, let's assume the registration is always successful
            return true;
        }

        private int GetUserRoleId()
        {
            // Get the user's role from the database or session
            UserModel userModel = TempData["UserModel"] as UserModel;

            if (userModel != null)
            {
                return userModel.intUserRoleID;
            }
         

            // Return a default role if the user's role cannot be determined
            return 1; // Or any other default value you prefer
        }

        [HttpPost]
        public ActionResult UpdateProfile(int userID, Dictionary<string, string> updatedData)
        {
            string connectionString = ConfigurationManager.AppSettings["AppDBConnect"];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Build the update query based on the updated fields
                string updateQuery = "UPDATE TUsers SET ";
                bool isFirstField = true;

                foreach (var field in updatedData)
                {
                    if (!isFirstField)
                    {
                        updateQuery += ", ";
                    }

                    updateQuery += $"{field.Key} = @{field.Key}";
                    isFirstField = false;
                }

                updateQuery += " WHERE intUserID = @UserID";

                SqlCommand cmd = new SqlCommand(updateQuery, conn);

                foreach (var field in updatedData)
                {
                    cmd.Parameters.AddWithValue($"@{field.Key}", field.Value);
                }

                cmd.Parameters.AddWithValue("@UserID", userID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Update successful
                    return Json(new { success = true });
                }
                else
                {
                    // Update failed
                    return Json(new { success = false, message = "Error updating user profile" });
                }
            }
        }
    }
}