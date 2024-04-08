using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tadmin {
    [Key]
    public int IntAdminId { get; set; }

    public string StrAdminName { get; set; } = null!;
}
