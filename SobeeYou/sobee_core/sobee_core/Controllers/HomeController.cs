using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sobee_core.Models;
using sobee_core.Models.AzureModels;
using sobee_core.Models.ViewModels;
using System.Diagnostics;

namespace sobee_core.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;
		private readonly SobeecoredbContext _context;

		public HomeController(ILogger<HomeController> logger, SobeecoredbContext context) {
			_logger = logger;
			_context = context;
		}

		public IActionResult Index() {
			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		public IActionResult Get5StarReviews() {
			var reviews = _context.Treviews
				.Where(r => r.IntRating == 5)
				.OrderByDescending(r => r.DtmReviewDate)
				.Select(r => new {
					ReviewText = r.StrReviewText,
					UserFirstName = r.User != null ? r.User.StrFirstName : "Anonymous",
					ReviewDate = r.DtmReviewDate
				})
				.ToList();

			return Json(reviews);
		}


	}
}
