using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SobeeYouCORE.Data;
using SobeeYouCORE.Models;
using SobeeYouCORE.Models.DbModels;
using SobeeYouCORE.Models.DbModels.Identity;


namespace SobeeYouCORE.Controllers {
    public class PurchaseController : Controller {

        // GET: Purchase

        private readonly SobeedbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private int shoppingCartID;


        public PurchaseController(SobeedbContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index() {
            // Retrieve the required product information using LINQ to Entities
            var products = _context.Tproducts
                .Select(p => new ProductDTO {
                    // Map the properties from the TProduct entity to the ProductDTO
                    intProductID = p.IntProductId,
                    strName = p.StrName,
                    decPrice = (decimal)p.DecPrice,
                    strStockAmount = p.StrStockAmount
                })
                .ToList(); // Execute the query and convert the result to a list

            // Pass the retrieved products to the view
            return View(products);
        }

    }
}
