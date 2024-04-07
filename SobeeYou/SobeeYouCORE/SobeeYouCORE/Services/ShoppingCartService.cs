using Microsoft.AspNetCore.Identity;
using SobeeYouCORE.Models.DbModels;
using SobeeYouCORE.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace SobeeYouCORE.Services {
	public class ShoppingCartService : IShoppingCartService {
		private readonly NewDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<ApplicationUser> _userManager;

		public ShoppingCartService(NewDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) {
			_context = context;
			_httpContextAccessor = httpContextAccessor;
			_userManager = userManager;
		}

		public async Task<List<CartItemDTO>> GetCartItemsAsync(int shoppingCartId) {
			var cartItems = await _context.TcartItems
				.Where(ci => ci.IntShoppingCartId == shoppingCartId)
				.Select(ci => new CartItemDTO {
					intProductID = (int)ci.IntProductId,
					intQuantity = (int)ci.IntQuantity,
					dtmDateAdded = (DateTime)ci.DtmDateAdded,
					strProductName = (string)ci.IntProduct.StrName,
					decPrice = (decimal)ci.IntProduct.DecPrice
				})
				.ToListAsync();

			return cartItems;
		}

		public async Task<int> GetTotalCartItemsAsync(int shoppingCartId) {
			int? totalCartItems = await _context.TcartItems
				.Where(ci => ci.IntShoppingCartId == shoppingCartId)
				.SumAsync(ci => ci.IntQuantity);

			return (int)totalCartItems;
		}

		public async Task<decimal> GetTotalPriceAsync(int shoppingCartId) {
			decimal? totalPrice = await _context.TcartItems
				.Where(ci => ci.IntShoppingCartId == shoppingCartId)
				.SumAsync(ci => ci.IntQuantity * ci.IntProduct.DecPrice);

			return (decimal)Math.Round(totalPrice ?? 0, 2);
		}

		// Retrieve the shopping cart ID for the current user or session
		public async Task<int> GetShoppingCartIdAsync(ClaimsPrincipal user) {
			string sessionId = _httpContextAccessor.HttpContext.Session.GetString("SessionId");

			if (string.IsNullOrEmpty(sessionId)) {
				sessionId = Guid.NewGuid().ToString();
				_httpContextAccessor.HttpContext.Session.SetString("SessionId", sessionId);
			}

			string userId = _userManager.GetUserId(user);

			var shoppingCart = await _context.TshoppingCarts
				.FirstOrDefaultAsync(sc => (sc.UserId == userId && sc.SessionId == null) || sc.SessionId == sessionId);

			if (shoppingCart == null) {
				shoppingCart = new TshoppingCart {
					UserId = userId,
					SessionId = string.IsNullOrEmpty(userId) ? sessionId : null,
					DtmDateCreated = DateTime.Now
				};
				_context.TshoppingCarts.Add(shoppingCart);
				await _context.SaveChangesAsync();
			}
			else if (!string.IsNullOrEmpty(userId) && shoppingCart.UserId != userId) {
				await UpdateShoppingCartUserIdAsync(userId);
			}

			return shoppingCart.IntShoppingCartId;
		}

		// Update the shopping cart user ID when a user logs in
		public async Task UpdateShoppingCartUserIdAsync(string userId) {
			// Get the session ID from the HTTP context
			string sessionId = _httpContextAccessor.HttpContext.Session.GetString("SessionId");

			// Find the shopping cart associated with the session ID, including its cart items
			var sessionShoppingCart = await _context.TshoppingCarts
				.Include(sc => sc.TcartItems)
				.FirstOrDefaultAsync(sc => sc.SessionId == sessionId);

			// Find the shopping cart associated with the user ID, including its cart items
			var userShoppingCart = await _context.TshoppingCarts
				.Include(sc => sc.TcartItems)
				.FirstOrDefaultAsync(sc => sc.UserId == userId);

			// If a session shopping cart exists
			if (sessionShoppingCart != null) {
				// If the user doesn't have a cart, update the session cart with the user ID
				if (userShoppingCart == null) {
					sessionShoppingCart.UserId = userId;
					sessionShoppingCart.SessionId = null;
				}
				else {
					// If the user has a cart, merge the items from the session cart into the user cart
					foreach (var item in sessionShoppingCart.TcartItems) {
						var existingItem = userShoppingCart.TcartItems
							.FirstOrDefault(i => i.IntProductId == item.IntProductId);

						// If the item already exists in the user cart, update its quantity
						if (existingItem != null) {
							existingItem.IntQuantity += item.IntQuantity;
						}
						// If the item doesn't exist in the user cart, add it
						else {
							userShoppingCart.TcartItems.Add(item);
						}
					}

					// Remove the session cart since its items have been merged into the user cart
					_context.TshoppingCarts.Remove(sessionShoppingCart);
				}

				// Save the changes to the database
				await _context.SaveChangesAsync();
			}
		}

		// Get the total number of items in the shopping cart
		public async Task<int> GetTotalCartItemsAsync(ClaimsPrincipal user) {
			int shoppingCartId = await GetShoppingCartIdAsync(user);
			int? totalCartItems = await _context.TcartItems
				.Where(ci => ci.IntShoppingCartId == shoppingCartId)
				.SumAsync(ci => ci.IntQuantity);

			return (int)totalCartItems;
		}

		public async Task ClearCartAsync(ClaimsPrincipal user) {
			int shoppingCartId = await GetShoppingCartIdAsync(user);

			// Remove all cart items associated with the shopping cart
			var cartItems = _context.TcartItems.Where(ci => ci.IntShoppingCartId == shoppingCartId);
			_context.TcartItems.RemoveRange(cartItems);

			// Remove the shopping cart
			var shoppingCart = _context.TshoppingCarts.FirstOrDefault(sc => sc.IntShoppingCartId == shoppingCartId);
			if (shoppingCart != null) {
				_context.TshoppingCarts.Remove(shoppingCart);
			}

			await _context.SaveChangesAsync();
		}


	}
}
