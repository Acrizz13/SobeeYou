namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TPayments")]
    public partial class TPayment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intPaymentID { get; set; }

        [Required]
        [StringLength(255)]
        public string strBillingAddress { get; set; }

        public int intPaymentMethodID { get; set; }

        public int intPaymentMethod { get; set; }
    }
}
