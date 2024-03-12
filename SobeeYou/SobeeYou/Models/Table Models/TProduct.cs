namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TProducts")]
    public partial class TProduct {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TProduct() {
            TCartItems = new HashSet<TCartItem>();
            TOrderItems = new HashSet<TOrderItem>();
            TOrdersProducts = new HashSet<TOrdersProduct>();
            TProductRecommendations = new HashSet<TProductRecommendation>();
            TReviews = new HashSet<TReview>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string strName { get; set; }

        [Required]
        [StringLength(255)]
        public string strStockAmount { get; set; }

        public decimal decPrice { get; set; }

        [StringLength(50)]
        public string strPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCartItem> TCartItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOrderItem> TOrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOrdersProduct> TOrdersProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TProductRecommendation> TProductRecommendations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TReview> TReviews { get; set; }
    }
}
