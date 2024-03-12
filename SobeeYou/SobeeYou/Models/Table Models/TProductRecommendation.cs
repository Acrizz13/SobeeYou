namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TProductRecommendations")]
    public partial class TProductRecommendation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intProductRecommendationID { get; set; }

        public int intUserID { get; set; }

        public int intProductID { get; set; }

        public DateTime dtmTimeOfRecommendation { get; set; }

        [Required]
        [StringLength(255)]
        public string strRelevantScore { get; set; }

        public virtual TProduct TProduct { get; set; }

        public virtual TUser TUser { get; set; }
    }
}
