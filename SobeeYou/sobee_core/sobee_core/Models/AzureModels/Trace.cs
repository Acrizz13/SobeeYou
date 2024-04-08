using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Trace {
    [Key]
    public int IntRaceId { get; set; }

    public string StrRace { get; set; } = null!;
}
