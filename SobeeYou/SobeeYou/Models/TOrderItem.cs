namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TOrderItems")]
    public partial class TOrderItem {
        [Key]
        public int intOrderItemID { get; set; }

        public int intOrderID { get; set; }

        public int intProductID { get; set; }

        public int intQuantity { get; set; }

        [Column(TypeName = "money")]
        public decimal monPricePerUnit { get; set; }

        public virtual TOrder TOrder { get; set; }

        public virtual TProduct TProduct { get; set; }
    }
}
