namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TDrinkCategories")]
    public partial class TDrinkCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intDrinkCategoryID { get; set; }

        [Required]
        [StringLength(255)]
        public string strDrinkCategory { get; set; }
    }
}
