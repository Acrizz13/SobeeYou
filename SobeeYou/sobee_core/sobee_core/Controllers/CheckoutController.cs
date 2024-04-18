using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sobee_core.Models.AzureModels;
using sobee_core.Models;
using sobee_core.Services;
using Microsoft.EntityFrameworkCore;

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


        // first check if discount code is valid IsDiscountValid(string DISCOUNT_CODE)
        // if valid, get percentage discount  GetDiscountAmount(decimal DISCOUNT)
        // calculate new total price  CalculateDiscountedPrice(decimal newTotal)
        // return new total price


        [HttpPost]
        public async Task<IActionResult> ApplyPromoCode(string promoCode) {
            // Get the current user's ID
            string userId = _userManager.GetUserId(User);

            // Get the shopping cart ID
            int shoppingCartId = await _shoppingCartService.GetShoppingCartIdAsync(User);

            // Check if the promo code is valid
            bool isValid = await IsDiscountValidAsync(promoCode);

            if (isValid) {
                // Check if the cart has already used the promo code
                bool isUsed = await IsPromoCodeUsedByCartAsync(shoppingCartId, promoCode);

                if (!isUsed) {
                    // Retrieve the discount percentage from the database
                    decimal? discountPercentage = await GetDiscountAmountAsync(promoCode);

                    // Get the current total price from the session
                    decimal? totalPrice = decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("TotalPrice"));

                    // Calculate the discount amount
                    decimal? discountAmount = Math.Round((totalPrice * discountPercentage) ?? 0, 2);

                    // Calculate the new total price after applying the discount
                    decimal? newTotalPrice = Math.Round((totalPrice - discountAmount) ?? 0, 2);

                    // Update the total price in the session
                    _httpContextAccessor.HttpContext.Session.SetString("TotalPrice", newTotalPrice.ToString());

                    // Store the usage history in the database
                    await SavePromoCodeUsageAsync(shoppingCartId, promoCode);

                    // Return the new total price and discount amount as JSON
                    return Json(new { success = true, newTotalPrice = newTotalPrice, discountAmount = discountAmount });
                }
                else {
                    // Return an error message if the cart has already used the promo code
                    return Json(new { success = false, message = "Promo code has already been used for this cart" });
                }
            }
            else {
                // Return an error message if the promo code is invalid
                return Json(new { success = false, message = "Invalid promo code" });
            }
        }


        // checks if discount is in the database or not
        public async Task<bool> IsDiscountValidAsync(string? DISCOUNT_CODE) {
            var availableDiscounts = await _context.Tpromotions
                .Where(dc => dc.StrPromoCode == DISCOUNT_CODE).FirstOrDefaultAsync();

            if (availableDiscounts == null) {
                return false;
            }


            return true;
        }

        //retrieves discount amount from matching discount code record
        public async Task<decimal> GetDiscountAmountAsync(string DISCOUNT_CODE) {
            var discountAmount = await _context.Tpromotions
                .Where(dc => dc.StrPromoCode == DISCOUNT_CODE).FirstOrDefaultAsync();


            return (decimal)discountAmount.DecDiscountPercentage;

        }

        // Checks if the cart has already used the promo code
        public async Task<bool> IsPromoCodeUsedByCartAsync(int shoppingCartId, string promoCode) {
            var usageHistory = await _context.TpromoCodeUsageHistories
                .FirstOrDefaultAsync(h => h.IntShoppingCartId == shoppingCartId && h.PromoCode == promoCode);
            return usageHistory != null;
        }

        // Saves the promo code usage history in the database
        public async Task SavePromoCodeUsageAsync(int shoppingCartId, string promoCode) {
            var usageHistory = new TpromoCodeUsageHistory {
                IntShoppingCartId = shoppingCartId,
                PromoCode = promoCode,
                UsedDateTime = DateTime.Now
            };
            _context.TpromoCodeUsageHistories.Add(usageHistory);
            await _context.SaveChangesAsync();
        }


        public ActionResult OrderConfirmed() {
            return View();
        }
    }
}
