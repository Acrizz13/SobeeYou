using sobee_core.Models;
using sobee_core.Models.AzureModels;

namespace sobee_core.Services {
    public class OrderService : IOrderService {
        private readonly Models.AzureModels.SobeecoredbContext _context;

        public OrderService(SobeecoredbContext context) {
            _context = context;
        }

        public async Task<string> GenerateTrackingNumberAsync() {
            // TODO: Implement the logic to generate a random tracking number
            return "XYAFEOWEJJ2222JFPQPJ1";
        }

        public async Task<Torder> CreateOrderAsync(decimal totalPrice, string trackingNumber, int paymentMethod, string userId, string sessionId, List<CartItemDTO> cartItems) {
            // Create a new order
            var order = new Torder {
                UserId = userId,
                SessionId = sessionId,
                DtmOrderDate = DateTime.Now,
                DecTotalAmount = totalPrice,
                IntShippingStatusId = 1,
                StrTrackingNumber = trackingNumber,
                IntPaymentMethodId = paymentMethod
            };

            // Add the order to the database and save changes
            _context.Torders.Add(order);
            await _context.SaveChangesAsync();

            // Insert order items for the given order
            foreach (var item in cartItems) {
                var orderItem = new TorderItem {
                    IntOrderId = order.IntOrderId,
                    IntProductId = item.intProductID,
                    IntQuantity = item.intQuantity,
                    MonPricePerUnit = item.decPrice
                };

                _context.TorderItems.Add(orderItem);
            }

            await _context.SaveChangesAsync();

            return order;
        }
    }
}

