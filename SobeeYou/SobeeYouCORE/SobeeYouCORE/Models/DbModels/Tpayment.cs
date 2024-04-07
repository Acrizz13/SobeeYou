using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tpayment {
    [Key]
    public int IntPaymentId { get; set; }

    public string StrBillingAddress { get; set; } = null!;

    public int? IntPaymentMethodId { get; set; }

    public int? IntPaymentMethod { get; set; }
}
