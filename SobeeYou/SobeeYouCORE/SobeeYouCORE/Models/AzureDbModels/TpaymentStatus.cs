using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TpaymentStatus
{
    public int IntPaymentStatusId { get; set; }

    public string? StrPaymentStatus { get; set; }
}
