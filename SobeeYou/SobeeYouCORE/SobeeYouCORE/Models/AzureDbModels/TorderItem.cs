using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TorderItem
{
    public int IntOrderItemId { get; set; }

    public int? IntOrderId { get; set; }

    public int? IntProductId { get; set; }

    public int? IntQuantity { get; set; }

    public decimal? MonPricePerUnit { get; set; }

    public virtual Torder? IntOrder { get; set; }

    public virtual Tproduct? IntProduct { get; set; }
}
