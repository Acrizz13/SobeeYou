using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sobee_core.Models.AzureModels;
using sobee_core.Models;
using Microsoft.EntityFrameworkCore;

namespace sobee_core.Areas.Identity.Pages.Account.Manage {
    public class FavoritesModel : PageModel {
        private readonly SobeecoredbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoritesModel(SobeecoredbContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public List<FavoriteViewModel> Favorites { get; set; }

        public async Task OnGetAsync() {
            var userId = _userManager.GetUserId(User);

            Favorites = await _context.Tfavorites
                .Where(f => f.UserId == userId)
                .Select(f => new FavoriteViewModel {
                    ProductId = f.IntProductId,
                    ProductName = f.IntProduct.StrName,
                    Price = f.IntProduct.DecPrice,
                    DateAdded = f.DtmDateAdded
                })
                .ToListAsync();
        }
    }
}
