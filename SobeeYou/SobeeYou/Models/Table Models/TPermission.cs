namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TPermissions")]
    public partial class TPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intPermissionID { get; set; }

        [Required]
        [StringLength(255)]
        public string strPermissionName { get; set; }

        [Required]
        [StringLength(255)]
        public string strDescription { get; set; }
    }
}
