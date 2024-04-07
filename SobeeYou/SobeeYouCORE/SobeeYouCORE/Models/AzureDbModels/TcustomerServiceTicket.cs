using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class TcustomerServiceTicket
{
    public int IntCustomerServiceTicketId { get; set; }

    public int IntUserId { get; set; }

    public int IntTicketCategoryId { get; set; }

    public int IntTicketStatusId { get; set; }

    public DateTime DtmTimeOfSubmission { get; set; }

    public string StrDescription { get; set; } = null!;

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual TticketCategory IntTicketCategory { get; set; } = null!;

    public virtual TticketStatus IntTicketStatus { get; set; } = null!;

    public virtual Tuser IntUser { get; set; } = null!;

    public virtual AspNetUser? User { get; set; }
}
