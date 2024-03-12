namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TReviews")]
    public partial class TReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intReviewID { get; set; }

        public int intUserID { get; set; }

        public int intProductID { get; set; }

        [Required]
        [StringLength(1000)]
        public string strReviewText { get; set; }

        [Required]
        [StringLength(255)]
        public string strRating { get; set; }

        public virtual TProduct TProduct { get; set; }

        public virtual TUser TUser { get; set; }
    }
}
