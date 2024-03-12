
using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class ShoppingCartController : Controller {
        // GET: Cart
        public ActionResult Index() {
            int intTotalCartItems = GetTotalCartItems();
            ViewBag.TotalCartItems = intTotalCartItems;

            try {
                var cartItems = GetCartItems();
                return View(cartItems);
            }
            catch (Exception ex) {
                ViewBag.ErrorMessage = "An error occurred while retrieving cart items: " + ex.Message;
                return View();
            }
        }




        // Gets total number of items in cart, works with Scripts/dynamicShoppingCart.js  
        public int GetTotalCartItems() {
            int intShoppingCartID = 2; // Replace with the actual ShoppingCartID

            Console.WriteLine("Starting GetTotalCartItems method...");
            Console.WriteLine("ShoppingCartID: " + intShoppingCartID);

            using (var context = new TableModels()) {
                Console.WriteLine("Querying database for CartItems with ShoppingCartID: " + intShoppingCartID);

                var cartItems = context.TCartItems
                    .Where(ci => ci.intShoppingCartID == intShoppingCartID)
                    .ToList();

                Console.WriteLine("Found " + cartItems.Count + " CartItems in the database");

                int intTotalCartItems = cartItems.Sum(ci => ci.intQuantity);

                Console.WriteLine("TotalCartItems calculated: " + intTotalCartItems);

                return intTotalCartItems;
            }
        }


        public decimal GetTotalPrice() {
            int intShoppingCartID = 2; // Replace with the actual ShoppingCartID
            decimal totalPrice = 0;

            if (GetTotalCartItems() != 0) {
                using (var context = new TableModels()) {
                    totalPrice = context.TCartItems
                        .Where(ci => ci.intShoppingCartID == intShoppingCartID)
                        .Sum(ci => (decimal?)ci.intQuantity * ci.Product.decPrice ?? 0);

                    return totalPrice;
                }
            }
            else {
                return totalPrice;
            }
        }



        [HttpPost]
        public ActionResult AddToCart(TCartItem newItem) {
            try {
                newItem.intShoppingCartID = 2; // Replace with the actual ShoppingCartID
                newItem.dtmDateAdded = DateTime.Now;

                using (var context = new TableModels()) {
                    // Check if the product already exists in the cart
                    var existingCartItem = context.TCartItems
                        .FirstOrDefault(ci => ci.intShoppingCartID == newItem.intShoppingCartID &&
                                              ci.intProductID == newItem.intProductID);

                    if (existingCartItem != null) {
                        // Update the quantity of the existing cart item
                        existingCartItem.intQuantity += newItem.intQuantity;
                    }
                    else {
                        // Add a new cart item
                        context.TCartItems.Add(newItem);
                    }

                    context.SaveChanges();
                }

                return Content("Item added to cart successfully");
            }
            catch (Exception ex) {
                return Content("An error occurred: " + ex.Message);
            }
        }




        [HttpPost]
        public ActionResult RemoveFromCart(int productId) {
            try {
                int shoppingCartId = 2; // Replace with the actual ShoppingCartID

                using (var context = new TableModels()) {
                    var cartItem = context.TCartItems
                        .SingleOrDefault(ci => ci.intShoppingCartID == shoppingCartId &&
                                               ci.intProductID == productId);

                    if (cartItem != null) {
                        context.TCartItems.Remove(cartItem);
                        context.SaveChanges();
                        return Content("Item removed from cart successfully");
                    }
                    else {
                        return Content("Item not found in the cart");
                    }
                }
            }
            catch (Exception ex) {
                return Content("An error occurred: " + ex.Message);
            }
        }



        [HttpPost]
        public ActionResult ModifyQuantity(int productId, int change) {
            try {
                int shoppingCartId = 2; // Replace with the actual ShoppingCartID

                using (var context = new TableModels()) {
                    var cartItem = context.TCartItems
                        .SingleOrDefault(ci => ci.intShoppingCartID == shoppingCartId &&
                                               ci.intProductID == productId);

                    if (cartItem != null) {
                        cartItem.intQuantity += change;

                        if (cartItem.intQuantity <= 0) {
                            context.TCartItems.Remove(cartItem);
                        }

                        context.SaveChanges();
                        return Content("Quantity modified successfully");
                    }
                    else {
                        return Content("Product not found in the cart");
                    }
                }
            }
            catch (Exception ex) {
                return Content("An error occurred: " + ex.Message);
            }
        }


        public ActionResult Checkout() {
            List<CartItemDTO> cartItems = GetCartItems();
            decimal totalPrice = GetTotalPrice();

            Session["CartItems"] = cartItems;
            Session["TotalPrice"] = totalPrice;

            return RedirectToAction("Index", "Checkout");
        }


        private List<CartItemDTO> GetCartItems() {
            using (var context = new TableModels()) {
                int intShoppingCartID = 2; // Replace with the actual ShoppingCartID

                var cartItems = context.TCartItems
                    .Where(ci => ci.intShoppingCartID == intShoppingCartID)
                    .Select(ci => new CartItemDTO {
                        intProductID = ci.intProductID,
                        intQuantity = ci.intQuantity,
                        dtmDateAdded = ci.dtmDateAdded,
                        strProductName = ci.Product.strName,
                        decPrice = ci.Product.decPrice
                    })
                    .OrderBy(ci => ci.dtmDateAdded)
                    .ToList();

                return cartItems;
            }
        }


    }
}
