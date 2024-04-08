using sobee_core.Models.AzureModels;
using sobee_core.Models;

namespace sobee_core.Services {
    public interface IOrderService {
        Task<string> GenerateTrackingNumberAsync();
        Task<Torder> CreateOrderAsync(decimal totalPrice, string trackingNumber, int paymentMethod, string userId, string sessionId, List<CartItemDTO> cartItems);
    }
}
