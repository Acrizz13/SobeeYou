using Microsoft.EntityFrameworkCore;
using sobee_core.Models.AzureModels;

namespace sobee_core.Services.AnalyticsServices {
    public class CustomerAnalyticsService : ICustomerAnalyticsService {

        private readonly SobeecoredbContext _context;

        public CustomerAnalyticsService(SobeecoredbContext context) {
            _context = context;
        }

        public List<dynamic> GetTopCustomers(List<Torder> filteredOrders, int? year, int? month) {
            var topRegisteredCustomers = filteredOrders
                .Where(o => o.UserId != null)
                .GroupBy(o => o.UserId)
                .Select(g => new {
                    Id = g.Key,
                    TotalSpending = g.Sum(o => o.DecTotalAmount)
                })
                .OrderByDescending(c => c.TotalSpending)
                .Take(10) // Take the top 10 registered customers
                .Select(c => new {
                    CustomerName = _context.AspNetUsers.FirstOrDefault(u => u.Id == c.Id)?.StrFirstName + " " + _context.AspNetUsers.FirstOrDefault(u => u.Id == c.Id)?.StrLastName,
                    c.TotalSpending
                })
                .ToList();

            var guestCustomersSpending = filteredOrders
                .Where(o => o.UserId == null)
                .Sum(o => o.DecTotalAmount);

            var topCustomers = topRegisteredCustomers
                .Select(c => c)
                .Concat(new[]
                {
            new
            {
                CustomerName = "Guests",
                TotalSpending = guestCustomersSpending
            }
                })
                .ToList();

            return topCustomers.Cast<dynamic>().ToList();
        }

        public List<dynamic> GetRegisteredVsGuestCustomerSpending(List<Torder> filteredOrders) {
            var registeredCustomersSpending = filteredOrders
                .Where(o => o.UserId != null)
                .Sum(o => o.DecTotalAmount);

            var guestCustomersSpending = filteredOrders
                .Where(o => o.UserId == null)
                .Sum(o => o.DecTotalAmount);

            var spendingData = new List<dynamic>
            {
        new { Category = "Registered Customers", TotalSpending = registeredCustomersSpending },
        new { Category = "Guest Customers", TotalSpending = guestCustomersSpending }
    };

            return spendingData;
        }










    }
}
