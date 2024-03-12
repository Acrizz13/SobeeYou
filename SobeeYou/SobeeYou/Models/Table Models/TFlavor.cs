namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TFlavors")]
    public partial class TFlavor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intFlavorID { get; set; }

        [Required]
        [StringLength(255)]
        public string strFlavor { get; set; }
    }
}
