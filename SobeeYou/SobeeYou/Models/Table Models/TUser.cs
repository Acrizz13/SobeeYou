namespace SobeeYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TUsers")]
    public partial class TUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUser()
        {
            TCustomerServiceTickets = new HashSet<TCustomerServiceTicket>();
            TOrders = new HashSet<TOrder>();
            TProductRecommendations = new HashSet<TProductRecommendation>();
            TReviews = new HashSet<TReview>();
            TShoppingCarts = new HashSet<TShoppingCart>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int intUserID { get; set; }

        public string strShippingAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string strEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string strPassword { get; set; }

        public int intUserRoleID { get; set; }

        [StringLength(255)]
        public string strBillingAddress { get; set; }


        public DateTime strDateCreated { get; set; }

        public DateTime strLastLoginDate { get; set; }

        [StringLength(50)]
        public string strFirstName { get; set; }

        [StringLength(50)]
        public string strLastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCustomerServiceTicket> TCustomerServiceTickets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOrder> TOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TProductRecommendation> TProductRecommendations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TReview> TReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; }

        public virtual TUserRole TUserRole { get; set; }

        //add the properties here that need to be added to get rid of the errors in my code in this method GetAdminDashBoardInfo in the Account Controller




    }
}
