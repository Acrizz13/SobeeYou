using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Trace {
    [Key]
    public int IntRaceId { get; set; }

    public string StrRace { get; set; } = null!;
}
