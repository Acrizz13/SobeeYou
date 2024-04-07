using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tpermission
{
    public int IntPermissionId { get; set; }

    public string StrPermissionName { get; set; } = null!;

    public string StrDescription { get; set; } = null!;
}
