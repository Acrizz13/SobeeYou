using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TtransactionType {
    [Key]
    public int IntTransactionTypeId { get; set; }

    public string StrTransactionType { get; set; } = null!;

    public virtual ICollection<TrewardsTransaction> TrewardsTransactions { get; set; } = new List<TrewardsTransaction>();
}
