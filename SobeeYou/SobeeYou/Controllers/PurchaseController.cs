using SobeeYou.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobeeYou.Controllers {
    public class PurchaseController : Controller {
        // GET: Purchase
        public ActionResult Index() {
            using (var context = new TableModels()) {
                // Retrieve the required product information using LINQ to Entities
                var products = context.TProducts
                    .Select(p => new ProductDTO {
                        // Map the properties from the TProduct entity to the ProductDTO
                        intProductID = p.intProductID,
                        strName = p.strName,
                        decPrice = p.decPrice,
                        strStockAmount = p.strStockAmount
                    })
                    .ToList(); // Execute the query and convert the result to a list

                // Pass the retrieved products to the view
                return View(products);
            }
        }


    }
}