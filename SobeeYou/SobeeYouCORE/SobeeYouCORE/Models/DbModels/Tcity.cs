using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tcity {
    [Key]
    public int IntCityId { get; set; }

    public string StrCity { get; set; } = null!;
}
