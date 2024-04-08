using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tcity {
    [Key]
    public int IntCityId { get; set; }

    public string StrCity { get; set; } = null!;
}
