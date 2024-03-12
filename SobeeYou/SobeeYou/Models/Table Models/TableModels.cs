using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SobeeYou.Models {
    public partial class TableModels : DbContext {
        public TableModels()
            : base("name=TableModels1") {
        }

        public virtual DbSet<TAdmin> TAdmins { get; set; }
        public virtual DbSet<TCartItem> TCartItems { get; set; }
        public virtual DbSet<TCity> TCities { get; set; }
        public virtual DbSet<TCoupon> TCoupons { get; set; }
        public virtual DbSet<TCustomerServiceTicket> TCustomerServiceTickets { get; set; }
        public virtual DbSet<TDrinkCategory> TDrinkCategories { get; set; }
        public virtual DbSet<TFavorite> TFavorites { get; set; }
        public virtual DbSet<TFlavor> TFlavors { get; set; }
        public virtual DbSet<TGender> TGenders { get; set; }
        public virtual DbSet<TIngredient> TIngredients { get; set; }
        public virtual DbSet<TOrderItem> TOrderItems { get; set; }
        public virtual DbSet<TOrder> TOrders { get; set; }
        public virtual DbSet<TOrdersProduct> TOrdersProducts { get; set; }
        public virtual DbSet<TPaymentMethod> TPaymentMethods { get; set; }
        public virtual DbSet<TPayment> TPayments { get; set; }
        public virtual DbSet<TPaymentStatu> TPaymentStatus { get; set; }
        public virtual DbSet<TPermission> TPermissions { get; set; }
        public virtual DbSet<TProductImage> TProductImages { get; set; }
        public virtual DbSet<TProductRecommendation> TProductRecommendations { get; set; }
        public virtual DbSet<TProduct> TProducts { get; set; }
        public virtual DbSet<TPromotion> TPromotions { get; set; }
        public virtual DbSet<TRace> TRaces { get; set; }
        public virtual DbSet<TReview> TReviews { get; set; }
        public virtual DbSet<TShippingMethod> TShippingMethods { get; set; }
        public virtual DbSet<TShippingStatu> TShippingStatus { get; set; }
        public virtual DbSet<TShoppingCart> TShoppingCarts { get; set; }
        public virtual DbSet<TState> TStates { get; set; }
        public virtual DbSet<TTicketCategory> TTicketCategories { get; set; }
        public virtual DbSet<TTicketStatu> TTicketStatus { get; set; }
        public virtual DbSet<TUserRole> TUserRoles { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<TAdmin>()
                .Property(e => e.strAdminName)
                .IsUnicode(false);

            modelBuilder.Entity<TCity>()
                .Property(e => e.strCity)
                .IsUnicode(false);

            modelBuilder.Entity<TCoupon>()
                .Property(e => e.strCouponCode)
                .IsUnicode(false);

            modelBuilder.Entity<TCoupon>()
                .Property(e => e.strDiscountAmount)
                .IsUnicode(false);

            modelBuilder.Entity<TCustomerServiceTicket>()
                .Property(e => e.strDescription)
                .IsUnicode(false);

            modelBuilder.Entity<TDrinkCategory>()
                .Property(e => e.strDrinkCategory)
                .IsUnicode(false);

            modelBuilder.Entity<TFavorite>()
                .Property(e => e.strFavorite)
                .IsUnicode(false);

            modelBuilder.Entity<TFlavor>()
                .Property(e => e.strFlavor)
                .IsUnicode(false);

            modelBuilder.Entity<TGender>()
                .Property(e => e.strGender)
                .IsUnicode(false);

            modelBuilder.Entity<TIngredient>()
                .Property(e => e.strIngredient)
                .IsUnicode(false);

            modelBuilder.Entity<TOrderItem>()
                .Property(e => e.monPricePerUnit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TOrder>()
                .Property(e => e.decTotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TOrder>()
                .Property(e => e.strShippingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<TOrder>()
                .Property(e => e.strTrackingNumber)
                .IsUnicode(false);

            modelBuilder.Entity<TOrdersProduct>()
                .Property(e => e.strOrdersProduct)
                .IsUnicode(false);

            modelBuilder.Entity<TPaymentMethod>()
                .Property(e => e.strPaymentMethodName)
                .IsUnicode(false);

            modelBuilder.Entity<TPayment>()
                .Property(e => e.strBillingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<TPaymentStatu>()
                .Property(e => e.strPaymentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<TPermission>()
                .Property(e => e.strPermissionName)
                .IsUnicode(false);

            modelBuilder.Entity<TPermission>()
                .Property(e => e.strDescription)
                .IsUnicode(false);

            modelBuilder.Entity<TProductImage>()
                .Property(e => e.strProductImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<TProductRecommendation>()
                .Property(e => e.strRelevantScore)
                .IsUnicode(false);

            modelBuilder.Entity<TProduct>()
                .Property(e => e.strName)
                .IsUnicode(false);

            modelBuilder.Entity<TProduct>()
                .Property(e => e.strStockAmount)
                .IsUnicode(false);

            modelBuilder.Entity<TProduct>()
                .Property(e => e.strPrice)
                .IsUnicode(false);

            modelBuilder.Entity<TPromotion>()
                .Property(e => e.strPromoCode)
                .IsUnicode(false);

            modelBuilder.Entity<TPromotion>()
                .Property(e => e.strDiscountPercentage)
                .IsUnicode(false);

            modelBuilder.Entity<TRace>()
                .Property(e => e.strRace)
                .IsUnicode(false);

            modelBuilder.Entity<TReview>()
                .Property(e => e.strReviewText)
                .IsUnicode(false);

            modelBuilder.Entity<TReview>()
                .Property(e => e.strRating)
                .IsUnicode(false);

            modelBuilder.Entity<TShippingMethod>()
                .Property(e => e.strShippingName)
                .IsUnicode(false);

            modelBuilder.Entity<TShippingMethod>()
                .Property(e => e.strBillingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<TShippingMethod>()
                .Property(e => e.strCost)
                .IsUnicode(false);

            modelBuilder.Entity<TShippingStatu>()
                .Property(e => e.strShippingStatus)
                .IsUnicode(false);

            modelBuilder.Entity<TState>()
                .Property(e => e.strState)
                .IsUnicode(false);

            modelBuilder.Entity<TTicketCategory>()
                .Property(e => e.strTicketCategory)
                .IsUnicode(false);

            modelBuilder.Entity<TTicketStatu>()
                .Property(e => e.strTicketStatus)
                .IsUnicode(false);

            modelBuilder.Entity<TUserRole>()
                .Property(e => e.strRole)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .Property(e => e.strEmail)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .Property(e => e.strPassword)
                .IsUnicode(false);
        }
    }
}
