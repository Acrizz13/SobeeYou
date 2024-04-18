using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TproductRecommendation {
    [Key]
    public int IntProductRecommendationId { get; set; }

    public int IntProductId { get; set; }

    public int IntInteractionId { get; set; }

    public DateTime DtmTimeOfRecommendation { get; set; }

    public int IntRelevantScore { get; set; }

    public virtual Tinteraction IntInteraction { get; set; } = null!;

    public virtual Tproduct IntProduct { get; set; } = null!;
}
