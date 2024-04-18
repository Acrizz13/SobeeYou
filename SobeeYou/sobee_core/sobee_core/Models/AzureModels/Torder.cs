using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sobee_core.Models.Identity;

namespace sobee_core.Models.AzureModels;

public partial class Torder {
    [Key]
    public int IntOrderId { get; set; }

    public DateTime? DtmOrderDate { get; set; }

    public decimal? DecTotalAmount { get; set; }

    public int? IntShippingStatusId { get; set; }

    public string? StrShippingAddress { get; set; }

    public string? StrTrackingNumber { get; set; }

    public int? IntPaymentMethodId { get; set; }

    public string? StrOrderStatus { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual TpaymentMethod? IntPaymentMethod { get; set; }

    public virtual TshippingStatus? IntShippingStatus { get; set; }

    public virtual ICollection<TorderItem> TorderItems { get; set; } = new List<TorderItem>();

    public virtual AspNetUser? User { get; set; }
}
