using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class Tfavorite
{
    public int IntFavoriteId { get; set; }

    public string StrFavorite { get; set; } = null!;
}
