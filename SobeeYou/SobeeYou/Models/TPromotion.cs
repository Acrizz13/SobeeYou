namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TPromotions")]
    public partial class TPromotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intPromotionID { get; set; }

        [Required]
        [StringLength(255)]
        public string strPromoCode { get; set; }

        [Required]
        [StringLength(255)]
        public string strDiscountPercentage { get; set; }

        public DateTime dtmExpirationDate { get; set; }
    }
}
