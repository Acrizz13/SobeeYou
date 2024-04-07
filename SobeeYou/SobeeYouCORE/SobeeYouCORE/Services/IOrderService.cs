using SobeeYouCORE.Models.DbModels;
using SobeeYouCORE.Models;

namespace SobeeYouCORE.Services {
	public interface IOrderService {
		Task<string> GenerateTrackingNumberAsync();
		Task<Torder> CreateOrderAsync(decimal totalPrice, string trackingNumber, int paymentMethod, string userId, string sessionId, List<CartItemDTO> cartItems);
	}
}
