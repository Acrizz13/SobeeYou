using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sobee_core.Models;
using sobee_core.Models.AzureModels;
using System.Security.Claims;

namespace sobee_core.Areas.Identity.Pages.Account.Manage {
    public class OrderHistoryModel : PageModel {
        private readonly SobeecoredbContext _context;

        public List<OrderHistoryViewModel> Orders { get; set; }

        public OrderHistoryModel(SobeecoredbContext context) {
            _context = context;
        }

        public async Task OnGetAsync() {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Orders = await _context.Torders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderHistoryViewModel {
                    OrderID = o.IntOrderId,
                    OrderDate = (DateTime)o.DtmOrderDate,
                    TotalAmount = (decimal)o.DecTotalAmount,
                    OrderStatus = o.StrOrderStatus
                })
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}