namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TCoupons")]
    public partial class TCoupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intCouponID { get; set; }

        [Required]
        [StringLength(255)]
        public string strCouponCode { get; set; }

        [Required]
        [StringLength(255)]
        public string strDiscountAmount { get; set; }

        public DateTime dtmExpirationDate { get; set; }
    }
}
