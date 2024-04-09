using Microsoft.AspNetCore.Mvc;

namespace sobee_core.Controllers {
	public class FAQController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
