using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class Torder
{
    public int IntOrderId { get; set; }

    public int? IntUserId { get; set; }

    public DateTime? DtmOrderDate { get; set; }

    public decimal? DecTotalAmount { get; set; }

    public int? IntShippingStatusId { get; set; }

    public string? StrShippingAddress { get; set; }

    public string? StrTrackingNumber { get; set; }

    public int? IntPaymentMethod { get; set; }

    public string? StrOrderStatus { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual TpaymentMethod? IntPaymentMethodNavigation { get; set; }

    public virtual TshippingStatus? IntShippingStatus { get; set; }

    public virtual Tuser? IntUser { get; set; }

    public virtual ICollection<TorderItem> TorderItems { get; set; } = new List<TorderItem>();

    public virtual AspNetUser? User { get; set; }
}
