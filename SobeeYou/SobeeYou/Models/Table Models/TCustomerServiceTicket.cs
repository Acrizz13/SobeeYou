namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TCustomerServiceTickets")]
    public partial class TCustomerServiceTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intCustomerServiceTicketID { get; set; }

        public int intUserID { get; set; }

        public int intTicketCategoryID { get; set; }

        public int intTicketStatusID { get; set; }

        public DateTime dtmTimeOfSubmission { get; set; }

        [Required]
        [StringLength(255)]
        public string strDescription { get; set; }

        public virtual TTicketCategory TTicketCategory { get; set; }

        public virtual TTicketStatu TTicketStatu { get; set; }

        public virtual TUser TUser { get; set; }
    }
}
