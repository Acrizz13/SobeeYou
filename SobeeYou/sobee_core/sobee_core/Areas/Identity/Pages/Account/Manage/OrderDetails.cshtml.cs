using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sobee_core.Models;
using sobee_core.Models.AzureModels;
using System.Security.Claims;

namespace sobee_core.Areas.Identity.Pages.Account.Manage {
    public class OrderDetailsModel : PageModel {
        private readonly SobeecoredbContext _context;

        public OrderDetailsViewModel Order { get; set; }

        public OrderDetailsModel(SobeecoredbContext context) {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id) {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Order = await _context.Torders
                .Where(o => o.IntOrderId == id && o.UserId == userId)
                .Select(o => new OrderDetailsViewModel {
                    OrderID = o.IntOrderId,
                    OrderDate = (DateTime)o.DtmOrderDate,
                    TotalAmount = (decimal)o.DecTotalAmount,
                    OrderStatus = o.StrOrderStatus,
                    ShippingAddress = o.StrShippingAddress,
                    TrackingNumber = o.StrTrackingNumber,
                    OrderItems = o.TorderItems.Select(oi => new OrderItemViewModel {
                        ProductName = oi.IntProduct.StrName,
                        Quantity = (int)oi.IntQuantity,
                        Price = (decimal)oi.MonPricePerUnit
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (Order == null) {
                return NotFound();
            }

            return Page();
        }
    }
}
