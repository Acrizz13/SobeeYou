using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tpermission {
    [Key]
    public int IntPermissionId { get; set; }

    public string StrPermissionName { get; set; } = null!;

    public string StrDescription { get; set; } = null!;
}
