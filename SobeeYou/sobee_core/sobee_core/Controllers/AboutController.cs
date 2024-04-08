using Microsoft.AspNetCore.Mvc;

namespace sobee_core.Controllers {
    public class AboutController : Controller {

        public IActionResult Index() {
            return View();      // returns view
        }
    }
}
