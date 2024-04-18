using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tpayment {
    [Key]
    public int IntPaymentId { get; set; }

    public string StrBillingAddress { get; set; } = null!;

    public int? IntPaymentMethodId { get; set; }

    public int? IntPaymentMethod { get; set; }

    public virtual TpaymentMethod? IntPaymentMethodNavigation { get; set; }
}
