using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TrewardsPoint {
    [Key]
    public int IntRewardsPointsId { get; set; }

    public string StrPointsBalance { get; set; } = null!;

    public string StrTotalPointsEarned { get; set; } = null!;

    public string StrTotalPointsRedeemed { get; set; } = null!;
}
