namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TProductImages")]
    public partial class TProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intProductImageID { get; set; }

        [Required]
        [StringLength(1000)]
        public string strProductImageURL { get; set; }
    }
}
