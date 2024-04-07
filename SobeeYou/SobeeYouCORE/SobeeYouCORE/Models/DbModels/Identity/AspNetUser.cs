using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SobeeYouCORE.Models.DbModels.Identity;

public partial class AspNetUser {
    [Key]
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public int IntUserRoleId { get; set; }

    public string StrBillingAddress { get; set; } = null!;

    public string StrFirstName { get; set; } = null!;

    public string StrLastName { get; set; } = null!;

    public string StrShippingAddress { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<TcustomerServiceTicket> TcustomerServiceTickets { get; set; } = new List<TcustomerServiceTicket>();

    public virtual ICollection<Torder> Torders { get; set; } = new List<Torder>();

    public virtual ICollection<TproductRecommendation> TproductRecommendations { get; set; } = new List<TproductRecommendation>();

    public virtual ICollection<Treview> Treviews { get; set; } = new List<Treview>();

    public virtual ICollection<TshoppingCart> TshoppingCarts { get; set; } = new List<TshoppingCart>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
