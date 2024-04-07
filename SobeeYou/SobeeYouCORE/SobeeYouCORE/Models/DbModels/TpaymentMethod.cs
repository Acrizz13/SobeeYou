using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class TpaymentMethod {
    [Key]
    public int IntPaymentMethod { get; set; }

    public string? StrPaymentMethodName { get; set; }

    public virtual ICollection<Torder> Torders { get; set; } = new List<Torder>();
}
