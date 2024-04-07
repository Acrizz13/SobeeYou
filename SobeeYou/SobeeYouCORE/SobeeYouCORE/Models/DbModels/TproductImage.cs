using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class TproductImage
{
    public int IntProductImageId { get; set; }

    public string StrProductImageUrl { get; set; } = null!;
}
