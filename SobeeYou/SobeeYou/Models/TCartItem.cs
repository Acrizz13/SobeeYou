namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TCartItems")]
    public partial class TCartItem {
        [Key]
        public int intCartItemID { get; set; }

        public int intShoppingCartID { get; set; }

        public int intProductID { get; set; }

        public int intQuantity { get; set; }

        public DateTime dtmDateAdded { get; set; }

        public virtual TProduct Product { get; set; }

        public virtual TShoppingCart TShoppingCart { get; set; }
    }
}
