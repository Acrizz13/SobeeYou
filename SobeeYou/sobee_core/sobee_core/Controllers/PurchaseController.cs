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


        public IActionResult Index(decimal? minPrice, decimal? maxPrice, string sortBy) {
            var products = _context.Tproducts.AsQueryable();

            // Filter by price range
            if (minPrice.HasValue) {
                products = products.Where(p => p.DecPrice >= minPrice.Value);
            }
            if (maxPrice.HasValue) {
                products = products.Where(p => p.DecPrice <= maxPrice.Value);
            }

            // Sort the products
            switch (sortBy) {
                case "price-asc":
                    products = products.OrderBy(p => p.DecPrice);
                    break;
                case "price-desc":
                    products = products.OrderByDescending(p => p.DecPrice);
                    break;
                case "rating-asc":
                    products = products.OrderBy(p => p.Treviews.Any() ? p.Treviews.Average(r => r.IntRating) : 0);
                    break;
                case "rating-desc":
                    products = products.OrderByDescending(p => p.Treviews.Any() ? p.Treviews.Average(r => r.IntRating) : 0);
                    break;
                default:
                    // Default sorting logic
                    break;
            }

            var productsDto = products.Select(p => new ProductDTO {
                intProductID = p.IntProductId,
                strName = p.StrName,
                decPrice = (decimal)p.DecPrice,
                strStockAmount = p.StrStockAmount,
                AverageRating = p.Treviews.Any() ? Math.Round(p.Treviews.Average(r => r.IntRating ?? 0), 1) : 0
            }).ToList();

            return View(productsDto);
        }

        // shows detailed view of products
        public ActionResult Details(int id) {
            var product = _context.Tproducts
                .Where(p => p.IntProductId == id)
                .Select(p => new ProductDTO {
                    intProductID = p.IntProductId,
                    strName = p.StrName,
                    decPrice = (decimal)p.DecPrice,
                    strStockAmount = p.StrStockAmount
                })
                .FirstOrDefault();

            // Calculate the average rating for the product
            var averageRating = _context.Treviews
                .Where(r => r.IntProductId == id)
                .Select(r => r.IntRating)
                .DefaultIfEmpty()
                .Average();

            ViewBag.AverageRating = averageRating.HasValue ? Math.Round(averageRating.Value, 1) : 0;

            // Retrieve the count of reviews for each rating value (1 to 5)
            var ratingCounts = Enumerable.Range(1, 5)
                .Select(rating => new {
                    Rating = rating,
                    Count = _context.Treviews.Count(r => r.IntProductId == id && r.IntRating == rating)
                })
                .ToList();

            ViewBag.RatingCounts = ratingCounts;

            // Calculate the total number of reviews
            var totalReviews = _context.Treviews.Count(r => r.IntProductId == id);
            ViewBag.TotalReviews = totalReviews;

            return View(product);
        }





        [HttpPost]
        [Authorize]
        public ActionResult SubmitRating(int productId, int rating) {
            // Get the current user's ID
            var userId = _userManager.GetUserId(User);

            // Check if the user has already rated this product
            var existingReview = _context.Treviews.FirstOrDefault(r => r.IntProductId == productId && r.UserId == userId);

            if (existingReview != null) {
                // Update the existing review
                existingReview.IntRating = rating;
                _context.SaveChanges();
            }
            else {
                // Create a new review
                var review = new Treview {
                    IntReviewId = GenerateReviewId(),
                    IntProductId = productId,
                    UserId = userId,
                    IntRating = rating,
                    StrRating = rating.ToString(),
                    StrReviewText = "Please provide a review text"
                };

                _context.Treviews.Add(review);
                _context.SaveChanges();
            }

            return Json(new { success = true });
        }


        private int GenerateReviewId() {
            // Get the maximum review ID from the database
            var maxReviewId = _context.Treviews.Max(r => (int?)r.IntReviewId) ?? 0;

            // Increment the maximum review ID by 1 to generate the next available ID
            return maxReviewId + 1;
        }


    }
}
