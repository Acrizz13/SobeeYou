using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tingredient {
    [Key]
    public int IntIngredientId { get; set; }

    public string StrIngredient { get; set; } = null!;
}
