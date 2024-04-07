using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tstate {
    [Key]
    public int IntStateId { get; set; }

    public string StrState { get; set; } = null!;
}
