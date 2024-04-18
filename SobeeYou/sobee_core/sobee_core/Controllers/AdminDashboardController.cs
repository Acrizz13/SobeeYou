using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sobee_core.Data;
using sobee_core.Models.AzureModels;
using sobee_core.Models;
using System.Net.Mail;
using System.Net;

namespace sobee_core.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller {
        private readonly SobeecoredbContext _context;
        private readonly ApplicationDbContext _identityContext;

        public AdminDashboardController(SobeecoredbContext context, ApplicationDbContext identityContext) {
            _context = context;
            _identityContext = identityContext;
        }

        // Action method to display the admin dashboard
        public IActionResult Index() {
            var adminDashBoard = GetAdminDashBoardInfo();
            return View(adminDashBoard);
        }

        // Private method to retrieve admin dashboard information
        private AdminDashboardViewModel GetAdminDashBoardInfo() {
            // Calculate the date 30 days ago
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            // Get the user IDs of admin users
            var adminUserIds = _identityContext.UserRoles
                .Where(ur => ur.RoleId == _identityContext.Roles.FirstOrDefault(r => r.Name == "Admin").Id)
                .Select(ur => ur.UserId)
                .ToList();

            // Count the totals of all fields 
            var adminDashBoard = new AdminDashboardViewModel {

                TotalCustomers = _identityContext.Users.Count(u => !adminUserIds.Contains(u.Id)),
                //  NewCustomers = _identityContext.Users.Count(u => u.CreatedDate >= thirtyDaysAgo && !adminUserIds.Contains(u.Id)),
                // ActiveCustomers = _identityContext.Users.Count(u => u.LastLoginDate >= thirtyDaysAgo && !adminUserIds.Contains(u.Id)),
                TotalUsers = _identityContext.Users.Count(u => adminUserIds.Contains(u.Id)),
                TotalOrders = _context.Torders.Count(o => o.IntShippingStatusId == 1), // Assuming 1 represents "Pending"
                RecentRevenue = (decimal)_context.Torders.Where(o => o.DtmOrderDate >= thirtyDaysAgo).Sum(o => o.DecTotalAmount),
                TotalProducts = _context.Tproducts.Count(),
                LowInventoryProducts = _context.Tproducts.Count(p => Convert.ToInt32(p.StrStockAmount) < 10), // Using SQL Cast function
                AvgProductRating = _context.Treviews.Any() ? _context.Treviews.Average(r => (decimal)r.IntRating) : 0,
                AdminUsers = adminUserIds.Count,
                RecentSupportRequests = _context.TcustomerServiceTickets.Count(t => t.DtmTimeOfSubmission >= thirtyDaysAgo)

            };

            return adminDashBoard;
        }

        [HttpGet]
        public void SendDiscountEmail() {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var inactiveUsers = _context.AspNetUsers
                .Where(u => u.LastLoginDate < thirtyDaysAgo)
                .ToList();

            string workEmail = "eyassu.million@gmail.com"; // replace with sobee email
            string fromPassword = "nkum abbn kcyz cvxs"; // replace with sobee app password

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587)) {
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(workEmail, fromPassword);

                foreach (var user in inactiveUsers) {
                    // Create the discount email
                    using (var mailMessage = new MailMessage()) {
                        mailMessage.From = new MailAddress(workEmail);
                        mailMessage.To.Add(user.Email);
                        mailMessage.Subject = "We Miss You! Here's a Special Discount";
                        mailMessage.Body = $"Dear {user.StrFirstName},<br><br>" +
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
            }

            //return RedirectToAction("AdminDashboard");
        }



    }
}
