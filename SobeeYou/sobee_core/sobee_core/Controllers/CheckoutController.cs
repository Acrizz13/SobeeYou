using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sobee_core.Models.AzureModels;
using sobee_core.Models.AzureModels.Identity;
using Microsoft.AspNetCore.Identity;
using sobee_core.Services;
using sobee_core.Models;

namespace sobee_core.Controllers {
    public class CheckoutController : Controller {
        private readonly SobeecoredbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;

        public CheckoutController(SobeecoredbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IShoppingCartService shoppingCartService, IOrderService orderService) {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index() {
            // Retrieve the cart items from the session
            List<CartItemDTO> cartItems = new List<CartItemDTO>();
            string cartItemsString = _httpContextAccessor.HttpContext.Session.GetString("CartItems");

            // if cart is not empty, store serialized object string in cartItemsString
            if (!string.IsNullOrEmpty(cartItemsString)) {
                cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>>(cartItemsString);
            }

            // Recalculate the total price
            decimal totalPrice = await _shoppingCartService.GetTotalPriceAsync(await _shoppingCartService.GetShoppingCartIdAsync(User));

            // Pass the cart items and total price to the view
            ViewBag.CartItems = cartItems;
            ViewBag.TotalPrice = totalPrice;

            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> ProcessCheckout(IFormCollection form) {
            try {
                // Get the cart items and total price from the session
                string cartItemsString = _httpContextAccessor.HttpContext.Session.GetString("CartItems");
                List<CartItemDTO> cartItems = JsonConvert.DeserializeObject<List<CartItemDTO>>(cartItemsString);
                decimal totalPrice = decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("TotalPrice"));

                // Get the selected payment method
                int paymentMethod = int.Parse(form["paymentMethod"]);

                // Generate a random tracking number
                string trackingNumber = await _orderService.GenerateTrackingNumberAsync();

                // Get the user ID and session ID
                string userId = _userManager.GetUserId(User);
                string sessionId = _httpContextAccessor.HttpContext.Session.GetString("SessionId");

                // Create a new order
                var order = await _orderService.CreateOrderAsync(totalPrice, trackingNumber, paymentMethod, userId, sessionId, cartItems);

                // Remove cart items and shopping cart
                await _shoppingCartService.ClearCartAsync(User);

                // Redirect to the OrderConfirmed action
                return RedirectToAction("OrderConfirmed");
            }
            catch (Exception ex) {
                // Handle any exceptions and display an error message
                ModelState.AddModelError("", "An error occurred while processing the checkout: " + ex.Message);
                return View("Error");
            }
        }

        public ActionResult OrderConfirmed() {
            return View();
        }
    }
}