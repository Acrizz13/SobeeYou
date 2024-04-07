using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tflavor {
    [Key]
    public int IntFlavorId { get; set; }

    public string StrFlavor { get; set; } = null!;
}
