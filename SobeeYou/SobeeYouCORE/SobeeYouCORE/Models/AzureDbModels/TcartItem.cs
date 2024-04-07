using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TcartItem
{
    public int IntCartItemId { get; set; }

    public int? IntShoppingCartId { get; set; }

    public int? IntProductId { get; set; }

    public int? IntQuantity { get; set; }

    public DateTime? DtmDateAdded { get; set; }

    public virtual Tproduct? IntProduct { get; set; }

    public virtual TshoppingCart? IntShoppingCart { get; set; }
}
