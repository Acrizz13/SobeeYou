using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sobee_core.Models.Identity;

namespace sobee_core.Models.AzureModels;

public partial class TcustomerServiceTicket {
    [Key]
    public int IntCustomerServiceTicketId { get; set; }

    public int IntTicketCategoryId { get; set; }

    public int IntTicketStatusId { get; set; }

    public DateTime DtmTimeOfSubmission { get; set; }

    public string StrDescription { get; set; } = null!;

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual TticketCategory IntTicketCategory { get; set; } = null!;

    public virtual TticketStatus IntTicketStatus { get; set; } = null!;

    public virtual AspNetUser? User { get; set; }
}
