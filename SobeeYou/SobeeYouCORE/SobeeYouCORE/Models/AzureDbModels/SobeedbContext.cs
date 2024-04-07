using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SobeeYouCORE.Models.AzureDbModels;

public partial class SobeedbContext : DbContext
{
    public SobeedbContext()
    {
    }

    public SobeedbContext(DbContextOptions<SobeedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Tadmin> Tadmins { get; set; }

    public virtual DbSet<TcartItem> TcartItems { get; set; }

    public virtual DbSet<Tcity> Tcities { get; set; }

    public virtual DbSet<Tcoupon> Tcoupons { get; set; }

    public virtual DbSet<TcustomerServiceTicket> TcustomerServiceTickets { get; set; }

    public virtual DbSet<TdrinkCategory> TdrinkCategories { get; set; }

    public virtual DbSet<Tfavorite> Tfavorites { get; set; }

    public virtual DbSet<Tflavor> Tflavors { get; set; }

    public virtual DbSet<Tgender> Tgenders { get; set; }

    public virtual DbSet<Tingredient> Tingredients { get; set; }

    public virtual DbSet<Torder> Torders { get; set; }

    public virtual DbSet<TorderItem> TorderItems { get; set; }

    public virtual DbSet<TordersProduct> TordersProducts { get; set; }

    public virtual DbSet<Tpayment> Tpayments { get; set; }

    public virtual DbSet<TpaymentMethod> TpaymentMethods { get; set; }

    public virtual DbSet<TpaymentStatus> TpaymentStatuses { get; set; }

    public virtual DbSet<Tpermission> Tpermissions { get; set; }

    public virtual DbSet<Tproduct> Tproducts { get; set; }

    public virtual DbSet<TproductImage> TproductImages { get; set; }

    public virtual DbSet<TproductRecommendation> TproductRecommendations { get; set; }

    public virtual DbSet<Tpromotion> Tpromotions { get; set; }

    public virtual DbSet<Trace> Traces { get; set; }

    public virtual DbSet<Treview> Treviews { get; set; }

    public virtual DbSet<TshippingMethod> TshippingMethods { get; set; }

    public virtual DbSet<TshippingStatus> TshippingStatuses { get; set; }

    public virtual DbSet<TshoppingCart> TshoppingCarts { get; set; }

    public virtual DbSet<Tstate> Tstates { get; set; }

    public virtual DbSet<TticketCategory> TticketCategories { get; set; }

    public virtual DbSet<TticketStatus> TticketStatuses { get; set; }

    public virtual DbSet<Tuser> Tusers { get; set; }

    public virtual DbSet<TuserRole> TuserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sobeeyoucore.database.windows.net;Initial Catalog=sobeedb;User ID=sobeeadmin;Password=Sobeeyou123!;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.ToTable("AspNetRoles", "db_owner");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.ToTable("AspNetRoleClaims", "db_owner");

            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.ToTable("AspNetUsers", "db_owner");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.IntUserRoleId).HasColumnName("intUserRoleID");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.StrBillingAddress)
                .HasDefaultValue("")
                .HasColumnName("strBillingAddress");
            entity.Property(e => e.StrFirstName)
                .HasDefaultValue("")
                .HasColumnName("strFirstName");
            entity.Property(e => e.StrLastName)
                .HasDefaultValue("")
                .HasColumnName("strLastName");
            entity.Property(e => e.StrShippingAddress)
                .HasDefaultValue("")
                .HasColumnName("strShippingAddress");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles", "db_owner");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.ToTable("AspNetUserClaims", "db_owner");

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.ToTable("AspNetUserLogins", "db_owner");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.ToTable("AspNetUserTokens", "db_owner");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Tadmin>(entity =>
        {
            entity.HasKey(e => e.IntAdminId).HasName("TAdmins_PK");

            entity.ToTable("TAdmins", "db_owner");

            entity.Property(e => e.IntAdminId)
                .ValueGeneratedNever()
                .HasColumnName("intAdminID");
            entity.Property(e => e.StrAdminName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strAdminName");
        });

        modelBuilder.Entity<TcartItem>(entity =>
        {
            entity.HasKey(e => e.IntCartItemId).HasName("PK__TCartIte__4A33868D73ECE44D");

            entity.ToTable("TCartItems", "db_owner");

            entity.Property(e => e.IntCartItemId).HasColumnName("intCartItemID");
            entity.Property(e => e.DtmDateAdded)
                .HasColumnType("datetime")
                .HasColumnName("dtmDateAdded");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntQuantity).HasColumnName("intQuantity");
            entity.Property(e => e.IntShoppingCartId).HasColumnName("intShoppingCartID");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TcartItems)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("FK__TCartItem__intPr__3493CFA7");

            entity.HasOne(d => d.IntShoppingCart).WithMany(p => p.TcartItems)
                .HasForeignKey(d => d.IntShoppingCartId)
                .HasConstraintName("FK__TCartItem__intSh__3587F3E0");
        });

        modelBuilder.Entity<Tcity>(entity =>
        {
            entity.HasKey(e => e.IntCityId).HasName("TCities_PK");

            entity.ToTable("TCities", "db_owner");

            entity.Property(e => e.IntCityId)
                .ValueGeneratedNever()
                .HasColumnName("intCityID");
            entity.Property(e => e.StrCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strCity");
        });

        modelBuilder.Entity<Tcoupon>(entity =>
        {
            entity.HasKey(e => e.IntCouponId).HasName("TCoupons_PK");

            entity.ToTable("TCoupons", "db_owner");

            entity.Property(e => e.IntCouponId)
                .ValueGeneratedNever()
                .HasColumnName("intCouponID");
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

        modelBuilder.Entity<TcustomerServiceTicket>(entity =>
        {
            entity.HasKey(e => e.IntCustomerServiceTicketId).HasName("TCustomerServiceTickets_PK");

            entity.ToTable("TCustomerServiceTickets", "db_owner");

            entity.Property(e => e.IntCustomerServiceTicketId)
                .ValueGeneratedNever()
                .HasColumnName("intCustomerServiceTicketID");
            entity.Property(e => e.DtmTimeOfSubmission)
                .HasColumnType("datetime")
                .HasColumnName("dtmTimeOfSubmission");
            entity.Property(e => e.IntTicketCategoryId).HasColumnName("intTicketCategoryID");
            entity.Property(e => e.IntTicketStatusId).HasColumnName("intTicketStatusID");
            entity.Property(e => e.IntUserId).HasColumnName("intUserID");
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

            entity.HasOne(d => d.IntUser).WithMany(p => p.TcustomerServiceTickets)
                .HasForeignKey(d => d.IntUserId)
                .HasConstraintName("TCustomerServiceTickets_TUsers_FK");

            entity.HasOne(d => d.User).WithMany(p => p.TcustomerServiceTickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TCustomerServiceTickets_AspNetUsers");
        });

        modelBuilder.Entity<TdrinkCategory>(entity =>
        {
            entity.HasKey(e => e.IntDrinkCategoryId).HasName("TDrinkCategories_PK");

            entity.ToTable("TDrinkCategories", "db_owner");

            entity.Property(e => e.IntDrinkCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("intDrinkCategoryID");
            entity.Property(e => e.StrDrinkCategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDrinkCategory");
        });

        modelBuilder.Entity<Tfavorite>(entity =>
        {
            entity.HasKey(e => e.IntFavoriteId).HasName("TFavorites_PK");

            entity.ToTable("TFavorites", "db_owner");

            entity.Property(e => e.IntFavoriteId)
                .ValueGeneratedNever()
                .HasColumnName("intFavoriteID");
            entity.Property(e => e.StrFavorite)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strFavorite");
        });

        modelBuilder.Entity<Tflavor>(entity =>
        {
            entity.HasKey(e => e.IntFlavorId).HasName("TFlavors_PK");

            entity.ToTable("TFlavors", "db_owner");

            entity.Property(e => e.IntFlavorId)
                .ValueGeneratedNever()
                .HasColumnName("intFlavorID");
            entity.Property(e => e.StrFlavor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strFlavor");
        });

        modelBuilder.Entity<Tgender>(entity =>
        {
            entity.HasKey(e => e.IntGenderId).HasName("TGenders_PK");

            entity.ToTable("TGenders", "db_owner");

            entity.Property(e => e.IntGenderId)
                .ValueGeneratedNever()
                .HasColumnName("intGenderID");
            entity.Property(e => e.StrGender)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strGender");
        });

        modelBuilder.Entity<Tingredient>(entity =>
        {
            entity.HasKey(e => e.IntIngredientId).HasName("TIngredients_PK");

            entity.ToTable("TIngredients", "db_owner");

            entity.Property(e => e.IntIngredientId)
                .ValueGeneratedNever()
                .HasColumnName("intIngredientID");
            entity.Property(e => e.StrIngredient)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strIngredient");
        });

        modelBuilder.Entity<Torder>(entity =>
        {
            entity.HasKey(e => e.IntOrderId).HasName("PK__TOrders__447BBC4417552EA2");

            entity.ToTable("TOrders", "db_owner");

            entity.Property(e => e.IntOrderId).HasColumnName("intOrderID");
            entity.Property(e => e.DecTotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("decTotalAmount");
            entity.Property(e => e.DtmOrderDate)
                .HasColumnType("datetime")
                .HasColumnName("dtmOrderDate");
            entity.Property(e => e.IntPaymentMethod).HasColumnName("intPaymentMethod");
            entity.Property(e => e.IntShippingStatusId).HasColumnName("intShippingStatusID");
            entity.Property(e => e.IntUserId).HasColumnName("intUserID");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.StrOrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("strOrderStatus");
            entity.Property(e => e.StrShippingAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strShippingAddress");
            entity.Property(e => e.StrTrackingNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strTrackingNumber");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.IntPaymentMethodNavigation).WithMany(p => p.Torders)
                .HasForeignKey(d => d.IntPaymentMethod)
                .HasConstraintName("FK_PaymentMethod");

            entity.HasOne(d => d.IntShippingStatus).WithMany(p => p.Torders)
                .HasForeignKey(d => d.IntShippingStatusId)
                .HasConstraintName("FK_TOrders_TShippingStatus");

            entity.HasOne(d => d.IntUser).WithMany(p => p.Torders)
                .HasForeignKey(d => d.IntUserId)
                .HasConstraintName("FK__TOrders__intUser__3C34F16F");

            entity.HasOne(d => d.User).WithMany(p => p.Torders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TORders_AspNetUsers");
        });

        modelBuilder.Entity<TorderItem>(entity =>
        {
            entity.HasKey(e => e.IntOrderItemId).HasName("PK__TOrderIt__33B6022565C3C971");

            entity.ToTable("TOrderItems", "db_owner");

            entity.Property(e => e.IntOrderItemId).HasColumnName("intOrderItemID");
            entity.Property(e => e.IntOrderId).HasColumnName("intOrderID");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntQuantity).HasColumnName("intQuantity");
            entity.Property(e => e.MonPricePerUnit)
                .HasColumnType("money")
                .HasColumnName("monPricePerUnit");

            entity.HasOne(d => d.IntOrder).WithMany(p => p.TorderItems)
                .HasForeignKey(d => d.IntOrderId)
                .HasConstraintName("FK__TOrderIte__intOr__3A4CA8FD");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TorderItems)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("FK__TOrderIte__intPr__3B40CD36");
        });

        modelBuilder.Entity<TordersProduct>(entity =>
        {
            entity.HasKey(e => e.IntOrdersProductId).HasName("TOrdersProducts_PK");

            entity.ToTable("TOrdersProducts", "db_owner");

            entity.Property(e => e.IntOrdersProductId)
                .ValueGeneratedNever()
                .HasColumnName("intOrdersProductID");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.StrOrdersProduct)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strOrdersProduct");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TordersProducts)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("TOrdersProducts_TProducts_FK");
        });

        modelBuilder.Entity<Tpayment>(entity =>
        {
            entity.HasKey(e => e.IntPaymentId).HasName("TPayments_PK");

            entity.ToTable("TPayments", "db_owner");

            entity.Property(e => e.IntPaymentId)
                .ValueGeneratedNever()
                .HasColumnName("intPaymentID");
            entity.Property(e => e.IntPaymentMethod).HasColumnName("intPaymentMethod");
            entity.Property(e => e.IntPaymentMethodId).HasColumnName("intPaymentMethodID");
            entity.Property(e => e.StrBillingAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strBillingAddress");
        });

        modelBuilder.Entity<TpaymentMethod>(entity =>
        {
            entity.HasKey(e => e.IntPaymentMethod).HasName("PK__TPayment__74D498AFEB78D64F");

            entity.ToTable("TPaymentMethods", "db_owner");

            entity.Property(e => e.IntPaymentMethod)
                .ValueGeneratedNever()
                .HasColumnName("intPaymentMethod");
            entity.Property(e => e.StrPaymentMethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strPaymentMethodName");
        });

        modelBuilder.Entity<TpaymentStatus>(entity =>
        {
            entity.HasKey(e => e.IntPaymentStatusId).HasName("PK__TPayment__4141EB108EB291E3");

            entity.ToTable("TPaymentStatus", "db_owner");

            entity.Property(e => e.IntPaymentStatusId)
                .ValueGeneratedNever()
                .HasColumnName("intPaymentStatusID");
            entity.Property(e => e.StrPaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strPaymentStatus");
        });

        modelBuilder.Entity<Tpermission>(entity =>
        {
            entity.HasKey(e => e.IntPermissionId).HasName("TPermissions_PK");

            entity.ToTable("TPermissions", "db_owner");

            entity.Property(e => e.IntPermissionId)
                .ValueGeneratedNever()
                .HasColumnName("intPermissionID");
            entity.Property(e => e.StrDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrPermissionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strPermissionName");
        });

        modelBuilder.Entity<Tproduct>(entity =>
        {
            entity.HasKey(e => e.IntProductId).HasName("TProducts_PK");

            entity.ToTable("TProducts", "db_owner");

            entity.Property(e => e.IntProductId)
                .ValueGeneratedNever()
                .HasColumnName("intProductID");
            entity.Property(e => e.DecPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("decPrice");
            entity.Property(e => e.StrName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strName");
            entity.Property(e => e.StrPrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strPrice");
            entity.Property(e => e.StrStockAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strStockAmount");
        });

        modelBuilder.Entity<TproductImage>(entity =>
        {
            entity.HasKey(e => e.IntProductImageId).HasName("TProductImages_PK");

            entity.ToTable("TProductImages", "db_owner");

            entity.Property(e => e.IntProductImageId)
                .ValueGeneratedNever()
                .HasColumnName("intProductImageID");
            entity.Property(e => e.StrProductImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("strProductImageURL");
        });

        modelBuilder.Entity<TproductRecommendation>(entity =>
        {
            entity.HasKey(e => e.IntProductRecommendationId).HasName("TProductRecommendations_PK");

            entity.ToTable("TProductRecommendations", "db_owner");

            entity.Property(e => e.IntProductRecommendationId)
                .ValueGeneratedNever()
                .HasColumnName("intProductRecommendationID");
            entity.Property(e => e.DtmTimeOfRecommendation)
                .HasColumnType("datetime")
                .HasColumnName("dtmTimeOfRecommendation");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntUserId).HasColumnName("intUserID");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.StrRelevantScore)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strRelevantScore");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.IntProduct).WithMany(p => p.TproductRecommendations)
                .HasForeignKey(d => d.IntProductId)
                .HasConstraintName("TProductRecommendations_TProducts_FK");

            entity.HasOne(d => d.IntUser).WithMany(p => p.TproductRecommendations)
                .HasForeignKey(d => d.IntUserId)
                .HasConstraintName("TProductRecommendations_TUsers_FK");

            entity.HasOne(d => d.User).WithMany(p => p.TproductRecommendations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TProductRecommendations_AspNetUsers");
        });

        modelBuilder.Entity<Tpromotion>(entity =>
        {
            entity.HasKey(e => e.IntPromotionId).HasName("TPromotions_PK");

            entity.ToTable("TPromotions", "db_owner");

            entity.Property(e => e.IntPromotionId)
                .ValueGeneratedNever()
                .HasColumnName("intPromotionID");
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

        modelBuilder.Entity<Trace>(entity =>
        {
            entity.HasKey(e => e.IntRaceId).HasName("TRaces_PK");

            entity.ToTable("TRaces", "db_owner");

            entity.Property(e => e.IntRaceId)
                .ValueGeneratedNever()
                .HasColumnName("intRaceID");
            entity.Property(e => e.StrRace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strRace");
        });

        modelBuilder.Entity<Treview>(entity =>
        {
            entity.HasKey(e => e.IntReviewId).HasName("TReviews_PK");

            entity.ToTable("TReviews", "db_owner");

            entity.Property(e => e.IntReviewId)
                .ValueGeneratedNever()
                .HasColumnName("intReviewID");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntUserId).HasColumnName("intUserID");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.StrRating)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strRating");
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

            entity.HasOne(d => d.IntUser).WithMany(p => p.Treviews)
                .HasForeignKey(d => d.IntUserId)
                .HasConstraintName("TReviews_TUsers_FK");

            entity.HasOne(d => d.User).WithMany(p => p.Treviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TReviews_AspNetUsers");
        });

        modelBuilder.Entity<TshippingMethod>(entity =>
        {
            entity.HasKey(e => e.IntShippingMethodId).HasName("TShippingMethods_PK");

            entity.ToTable("TShippingMethods", "db_owner");

            entity.Property(e => e.IntShippingMethodId)
                .ValueGeneratedNever()
                .HasColumnName("intShippingMethodID");
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

        modelBuilder.Entity<TshippingStatus>(entity =>
        {
            entity.HasKey(e => e.IntShippingStatusId).HasName("TShippingStatus_PK");

            entity.ToTable("TShippingStatus", "db_owner");

            entity.Property(e => e.IntShippingStatusId)
                .ValueGeneratedNever()
                .HasColumnName("intShippingStatusID");
            entity.Property(e => e.StrShippingStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strShippingStatus");
        });

        modelBuilder.Entity<TshoppingCart>(entity =>
        {
            entity.HasKey(e => e.IntShoppingCartId).HasName("PK__TShoppin__0A3129178578D1E1");

            entity.ToTable("TShoppingCarts", "db_owner");

            entity.Property(e => e.IntShoppingCartId).HasColumnName("intShoppingCartID");
            entity.Property(e => e.DtmDateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtmDateCreated");
            entity.Property(e => e.DtmDateLastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtmDateLastUpdated");
            entity.Property(e => e.SessionId)
                .HasMaxLength(450)
                .HasColumnName("session_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.TshoppingCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TShoppingCarts_AspNetUsers");
        });

        modelBuilder.Entity<Tstate>(entity =>
        {
            entity.HasKey(e => e.IntStateId).HasName("TStates_PK");

            entity.ToTable("TStates", "db_owner");

            entity.Property(e => e.IntStateId)
                .ValueGeneratedNever()
                .HasColumnName("intStateID");
            entity.Property(e => e.StrState)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strState");
        });

        modelBuilder.Entity<TticketCategory>(entity =>
        {
            entity.HasKey(e => e.IntTicketCategoryId).HasName("TTicketCategories_PK");

            entity.ToTable("TTicketCategories", "db_owner");

            entity.Property(e => e.IntTicketCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("intTicketCategoryID");
            entity.Property(e => e.StrTicketCategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTicketCategory");
        });

        modelBuilder.Entity<TticketStatus>(entity =>
        {
            entity.HasKey(e => e.IntTicketStatusId).HasName("TTicketStatus_PK");

            entity.ToTable("TTicketStatus", "db_owner");

            entity.Property(e => e.IntTicketStatusId)
                .ValueGeneratedNever()
                .HasColumnName("intTicketStatusID");
            entity.Property(e => e.StrTicketStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strTicketStatus");
        });

        modelBuilder.Entity<Tuser>(entity =>
        {
            entity.HasKey(e => e.IntUserId).HasName("TUsers_PK");

            entity.ToTable("TUsers", "db_owner");

            entity.Property(e => e.IntUserId)
                .ValueGeneratedNever()
                .HasColumnName("intUserID");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.IntUserRoleId).HasColumnName("intUserRoleID");
            entity.Property(e => e.StrBillingAddress)
                .HasMaxLength(255)
                .HasColumnName("strBillingAddress");
            entity.Property(e => e.StrDateCreated)
                .HasColumnType("datetime")
                .HasColumnName("strDateCreated");
            entity.Property(e => e.StrEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strEmail");
            entity.Property(e => e.StrFirstName)
                .HasMaxLength(50)
                .HasColumnName("strFirstName");
            entity.Property(e => e.StrLastLoginDate)
                .HasColumnType("datetime")
                .HasColumnName("strLastLoginDate");
            entity.Property(e => e.StrLastName)
                .HasMaxLength(50)
                .HasColumnName("strLastName");
            entity.Property(e => e.StrPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strPassword");
            entity.Property(e => e.StrShippingAddress).HasColumnName("strShippingAddress");

            entity.HasOne(d => d.IntUserRole).WithMany(p => p.Tusers)
                .HasForeignKey(d => d.IntUserRoleId)
                .HasConstraintName("FK_intUserRoleID");
        });

        modelBuilder.Entity<TuserRole>(entity =>
        {
            entity.HasKey(e => e.IntUserRoleId).HasName("TUserRoles_PK");

            entity.ToTable("TUserRoles", "db_owner");

            entity.Property(e => e.IntUserRoleId)
                .ValueGeneratedNever()
                .HasColumnName("intUserRoleID");
            entity.Property(e => e.StrRole)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
