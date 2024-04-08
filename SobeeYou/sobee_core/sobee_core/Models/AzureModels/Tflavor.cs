using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tflavor {
    [Key]
    public int IntFlavorId { get; set; }

    public string StrFlavor { get; set; } = null!;
}
