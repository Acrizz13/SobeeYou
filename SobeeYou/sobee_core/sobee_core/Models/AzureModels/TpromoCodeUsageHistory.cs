using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TpromoCodeUsageHistory {
    [Key]
    public int IntUsageHistoryId { get; set; }

    public int IntShoppingCartId { get; set; }

    public string PromoCode { get; set; } = null!;

    public DateTime? UsedDateTime { get; set; }

    public virtual TshoppingCart IntShoppingCart { get; set; } = null!;
}
