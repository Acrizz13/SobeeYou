using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TticketCategory {
    [Key]
    public int IntTicketCategoryId { get; set; }

    public string StrTicketCategory { get; set; } = null!;

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();
}
