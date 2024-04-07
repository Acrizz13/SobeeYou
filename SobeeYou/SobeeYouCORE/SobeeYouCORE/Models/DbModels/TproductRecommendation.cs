using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class TproductRecommendation {
    [Key]
    public int IntProductRecommendationId { get; set; }

    public int IntUserId { get; set; }

    public int IntProductId { get; set; }

    public DateTime DtmTimeOfRecommendation { get; set; }

    public string StrRelevantScore { get; set; } = null!;

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual Tproduct IntProduct { get; set; } = null!;

    public virtual Tuser IntUser { get; set; } = null!;
}
