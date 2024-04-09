using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sobee_core.Models;
using sobee_core.Data;
using sobee_core.Models.AzureModels;
using sobee_core.Models.AzureModels.Identity;


namespace sobee_core.Controllers {
	public class PurchaseController : Controller {

		// GET: Purchase

		private readonly SobeecoredbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private int shoppingCartID;


		public PurchaseController(SobeecoredbContext context, UserManager<ApplicationUser> userManager) {
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

		// shows detailed view of products
		public ActionResult Details(int id) {

			var product = _context.Tproducts
				.Where(p => p.IntProductId == id)
				.Select(p => new ProductDTO {
					intProductID = p.IntProductId,
					strName = p.StrName,
					decPrice = (decimal)p.DecPrice,
					strStockAmount = p.StrStockAmount,
					// Add additional properties as needed
				})
				.FirstOrDefault();

			//if (product == null) {
			//	return HttpNotFound(); 
			//}

			return View(product);
		}



	}





}
