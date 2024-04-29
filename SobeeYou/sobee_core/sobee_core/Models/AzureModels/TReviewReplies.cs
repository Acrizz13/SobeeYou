using sobee_core.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels {
	public class TReviewReplies {
		[Key]
		public int IntReviewReplyID { get; set; }

		public int IntReviewId { get; set; }
		public string? UserId { get; set; }

		public string? content { get; set; }

		public DateTime created_at { get; set; }

		public virtual Treview? Treview { get; set; }

		public virtual AspNetUser? User { get; set; }



	}
}
