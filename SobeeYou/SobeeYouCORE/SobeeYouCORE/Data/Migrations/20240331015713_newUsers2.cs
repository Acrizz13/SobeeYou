using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Data.Migrations {
    /// <inheritdoc />
    public partial class newUsers2 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.EnsureSchema(
                name: "db_owner");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "db_owner",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    strShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    intUserRoleID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    schema: "db_owner",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "db_owner",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TAdmins",
                schema: "db_owner",
                columns: table => new {
                    intAdminID = table.Column<int>(type: "int", nullable: false),
                    strAdminName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TAdmins_PK", x => x.intAdminID);
                });

            migrationBuilder.CreateTable(
                name: "TCities",
                schema: "db_owner",
                columns: table => new {
                    intCityID = table.Column<int>(type: "int", nullable: false),
                    strCity = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TCities_PK", x => x.intCityID);
                });

            migrationBuilder.CreateTable(
                name: "TCoupons",
                schema: "db_owner",
                columns: table => new {
                    intCouponID = table.Column<int>(type: "int", nullable: false),
                    strCouponCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strDiscountAmount = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    dtmExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TCoupons_PK", x => x.intCouponID);
                });

            migrationBuilder.CreateTable(
                name: "TDrinkCategories",
                schema: "db_owner",
                columns: table => new {
                    intDrinkCategoryID = table.Column<int>(type: "int", nullable: false),
                    strDrinkCategory = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TDrinkCategories_PK", x => x.intDrinkCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TFavorites",
                schema: "db_owner",
                columns: table => new {
                    intFavoriteID = table.Column<int>(type: "int", nullable: false),
                    strFavorite = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TFavorites_PK", x => x.intFavoriteID);
                });

            migrationBuilder.CreateTable(
                name: "TFlavors",
                schema: "db_owner",
                columns: table => new {
                    intFlavorID = table.Column<int>(type: "int", nullable: false),
                    strFlavor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TFlavors_PK", x => x.intFlavorID);
                });

            migrationBuilder.CreateTable(
                name: "TGenders",
                schema: "db_owner",
                columns: table => new {
                    intGenderID = table.Column<int>(type: "int", nullable: false),
                    strGender = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TGenders_PK", x => x.intGenderID);
                });

            migrationBuilder.CreateTable(
                name: "TIngredients",
                schema: "db_owner",
                columns: table => new {
                    intIngredientID = table.Column<int>(type: "int", nullable: false),
                    strIngredient = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TIngredients_PK", x => x.intIngredientID);
                });

            migrationBuilder.CreateTable(
                name: "TPaymentMethods",
                schema: "db_owner",
                columns: table => new {
                    intPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    strPaymentMethodName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK__TPayment__74D498AF41BBBA60", x => x.intPaymentMethod);
                });

            migrationBuilder.CreateTable(
                name: "TPayments",
                schema: "db_owner",
                columns: table => new {
                    intPaymentID = table.Column<int>(type: "int", nullable: false),
                    strBillingAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    intPaymentMethodID = table.Column<int>(type: "int", nullable: false),
                    intPaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TPayments_PK", x => x.intPaymentID);
                });

            migrationBuilder.CreateTable(
                name: "TPaymentStatus",
                schema: "db_owner",
                columns: table => new {
                    intPaymentStatusID = table.Column<int>(type: "int", nullable: false),
                    strPaymentStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK__TPayment__4141EB108DDA446F", x => x.intPaymentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TPermissions",
                schema: "db_owner",
                columns: table => new {
                    intPermissionID = table.Column<int>(type: "int", nullable: false),
                    strPermissionName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TPermissions_PK", x => x.intPermissionID);
                });

            migrationBuilder.CreateTable(
                name: "TProductImages",
                schema: "db_owner",
                columns: table => new {
                    intProductImageID = table.Column<int>(type: "int", nullable: false),
                    strProductImageURL = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TProductImages_PK", x => x.intProductImageID);
                });

            migrationBuilder.CreateTable(
                name: "TProducts",
                schema: "db_owner",
                columns: table => new {
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    strName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strStockAmount = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    decPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    strPrice = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TProducts_PK", x => x.intProductID);
                });

            migrationBuilder.CreateTable(
                name: "TPromotions",
                schema: "db_owner",
                columns: table => new {
                    intPromotionID = table.Column<int>(type: "int", nullable: false),
                    strPromoCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strDiscountPercentage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    dtmExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TPromotions_PK", x => x.intPromotionID);
                });

            migrationBuilder.CreateTable(
                name: "TRaces",
                schema: "db_owner",
                columns: table => new {
                    intRaceID = table.Column<int>(type: "int", nullable: false),
                    strRace = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TRaces_PK", x => x.intRaceID);
                });

            migrationBuilder.CreateTable(
                name: "TShippingMethods",
                schema: "db_owner",
                columns: table => new {
                    intShippingMethodID = table.Column<int>(type: "int", nullable: false),
                    strShippingName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strBillingAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    dtmEstimatedDelivery = table.Column<DateTime>(type: "datetime", nullable: false),
                    strCost = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TShippingMethods_PK", x => x.intShippingMethodID);
                });

            migrationBuilder.CreateTable(
                name: "TShippingStatus",
                schema: "db_owner",
                columns: table => new {
                    intShippingStatusID = table.Column<int>(type: "int", nullable: false),
                    strShippingStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TShippingStatus_PK", x => x.intShippingStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TStates",
                schema: "db_owner",
                columns: table => new {
                    intStateID = table.Column<int>(type: "int", nullable: false),
                    strState = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TStates_PK", x => x.intStateID);
                });

            migrationBuilder.CreateTable(
                name: "TTicketCategories",
                schema: "db_owner",
                columns: table => new {
                    intTicketCategoryID = table.Column<int>(type: "int", nullable: false),
                    strTicketCategory = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TTicketCategories_PK", x => x.intTicketCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TTicketStatus",
                schema: "db_owner",
                columns: table => new {
                    intTicketStatusID = table.Column<int>(type: "int", nullable: false),
                    strTicketStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TTicketStatus_PK", x => x.intTicketStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TUserRoles",
                schema: "db_owner",
                columns: table => new {
                    intUserRoleID = table.Column<int>(type: "int", nullable: false),
                    strRole = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TUserRoles_PK", x => x.intUserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "db_owner",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "db_owner",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "db_owner",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "db_owner",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "db_owner",
                columns: table => new {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "db_owner",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "db_owner",
                columns: table => new {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "db_owner",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "db_owner",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "db_owner",
                columns: table => new {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "db_owner",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TOrdersProducts",
                schema: "db_owner",
                columns: table => new {
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    IntOrdersProductId = table.Column<int>(type: "int", nullable: false),
                    strOrdersProduct = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TOrdersProducts_PK", x => x.intProductID);
                    table.ForeignKey(
                        name: "TOrdersProducts_TProducts_FK",
                        column: x => x.intProductID,
                        principalSchema: "db_owner",
                        principalTable: "TProducts",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TUsers",
                schema: "db_owner",
                columns: table => new {
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strPassword = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    intUserRoleID = table.Column<int>(type: "int", nullable: false),
                    strBillingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    strFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    strLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    strDateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    strLastLoginDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TUsers_PK", x => x.intUserID);
                    table.ForeignKey(
                        name: "FK_intUserRoleID",
                        column: x => x.intUserRoleID,
                        principalSchema: "db_owner",
                        principalTable: "TUserRoles",
                        principalColumn: "intUserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCustomerServiceTickets",
                schema: "db_owner",
                columns: table => new {
                    intCustomerServiceTicketID = table.Column<int>(type: "int", nullable: false),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    intTicketCategoryID = table.Column<int>(type: "int", nullable: false),
                    intTicketStatusID = table.Column<int>(type: "int", nullable: false),
                    dtmTimeOfSubmission = table.Column<DateTime>(type: "datetime", nullable: false),
                    strDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TCustomerServiceTickets_PK", x => x.intCustomerServiceTicketID);
                    table.ForeignKey(
                        name: "TCustomerServiceTickets_TTicketCategories_FK",
                        column: x => x.intTicketCategoryID,
                        principalSchema: "db_owner",
                        principalTable: "TTicketCategories",
                        principalColumn: "intTicketCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TCustomerServiceTickets_TTicketStatus_FK",
                        column: x => x.intTicketStatusID,
                        principalSchema: "db_owner",
                        principalTable: "TTicketStatus",
                        principalColumn: "intTicketStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TCustomerServiceTickets_TUsers_FK",
                        column: x => x.intUserID,
                        principalSchema: "db_owner",
                        principalTable: "TUsers",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TOrders",
                schema: "db_owner",
                columns: table => new {
                    intOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    dtmOrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    decTotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    intShippingStatusID = table.Column<int>(type: "int", nullable: false),
                    strShippingAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    strTrackingNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    intPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    strOrderStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "Pending")
                },
                constraints: table => {
                    table.PrimaryKey("PK__TOrders__447BBC4445C2DAD9", x => x.intOrderID);
                    table.ForeignKey(
                        name: "FK_PaymentMethod",
                        column: x => x.intPaymentMethod,
                        principalSchema: "db_owner",
                        principalTable: "TPaymentMethods",
                        principalColumn: "intPaymentMethod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TOrders_TShippingStatus",
                        column: x => x.intShippingStatusID,
                        principalSchema: "db_owner",
                        principalTable: "TShippingStatus",
                        principalColumn: "intShippingStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__TOrders__intUser__0FEC5ADD",
                        column: x => x.intUserID,
                        principalSchema: "db_owner",
                        principalTable: "TUsers",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TProductRecommendations",
                schema: "db_owner",
                columns: table => new {
                    intProductRecommendationID = table.Column<int>(type: "int", nullable: false),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    dtmTimeOfRecommendation = table.Column<DateTime>(type: "datetime", nullable: false),
                    strRelevantScore = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TProductRecommendations_PK", x => x.intProductRecommendationID);
                    table.ForeignKey(
                        name: "TProductRecommendations_TProducts_FK",
                        column: x => x.intProductID,
                        principalSchema: "db_owner",
                        principalTable: "TProducts",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TProductRecommendations_TUsers_FK",
                        column: x => x.intUserID,
                        principalSchema: "db_owner",
                        principalTable: "TUsers",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TReviews",
                schema: "db_owner",
                columns: table => new {
                    intReviewID = table.Column<int>(type: "int", nullable: false),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    strReviewText = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    strRating = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("TReviews_PK", x => x.intReviewID);
                    table.ForeignKey(
                        name: "TReviews_TProducts_FK",
                        column: x => x.intProductID,
                        principalSchema: "db_owner",
                        principalTable: "TProducts",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TReviews_TUsers_FK",
                        column: x => x.intUserID,
                        principalSchema: "db_owner",
                        principalTable: "TUsers",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TShoppingCarts",
                schema: "db_owner",
                columns: table => new {
                    intShoppingCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dtmDateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    dtmDateLastUpdated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    TuserintUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK__TShoppin__0A31291739EF1EA0", x => x.intShoppingCartID);
                    table.ForeignKey(
                        name: "FK_TShoppingCarts_TUsers_TuserintUserID",
                        column: x => x.TuserintUserID,
                        principalSchema: "db_owner",
                        principalTable: "TUsers",
                        principalColumn: "intUserID");
                    table.ForeignKey(
                        name: "FK__TShopping__intUs__178D7CA5",
                        column: x => x.intUserID,
                        principalSchema: "db_owner",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TOrderItems",
                schema: "db_owner",
                columns: table => new {
                    intOrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intOrderID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    intQuantity = table.Column<int>(type: "int", nullable: false),
                    monPricePerUnit = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK__TOrderIt__33B60225A0D3B9FE", x => x.intOrderItemID);
                    table.ForeignKey(
                        name: "FK__TOrderIte__intOr__12C8C788",
                        column: x => x.intOrderID,
                        principalSchema: "db_owner",
                        principalTable: "TOrders",
                        principalColumn: "intOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__TOrderIte__intPr__13BCEBC1",
                        column: x => x.intProductID,
                        principalSchema: "db_owner",
                        principalTable: "TProducts",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCartItems",
                schema: "db_owner",
                columns: table => new {
                    intCartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intShoppingCartID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    intQuantity = table.Column<int>(type: "int", nullable: false),
                    dtmDateAdded = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK__TCartIte__4A33868DCDF2DFE8", x => x.intCartItemID);
                    table.ForeignKey(
                        name: "FK__TCartItem__intPr__1D4655FB",
                        column: x => x.intProductID,
                        principalSchema: "db_owner",
                        principalTable: "TProducts",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__TCartItem__intSh__1C5231C2",
                        column: x => x.intShoppingCartID,
                        principalSchema: "db_owner",
                        principalTable: "TShoppingCarts",
                        principalColumn: "intShoppingCartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "db_owner",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "db_owner",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "db_owner",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "db_owner",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "db_owner",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "db_owner",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "db_owner",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_TCartItems_intProductID",
                schema: "db_owner",
                table: "TCartItems",
                column: "intProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TCartItems_intShoppingCartID",
                schema: "db_owner",
                table: "TCartItems",
                column: "intShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_intTicketCategoryID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intTicketCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_intTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intTicketStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_intUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TOrderItems_intOrderID",
                schema: "db_owner",
                table: "TOrderItems",
                column: "intOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_TOrderItems_intProductID",
                schema: "db_owner",
                table: "TOrderItems",
                column: "intProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TOrders_intPaymentMethod",
                schema: "db_owner",
                table: "TOrders",
                column: "intPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_TOrders_intShippingStatusID",
                schema: "db_owner",
                table: "TOrders",
                column: "intShippingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TOrders_intUserID",
                schema: "db_owner",
                table: "TOrders",
                column: "intUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TProductRecommendations_intProductID",
                schema: "db_owner",
                table: "TProductRecommendations",
                column: "intProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TProductRecommendations_intUserID",
                schema: "db_owner",
                table: "TProductRecommendations",
                column: "intUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TReviews_intProductID",
                schema: "db_owner",
                table: "TReviews",
                column: "intProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TReviews_intUserID",
                schema: "db_owner",
                table: "TReviews",
                column: "intUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TShoppingCarts_intUserID",
                schema: "db_owner",
                table: "TShoppingCarts",
                column: "intUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TShoppingCarts_TuserintUserID",
                schema: "db_owner",
                table: "TShoppingCarts",
                column: "TuserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TUsers_intUserRoleID",
                schema: "db_owner",
                table: "TUsers",
                column: "intUserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TAdmins",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TCartItems",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TCities",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TCoupons",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TCustomerServiceTickets",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TDrinkCategories",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TFavorites",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TFlavors",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TGenders",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TIngredients",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TOrderItems",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TOrdersProducts",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TPayments",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TPaymentStatus",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TPermissions",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TProductImages",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TProductRecommendations",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TPromotions",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TRaces",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TReviews",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TShippingMethods",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TStates",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TShoppingCarts",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TTicketCategories",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TTicketStatus",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TOrders",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TProducts",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TPaymentMethods",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TShippingStatus",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TUsers",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "TUserRoles",
                schema: "db_owner");
        }
    }
}
