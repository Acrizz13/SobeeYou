namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TShoppingCarts")]
    public partial class TShoppingCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TShoppingCart()
        {
            TCartItems = new HashSet<TCartItem>();
        }

        [Key]
        public int intShoppingCartID { get; set; }

        public int? intUserID { get; set; }

        public DateTime? dtmDateCreated { get; set; }

        public DateTime? dtmDateLastUpdated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCartItem> TCartItems { get; set; }

        public virtual TUser TUser { get; set; }
    }
}
