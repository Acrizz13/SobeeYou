using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class Tpermission
{
    public int IntPermissionId { get; set; }

    public string StrPermissionName { get; set; } = null!;

    public string StrDescription { get; set; } = null!;
}
