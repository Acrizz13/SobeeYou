using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TpaymentStatus {
    [Key]
    public int IntPaymentStatusId { get; set; }

    public string? StrPaymentStatus { get; set; }
}
