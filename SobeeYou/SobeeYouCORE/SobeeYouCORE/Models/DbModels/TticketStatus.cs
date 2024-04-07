using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels;

public partial class TticketStatus {
    [Key]
    public int IntTicketStatusId { get; set; }

    public string StrTicketStatus { get; set; } = null!;

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();
}
