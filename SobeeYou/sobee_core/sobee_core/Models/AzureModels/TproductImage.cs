using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TproductImage {
    [Key]
    public int IntProductImageId { get; set; }

    public string StrProductImageUrl { get; set; } = null!;
}
