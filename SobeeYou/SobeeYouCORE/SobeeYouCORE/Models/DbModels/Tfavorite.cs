using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tfavorite {
    [Key]
    public int IntFavoriteId { get; set; }

    public string StrFavorite { get; set; } = null!;
}
