using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TticketCategory
{
    public int IntTicketCategoryId { get; set; }

    public string StrTicketCategory { get; set; } = null!;

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();
}
