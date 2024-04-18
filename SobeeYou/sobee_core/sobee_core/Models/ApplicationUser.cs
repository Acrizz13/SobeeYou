using Microsoft.AspNetCore.Identity;
using sobee_core.Models.AzureModels;

namespace sobee_core.Models {
    // custom identity user model that is associated with with existing db tables and Identity default tables 
    public class ApplicationUser : IdentityUser {
        public string strShippingAddress { get; set; }
        public string strBillingAddress { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; } = DateTime.Now;
   

        public virtual ICollection<TshoppingCart> ShoppingCarts { get; set; }
    }
}
