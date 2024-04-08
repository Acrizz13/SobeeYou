using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TshippingMethod {
    [Key]
    public int IntShippingMethodId { get; set; }

    public string StrShippingName { get; set; } = null!;

    public string StrBillingAddress { get; set; } = null!;

    public DateTime DtmEstimatedDelivery { get; set; }

    public string StrCost { get; set; } = null!;
}
