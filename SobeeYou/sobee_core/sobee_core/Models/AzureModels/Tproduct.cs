using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sobee_core.Models.AzureModels;

public partial class Tproduct {
    [Key]
    public int IntProductId { get; set; }

    public string StrName { get; set; } = null!;

    public string StrDescription { get; set; } = null!;

    public decimal DecPrice { get; set; }

    public string StrStockAmount { get; set; } = null!;

    public virtual ICollection<TcartItem> TcartItems { get; set; } = new List<TcartItem>();

    public virtual ICollection<Tfavorite> Tfavorites { get; set; } = new List<Tfavorite>();

    public virtual ICollection<TorderItem> TorderItems { get; set; } = new List<TorderItem>();

    public virtual ICollection<TproductRecommendation> TproductRecommendations { get; set; } = new List<TproductRecommendation>();

    public virtual ICollection<Treview> Treviews { get; set; } = new List<Treview>();
}
