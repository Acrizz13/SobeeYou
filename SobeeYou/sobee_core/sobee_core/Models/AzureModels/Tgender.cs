﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tgender {
    [Key]
    public int IntGenderId { get; set; }

    public string StrGender { get; set; } = null!;
}
