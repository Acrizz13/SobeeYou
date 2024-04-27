using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sobee_core.Models.AzureModels;

public partial class TestContext : DbContext {
    public TestContext() {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options) {
    }

    public virtual DbSet<TcartItem> TcartItems { get; set; }

    public virtual DbSet<Tcity> Tcities { get; set; }

    public virtual DbSet<Tcoupon> Tcoupons { get; set; }

    public virtual DbSet<TcustomerServiceTicket> TcustomerServiceTickets { get; set; }

    public virtual DbSet<TdrinkCategory> TdrinkCategories { get; set; }

    public virtual DbSet<Tfavorite> Tfavorites { get; set; }

    public virtual DbSet<Tflavor> Tflavors { get; set; }

    public virtual DbSet<Tgender> Tgenders { get; set; }

    public virtual DbSet<Tingredient> Tingredients { get; set; }

    public virtual DbSet<Tinteraction> Tinteractions { get; set; }

    public virtual DbSet<Torder> Torders { get; set; }

    public virtual DbSet<TorderItem> TorderItems { get; set; }

    public virtual DbSet<TordersProduct> TordersProducts { get; set; }

    public virtual DbSet<Tpayment> Tpayments { get; set; }

    public virtual DbSet<TpaymentMethod> TpaymentMethods { get; set; }

    public virtual DbSet<Tproduct> Tproducts { get; set; }

    public virtual DbSet<TproductImage> TproductImages { get; set; }

    public virtual DbSet<TproductRecommendation> TproductRecommendations { get; set; }

    public virtual DbSet<TpromoCodeUsageHistory> TpromoCodeUsageHistories { get; set; }

    public virtual DbSet<Tpromotion> Tpromotions { get; set; }

    public virtual DbSet<Trace> Traces { get; set; }

    public virtual DbSet<Treview> Treviews { get; set; }

    public virtual DbSet<TrewardsOption> TrewardsOptions { get; set; }

    public virtual DbSet<TrewardsPoint> TrewardsPoints { get; set; }

    public virtual DbSet<TrewardsTransaction> TrewardsTransactions { get; set; }

    public virtual DbSet<TshippingMethod> TshippingMethods { get; set; }

    public virtual DbSet<TshippingStatus> TshippingStatuses { get; set; }

    public virtual DbSet<TshoppingCart> TshoppingCarts { get; set; }

    public virtual DbSet<Tstate> Tstates { get; set; }

    public virtual DbSet<TticketCategory> TticketCategories { get; set; }

    public virtual DbSet<TticketStatus> TticketStatuses { get; set; }

    public virtual DbSet<TtransactionType> TtransactionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1V8CQR5;Initial Catalog=TEST;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<TcartItem>(entity => {
            entity.HasKey(e => e.IntCartItemId).HasName("TCartItems_PK");

            entity.ToTable("TCartItems");

            entity.Property(e => e.IntCartItemId).HasColumnName("intCartItemID");
            entity.Property(e => e.DtmDateAdded)
                .HasColumnType("datetime")
                .HasColumnName("dtmDateAdded");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntQuantity).HasColumnName("intQuantity");
            entity.Property(e => e.IntShoppingCartId).HasColumnName("intShoppingCartID");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TcartItems)
                .HasForeignKey(d => d.IntProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TCartItems_TProducts_FK");

            entity.HasOne(d => d.IntShoppingCart).WithMany(p => p.TcartItems)
                .HasForeignKey(d => d.IntShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TCartItems_TShoppingCarts_FK");
        });

        modelBuilder.Entity<Tcity>(entity => {
            entity.HasKey(e => e.IntCityId).HasName("TCities_PK");

            entity.ToTable("TCities");

            entity.Property(e => e.IntCityId).HasColumnName("intCityID");
            entity.Property(e => e.StrCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strCity");
        });

        modelBuilder.Entity<Tcoupon>(entity => {
            entity.HasKey(e => e.IntCouponId).HasName("TCoupons_PK");

            entity.ToTable("TCoupons");

            entity.Property(e => e.IntCouponId).HasColumnName("intCouponID");
            entity.Property(e => e.DtmExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("dtmExpirationDate");
            entity.Property(e => e.StrCouponCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strCouponCode");
            entity.Property(e => e.StrDiscountAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDiscountAmount");
        });

        modelBuilder.Entity<TcustomerServiceTicket>(entity => {
            entity.HasKey(e => e.IntCustomerServiceTicketId).HasName("TCustomerServiceTickets_PK");

            entity.ToTable("TCustomerServiceTickets");

            entity.Property(e => e.IntCustomerServiceTicketId).HasColumnName("intCustomerServiceTicketID");
            entity.Property(e => e.DtmTimeOfSubmission)
                .HasColumnType("datetime")
                .HasColumnName("dtmTimeOfSubmission");
            entity.Property(e => e.IntTicketCategoryId).HasColumnName("intTicketCategoryID");
            entity.Property(e => e.IntTicketStatusId).HasColumnName("intTicketStatusID");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.StrDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.IntTicketCategory).WithMany(p => p.TcustomerServiceTickets)
                .HasForeignKey(d => d.IntTicketCategoryId)
                .HasConstraintName("TCustomerServiceTickets_TTicketCategories_FK");

            entity.HasOne(d => d.IntTicketStatus).WithMany(p => p.TcustomerServiceTickets)
                .HasForeignKey(d => d.IntTicketStatusId)
                .HasConstraintName("TCustomerServiceTickets_TTicketStatus_FK");
        });

        modelBuilder.Entity<TdrinkCategory>(entity => {
            entity.HasKey(e => e.IntDrinkCategoryId).HasName("TDrinkCategories_PK");

            entity.ToTable("TDrinkCategories");

            entity.Property(e => e.IntDrinkCategoryId).HasColumnName("intDrinkCategoryID");
            entity.Property(e => e.StrDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strName");
        });

        modelBuilder.Entity<Tfavorite>(entity => {
            entity.HasKey(e => e.IntFavoriteId).HasName("TFavorites_PK");

            entity.ToTable("TFavorites");

            entity.Property(e => e.IntFavoriteId).HasColumnName("intFavoriteID");
            entity.Property(e => e.DtmDateAdded)
                .HasColumnType("datetime")
                .HasColumnName("dtmDateAdded");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.Tfavorites)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("TFavorites_TProducts_FK");
        });

        modelBuilder.Entity<Tflavor>(entity => {
            entity.HasKey(e => e.IntFlavorId).HasName("TFlavors_PK");

            entity.ToTable("TFlavors");

            entity.Property(e => e.IntFlavorId).HasColumnName("intFlavorID");
            entity.Property(e => e.StrFlavor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strFlavor");
        });

        modelBuilder.Entity<Tgender>(entity => {
            entity.HasKey(e => e.IntGenderId).HasName("TGenders_PK");

            entity.ToTable("TGenders");

            entity.Property(e => e.IntGenderId).HasColumnName("intGenderID");
            entity.Property(e => e.StrGender)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strGender");
        });

        modelBuilder.Entity<Tingredient>(entity => {
            entity.HasKey(e => e.IntIngredientId).HasName("TIngredients_PK");

            entity.ToTable("TIngredients");

            entity.Property(e => e.IntIngredientId).HasColumnName("intIngredientID");
            entity.Property(e => e.StrIngredient)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strIngredient");
        });

        modelBuilder.Entity<Tinteraction>(entity => {
            entity.HasKey(e => e.IntInteractionId).HasName("TInteractions_PK");

            entity.ToTable("TInteractions");

            entity.Property(e => e.IntInteractionId).HasColumnName("intInteractionID");
            entity.Property(e => e.StrDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strName");
        });

        modelBuilder.Entity<Torder>(entity => {
            entity.HasKey(e => e.IntOrderId).HasName("TOrders_PK");

            entity.ToTable("TOrders");

            entity.Property(e => e.IntOrderId).HasColumnName("intOrderID");
            entity.Property(e => e.DecTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("decTotalAmount");
            entity.Property(e => e.DtmOrderDate)
                .HasColumnType("datetime")
                .HasColumnName("dtmOrderDate");
            entity.Property(e => e.IntPaymentMethodId).HasColumnName("intPaymentMethodID");
            entity.Property(e => e.IntShippingStatusId).HasColumnName("intShippingStatusID");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.StrOrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strOrderStatus");
            entity.Property(e => e.StrShippingAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strShippingAddress");
            entity.Property(e => e.StrTrackingNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTrackingNumber");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.IntPaymentMethod).WithMany(p => p.Torders)
                .HasForeignKey(d => d.IntPaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TOrders_TPaymentMethods_FK");

            entity.HasOne(d => d.IntShippingStatus).WithMany(p => p.Torders)
                .HasForeignKey(d => d.IntShippingStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TOrders_TShippingStatus_FK");
        });

        modelBuilder.Entity<TorderItem>(entity => {
            entity.HasKey(e => e.IntOrderItemId).HasName("TOrderItems_PK");

            entity.ToTable("TOrderItems");

            entity.Property(e => e.IntOrderItemId).HasColumnName("intOrderItemID");
            entity.Property(e => e.IntOrderId).HasColumnName("intOrderID");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntQuantity).HasColumnName("intQuantity");
            entity.Property(e => e.MonPricePerUnit)
                .HasColumnType("money")
                .HasColumnName("monPricePerUnit");

            entity.HasOne(d => d.IntOrder).WithMany(p => p.TorderItems)
                .HasForeignKey(d => d.IntOrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TOrderItems_TOrders_FK");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TorderItems)
                .HasForeignKey(d => d.IntProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TOrderItems_TProducts_FK");
        });

        modelBuilder.Entity<TordersProduct>(entity => {
            entity.HasKey(e => e.IntOrdersProductId).HasName("TOrdersProducts_PK");

            entity.ToTable("TOrdersProducts");

            entity.Property(e => e.IntOrdersProductId).HasColumnName("intOrdersProductID");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.StrOrdersProduct)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strOrdersProduct");
        });

        modelBuilder.Entity<Tpayment>(entity => {
            entity.HasKey(e => e.IntPaymentId).HasName("TPayments_PK");

            entity.ToTable("TPayments");

            entity.Property(e => e.IntPaymentId).HasColumnName("intPaymentID");
            entity.Property(e => e.IntPaymentMethod).HasColumnName("intPaymentMethod");
            entity.Property(e => e.IntPaymentMethodId).HasColumnName("intPaymentMethodID");
            entity.Property(e => e.StrBillingAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strBillingAddress");

            entity.HasOne(d => d.IntPaymentMethodNavigation).WithMany(p => p.Tpayments)
                .HasForeignKey(d => d.IntPaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TPayments_TPaymentMethods_FK");
        });

        modelBuilder.Entity<TpaymentMethod>(entity => {
            entity.HasKey(e => e.IntPaymentMethodId).HasName("TPaymentMethods_PK");

            entity.ToTable("TPaymentMethods");

            entity.Property(e => e.IntPaymentMethodId).HasColumnName("intPaymentMethodID");
            entity.Property(e => e.StrBillingAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strBillingAddress");
            entity.Property(e => e.StrCreditCardDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strCreditCardDetails");
            entity.Property(e => e.StrDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
        });

        modelBuilder.Entity<Tproduct>(entity => {
            entity.HasKey(e => e.IntProductId).HasName("TProducts_PK");

            entity.ToTable("TProducts");

            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.DecPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("decPrice");
            entity.Property(e => e.strDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strName");
            entity.Property(e => e.StrStockAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strStockAmount");
        });

        modelBuilder.Entity<TproductImage>(entity => {
            entity.HasKey(e => e.IntProductImageId).HasName("TProductImages_PK");

            entity.ToTable("TProductImages");

            entity.Property(e => e.IntProductImageId).HasColumnName("intProductImageID");
            entity.Property(e => e.StrProductImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("strProductImageURL");
        });

        modelBuilder.Entity<TproductRecommendation>(entity => {
            entity.HasKey(e => e.IntProductRecommendationId).HasName("TProductRecommendations_PK");

            entity.ToTable("TProductRecommendations");

            entity.Property(e => e.IntProductRecommendationId).HasColumnName("intProductRecommendationID");
            entity.Property(e => e.DtmTimeOfRecommendation)
                .HasColumnType("datetime")
                .HasColumnName("dtmTimeOfRecommendation");
            entity.Property(e => e.IntInteractionId).HasColumnName("intInteractionID");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntRelevantScore).HasColumnName("intRelevantScore");

            entity.HasOne(d => d.IntInteraction).WithMany(p => p.TproductRecommendations)
                .HasForeignKey(d => d.IntInteractionId)
                .HasConstraintName("TProductRecommendations_TInteractions_FK");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TproductRecommendations)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("TProductRecommendations_TProducts_FK");
        });

        modelBuilder.Entity<TpromoCodeUsageHistory>(entity => {
            entity.HasKey(e => e.IntUsageHistoryId).HasName("TPromoCodeUsageHistory_PK");

            entity.ToTable("TPromoCodeUsageHistory");

            entity.Property(e => e.IntUsageHistoryId).HasColumnName("intUsageHistoryID");
            entity.Property(e => e.IntShoppingCartId).HasColumnName("intShoppingCartID");
            entity.Property(e => e.PromoCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.IntShoppingCart).WithMany(p => p.TpromoCodeUsageHistories)
                .HasForeignKey(d => d.IntShoppingCartId)
                .HasConstraintName("TPromoCodeUsageHistory_TShoppingCarts_FK");
        });

        modelBuilder.Entity<Tpromotion>(entity => {
            entity.HasKey(e => e.IntPromotionId).HasName("TPromotions_PK");

            entity.ToTable("TPromotions");

            entity.Property(e => e.IntPromotionId).HasColumnName("intPromotionID");
            entity.Property(e => e.DecDiscountPercentage)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("decDiscountPercentage");
            entity.Property(e => e.DtmExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("dtmExpirationDate");
            entity.Property(e => e.StrDiscountPercentage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDiscountPercentage");
            entity.Property(e => e.StrPromoCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strPromoCode");
        });

        modelBuilder.Entity<Trace>(entity => {
            entity.HasKey(e => e.IntRaceId).HasName("TRaces_PK");

            entity.ToTable("TRaces");

            entity.Property(e => e.IntRaceId).HasColumnName("intRaceID");
            entity.Property(e => e.StrRace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strRace");
        });

        modelBuilder.Entity<Treview>(entity => {
            entity.HasKey(e => e.IntReviewId).HasName("TReviews_PK");

            entity.ToTable("TReviews");

            entity.Property(e => e.IntReviewId).HasColumnName("intReviewID");
            entity.Property(e => e.DtmReviewDate)
                .HasColumnType("datetime")
                .HasColumnName("dtmReviewDate");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntRating).HasColumnName("intRating");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.StrReviewText)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("strReviewText");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.Treviews)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("TReviews_TProducts_FK");
        });

        modelBuilder.Entity<TrewardsOption>(entity => {
            entity.HasKey(e => e.IntRewardsOptionsId).HasName("TRewardsOptions_PK");

            entity.ToTable("TRewardsOptions");

            entity.Property(e => e.IntRewardsOptionsId).HasColumnName("intRewardsOptionsID");
            entity.Property(e => e.StrDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrOptionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strOptionName");
            entity.Property(e => e.StrPointsRequired)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strPointsRequired");
        });

        modelBuilder.Entity<TrewardsPoint>(entity => {
            entity.HasKey(e => e.IntRewardsPointsId).HasName("TRewardsPoints_PK");

            entity.ToTable("TRewardsPoints");

            entity.Property(e => e.IntRewardsPointsId).HasColumnName("intRewardsPointsID");
            entity.Property(e => e.StrPointsBalance)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strPointsBalance");
            entity.Property(e => e.StrTotalPointsEarned)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTotalPointsEarned");
            entity.Property(e => e.StrTotalPointsRedeemed)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTotalPointsRedeemed");
        });

        modelBuilder.Entity<TrewardsTransaction>(entity => {
            entity.HasKey(e => e.IntRewardsTransactionId).HasName("TRewardsTransactions_PK");

            entity.ToTable("TRewardsTransactions");

            entity.Property(e => e.IntRewardsTransactionId).HasColumnName("intRewardsTransactionID");
            entity.Property(e => e.DtmTransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("dtmTransactionDate");
            entity.Property(e => e.IntTransactionTypeId).HasColumnName("intTransactionTypeID");
            entity.Property(e => e.StrPointAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strPointAmount");

            entity.HasOne(d => d.IntTransactionType).WithMany(p => p.TrewardsTransactions)
                .HasForeignKey(d => d.IntTransactionTypeId)
                .HasConstraintName("TRewardsTransactions_TTransactionTypes_FK");
        });

        modelBuilder.Entity<TshippingMethod>(entity => {
            entity.HasKey(e => e.IntShippingMethodId).HasName("TShippingMethods_PK");

            entity.ToTable("TShippingMethods");

            entity.Property(e => e.IntShippingMethodId).HasColumnName("intShippingMethodID");
            entity.Property(e => e.DtmEstimatedDelivery)
                .HasColumnType("datetime")
                .HasColumnName("dtmEstimatedDelivery");
            entity.Property(e => e.StrBillingAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strBillingAddress");
            entity.Property(e => e.StrCost)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strCost");
            entity.Property(e => e.StrShippingName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strShippingName");
        });

        modelBuilder.Entity<TshippingStatus>(entity => {
            entity.HasKey(e => e.IntShippingStatusId).HasName("TShippingStatus_PK");

            entity.ToTable("TShippingStatus");

            entity.Property(e => e.IntShippingStatusId).HasColumnName("intShippingStatusID");
            entity.Property(e => e.StrShippingStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strShippingStatus");
        });

        modelBuilder.Entity<TshoppingCart>(entity => {
            entity.HasKey(e => e.IntShoppingCartId).HasName("TShoppingCarts_PK");

            entity.ToTable("TShoppingCarts");

            entity.Property(e => e.IntShoppingCartId).HasColumnName("intShoppingCartID");
            entity.Property(e => e.DtmDateCreated)
                .HasColumnType("datetime")
                .HasColumnName("dtmDateCreated");
            entity.Property(e => e.DtmDateLastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("dtmDateLastUpdated");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<Tstate>(entity => {
            entity.HasKey(e => e.IntStateId).HasName("TStates_PK");

            entity.ToTable("TStates");

            entity.Property(e => e.IntStateId).HasColumnName("intStateID");
            entity.Property(e => e.StrState)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strState");
        });

        modelBuilder.Entity<TticketCategory>(entity => {
            entity.HasKey(e => e.IntTicketCategoryId).HasName("TTicketCategories_PK");

            entity.ToTable("TTicketCategories");

            entity.Property(e => e.IntTicketCategoryId).HasColumnName("intTicketCategoryID");
            entity.Property(e => e.StrTicketCategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTicketCategory");
        });

        modelBuilder.Entity<TticketStatus>(entity => {
            entity.HasKey(e => e.IntTicketStatusId).HasName("TTicketStatus_PK");

            entity.ToTable("TTicketStatus");

            entity.Property(e => e.IntTicketStatusId).HasColumnName("intTicketStatusID");
            entity.Property(e => e.StrTicketStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTicketStatus");
        });

        modelBuilder.Entity<TtransactionType>(entity => {
            entity.HasKey(e => e.IntTransactionTypeId).HasName("TTransactionTypes_PK");

            entity.ToTable("TTransactionTypes");

            entity.Property(e => e.IntTransactionTypeId).HasColumnName("intTransactionTypeID");
            entity.Property(e => e.StrTransactionType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTransactionType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
