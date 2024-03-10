namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TIngredients")]
    public partial class TIngredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intIngredientID { get; set; }

        [Required]
        [StringLength(255)]
        public string strIngredient { get; set; }
    }
}
