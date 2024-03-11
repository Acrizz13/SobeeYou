using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class CheckoutController : Controller {
        // GET: Checkout
        public ActionResult Index() {
            // Retrieve the cart items from the session
            List<CartItemDTO> cartItems = (List<CartItemDTO>)Session["CartItems"];

            // Recalculate the total price
            decimal totalPrice = CalculateTotalPrice(cartItems);

            // Pass the cart items and total price to the view
            ViewBag.CartItems = cartItems;
            ViewBag.TotalPrice = totalPrice;

            return View();
        }

        private decimal CalculateTotalPrice(List<CartItemDTO> cartItems) {
            decimal totalPrice = 0;
            foreach (var item in cartItems) {
                decimal itemPrice = item.decPrice;
                totalPrice += itemPrice * item.intQuantity;
            }
            return totalPrice;
        }



        [HttpPost]
        public ActionResult ProcessCheckout(FormCollection form) {
            try {
                // Get the cart items and total price from the session
                List<CartItemDTO> cartItems = (List<CartItemDTO>)Session["CartItems"];
                decimal totalPrice = (decimal)Session["TotalPrice"];

                // Get the selected payment method
                int paymentMethod = int.Parse(form["paymentMethod"]);

                // Generate a random tracking number
                string trackingNumber = GenerateRandomTrackingNumber();

                // Insert a new order into the TOrders table
                int orderId = InsertOrder(totalPrice, trackingNumber, paymentMethod);

                // Insert order items into the TOrderItems table
                InsertOrderItems(orderId, cartItems);

                // Remove cart items from the TCartItems table
                RemoveCartItems();

                // Remove shopping cart from the TShoppingCarts table
                // RemoveShoppingCart();

                // Redirect to the OrderConfirmed view
                return RedirectToAction("OrderConfirmed");
            }
            catch (Exception ex) {
                // Handle any exceptions and display an error message
                ViewBag.ErrorMessage = "An error occurred while processing the checkout: " + ex.Message;
                return View("Error");
            }
        }

        private int InsertOrder(decimal totalPrice, string trackingNumber, int paymentMethod) {
            int orderId = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();
                string query = @"INSERT INTO TOrders (intUserID, dtmOrderDate, decTotalAmount, intShippingStatusID, strTrackingNumber, intPaymentMethod)
                         VALUES (@intUserID, @dtmOrderDate, @decTotalAmount, @intShippingStatusID, @strTrackingNumber, @intPaymentMethod);
                         SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@intUserID", 1);
                cmd.Parameters.AddWithValue("@dtmOrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@decTotalAmount", totalPrice);
                cmd.Parameters.AddWithValue("@intShippingStatusID", 1);
                cmd.Parameters.AddWithValue("@strTrackingNumber", trackingNumber);
                cmd.Parameters.AddWithValue("@intPaymentMethod", paymentMethod);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value) {
                    orderId = Convert.ToInt32(result);
                }
            }
            return orderId;
        }

        private void InsertOrderItems(int orderId, List<CartItemDTO> cartItems) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();
                foreach (var item in cartItems) {
                    string query = @"INSERT INTO TOrderItems (intOrderID, intProductID, intQuantity, monPricePerUnit)
                             VALUES (@intOrderID, @intProductID, @intQuantity, @monPricePerUnit)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@intOrderID", orderId);
                    cmd.Parameters.AddWithValue("@intProductID", item.intProductID);
                    cmd.Parameters.AddWithValue("@intQuantity", item.intQuantity);
                    cmd.Parameters.AddWithValue("@monPricePerUnit", item.decPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void RemoveCartItems() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();
                string query = "DELETE FROM TCartItems WHERE intShoppingCartID = 2";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void RemoveShoppingCart() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();
                string query = "DELETE FROM TShoppingCarts WHERE intShoppingCartID = 2";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private string GenerateRandomTrackingNumber() {
            // Generate a random tracking number
            return "XYAFEOWEJJ2222JFPQPJ1";
        }



        public ActionResult OrderConfirmed() {
            return View();
        }



    }
}