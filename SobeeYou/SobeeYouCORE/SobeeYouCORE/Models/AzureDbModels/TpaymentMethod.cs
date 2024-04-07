using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TpaymentMethod
{
    public int IntPaymentMethod { get; set; }

    public string? StrPaymentMethodName { get; set; }

    public virtual ICollection<Torder> Torders { get; set; } = new List<Torder>();
}
