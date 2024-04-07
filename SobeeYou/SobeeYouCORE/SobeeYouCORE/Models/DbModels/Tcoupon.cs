using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tcoupon
{
    public int IntCouponId { get; set; }

    public string StrCouponCode { get; set; } = null!;

    public string StrDiscountAmount { get; set; } = null!;

    public DateTime DtmExpirationDate { get; set; }
}
