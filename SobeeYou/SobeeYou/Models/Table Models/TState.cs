namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TStates")]
    public partial class TState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intStateID { get; set; }

        [Required]
        [StringLength(255)]
        public string strState { get; set; }
    }
}
