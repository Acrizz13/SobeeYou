using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tinteraction {
    [Key]
    public int IntInteractionId { get; set; }

    public string StrName { get; set; } = null!;

    public string StrDescription { get; set; } = null!;

    public virtual ICollection<TproductRecommendation> TproductRecommendations { get; set; } = new List<TproductRecommendation>();
}
