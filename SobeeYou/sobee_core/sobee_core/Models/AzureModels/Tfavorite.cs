using sobee_core.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tfavorite {
    [Key]
    public int IntFavoriteId { get; set; }

    public int IntProductId { get; set; }

    public DateTime DtmDateAdded { get; set; }

    public string? UserId { get; set; }

    public virtual AspNetUser? User { get; set; }

    public virtual Tproduct IntProduct { get; set; } = null!;
}
