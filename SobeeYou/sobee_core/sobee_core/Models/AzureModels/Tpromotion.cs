using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tpromotion {
    [Key]
    public int IntPromotionId { get; set; }

    public string StrPromoCode { get; set; } = null!;

    public string StrDiscountPercentage { get; set; } = null!;

    public DateTime DtmExpirationDate { get; set; }

    public decimal DecDiscountPercentage { get; set; }
}
