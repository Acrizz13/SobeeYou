using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class TshippingStatus
{
    public int IntShippingStatusId { get; set; }

    public string StrShippingStatus { get; set; } = null!;

    public virtual ICollection<Torder> Torders { get; set; } = new List<Torder>();
}
