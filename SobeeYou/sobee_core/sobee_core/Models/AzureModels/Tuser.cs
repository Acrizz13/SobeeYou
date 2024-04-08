using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tuser {
    [Key]
    public int IntUserId { get; set; }

    public string? StrShippingAddress { get; set; }

    public string StrEmail { get; set; } = null!;

    public string StrPassword { get; set; } = null!;

    public int? IntUserRoleId { get; set; }

    public string? StrBillingAddress { get; set; }

    public string? StrFirstName { get; set; }

    public string? StrLastName { get; set; }

    public DateTime? StrDateCreated { get; set; }

    public DateTime? StrLastLoginDate { get; set; }

    public string? Id { get; set; }

    public virtual TuserRole? IntUserRole { get; set; }

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();

    public virtual ICollection<Torder> Torders { get; set; } = new List<Torder>();

    public virtual ICollection<TproductRecommendation> TproductRecommendations { get; set; } = new List<TproductRecommendation>();

    public virtual ICollection<Treview> Treviews { get; set; } = new List<Treview>();
}
