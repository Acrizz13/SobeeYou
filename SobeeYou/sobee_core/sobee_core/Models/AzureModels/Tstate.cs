using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tstate {
    [Key]
    public int IntStateId { get; set; }

    public string StrState { get; set; } = null!;
}
