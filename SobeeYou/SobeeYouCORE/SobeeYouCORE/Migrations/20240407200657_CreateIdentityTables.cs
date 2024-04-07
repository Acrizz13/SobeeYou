using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    IntUserRoleId = table.Column<int>(type: "int", nullable: false),
                    StrBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    strShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    intUserRoleID = table.Column<int>(type: "int", nullable: false),
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TpaymentMethod",
                columns: table => new
                {
                    IntPaymentMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrPaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TpaymentMethod", x => x.IntPaymentMethod);
                });

            migrationBuilder.CreateTable(
                name: "Tproduct",
                columns: table => new
                {
                    IntProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrStockAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StrPrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tproduct", x => x.IntProductId);
                });

            migrationBuilder.CreateTable(
                name: "TshippingStatus",
                columns: table => new
                {
                    IntShippingStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrShippingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TshippingStatus", x => x.IntShippingStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TticketCategory",
                columns: table => new
                {
                    IntTicketCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrTicketCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TticketCategory", x => x.IntTicketCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TticketStatus",
                columns: table => new
                {
                    IntTicketStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrTicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TticketStatus", x => x.IntTicketStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TuserRole",
                columns: table => new
                {
                    IntUserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuserRole", x => x.IntUserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaim_AspNetRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleAspNetUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleAspNetUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetRole_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaim_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogin", x => x.LoginProvider);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogin_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserToken", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUserToken_AspNetUser_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TshoppingCart",
                columns: table => new
                {
                    IntShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtmDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtmDateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TshoppingCart", x => x.IntShoppingCartId);
                    table.ForeignKey(
                        name: "FK_TshoppingCart_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TshoppingCart_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TordersProduct",
                columns: table => new
                {
                    IntOrdersProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntProductId = table.Column<int>(type: "int", nullable: false),
                    StrOrdersProduct = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TordersProduct", x => x.IntOrdersProductId);
                    table.ForeignKey(
                        name: "FK_TordersProduct_Tproduct_IntProductId",
                        column: x => x.IntProductId,
                        principalTable: "Tproduct",
                        principalColumn: "IntProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tuser",
                columns: table => new
                {
                    IntUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntUserRoleId = table.Column<int>(type: "int", nullable: true),
                    StrBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StrLastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuser", x => x.IntUserId);
                    table.ForeignKey(
                        name: "FK_Tuser_TuserRole_IntUserRoleId",
                        column: x => x.IntUserRoleId,
                        principalTable: "TuserRole",
                        principalColumn: "IntUserRoleId");
                });

            migrationBuilder.CreateTable(
                name: "TcartItem",
                columns: table => new
                {
                    IntCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntShoppingCartId = table.Column<int>(type: "int", nullable: true),
                    IntProductId = table.Column<int>(type: "int", nullable: true),
                    IntQuantity = table.Column<int>(type: "int", nullable: true),
                    DtmDateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcartItem", x => x.IntCartItemId);
                    table.ForeignKey(
                        name: "FK_TcartItem_Tproduct_IntProductId",
                        column: x => x.IntProductId,
                        principalTable: "Tproduct",
                        principalColumn: "IntProductId");
                    table.ForeignKey(
                        name: "FK_TcartItem_TshoppingCart_IntShoppingCartId",
                        column: x => x.IntShoppingCartId,
                        principalTable: "TshoppingCart",
                        principalColumn: "IntShoppingCartId");
                });

            migrationBuilder.CreateTable(
                name: "TcustomerServiceTicket",
                columns: table => new
                {
                    IntCustomerServiceTicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntUserId = table.Column<int>(type: "int", nullable: false),
                    IntTicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    IntTicketStatusId = table.Column<int>(type: "int", nullable: false),
                    DtmTimeOfSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StrDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcustomerServiceTicket", x => x.IntCustomerServiceTicketId);
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_TticketCategory_IntTicketCategoryId",
                        column: x => x.IntTicketCategoryId,
                        principalTable: "TticketCategory",
                        principalColumn: "IntTicketCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_TticketStatus_IntTicketStatusId",
                        column: x => x.IntTicketStatusId,
                        principalTable: "TticketStatus",
                        principalColumn: "IntTicketStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_Tuser_IntUserId",
                        column: x => x.IntUserId,
                        principalTable: "Tuser",
                        principalColumn: "IntUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Torder",
                columns: table => new
                {
                    IntOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntUserId = table.Column<int>(type: "int", nullable: true),
                    DtmOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DecTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IntShippingStatusId = table.Column<int>(type: "int", nullable: true),
                    StrShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrTrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntPaymentMethod = table.Column<int>(type: "int", nullable: true),
                    StrOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntPaymentMethodNavigationIntPaymentMethod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torder", x => x.IntOrderId);
                    table.ForeignKey(
                        name: "FK_Torder_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Torder_TpaymentMethod_IntPaymentMethodNavigationIntPaymentMethod",
                        column: x => x.IntPaymentMethodNavigationIntPaymentMethod,
                        principalTable: "TpaymentMethod",
                        principalColumn: "IntPaymentMethod");
                    table.ForeignKey(
                        name: "FK_Torder_TshippingStatus_IntShippingStatusId",
                        column: x => x.IntShippingStatusId,
                        principalTable: "TshippingStatus",
                        principalColumn: "IntShippingStatusId");
                    table.ForeignKey(
                        name: "FK_Torder_Tuser_IntUserId",
                        column: x => x.IntUserId,
                        principalTable: "Tuser",
                        principalColumn: "IntUserId");
                });

            migrationBuilder.CreateTable(
                name: "TproductRecommendation",
                columns: table => new
                {
                    IntProductRecommendationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntUserId = table.Column<int>(type: "int", nullable: false),
                    IntProductId = table.Column<int>(type: "int", nullable: false),
                    DtmTimeOfRecommendation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StrRelevantScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TproductRecommendation", x => x.IntProductRecommendationId);
                    table.ForeignKey(
                        name: "FK_TproductRecommendation_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TproductRecommendation_Tproduct_IntProductId",
                        column: x => x.IntProductId,
                        principalTable: "Tproduct",
                        principalColumn: "IntProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TproductRecommendation_Tuser_IntUserId",
                        column: x => x.IntUserId,
                        principalTable: "Tuser",
                        principalColumn: "IntUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treview",
                columns: table => new
                {
                    IntReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntUserId = table.Column<int>(type: "int", nullable: false),
                    IntProductId = table.Column<int>(type: "int", nullable: false),
                    StrReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treview", x => x.IntReviewId);
                    table.ForeignKey(
                        name: "FK_Treview_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Treview_Tproduct_IntProductId",
                        column: x => x.IntProductId,
                        principalTable: "Tproduct",
                        principalColumn: "IntProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treview_Tuser_IntUserId",
                        column: x => x.IntUserId,
                        principalTable: "Tuser",
                        principalColumn: "IntUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TorderItem",
                columns: table => new
                {
                    IntOrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntOrderId = table.Column<int>(type: "int", nullable: true),
                    IntProductId = table.Column<int>(type: "int", nullable: true),
                    IntQuantity = table.Column<int>(type: "int", nullable: true),
                    MonPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorderItem", x => x.IntOrderItemId);
                    table.ForeignKey(
                        name: "FK_TorderItem_Torder_IntOrderId",
                        column: x => x.IntOrderId,
                        principalTable: "Torder",
                        principalColumn: "IntOrderId");
                    table.ForeignKey(
                        name: "FK_TorderItem_Tproduct_IntProductId",
                        column: x => x.IntProductId,
                        principalTable: "Tproduct",
                        principalColumn: "IntProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAspNetUser_UsersId",
                table: "AspNetRoleAspNetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaim_RoleId",
                table: "AspNetRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaim_UserId",
                table: "AspNetUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogin_UserId",
                table: "AspNetUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserToken_UserId1",
                table: "AspNetUserToken",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TcartItem_IntProductId",
                table: "TcartItem",
                column: "IntProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TcartItem_IntShoppingCartId",
                table: "TcartItem",
                column: "IntShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_IntTicketCategoryId",
                table: "TcustomerServiceTicket",
                column: "IntTicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_IntTicketStatusId",
                table: "TcustomerServiceTicket",
                column: "IntTicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_IntUserId",
                table: "TcustomerServiceTicket",
                column: "IntUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_UserId",
                table: "TcustomerServiceTicket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_IntPaymentMethodNavigationIntPaymentMethod",
                table: "Torder",
                column: "IntPaymentMethodNavigationIntPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_IntShippingStatusId",
                table: "Torder",
                column: "IntShippingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_IntUserId",
                table: "Torder",
                column: "IntUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_UserId",
                table: "Torder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TorderItem_IntOrderId",
                table: "TorderItem",
                column: "IntOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TorderItem_IntProductId",
                table: "TorderItem",
                column: "IntProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TordersProduct_IntProductId",
                table: "TordersProduct",
                column: "IntProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TproductRecommendation_IntProductId",
                table: "TproductRecommendation",
                column: "IntProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TproductRecommendation_IntUserId",
                table: "TproductRecommendation",
                column: "IntUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TproductRecommendation_UserId",
                table: "TproductRecommendation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treview_IntProductId",
                table: "Treview",
                column: "IntProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Treview_IntUserId",
                table: "Treview",
                column: "IntUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treview_UserId",
                table: "Treview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TshoppingCart_ApplicationUserId",
                table: "TshoppingCart",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TshoppingCart_UserId",
                table: "TshoppingCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuser_IntUserRoleId",
                table: "Tuser",
                column: "IntUserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleAspNetUser");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaim");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaim");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogin");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserToken");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TcartItem");

            migrationBuilder.DropTable(
                name: "TcustomerServiceTicket");

            migrationBuilder.DropTable(
                name: "TorderItem");

            migrationBuilder.DropTable(
                name: "TordersProduct");

            migrationBuilder.DropTable(
                name: "TproductRecommendation");

            migrationBuilder.DropTable(
                name: "Treview");

            migrationBuilder.DropTable(
                name: "AspNetRole");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TshoppingCart");

            migrationBuilder.DropTable(
                name: "TticketCategory");

            migrationBuilder.DropTable(
                name: "TticketStatus");

            migrationBuilder.DropTable(
                name: "Torder");

            migrationBuilder.DropTable(
                name: "Tproduct");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetUser");

            migrationBuilder.DropTable(
                name: "TpaymentMethod");

            migrationBuilder.DropTable(
                name: "TshippingStatus");

            migrationBuilder.DropTable(
                name: "Tuser");

            migrationBuilder.DropTable(
                name: "TuserRole");
        }
    }
}
