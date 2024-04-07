using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tingredient {
    [Key]
    public int IntIngredientId { get; set; }

    public string StrIngredient { get; set; } = null!;
}
