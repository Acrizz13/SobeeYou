using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TrewardsOption {
    [Key]
    public int IntRewardsOptionsId { get; set; }

    public string StrOptionName { get; set; } = null!;

    public string StrPointsRequired { get; set; } = null!;

    public string StrDescription { get; set; } = null!;
}
