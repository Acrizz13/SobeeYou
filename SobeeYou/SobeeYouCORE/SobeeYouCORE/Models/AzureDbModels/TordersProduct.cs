using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TordersProduct
{
    public int IntOrdersProductId { get; set; }

    public int IntProductId { get; set; }

    public string StrOrdersProduct { get; set; } = null!;

    public virtual Tproduct IntProduct { get; set; } = null!;
}
