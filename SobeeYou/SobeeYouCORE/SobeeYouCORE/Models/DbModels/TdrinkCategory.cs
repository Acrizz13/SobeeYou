using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class TdrinkCategory {
    [Key]
    public int IntDrinkCategoryId { get; set; }

    public string StrDrinkCategory { get; set; } = null!;
}
