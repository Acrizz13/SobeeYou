using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class TticketStatus {
    [Key]
    public int IntTicketStatusId { get; set; }

    public string StrTicketStatus { get; set; } = null!;

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();
}
