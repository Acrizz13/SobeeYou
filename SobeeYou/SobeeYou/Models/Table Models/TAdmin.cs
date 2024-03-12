namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TAdmins")]
    public partial class TAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intAdminID { get; set; }

        [Required]
        [StringLength(255)]
        public string strAdminName { get; set; }
    }
}
