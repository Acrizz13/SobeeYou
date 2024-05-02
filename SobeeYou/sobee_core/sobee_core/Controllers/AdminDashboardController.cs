using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sobee_core.Data;
using sobee_core.Models.AzureModels;
using System.Net.Mail;
using System.Net;
using sobee_core.Classes;
using sobee_core.Models.AnalyticsModels;
using sobee_core.Services.AnalyticsServices;
using sobee_core.Models.ViewModels;
using sobee_core.Models;

namespace sobee_core.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller {
        private readonly SobeecoredbContext _context;
        private readonly ApplicationDbContext _identityContext;
        private readonly ISalesAnalyticsService _salesAnalyticsContext;
        private readonly ICustomerAnalyticsService _customerAnalyticsContext;

        public AdminDashboardController(SobeecoredbContext context, ApplicationDbContext identityContext, ISalesAnalyticsService salesAnalyticsService, ICustomerAnalyticsService customerAnalyticsService) {
            _context = context;
            _identityContext = identityContext;
            _salesAnalyticsContext = salesAnalyticsService;
            _customerAnalyticsContext = customerAnalyticsService;
        }

        // Action method to display the admin dashboard
        public IActionResult Index() {
            //   var adminDashBoard = GetAdminDashBoardInfo();
            return View();
        }


        public IActionResult Sales(int? year, int? month, int? day) {
            // Set default value of year to 2024 if all parameters are empty
            year ??= 2024;

            var orders = _context.Torders.AsQueryable();
            orders = _salesAnalyticsContext.FilterOrdersByDate(orders, year, month, day);

            var filteredOrders = orders.Where(o => o.DtmOrderDate.HasValue).ToList();

            var salesTrends = _salesAnalyticsContext.GetSalesTrends(filteredOrders, year, month);
            var topSellingProducts = _salesAnalyticsContext.GetTopSellingProducts(orders);
            var paymentMethodBreakdown = _salesAnalyticsContext.GetPaymentMethodBreakdown(filteredOrders);
            var productSalesData = _salesAnalyticsContext.GetProductSalesData(filteredOrders);

            var viewModel = new SalesViewModel {
                TopSellingProducts = topSellingProducts,
                SalesTrends = salesTrends,
                PaymentMethodBreakdown = paymentMethodBreakdown,
                SelectedYear = year,
                SelectedMonth = month,
                IsMonthSelected = month.HasValue,
                SelectedDay = day,
                ProductSalesData = productSalesData
            };

            return View(viewModel);
        }


        // Action method for the Customers page
        public IActionResult Customers(int? year, int? month) {
            var orders = _context.Torders.AsQueryable();
            orders = _salesAnalyticsContext.FilterOrdersByDate(orders, year, month, null);

            var filteredOrders = orders.Where(o => o.DtmOrderDate.HasValue).ToList();

            var topRegisteredCustomers = _customerAnalyticsContext.GetTopCustomers(filteredOrders, year, month);
            var registeredVsGuestSpending = _customerAnalyticsContext.GetRegisteredVsGuestCustomerSpending(filteredOrders);

            var viewModel = new CustomersViewModel {
                TopRegisteredCustomers = topRegisteredCustomers,
                RegisteredVsGuestSpending = registeredVsGuestSpending,
                SelectedYear = year,
                SelectedMonth = month
            };

            return View(viewModel);
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
        public IActionResult ProductReviews(int? year, int? month, int? day) {
            var topRatedProducts = _salesAnalyticsContext.GetTopRatedProducts(year, month, day);
            var mostReviewedProducts = _salesAnalyticsContext.GetMostReviewedProducts(year, month, day);

            var viewModel = new ReviewsViewModel {
                TopRatedProducts = topRatedProducts,
                MostReviewedProducts = mostReviewedProducts,
                SelectedYear = year,
                SelectedMonth = month,
                SelectedDay = day
            };

            return View(viewModel);
        }

        // Action method for the Promotions page
        public IActionResult Promotions() {
            var promotions = _context.Tpromotions.ToList();
            var promotionDTOs = promotions.Select(p => new PromotionDTO {
                PromotionId = (int)p.IntPromotionId,
                PromoCode = p.StrPromoCode,
                StrDiscountPercentage = p.StrDiscountPercentage,
                DecimalPercent = p.DecDiscountPercentage,
                ExpirationDate = p.DtmExpirationDate
            }).ToList();

            var viewModel = new PromotionsViewModel {
                Promotions = promotionDTOs
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPromotion(Tpromotion promotion) {
            if (ModelState.IsValid) {
                _context.Tpromotions.Update(promotion);
                _context.SaveChanges();

                // Retrieve the updated list of promotions
                var updatedPromotions = _context.Tpromotions.ToList();
                var updatedPromotionDTOs = updatedPromotions.Select(p => new PromotionDTO {
                    PromotionId = (int)p.IntPromotionId,
                    PromoCode = p.StrPromoCode,
                    StrDiscountPercentage = p.StrDiscountPercentage,
                    DecimalPercent = p.DecDiscountPercentage,
                    ExpirationDate = p.DtmExpirationDate
                }).ToList();

                return Json(new { success = true, promotions = updatedPromotionDTOs });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        [HttpPost]
        public IActionResult DeletePromotion(int id) {
            var promotion = _context.Tpromotions.FirstOrDefault(p => p.IntPromotionId == id);
            if (promotion != null) {
                _context.Tpromotions.Remove(promotion);
                _context.SaveChanges();

                // Retrieve the updated list of promotions
                var updatedPromotions = _context.Tpromotions.ToList();
                var updatedPromotionDTOs = updatedPromotions.Select(p => new PromotionDTO {
                    PromotionId = (int)p.IntPromotionId,
                    PromoCode = p.StrPromoCode,
                    StrDiscountPercentage = p.StrDiscountPercentage,
                    DecimalPercent = p.DecDiscountPercentage,
                    ExpirationDate = p.DtmExpirationDate
                }).ToList();

                return Json(new { success = true, promotions = updatedPromotionDTOs });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePromotion(Tpromotion promotion) {
            if (ModelState.IsValid) {
                _context.Tpromotions.Add(promotion);
                _context.SaveChanges();

                // Retrieve the updated list of promotions
                var updatedPromotions = _context.Tpromotions.ToList();
                var updatedPromotionDTOs = updatedPromotions.Select(p => new PromotionDTO {
                    PromotionId = (int)p.IntPromotionId,
                    PromoCode = p.StrPromoCode,
                    StrDiscountPercentage = p.StrDiscountPercentage,
                    DecimalPercent = p.DecDiscountPercentage,
                    ExpirationDate = p.DtmExpirationDate
                }).ToList();

                return Json(new { success = true, promotions = updatedPromotionDTOs });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        // Action method for the User Manager page
        public IActionResult UserManager() {
            var userViewModels = GetUserViewModels();
            return View(userViewModels);
        }

        public IActionResult GetUsers() {
            var userViewModels = GetUserViewModels();
            return PartialView("_UserManagerList", userViewModels);
        }

        private List<UserViewModel> GetUserViewModels() {
            var users = _context.AspNetUsers.ToList();

            var userViewModels = users.Select(u => new UserViewModel {
                Id = u.Id,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                FirstName = u.StrFirstName,
                LastName = u.StrLastName,
                BillingAddress = u.StrBillingAddress,
                ShippingAddress = u.StrShippingAddress,
                IsAdmin = _identityContext.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == _identityContext.Roles.FirstOrDefault(r => r.Name == "Admin").Id)
            }).ToList();

            return userViewModels;
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel model) {
            if (ModelState.IsValid) {
                var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == model.Id);

                if (user != null) {
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.StrFirstName = model.FirstName;
                    user.StrLastName = model.LastName;
                    user.StrBillingAddress = model.BillingAddress;
                    user.StrShippingAddress = model.ShippingAddress;

                    _context.SaveChanges();

                    return Json(new { success = true });
                }
            }

            return Json(new { success = false });
        }



        [HttpPost]
        public IActionResult DeleteUser(string Id) {
            // Find the user by Id
            var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == Id);

            if (user != null) {
                try {
                    // Delete all records from TFavorites associated with the user ID
                    var userFavorites = _context.Tfavorites.Where(f => f.UserId == Id);
                    _context.Tfavorites.RemoveRange(userFavorites);


                    // Delete the user from AspNetUsers
                    _context.AspNetUsers.Remove(user);

                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                catch (Exception ex) {
                    // Handle any exceptions that occur during the deletion process
                    return Json(new { success = false, error = ex.Message });
                }
            }

            return Json(new { success = false, error = "User not found" });
        }

        // Action method for the Settings page
        public IActionResult Settings() {
            return View();
        }


        public IActionResult InactiveUsers() {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);
            var inactiveUsers = _context.AspNetUsers
                .Where(u => u.LastLoginDate < thirtyDaysAgo)
                .Select(u => new InactiveUserViewModel {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.StrFirstName,
                    LastName = u.StrLastName,
                    LastLoginDate = u.LastLoginDate
                })
                .ToList();

            return PartialView("_InactiveUsers", inactiveUsers);
        }


        [HttpGet]
        public void SendDiscountEmail() {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var inactiveUsers = _context.AspNetUsers
                .Where(u => u.LastLoginDate < thirtyDaysAgo)
                .ToList();

            string workEmail = "sobeeyoubusiness@gmail.com";
            string fromPassword = "yplu kfwq wufa jpjp";

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
