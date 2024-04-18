using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sobee_core.Models.AzureModels;
using sobee_core.Models;
using sobee_core.Services;
using Microsoft.EntityFrameworkCore;

namespace sobee_core.Controllers {
	public class ShoppingCartController : Controller {
		private readonly SobeecoredbContext _context;
		private readonly IShoppingCartService _shoppingCartService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<ApplicationUser> _userManager;

		public ShoppingCartController(SobeecoredbContext context, IShoppingCartService shoppingCartService, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) {
			_context = context;
			_shoppingCartService = shoppingCartService;
			_httpContextAccessor = httpContextAccessor;
			_userManager = userManager;
		}



		// Display the shopping cart
		public async Task<IActionResult> Index() {

			// stores the shoppingCartId, and totalCartItems
			int shoppingCartId = await _shoppingCartService.GetShoppingCartIdAsync(User);
			var viewModel = new ShoppingCartViewModel {
				CartItems = await _shoppingCartService.GetCartItemsAsync(shoppingCartId),
				TotalPrice = await _shoppingCartService.GetTotalPriceAsync(shoppingCartId),
				TotalCartItems = await _shoppingCartService.GetTotalCartItemsAsync(shoppingCartId)
			};
			return View(viewModel);
		}

		// Retrieve the cart items for the current shopping cart
		[HttpGet]
		public async Task<int> GetTotalCartItems() {
			int totalCartItems = await _shoppingCartService.GetTotalCartItemsAsync(User);
			return totalCartItems;
		}

		// Calculate the total price of the items in the shopping cart
		[HttpGet]
		public async Task<decimal> GetTotalPrice() {
			int shoppingCartId = await _shoppingCartService.GetShoppingCartIdAsync(User);
			decimal totalPrice = await _shoppingCartService.GetTotalPriceAsync(shoppingCartId);

			return totalPrice;
		}

		// Add an item to the shopping cart
		[HttpPost]
		public async Task<ActionResult> AddToCart(TcartItem newItem) {
			try {
				// Get the ID of the current shopping cart
				int shoppingCartId = await _shoppingCartService.GetShoppingCartIdAsync(User);

				// Set the shopping cart ID and date added for the new item
				newItem.IntShoppingCartId = shoppingCartId;
				newItem.DtmDateAdded = DateTime.Now;

				// Check if the item already exists in the cart
				var existingCartItem = await _context.TcartItems
					.FirstOrDefaultAsync(ci => ci.IntShoppingCartId == shoppingCartId && ci.IntProductId == newItem.IntProductId);

				// If the item already exists, update its quantity
				if (existingCartItem != null) {
					existingCartItem.IntQuantity += newItem.IntQuantity;
				}
				// If the item doesn't exist, add it to the cart
				else {
					_context.TcartItems.Add(newItem);
				}

				// Save the changes to the database
				await _context.SaveChangesAsync();

				// Return a success message
				return Content("Item added to cart successfully");
			}
			catch (Exception ex) {
				// Return an error message if an exception occurs
				return Content("An error occurred while adding the item to the cart: " + ex.Message);
			}
		}

		// Remove an item from the shopping cart
		[HttpPost]
		public async Task<ActionResult> RemoveFromCart(int productId) {
			try {
				// Get the ID of the current shopping cart
				int shoppingCartId = await _shoppingCartService.GetShoppingCartIdAsync(User);

				// Find the cart item with the specified product ID in the current shopping cart
				var cartItem = await _context.TcartItems
					.FirstOrDefaultAsync(ci => ci.IntShoppingCartId == shoppingCartId && ci.IntProductId == productId);

				// If the cart item exists, remove it from the cart
				if (cartItem != null) {
					_context.TcartItems.Remove(cartItem);
					await _context.SaveChangesAsync();
					return Content("Item removed from cart successfully");
				}
				else {
					return Content("Item not found in the cart");
				}
			}
			catch (Exception ex) {
				// Return an error message if an exception occurs
				return Content("An error occurred while removing the item from the cart: " + ex.Message);
			}
		}

		// Modify the quantity of an item in the shopping cart
		[HttpPost]
		public async Task<ActionResult> ModifyQuantity(int productId, int change) {
			try {
				// Get the ID of the current shopping cart
				int shoppingCartId = await _shoppingCartService.GetShoppingCartIdAsync(User);

				// Find the cart item with the specified product ID in the current shopping cart
				var cartItem = await _context.TcartItems
					.FirstOrDefaultAsync(ci => ci.IntShoppingCartId == shoppingCartId && ci.IntProductId == productId);

				// If the cart item exists, modify its quantity
				if (cartItem != null) {
					cartItem.IntQuantity += change;

					// If the quantity becomes zero or negative, remove the item from the cart
					if (cartItem.IntQuantity <= 0) {
						_context.TcartItems.Remove(cartItem);
					}

					// Save the changes to the database
					await _context.SaveChangesAsync();
					return Content("Quantity modified successfully");
				}
				else {
					return Content("Product not found in the cart");
				}
			}
			catch (Exception ex) {
				// Return an error message if an exception occurs
				return Content("An error occurred while modifying the quantity: " + ex.Message);
			}
		}

		// Proceed to checkout
		public async Task<ActionResult> Checkout() {
			// Create an instance of the shopping cart view model
			var viewModel = new ShoppingCartViewModel {
				CartItems = await _shoppingCartService.GetCartItemsAsync(await _shoppingCartService.GetShoppingCartIdAsync(User)),
				TotalPrice = await _shoppingCartService.GetTotalPriceAsync(await _shoppingCartService.GetShoppingCartIdAsync(User)),
				TotalCartItems = await _shoppingCartService.GetTotalCartItemsAsync(await _shoppingCartService.GetShoppingCartIdAsync(User))
			};

			// Serialize the cart items to a JSON string
			string cartItemsJson = JsonConvert.SerializeObject(viewModel.CartItems);

			// Store the serialized cart items and total price in the session
			_httpContextAccessor.HttpContext.Session.SetString("CartItems", cartItemsJson);
			_httpContextAccessor.HttpContext.Session.SetString("TotalPrice", viewModel.TotalPrice.ToString());

			// Get the ID of the currently logged-in user
			var userId = _userManager.GetUserId(User);

			// If it's a guest and there is no user ID, go straight to checkout with session ID string
			if (userId == null) {
				return RedirectToAction("Index", "Checkout");
			}

			// Else, store the user ID in the session
			_httpContextAccessor.HttpContext.Session.SetString("UserId", userId);

			// Redirect to the checkout page
			return RedirectToAction("Index", "Checkout");
		}
	}
}
