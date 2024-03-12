namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TShippingMethods")]
    public partial class TShippingMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intShippingMethodID { get; set; }

        [Required]
        [StringLength(255)]
        public string strShippingName { get; set; }

        [Required]
        [StringLength(255)]
        public string strBillingAddress { get; set; }

        public DateTime dtmEstimatedDelivery { get; set; }

        [Required]
        [StringLength(255)]
        public string strCost { get; set; }
    }
}
