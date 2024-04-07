using Microsoft.AspNetCore.Mvc;

namespace SobeeYouCORE.Controllers {
	public class AboutController : Controller {

		public IActionResult Index() {
			return View();      // returns view
		}
	}
}
