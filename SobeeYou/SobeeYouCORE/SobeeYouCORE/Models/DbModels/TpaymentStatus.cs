using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class TpaymentStatus {
    [Key]
    public int IntPaymentStatusId { get; set; }

    public string? StrPaymentStatus { get; set; }
}
