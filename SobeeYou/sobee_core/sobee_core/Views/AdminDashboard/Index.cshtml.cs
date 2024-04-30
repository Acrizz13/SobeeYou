using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sobee_core.Views.AdminDashboard {
    public class IndexModel : PageModel {
        public IActionResult OnGet() {
            return new RedirectResult("/Start");
        }
    }
}