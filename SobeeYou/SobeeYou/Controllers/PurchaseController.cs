using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            List<TProduct> products = new List<TProduct>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["AppDBConnect"];
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT intProductID, strName, strPrice, strStockAmount FROM TProducts", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new TProduct
                        {
                            intProductID = (int)reader["intProductID"],
                            strName = reader["strName"].ToString(),
                            strPrice = reader["strPrice"].ToString(),
                            strStockAmount = reader["strStockAmount"].ToString()
                        });
                    }
                }
            }

            return View(products);
        }
    }
}