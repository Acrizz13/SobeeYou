using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sobee_core.Models.Identity;

namespace sobee_core.Models.AzureModels;

public partial class Treview {
	[Key]
	public int IntReviewId { get; set; }

	public int IntProductId { get; set; }

	public string StrReviewText { get; set; } = null!;

	public int IntRating { get; set; }

	public DateTime DtmReviewDate { get; set; }

	public string? UserId { get; set; }

	public string? SessionId { get; set; }

	public virtual Tproduct IntProduct { get; set; } = null!;

	public virtual ICollection<TReviewReplies> TReviewReplies { get; set; } = new List<TReviewReplies>();

	public virtual AspNetUser? User { get; set; }

}
