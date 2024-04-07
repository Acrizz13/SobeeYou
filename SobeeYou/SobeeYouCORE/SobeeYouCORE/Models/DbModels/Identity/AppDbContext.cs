using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SobeeYouCORE.Models.DbModels.Identity;

public partial class AppDbContext : DbContext {
    //public AppDbContext() {
    //}

    //public AppDbContext(DbContextOptions<AppDbContext> options)
    //    : base(options) {
    //}

    //    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    //    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    //    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    //    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    //    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    //    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    //    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    //    public virtual DbSet<Tadmin> Tadmins { get; set; }

    //    public virtual DbSet<TcartItem> TcartItems { get; set; }

    //    public virtual DbSet<Tcity> Tcities { get; set; }

    //    public virtual DbSet<Tcoupon> Tcoupons { get; set; }

    //    public virtual DbSet<TcustomerServiceTicket> TcustomerServiceTickets { get; set; }

    //    public virtual DbSet<TdrinkCategory> TdrinkCategories { get; set; }

    //    public virtual DbSet<Tfavorite> Tfavorites { get; set; }

    //    public virtual DbSet<Tflavor> Tflavors { get; set; }

    //    public virtual DbSet<Tgender> Tgenders { get; set; }

    //    public virtual DbSet<Tingredient> Tingredients { get; set; }

    //    public virtual DbSet<Torder> Torders { get; set; }

    //    public virtual DbSet<TorderItem> TorderItems { get; set; }

    //    public virtual DbSet<TordersProduct> TordersProducts { get; set; }

    //    public virtual DbSet<Tpayment> Tpayments { get; set; }

    //    public virtual DbSet<TpaymentMethod> TpaymentMethods { get; set; }

    //    public virtual DbSet<TpaymentStatus> TpaymentStatuses { get; set; }

    //    public virtual DbSet<Tpermission> Tpermissions { get; set; }

    //    public virtual DbSet<Tproduct> Tproducts { get; set; }

    //    public virtual DbSet<TproductImage> TproductImages { get; set; }

    //    public virtual DbSet<TproductRecommendation> TproductRecommendations { get; set; }

    //    public virtual DbSet<Tpromotion> Tpromotions { get; set; }

    //    public virtual DbSet<Trace> Traces { get; set; }

    //    public virtual DbSet<Treview> Treviews { get; set; }

    //    public virtual DbSet<TshippingMethod> TshippingMethods { get; set; }

    //    public virtual DbSet<TshippingStatus> TshippingStatuses { get; set; }

    //    public virtual DbSet<TshoppingCart> TshoppingCarts { get; set; }

    //    public virtual DbSet<Tstate> Tstates { get; set; }

    //    public virtual DbSet<TticketCategory> TticketCategories { get; set; }

    //    public virtual DbSet<TticketStatus> TticketStatuses { get; set; }

    //    public virtual DbSet<Tuser> Tusers { get; set; }

    //    public virtual DbSet<TuserRole> TuserRoles { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("data source=itd2.cincinnatistate.edu;initial catalog=WAPP2-ChrismerA;user id=WAPP2-aChrismer;password=0695152;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework");

    //    protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //        modelBuilder.HasDefaultSchema("db_owner");

    //        modelBuilder.Entity<AspNetRole>(entity => {
    //            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
    //                .IsUnique()
    //                .HasFilter("([NormalizedName] IS NOT NULL)");

    //            entity.Property(e => e.Name).HasMaxLength(256);
    //            entity.Property(e => e.NormalizedName).HasMaxLength(256);
    //        });

    //        modelBuilder.Entity<AspNetRoleClaim>(entity => {
    //            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

    //            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
    //        });

    //        modelBuilder.Entity<AspNetUser>(entity => {
    //            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

    //            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
    //                .IsUnique()
    //                .HasFilter("([NormalizedUserName] IS NOT NULL)");

    //            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
    //            entity.Property(e => e.Email).HasMaxLength(256);
    //            entity.Property(e => e.IntUserRoleId).HasColumnName("intUserRoleID");
    //            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
    //            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
    //            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
    //            entity.Property(e => e.StrBillingAddress)
    //                .HasDefaultValue("")
    //                .HasColumnName("strBillingAddress");
    //            entity.Property(e => e.StrFirstName)
    //                .HasDefaultValue("")
    //                .HasColumnName("strFirstName");
    //            entity.Property(e => e.StrLastName)
    //                .HasDefaultValue("")
    //                .HasColumnName("strLastName");
    //            entity.Property(e => e.StrShippingAddress)
    //                .HasDefaultValue("")
    //                .HasColumnName("strShippingAddress");
    //            entity.Property(e => e.UserName).HasMaxLength(256);

    //            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
    //                .UsingEntity<Dictionary<string, object>>(
    //                    "AspNetUserRole",
    //                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
    //                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
    //                    j => {
    //                        j.HasKey("UserId", "RoleId");
    //                        j.ToTable("AspNetUserRoles");
    //                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
    //                    });
    //        });

    //        modelBuilder.Entity<AspNetUserClaim>(entity => {
    //            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

    //            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
    //        });

    //        modelBuilder.Entity<AspNetUserLogin>(entity => {
    //            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

    //            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

    //            entity.Property(e => e.LoginProvider).HasMaxLength(128);
    //            entity.Property(e => e.ProviderKey).HasMaxLength(128);

    //            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
    //        });

    //        modelBuilder.Entity<AspNetUserToken>(entity => {
    //            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

    //            entity.Property(e => e.LoginProvider).HasMaxLength(128);
    //            entity.Property(e => e.Name).HasMaxLength(128);

    //            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
    //        });



    //        modelBuilder.Entity<MigrationHistory>(entity => {
    //            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

    //            entity.ToTable("__MigrationHistory", "dbo");

    //            entity.Property(e => e.MigrationId).HasMaxLength(150);
    //            entity.Property(e => e.ContextKey).HasMaxLength(300);
    //            entity.Property(e => e.ProductVersion).HasMaxLength(32);
    //        });


    //        modelBuilder.Entity<Tadmin>(entity => {
    //            entity.HasKey(e => e.intAdminID).HasName("TAdmins_PK");

    //            entity.ToTable("TAdmins");

    //            entity.Property(e => e.intAdminID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intAdminID");
    //            entity.Property(e => e.strAdminName)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strAdminName");
    //        });

    //        modelBuilder.Entity<TcartItem>(entity => {
    //            entity.HasKey(e => e.intCartItemID).HasName("PK__TCartIte__4A33868DCDF2DFE8");

    //            entity.ToTable("TCartItems");

    //            entity.Property(e => e.intCartItemID).HasColumnName("intCartItemID");
    //            entity.Property(e => e.dtmDateAdded)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmDateAdded");
    //            entity.Property(e => e.intProductID).HasColumnName("intProductID");
    //            entity.Property(e => e.intQuantity).HasColumnName("intQuantity");
    //            entity.Property(e => e.intShoppingCartID).HasColumnName("intShoppingCartID");

    //            entity.HasOne(d => d.Product).WithMany(p => p.TcartItems)
    //                .HasForeignKey(d => d.intProductID)
    //                .HasConstraintName("FK__TCartItem__intPr__1D4655FB");

    //            entity.HasOne(d => d.ShoppingCart).WithMany(p => p.TcartItems)
    //                .HasForeignKey(d => d.intShoppingCartID)
    //                .HasConstraintName("FK__TCartItem__intSh__1C5231C2");
    //        });

    //        modelBuilder.Entity<Tcity>(entity => {
    //            entity.HasKey(e => e.intCityID).HasName("TCities_PK");

    //            entity.ToTable("TCities");

    //            entity.Property(e => e.intCityID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intCityID");
    //            entity.Property(e => e.strCity)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strCity");
    //        });

    //        modelBuilder.Entity<Tcoupon>(entity => {
    //            entity.HasKey(e => e.intCouponID).HasName("TCoupons_PK");

    //            entity.ToTable("TCoupons");

    //            entity.Property(e => e.intCouponID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intCouponID");
    //            entity.Property(e => e.dtmExpirationDate)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmExpirationDate");
    //            entity.Property(e => e.strCouponCode)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strCouponCode");
    //            entity.Property(e => e.strDiscountAmount)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strDiscountAmount");
    //        });

    //        modelBuilder.Entity<TcustomerServiceTicket>(entity => {
    //            entity.HasKey(e => e.intCustomerServiceTicketID).HasName("TCustomerServiceTickets_PK");

    //            entity.ToTable("TCustomerServiceTickets");

    //            entity.Property(e => e.intCustomerServiceTicketID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intCustomerServiceTicketID");
    //            entity.Property(e => e.dtmTimeOfSubmission)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmTimeOfSubmission");
    //            entity.Property(e => e.intTicketCategoryID).HasColumnName("intTicketCategoryID");
    //            entity.Property(e => e.intTicketStatusID).HasColumnName("intTicketStatusID");
    //            entity.Property(e => e.intUserID).HasColumnName("intUserID");
    //            entity.Property(e => e.strDescription)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strDescription");
    //            entity.Property(e => e.userID)
    //                .HasMaxLength(450)
    //                .HasColumnName("user_id");

    //            entity.HasOne(d => d.TicketCategory).WithMany(p => p.TcustomerServiceTicket)
    //                .HasForeignKey(d => d.intTicketCategoryID)
    //                .HasConstraintName("TCustomerServiceTickets_TTicketCategories_FK");

    //            entity.HasOne(d => d.TicketCategory).WithMany(p => p.TcustomerServiceTicket)
    //                .HasForeignKey(d => d.intTicketStatusID)
    //                .HasConstraintName("TCustomerServiceTickets_TTicketStatus_FK");

    //            entity.HasOne(d => d.User).WithMany(p => p.TcustomerServiceTicket)
    //                .HasForeignKey(d => d.intUserID)
    //                .HasConstraintName("TCustomerServiceTickets_TUsers_FK");

    //            entity.HasOne(d => d.User).WithMany(p => p.TcustomerServiceTicket)
    //                .HasForeignKey(d => d.userID)
    //                .HasConstraintName("FK_TCustomerServiceTickets_AspNetUsers");
    //        });

    //        modelBuilder.Entity<TdrinkCategory>(entity => {
    //            entity.HasKey(e => e.intDrinkCategoryID).HasName("TDrinkCategories_PK");

    //            entity.ToTable("TDrinkCategories");

    //            entity.Property(e => e.intDrinkCategoryID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intDrinkCategoryID");
    //            entity.Property(e => e.strDrinkCategory)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strDrinkCategory");
    //        });

    //        modelBuilder.Entity<Tfavorite>(entity => {
    //            entity.HasKey(e => e.intFavoriteID).HasName("TFavorites_PK");

    //            entity.ToTable("TFavorites");

    //            entity.Property(e => e.intFavoriteID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intFavoriteID");
    //            entity.Property(e => e.strFavorite)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strFavorite");
    //        });

    //        modelBuilder.Entity<Tflavor>(entity => {
    //            entity.HasKey(e => e.intFlavorID).HasName("TFlavors_PK");

    //            entity.ToTable("TFlavors");

    //            entity.Property(e => e.intFlavorID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intFlavorID");
    //            entity.Property(e => e.strFlavor)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strFlavor");
    //        });

    //        modelBuilder.Entity<Tgender>(entity => {
    //            entity.HasKey(e => e.intGenderID).HasName("TGenders_PK");

    //            entity.ToTable("TGenders");

    //            entity.Property(e => e.intGenderID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intGenderID");
    //            entity.Property(e => e.strGender)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strGender");
    //        });

    //        modelBuilder.Entity<Tingredient>(entity => {
    //            entity.HasKey(e => e.intIngredientID).HasName("TIngredients_PK");

    //            entity.ToTable("TIngredients");

    //            entity.Property(e => e.intIngredientID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intIngredientID");
    //            entity.Property(e => e.strIngredient)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strIngredient");
    //        });

    //        modelBuilder.Entity<Torder>(entity => {
    //            entity.HasKey(e => e.intOrderID).HasName("PK__TOrders__447BBC4445C2DAD9");

    //            entity.ToTable("TOrders");

    //            entity.Property(e => e.intOrderID).HasColumnName("intOrderID");
    //            entity.Property(e => e.decTotalAmount)
    //                .HasColumnType("decimal(10, 2)")
    //                .HasColumnName("decTotalAmount");
    //            entity.Property(e => e.dtmOrderDate)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmOrderDate");
    //            entity.Property(e => e.intPaymentMethod).HasColumnName("intPaymentMethod");
    //            entity.Property(e => e.intShippingStatusID).HasColumnName("intShippingStatusID");
    //            entity.Property(e => e.intUserID).HasColumnName("intUserID");
    //            entity.Property(e => e.strOrderStatus)
    //                .HasMaxLength(50)
    //                .IsUnicode(false)
    //                .HasDefaultValue("Pending")
    //                .HasColumnName("strOrderStatus");
    //            entity.Property(e => e.strShippingAddress)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strShippingAddress");
    //            entity.Property(e => e.strTrackingNumber)
    //                .HasMaxLength(50)
    //                .IsUnicode(false)
    //                .HasColumnName("strTrackingNumber");
    //            entity.Property(e => e.userID)
    //                .HasMaxLength(450)
    //                .HasColumnName("user_id");

    //            entity.HasOne(d => d.intPaymentMethodNavigation).WithMany(p => p.Torders)
    //                .HasForeignKey(d => d.intPaymentMethod)
    //                .HasConstraintName("FK_PaymentMethod");

    //            entity.HasOne(d => d.intShippingStatus).WithMany(p => p.Torders)
    //                .HasForeignKey(d => d.intShippingStatusID)
    //                .HasConstraintName("FK_TOrders_TShippingStatus");

    //            entity.HasOne(d => d.Tuser).WithMany(p => p.Torders)
    //                .HasForeignKey(d => d.intUserID)
    //                .HasConstraintName("FK__TOrders__intUser__0FEC5ADD");

    //            entity.HasOne(d => d.User).WithMany(p => p.Torders)
    //                .HasForeignKey(d => d.userID)
    //                .HasConstraintName("FK_TORders_AspNetUsers");
    //        });

    //        modelBuilder.Entity<TorderItem>(entity => {
    //            entity.HasKey(e => e.intOrderItemID).HasName("PK__TOrderIt__33B60225A0D3B9FE");

    //            entity.ToTable("TOrderItems");

    //            entity.Property(e => e.intOrderItemID).HasColumnName("intOrderItemID");
    //            entity.Property(e => e.intOrderID).HasColumnName("intOrderID");
    //            entity.Property(e => e.intProductID).HasColumnName("intProductID");
    //            entity.Property(e => e.intQuantity).HasColumnName("intQuantity");
    //            entity.Property(e => e.monPricePerUnit)
    //                .HasColumnType("money")
    //                .HasColumnName("monPricePerUnit");

    //            entity.HasOne(d => d.intOrder).WithMany(p => p.TorderItems)
    //                .HasForeignKey(d => d.intOrderID)
    //                .HasConstraintName("FK__TOrderIte__intOr__12C8C788");

    //            entity.HasOne(d => d.intProduct).WithMany(p => p.TorderItems)
    //                .HasForeignKey(d => d.intProductID)
    //                .HasConstraintName("FK__TOrderIte__intPr__13BCEBC1");
    //        });

    //        modelBuilder.Entity<Tpayment>(entity => {
    //            entity.HasKey(e => e.intPaymentID).HasName("TPayments_PK");

    //            entity.ToTable("TPayments");

    //            entity.Property(e => e.intPaymentID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intPaymentID");
    //            entity.Property(e => e.intPaymentMethod).HasColumnName("intPaymentMethod");
    //            entity.Property(e => e.intPaymentMethodID).HasColumnName("intPaymentMethodID");
    //            entity.Property(e => e.strBillingAddress)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strBillingAddress");
    //        });

    //        modelBuilder.Entity<TpaymentMethod>(entity => {
    //            entity.HasKey(e => e.intPaymentMethod).HasName("PK__TPayment__74D498AF41BBBA60");

    //            entity.ToTable("TPaymentMethods");

    //            entity.Property(e => e.intPaymentMethod)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intPaymentMethod");
    //            entity.Property(e => e.strPaymentMethodName)
    //                .HasMaxLength(50)
    //                .IsUnicode(false)
    //                .HasColumnName("strPaymentMethodName");
    //        });

    //        modelBuilder.Entity<TpaymentStatus>(entity => {
    //            entity.HasKey(e => e.intPaymentStatusID).HasName("PK__TPayment__4141EB108DDA446F");

    //            entity.ToTable("TPaymentStatus");

    //            entity.Property(e => e.intPaymentStatusID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intPaymentStatusID");
    //            entity.Property(e => e.strPaymentStatus)
    //                .HasMaxLength(50)
    //                .IsUnicode(false)
    //                .HasColumnName("strPaymentStatus");
    //        });

    //        modelBuilder.Entity<Tpermission>(entity => {
    //            entity.HasKey(e => e.intPermissionID).HasName("TPermissions_PK");

    //            entity.ToTable("TPermissions");

    //            entity.Property(e => e.intPermissionID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intPermissionID");
    //            entity.Property(e => e.strDescription)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strDescription");
    //            entity.Property(e => e.strPermissionName)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strPermissionName");
    //        });

    //        modelBuilder.Entity<Tproduct>(entity => {
    //            entity.HasKey(e => e.intProductID).HasName("TProducts_PK");

    //            entity.ToTable("TProducts");

    //            entity.Property(e => e.intProductID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intProductID");
    //            entity.Property(e => e.decPrice)
    //                .HasColumnType("decimal(18, 2)")
    //                .HasColumnName("decPrice");
    //            entity.Property(e => e.strName)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strName");
    //            entity.Property(e => e.strPrice)
    //                .HasMaxLength(50)
    //                .IsUnicode(false)
    //                .HasColumnName("strPrice");
    //            entity.Property(e => e.strStockAmount)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strStockAmount");
    //        });

    //        modelBuilder.Entity<TproductImage>(entity => {
    //            entity.HasKey(e => e.intProductImageID).HasName("TProductImages_PK");

    //            entity.ToTable("TProductImages");

    //            entity.Property(e => e.intProductImageID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intProductImageID");
    //            entity.Property(e => e.strProductImageUrl)
    //                .HasMaxLength(1000)
    //                .IsUnicode(false)
    //                .HasColumnName("strProductImageURL");
    //        });

    //        modelBuilder.Entity<TproductRecommendation>(entity => {
    //            entity.HasKey(e => e.intProductRecommendationID).HasName("TProductRecommendations_PK");

    //            entity.ToTable("TProductRecommendations");

    //            entity.Property(e => e.intProductRecommendationID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intProductRecommendationID");
    //            entity.Property(e => e.dtmTimeOfRecommendation)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmTimeOfRecommendation");
    //            entity.Property(e => e.intProductID).HasColumnName("intProductID");
    //            entity.Property(e => e.intUserID).HasColumnName("intUserID");
    //            entity.Property(e => e.strRelevantScore)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strRelevantScore");
    //            entity.Property(e => e.userID)
    //                .HasMaxLength(450)
    //                .HasColumnName("user_id");

    //            entity.HasOne(d => d.intProduct).WithMany(p => p.TproductRecommendations)
    //                .HasForeignKey(d => d.intProductID)
    //                .HasConstraintName("TProductRecommendations_TProducts_FK");

    //            entity.HasOne(d => d.intUser).WithMany(p => p.TproductRecommendations)
    //                .HasForeignKey(d => d.intUserID)
    //                .HasConstraintName("TProductRecommendations_TUsers_FK");

    //            entity.HasOne(d => d.user).WithMany(p => p.TproductRecommendations)
    //                .HasForeignKey(d => d.userID)
    //                .HasConstraintName("FK_TProductRecommendations_AspNetUsers");
    //        });

    //        modelBuilder.Entity<Tpromotion>(entity => {
    //            entity.HasKey(e => e.intPromotionID).HasName("TPromotions_PK");

    //            entity.ToTable("TPromotions");

    //            entity.Property(e => e.intPromotionID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intPromotionID");
    //            entity.Property(e => e.dtmExpirationDate)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmExpirationDate");
    //            entity.Property(e => e.strDiscountPercentage)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strDiscountPercentage");
    //            entity.Property(e => e.strPromoCode)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strPromoCode");
    //        });

    //        modelBuilder.Entity<Trace>(entity => {
    //            entity.HasKey(e => e.intRaceID).HasName("TRaces_PK");

    //            entity.ToTable("TRaces");

    //            entity.Property(e => e.intRaceID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intRaceID");
    //            entity.Property(e => e.strRace)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strRace");
    //        });

    //        modelBuilder.Entity<Treview>(entity => {
    //            entity.HasKey(e => e.intReviewID).HasName("TReviews_PK");

    //            entity.ToTable("TReviews");

    //            entity.Property(e => e.intReviewID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intReviewID");
    //            entity.Property(e => e.intProductID).HasColumnName("intProductID");
    //            entity.Property(e => e.intUserID).HasColumnName("intUserID");
    //            entity.Property(e => e.strRating)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strRating");
    //            entity.Property(e => e.strReviewText)
    //                .HasMaxLength(1000)
    //                .IsUnicode(false)
    //                .HasColumnName("strReviewText");
    //            entity.Property(e => e.userID)
    //                .HasMaxLength(450)
    //                .HasColumnName("user_id");

    //            entity.HasOne(d => d.intProduct).WithMany(p => p.Treviews)
    //                .HasForeignKey(d => d.intProductID)
    //                .HasConstraintName("TReviews_TProducts_FK");

    //            entity.HasOne(d => d.intUser).WithMany(p => p.Treviews)
    //                .HasForeignKey(d => d.intUserID)
    //                .HasConstraintName("TReviews_TUsers_FK");

    //            entity.HasOne(d => d.user).WithMany(p => p.Treviews)
    //                .HasForeignKey(d => d.userID)
    //                .HasConstraintName("FK_TReviews_AspNetUsers");
    //        });

    //        modelBuilder.Entity<TshippingMethod>(entity => {
    //            entity.HasKey(e => e.intShippingMethodID).HasName("TShippingMethods_PK");

    //            entity.ToTable("TShippingMethods");

    //            entity.Property(e => e.intShippingMethodID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intShippingMethodID");
    //            entity.Property(e => e.dtmEstimatedDelivery)
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmEstimatedDelivery");
    //            entity.Property(e => e.strBillingAddress)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strBillingAddress");
    //            entity.Property(e => e.strCost)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strCost");
    //            entity.Property(e => e.strShippingName)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strShippingName");
    //        });

    //        modelBuilder.Entity<TshippingStatus>(entity => {
    //            entity.HasKey(e => e.intShippingStatusID).HasName("TShippingStatus_PK");

    //            entity.ToTable("TShippingStatus");

    //            entity.Property(e => e.intShippingStatusID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intShippingStatusID");
    //            entity.Property(e => e.strShippingStatus)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strShippingStatus");
    //        });

    //        modelBuilder.Entity<TshoppingCart>(entity => {
    //            entity.HasKey(e => e.intShoppingCartID).HasName("PK__TShoppin__0A31291739EF1EA0");

    //            entity.ToTable("TShoppingCarts");

    //            entity.Property(e => e.intShoppingCartID).HasColumnName("intShoppingCartID");
    //            entity.Property(e => e.dtmDateCreated)
    //                .HasDefaultValueSql("(getdate())")
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmDateCreated");
    //            entity.Property(e => e.dtmDateLastUpdated)
    //                .HasDefaultValueSql("(getdate())")
    //                .HasColumnType("datetime")
    //                .HasColumnName("dtmDateLastUpdated");
    //            entity.Property(e => e.userID)
    //                .HasMaxLength(450)
    //                .HasColumnName("user_id");

    //            entity.HasOne(d => d.user).WithMany(p => p.TshoppingCarts)
    //                .HasForeignKey(d => d.userID)
    //                .HasConstraintName("FK_TShoppingCarts_AspNetUsers");
    //        });

    //        modelBuilder.Entity<Tstate>(entity => {
    //            entity.HasKey(e => e.intStateID).HasName("TStates_PK");

    //            entity.ToTable("TStates");

    //            entity.Property(e => e.intStateID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intStateID");
    //            entity.Property(e => e.strState)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strState");
    //        });

    //        modelBuilder.Entity<TticketCategory>(entity => {
    //            entity.HasKey(e => e.intTicketCategoryID).HasName("TTicketCategories_PK");

    //            entity.ToTable("TTicketCategories");

    //            entity.Property(e => e.intTicketCategoryID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intTicketCategoryID");
    //            entity.Property(e => e.strTicketCategory)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strTicketCategory");
    //        });

    //        modelBuilder.Entity<TticketStatus>(entity => {
    //            entity.HasKey(e => e.intTicketStatusID).HasName("TTicketStatus_PK");

    //            entity.ToTable("TTicketStatus");

    //            entity.Property(e => e.intTicketStatusID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intTicketStatusID");
    //            entity.Property(e => e.strTicketStatus)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strTicketStatus");
    //        });

    //        modelBuilder.Entity<Tuser>(entity => {
    //            entity.HasKey(e => e.intUserID).HasName("TUsers_PK");

    //            entity.ToTable("TUsers");

    //            entity.Property(e => e.intUserID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intUserID");
    //            entity.Property(e => e.userID)
    //                .HasMaxLength(50)
    //                .HasColumnName("ID");
    //            entity.Property(e => e.intUserRoleID).HasColumnName("intUserRoleID");
    //            entity.Property(e => e.strBillingAddress)
    //                .HasMaxLength(255)
    //                .HasColumnName("strBillingAddress");
    //            entity.Property(e => e.strDateCreated)
    //                .HasColumnType("datetime")
    //                .HasColumnName("strDateCreated");
    //            entity.Property(e => e.strEmail)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strEmail");
    //            entity.Property(e => e.strFirstName)
    //                .HasMaxLength(50)
    //                .HasColumnName("strFirstName");
    //            entity.Property(e => e.strLastLoginDate)
    //                .HasColumnType("datetime")
    //                .HasColumnName("strLastLoginDate");
    //            entity.Property(e => e.strLastName)
    //                .HasMaxLength(50)
    //                .HasColumnName("strLastName");
    //            entity.Property(e => e.strPassword)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strPassword");
    //            entity.Property(e => e.strShippingAddress).HasColumnName("strShippingAddress");

    //            entity.HasOne(d => d.intUserRole).WithMany(p => p.Tusers)
    //                .HasForeignKey(d => d.intUserRoleID)
    //                .HasConstraintName("FK_intUserRoleID");
    //        });

    //        modelBuilder.Entity<TuserRole>(entity => {
    //            entity.HasKey(e => e.intUserRoleID).HasName("TUserRoles_PK");

    //            entity.ToTable("TUserRoles");

    //            entity.Property(e => e.intUserRoleID)
    //                .ValueGeneratedNever()
    //                .HasColumnName("intUserRoleID");
    //            entity.Property(e => e.strRole)
    //                .HasMaxLength(255)
    //                .IsUnicode(false)
    //                .HasColumnName("strRole");
    //        });




    //        OnModelCreatingPartial(modelBuilder);
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
