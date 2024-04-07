using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class TshippingMethod
{
    public int IntShippingMethodId { get; set; }

    public string StrShippingName { get; set; } = null!;

    public string StrBillingAddress { get; set; } = null!;

    public DateTime DtmEstimatedDelivery { get; set; }

    public string StrCost { get; set; } = null!;
}
