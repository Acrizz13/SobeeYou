using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SobeeYouCORE.Data;
using SobeeYouCORE.Models;
using SobeeYouCORE.Models.DbModels;

namespace SobeeYouCORE.Controllers {
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
                NewCustomers = _identityContext.Users.Count(u => u.CreatedDate >= thirtyDaysAgo && !adminUserIds.Contains(u.Id)),
                ActiveCustomers = _identityContext.Users.Count(u => u.LastLoginDate >= thirtyDaysAgo && !adminUserIds.Contains(u.Id)),
                TotalUsers = _identityContext.Users.Count(u => adminUserIds.Contains(u.Id)),
                TotalOrders = _context.Torders.Count(o => o.IntShippingStatusId == 1), // Assuming 1 represents "Pending"
                RecentRevenue = (decimal)_context.Torders.Where(o => o.DtmOrderDate >= thirtyDaysAgo).Sum(o => o.DecTotalAmount),
                TotalProducts = _context.Tproducts.Count(),
                LowInventoryProducts = _context.Tproducts.Count(p => Convert.ToInt32(p.StrStockAmount) < 10), // Using SQL Cast function
                AvgProductRating = _context.Treviews.Any() ? _context.Treviews.Average(r => Decimal.Parse(r.StrRating)) : 0,
                AdminUsers = adminUserIds.Count,
                RecentSupportRequests = _context.TcustomerServiceTickets.Count(t => t.DtmTimeOfSubmission >= thirtyDaysAgo)

            };

            return adminDashBoard;
        }
    }
}