using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class ShoppingCartController : Controller {
        // GET: Cart
        public ActionResult Index() {
            int intTotalCartItems = GetTotalCartItems();
            ViewBag.TotalCartItems = intTotalCartItems;

            List<CartItemProductJoin> cartItems = new List<CartItemProductJoin>();

            try {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                    conn.Open();
                    string query = @"SELECT ci.intProductID, ci.intQuantity, ci.dtmDateAdded, p.strName, p.strPrice
                             FROM TCartItems ci
                             JOIN TProducts p ON ci.intProductID = p.intProductID
                             WHERE ci.intShoppingCartID = 1
                             ORDER BY ci.dtmDateAdded";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // cmd.Parameters.AddWithValue("@intShoppingCartID", 1); // Set ShoppingCartID to 1 for testing

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            cartItems.Add(new CartItemProductJoin {
                                intProductID = (int)reader["intProductID"],
                                intQuantity = (int)reader["intQuantity"],
                                dtmDateAdded = (DateTime)reader["dtmDateAdded"],
                                strProductName = (string)reader["strName"],
                                decPrice = (string)reader["strPrice"]
                            });
                        }
                    }
                }

                return View(cartItems);
            }
            catch (Exception ex) {
                ViewBag.ErrorMessage = "An error occurred while retrieving cart items: " + ex.Message;
                return View();
            }
        }



        // Gets total number of items in cart, works with Scripts/dynamicShoppingCart.js  
        public int GetTotalCartItems() {
            // Assuming you have a way to get the current ShoppingCartID's ID
            string intShoppingCartID = "1"; // Replace "current_cart_id" with the actual ShoppingCartID 

            int intTotalCartItems = 0; // stores the total that will be returned

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();

                // Retrieve the total quantity of items in the user's cart
                string query = "SELECT SUM(intQuantity) FROM TCartItems WHERE intShoppingCartID = @intShoppingCartID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@intShoppingCartID", intShoppingCartID);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value) {
                    intTotalCartItems = Convert.ToInt32(result);
                }
            }
            return intTotalCartItems;
        }


        public decimal GetTotalPrice() {
            string intShoppingCartID = "1"; // Replace "intShoppingCartID" with the actual ShoppingCartID 

            decimal totalPrice = 0; // stores the total price that will be returned

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();

                // Retrieve the total price of items in the user's cart
                string query = @"SELECT SUM(ci.intQuantity * TRY_CAST(p.strPrice AS decimal(18, 2)))
                                FROM TCartItems ci 
                                JOIN TProducts p ON ci.intProductID = p.intProductID 
                                WHERE ci.intShoppingCartID = @intShoppingCartID
                                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@intShoppingCartID", intShoppingCartID);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value) {
                    totalPrice = Convert.ToDecimal(result);
                }
            }
            return totalPrice;
        }




        [HttpPost]
        public ActionResult AddToCart(CartItems newItem) {
            try {
                // Get the current shoppingCart's ID - You need to replace this with your actual method to retrieve the shoppingCart ID
                newItem.intShoppingCartID = 1; // Replace intShoppingCartID with your actual ID

                // Set the current date/time
                newItem.dtmDateAdded = DateTime.Now;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                    conn.Open();
                    string query;
                    SqlCommand cmd;

                    // Check if the product already exists in the cart
                    query = "SELECT intQuantity FROM TCartItems WHERE intShoppingCartID = @intShoppingCartID AND intProductID = @intProductID";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@intShoppingCartID", newItem.intShoppingCartID);
                    cmd.Parameters.AddWithValue("@intProductID", newItem.intProductID);
                    int existingQuantity = Convert.ToInt32(cmd.ExecuteScalar());

                    if (existingQuantity > 0) {
                        // Update the quantity of the existing product
                        query = "UPDATE TCartItems SET intQuantity = intQuantity + @intQuantity WHERE intShoppingCartID = @intShoppingCartID AND intProductID = @intProductID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@intShoppingCartID", newItem.intShoppingCartID);
                        cmd.Parameters.AddWithValue("@intProductID", newItem.intProductID);
                        cmd.Parameters.AddWithValue("@intQuantity", newItem.intQuantity);
                        cmd.ExecuteNonQuery();
                    }
                    else {
                        // Add a new entry for the product
                        query = "INSERT INTO TCartItems (intShoppingCartID, intProductID, intQuantity, dtmDateAdded) VALUES (@intShoppingCartID, @intProductID, @intQuantity, @dtmDateAdded)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@intShoppingCartID", newItem.intShoppingCartID);
                        cmd.Parameters.AddWithValue("@intProductID", newItem.intProductID);
                        cmd.Parameters.AddWithValue("@intQuantity", newItem.intQuantity);
                        cmd.Parameters.AddWithValue("@dtmDateAdded", newItem.dtmDateAdded);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Return a success message or status
                return Content("Item added to cart successfully");
            }
            catch (Exception ex) {
                // Return error message
                return Content("An error occurred: " + ex.Message);
            }
        }




        [HttpPost]
        public ActionResult RemoveFromCart(int productId) {
            try {
                // Get the current shoppingCart's ID - You need to replace this with your actual method to retrieve the shoppingCart ID
                int shoppingCartId = 1; // Replace intShoppingCartID with your actual ID

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                    conn.Open();
                    string query = "DELETE FROM TCartItems WHERE intShoppingCartID = @intShoppingCartID AND intProductID = @intProductID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@intShoppingCartID", shoppingCartId);
                    cmd.Parameters.AddWithValue("@intProductID", productId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        // Return a success message or status
                        return Content("Item removed from cart successfully");
                    }
                    else {
                        // Return a message indicating that the item was not found in the cart
                        return Content("Item not found in the cart");
                    }
                }
            }
            catch (Exception ex) {
                // Return error message
                return Content("An error occurred: " + ex.Message);
            }
        }



        [HttpPost]
        public ActionResult ModifyQuantity(int productId, int change) {
            try {
                // Get the current shoppingCart's ID - You need to replace this with your actual method to retrieve the shoppingCart ID
                int shoppingCartId = 1; // Replace intShoppingCartID with your actual ID

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                    conn.Open();

                    // Check if the product exists in the cart
                    string checkQuery = "SELECT COUNT(*) FROM TCartItems WHERE intShoppingCartID = @intShoppingCartID AND intProductID = @intProductID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@intShoppingCartID", shoppingCartId);
                    checkCmd.Parameters.AddWithValue("@intProductID", productId);
                    int productCount = (int)checkCmd.ExecuteScalar();

                    if (productCount > 0) {
                        // Modify the quantity of the existing product
                        string updateQuery = "UPDATE TCartItems SET intQuantity = intQuantity + @change WHERE intShoppingCartID = @intShoppingCartID AND intProductID = @intProductID";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@intShoppingCartID", shoppingCartId);
                        updateCmd.Parameters.AddWithValue("@intProductID", productId);
                        updateCmd.Parameters.AddWithValue("@change", change);
                        updateCmd.ExecuteNonQuery();

                        // Check if the quantity became 0, if so, remove the item from the cart
                        if (change < 0) {
                            string removeQuery = "DELETE FROM TCartItems WHERE intShoppingCartID = @intShoppingCartID AND intProductID = @intProductID AND intQuantity = 0";
                            SqlCommand removeCmd = new SqlCommand(removeQuery, conn);
                            removeCmd.Parameters.AddWithValue("@intShoppingCartID", shoppingCartId);
                            removeCmd.Parameters.AddWithValue("@intProductID", productId);
                            removeCmd.ExecuteNonQuery();
                        }

                        // Return a success message or status
                        return Content("Quantity modified successfully");
                    }
                    else {
                        // Return a message indicating that the product is not found in the cart
                        return Content("Product not found in the cart");
                    }
                }
            }
            catch (Exception ex) {
                // Return error message
                return Content("An error occurred: " + ex.Message);
            }
        }








    }
}
