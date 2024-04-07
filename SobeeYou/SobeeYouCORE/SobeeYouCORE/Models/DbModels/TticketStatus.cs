using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class TticketStatus
{
    public int IntTicketStatusId { get; set; }

    public string StrTicketStatus { get; set; } = null!;

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();
}
