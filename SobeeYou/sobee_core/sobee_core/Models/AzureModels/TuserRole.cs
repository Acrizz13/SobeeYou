using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TuserRole {
    [Key]
    public int IntUserRoleId { get; set; }

    public string StrRole { get; set; } = null!;

    public virtual ICollection<Tuser> Tusers { get; set; } = new List<Tuser>();
}
