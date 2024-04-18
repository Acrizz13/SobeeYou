using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TrewardsTransaction {
    [Key]
    public int IntRewardsTransactionId { get; set; }

    public int IntTransactionTypeId { get; set; }

    public DateTime DtmTransactionDate { get; set; }

    public string StrPointAmount { get; set; } = null!;

    public virtual TtransactionType IntTransactionType { get; set; } = null!;
}
