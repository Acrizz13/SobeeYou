namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TOrders")]
    public partial class TOrder {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOrder() {
            TOrderItems = new HashSet<TOrderItem>();
        }

        [Key]
        public int intOrderID { get; set; }

        public int intUserID { get; set; }

        public DateTime dtmOrderDate { get; set; }

        public decimal decTotalAmount { get; set; }

        public int intShippingStatusID { get; set; }

        [StringLength(255)]
        public string strShippingAddress { get; set; }

        [StringLength(50)]
        public string strTrackingNumber { get; set; }

        [StringLength(50)]
        public string strOrderStatus { get; set; }

        public int intPaymentMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOrderItem> TOrderItems { get; set; }

        public virtual TUser TUser { get; set; }

        public virtual TPaymentMethod TPaymentMethod { get; set; }

        public virtual TShippingStatu TShippingStatu { get; set; }
    }
}
