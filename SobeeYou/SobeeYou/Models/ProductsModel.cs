namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductsModel {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductsModel() {
            CartItems = new HashSet<TCartItem>();
        }

        [Key]
        public int intProductID { get; set; }

        public string strName { get; set; }

        public string strPrice { get; set; }

        public string strStockAmount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCartItem> CartItems { get; set; }
    }
}
