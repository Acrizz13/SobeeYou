using Microsoft.AspNetCore.Identity;
using sobee_core.Models;


namespace sobee_core.Controllers {

	public class CustomPasswordHasher : IPasswordHasher<ApplicationUser> {
		public string HashPassword(ApplicationUser user, string password) {
			return password;
		}

		public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword) {
			return hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
		}
	}
}
