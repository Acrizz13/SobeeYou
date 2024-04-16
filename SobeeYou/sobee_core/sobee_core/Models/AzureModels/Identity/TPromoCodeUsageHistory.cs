using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels.Identity {
	public class TPromoCodeUsageHistory {
		[Key]
		public int Id { get; set; }
		public int ShoppingCartId { get; set; }
		public string? PromoCode { get; set; }
		public DateTime UsedDateTime { get; set; }

		// Foreign key relationship
		public virtual TshoppingCart TShoppingCart { get; set; }
	}
}
