using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TdrinkCategory {
    [Key]
    public int IntDrinkCategoryId { get; set; }

    public string StrName { get; set; } = null!;

    public string StrDescription { get; set; } = null!;
}
