namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCart {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoppingCart() {
            CartItems = new HashSet<TCartItem>();
        }

        [Key]
        public int intShoppingCartID { get; set; }

        public int intUserID { get; set; }

        public decimal decTotalPrice { get; set; }

        public DateTime dtmDateCreated { get; set; }

        public DateTime dtmLastUpdated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCartItem> CartItems { get; set; }
    }
}
