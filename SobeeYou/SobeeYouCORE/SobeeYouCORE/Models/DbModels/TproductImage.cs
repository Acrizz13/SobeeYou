using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class TproductImage {
    [Key]
    public int IntProductImageId { get; set; }

    public string StrProductImageUrl { get; set; } = null!;
}
