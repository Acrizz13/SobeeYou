using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sobee_core.Models.AzureModels.Identity;

namespace sobee_core.Models.AzureModels;

public partial class TshoppingCart {
    [Key]
    public int IntShoppingCartId { get; set; }

    public DateTime? DtmDateCreated { get; set; }

    public DateTime? DtmDateLastUpdated { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual ICollection<TcartItem> TcartItems { get; set; } = new List<TcartItem>();

    public virtual AspNetUser? User { get; set; }
}
