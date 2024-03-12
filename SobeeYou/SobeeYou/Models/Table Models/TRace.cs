namespace SobeeYou.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TRaces")]
    public partial class TRace {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intRaceID { get; set; }

        [Required]
        [StringLength(255)]
        public string strRace { get; set; }
    }
}
