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

            return View();

        }

        // Gets total number of items in cart, works with Scripts/dynamicShoppingCart.js  
        public int GetTotalCartItems() {
            // Assuming you have a way to get the current ShoppingCartID's ID
            string intShoppingCartID = "1"; // Replace "current_cart_id" with the actual ShoppingCartID 

            List<CartItems> cartItems = new List<CartItems>();
            int intTotalCartItems = 0; // stores the total that will be returned

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                conn.Open();

                // Retrieve the user's cart items
                string query = "SELECT * FROM TCartItems WHERE @intShoppingCartID = @intShoppingCartID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@intShoppingCartID", intShoppingCartID);

                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        CartItems item = new CartItems {
                            intCartItemID = (int)reader["intCartItemID"],
                            intShoppingCartID = (int)reader["intShoppingCartID"],
                            intProductID = (int)reader["intProductID"],
                            intQuantity = (int)reader["intQuantity"],
                            dtmDateAdded = (DateTime)reader["dtmDateAdded"]
                        };
                        cartItems.Add(item);
                    }
                }


                // Retrieve the total number of items in the user's cart
                string countQuery = "SELECT COUNT(*) FROM TCartItems WHERE intShoppingCartID = @intShoppingCartID";
                SqlCommand countCmd = new SqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@intShoppingCartID", intShoppingCartID);
                intTotalCartItems = (int)countCmd.ExecuteScalar();
            }
            return intTotalCartItems;
        }



        [HttpPost]
        public ActionResult AddToCart(CartItems newItem) {
            {
                // Get the current shoppingCart's ID - You need to replace this with your actual method to retrieve the shoppingCart ID
                newItem.intShoppingCartID = 1; // Replace intShoppingCartID with your actual ID

                // Set the current date/time
                newItem.dtmDateAdded = DateTime.Now;

                // Add the item to the shopping cart in the database
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["AppDBConnect"])) {
                    conn.Open();
                    string query = "INSERT INTO TCartItems (intShoppingCartID, intProductID, intQuantity, dtmDateAdded) VALUES (@intShoppingCartID, @intProductID, @intQuantity, @dtmDateAdded)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@intShoppingCartID", newItem.intShoppingCartID); // Assuming this is the correct property for ShoppingCartID
                    cmd.Parameters.AddWithValue("@intProductID", newItem.intProductID);
                    cmd.Parameters.AddWithValue("@intQuantity", newItem.intQuantity);
                    cmd.Parameters.AddWithValue("@dtmDateAdded", newItem.dtmDateAdded);
                    cmd.ExecuteNonQuery();
                }


                // Return a success message or status
                return Content("Item added to cart successfully");

            }
        }
    }
}
