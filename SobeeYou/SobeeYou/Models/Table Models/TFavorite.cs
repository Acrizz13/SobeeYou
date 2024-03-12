namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TFavorites")]
    public partial class TFavorite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intFavoriteID { get; set; }

        [Required]
        [StringLength(255)]
        public string strFavorite { get; set; }
    }
}
