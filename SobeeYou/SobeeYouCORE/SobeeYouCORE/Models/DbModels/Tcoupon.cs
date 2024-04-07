using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tcoupon {
    [Key]
    public int IntCouponId { get; set; }

    public string StrCouponCode { get; set; } = null!;

    public string StrDiscountAmount { get; set; } = null!;

    public DateTime DtmExpirationDate { get; set; }
}
