using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TorderItem {
    [Key]
    public int IntOrderItemId { get; set; }

    public int? IntOrderId { get; set; }

    public int? IntProductId { get; set; }

    public int? IntQuantity { get; set; }

    public decimal? MonPricePerUnit { get; set; }

    public virtual Torder? IntOrder { get; set; }

    public virtual Tproduct? IntProduct { get; set; }
}
