using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tpromotion
{
    public int IntPromotionId { get; set; }

    public string StrPromoCode { get; set; } = null!;

    public string StrDiscountPercentage { get; set; } = null!;

    public DateTime DtmExpirationDate { get; set; }
}
