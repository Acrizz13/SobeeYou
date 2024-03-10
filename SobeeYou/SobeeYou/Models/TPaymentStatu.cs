namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TPaymentStatus")]
    public partial class TPaymentStatu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intPaymentStatusID { get; set; }

        [StringLength(50)]
        public string strPaymentStatus { get; set; }
    }
}
