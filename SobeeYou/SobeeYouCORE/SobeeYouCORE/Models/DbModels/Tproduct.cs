using System;
using System.Collections.Generic;

namespace SobeeYouCORE.Models.DbModels;

public partial class Tproduct
{
    public int IntProductId { get; set; }

    public string StrName { get; set; } = null!;

    public string StrStockAmount { get; set; } = null!;

    public decimal? DecPrice { get; set; }

    public string? StrPrice { get; set; }

    public virtual ICollection<TcartItem> TcartItems { get; set; } = new List<TcartItem>();

    public virtual ICollection<TorderItem> TorderItems { get; set; } = new List<TorderItem>();

    public virtual ICollection<TordersProduct> TordersProducts { get; set; } = new List<TordersProduct>();

    public virtual ICollection<TproductRecommendation> TproductRecommendations { get; set; } = new List<TproductRecommendation>();

    public virtual ICollection<Treview> Treviews { get; set; } = new List<Treview>();
}
