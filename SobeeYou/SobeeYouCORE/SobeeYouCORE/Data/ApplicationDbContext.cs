using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SobeeYouCORE.Models;

namespace SobeeYouCORE.Data {

	// db context for identity functionality
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) {
		}
	}
}
