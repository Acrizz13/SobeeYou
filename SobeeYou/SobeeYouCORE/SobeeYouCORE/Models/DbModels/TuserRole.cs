using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class TuserRole
{
    public int IntUserRoleId { get; set; }

    public string StrRole { get; set; } = null!;

    public virtual ICollection<Tuser> Tusers { get; set; } = new List<Tuser>();
}
