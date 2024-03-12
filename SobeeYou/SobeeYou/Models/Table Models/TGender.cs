namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TGenders")]
    public partial class TGender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intGenderID { get; set; }

        [Required]
        [StringLength(255)]
        public string strGender { get; set; }
    }
}
