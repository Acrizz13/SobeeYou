namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TOrdersProducts")]
    public partial class TOrdersProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intOrdersProductID { get; set; }

        public int intProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string strOrdersProduct { get; set; }

        public virtual TProduct TProduct { get; set; }
    }
}
