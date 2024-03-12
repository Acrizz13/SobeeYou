namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TCities")]
    public partial class TCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intCityID { get; set; }

        [Required]
        [StringLength(255)]
        public string strCity { get; set; }
    }
}
