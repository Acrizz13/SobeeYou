using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sobee_core.Data;
using sobee_core.Models.AzureModels;
using sobee_core.Models;
using System.Net.Mail;
using System.Net;
using sobee_core.Classes;
using sobee_core.Models.AnalyticsModels;

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
            //   var adminDashBoard = GetAdminDashBoardInfo();
            return View();
        }


        public IActionResult Sales() {
            // Top Selling Products
            var topSellingProducts = _context.TorderItems
                .GroupBy(oi => oi.IntProductId)
                .Select(g => new {
                    ProductID = g.Key,
                    TotalQuantity = g.Sum(oi => oi.IntQuantity)
                })
                .OrderByDescending(tp => tp.TotalQuantity)
                .Take(10)
                .Join(_context.Tproducts, tp => tp.ProductID, p => p.IntProductId, (tp, p) => new {
                    ProductName = p.StrName,
                    TotalQuantity = tp.TotalQuantity
                })
                .ToList();

            // Sales Trends Over Time
            var salesTrends = _context.Torders
                .GroupBy(o => new { o.DtmOrderDate.Value.Year, o.DtmOrderDate.Value.Month })
                .Select(g => new {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalSales = g.Sum(o => o.DecTotalAmount)
                })
                .OrderBy(st => st.Year)
                .ThenBy(st => st.Month)
                .ToList();

            //// Promotion Performance
            //var promotionPerformance = _context.Torders
            //    .Where(o => o.IntPromotionId != null)
            //    .GroupBy(o => o.intPromotionID)
            //    .Select(g => new {
            //        PromotionID = g.Key,
            //        TotalSales = g.Sum(o => o.decTotalAmount)
            //    })
            //    .Join(_context.Tpromotions, pp => pp.PromotionID, p => p.IntPromotionId, (pp, p) => new {
            //        PromotionCode = p.strPromoCode,
            //        TotalSales = pp.TotalSales
            //    })
            //    .ToList();

            // Payment Method Breakdown
            var paymentMethodBreakdown = _context.Torders
                .GroupBy(o => o.IntPaymentMethodId)
                .Select(g => new {
                    PaymentMethodID = g.Key,
                    TotalOrders = g.Count()
                })
                .Join(_context.TpaymentMethods, pm => pm.PaymentMethodID, p => p.IntPaymentMethodId, (pm, p) => new {
                    PaymentMethod = p.StrDescription,
                    TotalOrders = pm.TotalOrders
                })
                .ToList();


            // Explicitly cast topSellingProducts to List<dynamic>
            var topSellingProductsDynamic = topSellingProducts
                .Select(p => new { ProductName = p.ProductName, TotalQuantity = p.TotalQuantity })
                .Cast<dynamic>()
                .ToList();

            // Explicitly cast paymentMethodBreakdown to List<dynamic>
            var paymentMethodBreakdownDynamic = paymentMethodBreakdown
                .Select(p => new { PaymentMethod = p.PaymentMethod, TotalOrders = p.TotalOrders })
                .Cast<dynamic>()
                .ToList();

            // Explicitly cast salesTrends to List<dynamic>
            var salesTrendsDynamic = salesTrends
                .Select(st => new { Year = st.Year, Month = st.Month, TotalSales = st.TotalSales })
                .Cast<dynamic>()
                .ToList();


            // Create a view model to hold all the data
            var viewModel = new SalesViewModel {
                TopSellingProducts = topSellingProductsDynamic,
                SalesTrends = salesTrendsDynamic,
                //    PromotionPerformance = promotionPerformance,
                PaymentMethodBreakdown = paymentMethodBreakdownDynamic // Assign the dynamically typed list
            };

            return View(viewModel);
        }

        // Action method for the Customers page
        public IActionResult Customers() {
            return View();
        }

        // Action method for the Inventory Management page
        public IActionResult InventoryManager() {
            return View();
        }

        // Action method for the Orders page
        public IActionResult Orders() {
            return View();
        }

        // Action method for the Product Catalog page
        public IActionResult ProductCatalog() {
            return View();
        }

        // Action method for the Product Reviews page
        public IActionResult ProductReviews() {
            return View();
        }

        // Action method for the Promotions page
        public IActionResult Promotions() {
            return View();
        }

        // Action method for the User Manager page
        public IActionResult UserManager() {
            return View();
        }

        // Action method for the Settings page
        public IActionResult Settings() {
            return View();
        }







        // Private method to retrieve admin dashboard information
        private AdminDashboardViewModel GetAdminDashBoardInfo() {
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
                // NewCustomers = _identityContext.Users.Count(u => u.CreatedDate >= thirtyDaysAgo && !adminUserIds.Contains(u.Id)),
                // ActiveCustomers = _identityContext.Users.Count(u => u.LastLoginDate >= thirtyDaysAgo && !adminUserIds.Contains(u.Id)),
                TotalUsers = _identityContext.Users.Count(u => adminUserIds.Contains(u.Id)),
                TotalOrders = _context.Torders.Count(o => o.IntShippingStatusId == 1), // Assuming 1 represents "Pending"
                RecentRevenue = (decimal)_context.Torders.Where(o => o.DtmOrderDate >= thirtyDaysAgo).Sum(o => o.DecTotalAmount),
                TotalProducts = _context.Tproducts.Count(),
                LowInventoryProducts = _context.Tproducts.Count(p => Convert.ToInt32(p.StrStockAmount) < 10), // Using SQL Cast function
                AvgProductRating = _context.Treviews.Any() ? _context.Treviews.Average(r => (decimal)r.IntRating) : 0,
                AdminUsers = adminUserIds.Count,
                RecentSupportRequests = _context.TcustomerServiceTickets.Count(t => t.DtmTimeOfSubmission >= thirtyDaysAgo),
                ProductSales = _context.TorderItems
                    .GroupBy(oi => oi.IntProduct.StrName)
                    .Select(g => new ProductSalesData {
                        ProductName = g.Key,
                        TotalSales = (decimal)g.Sum(oi => oi.IntQuantity * oi.MonPricePerUnit)
                    })
                    .ToList(),
                WebsiteTraffic = websiteTraffic
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
