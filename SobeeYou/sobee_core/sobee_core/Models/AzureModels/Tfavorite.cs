using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tfavorite {
    [Key]
    public int IntFavoriteId { get; set; }

    public string StrFavorite { get; set; } = null!;
}
