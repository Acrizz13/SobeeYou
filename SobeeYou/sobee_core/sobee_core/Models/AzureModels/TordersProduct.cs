using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TordersProduct {
    [Key]
    public int IntOrdersProductId { get; set; }

    public int IntProductId { get; set; }

    public string StrOrdersProduct { get; set; } = null!;

    public virtual Tproduct IntProduct { get; set; } = null!;
}
