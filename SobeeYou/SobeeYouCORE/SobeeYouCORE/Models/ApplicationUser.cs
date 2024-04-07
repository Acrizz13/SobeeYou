using Microsoft.AspNetCore.Identity;
using SobeeYouCORE.Models.DbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SobeeYouCORE.Models {

	// custom identity user model that is associated with with existing db tables and Identity default tables 
	public class ApplicationUser : IdentityUser {
		public string strShippingAddress { get; set; }
		public string strBillingAddress { get; set; }
		public string strFirstName { get; set; }
		public string strLastName { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime LastLoginDate { get; set; } = DateTime.Now;
		public int intUserRoleID { get; set; }

		public virtual ICollection<TshoppingCart> ShoppingCarts { get; set; }
	}
}
