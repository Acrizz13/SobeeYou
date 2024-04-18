using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TpaymentMethod {
    [Key]
    public int IntPaymentMethodId { get; set; }

    public string StrCreditCardDetails { get; set; } = null!;

    public string StrBillingAddress { get; set; } = null!;

    public string StrDescription { get; set; } = null!;

    public virtual ICollection<Torder> Torders { get; set; } = new List<Torder>();

    public virtual ICollection<Tpayment> Tpayments { get; set; } = new List<Tpayment>();
}
