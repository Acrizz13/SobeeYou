using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tpromotion {
    [Key]
    public int IntPromotionId { get; set; }

    public string StrPromoCode { get; set; } = null!;

    public string StrDiscountPercentage { get; set; } = null!;

    public DateTime DtmExpirationDate { get; set; }
}
