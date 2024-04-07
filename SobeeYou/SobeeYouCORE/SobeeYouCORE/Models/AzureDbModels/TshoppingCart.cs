using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TshoppingCart
{
    public int IntShoppingCartId { get; set; }

    public DateTime? DtmDateCreated { get; set; }

    public DateTime? DtmDateLastUpdated { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual ICollection<TcartItem> TcartItems { get; set; } = new List<TcartItem>();

    public virtual AspNetUser? User { get; set; }
}
