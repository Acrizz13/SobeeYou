using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class Treview
{
    public int IntReviewId { get; set; }

    public int IntUserId { get; set; }

    public int IntProductId { get; set; }

    public string StrReviewText { get; set; } = null!;

    public string StrRating { get; set; } = null!;

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual Tproduct IntProduct { get; set; } = null!;

    public virtual Tuser IntUser { get; set; } = null!;

    public virtual AspNetUser? User { get; set; }
}
