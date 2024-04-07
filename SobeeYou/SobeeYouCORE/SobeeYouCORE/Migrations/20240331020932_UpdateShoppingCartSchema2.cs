using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShoppingCartSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TpaymentMethod",
                columns: table => new
                {
                    intPaymentMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strPaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TpaymentMethod", x => x.intPaymentMethod);
                });

            migrationBuilder.CreateTable(
                name: "Tproduct",
                columns: table => new
                {
                    intProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strStockAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    decPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    strPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tproduct", x => x.intProductID);
                });

            migrationBuilder.CreateTable(
                name: "TshippingStatus",
                columns: table => new
                {
                    intShippingStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strShippingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TshippingStatus", x => x.intShippingStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TticketCategory",
                columns: table => new
                {
                    intTicketCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strTicketCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TticketCategory", x => x.intTicketCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TticketStatus",
                columns: table => new
                {
                    intTicketStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strTicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TticketStatus", x => x.intTicketStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TuserRole",
                columns: table => new
                {
                    intUserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuserRole", x => x.intUserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "TordersProduct",
                columns: table => new
                {
                    IntOrdersProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    strOrdersProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductintProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TordersProduct", x => x.IntOrdersProductId);
                    table.ForeignKey(
                        name: "FK_TordersProduct_Tproduct_ProductintProductID",
                        column: x => x.ProductintProductID,
                        principalTable: "Tproduct",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tuser",
                columns: table => new
                {
                    intUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intUserRoleID = table.Column<int>(type: "int", nullable: false),
                    strBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    strLastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserRoleintUserRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuser", x => x.intUserID);
                    table.ForeignKey(
                        name: "FK_Tuser_TuserRole_UserRoleintUserRoleID",
                        column: x => x.UserRoleintUserRoleID,
                        principalTable: "TuserRole",
                        principalColumn: "intUserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TcustomerServiceTicket",
                columns: table => new
                {
                    intCustomerServiceTicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    intTicketCategoryID = table.Column<int>(type: "int", nullable: false),
                    intTicketStatusID = table.Column<int>(type: "int", nullable: false),
                    dtmTimeOfSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    strDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketCategoryintTicketCategoryID = table.Column<int>(type: "int", nullable: false),
                    TicketStatusintTicketStatusID = table.Column<int>(type: "int", nullable: false),
                    UserintUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcustomerServiceTicket", x => x.intCustomerServiceTicketID);
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_TticketCategory_TicketCategoryintTicketCategoryID",
                        column: x => x.TicketCategoryintTicketCategoryID,
                        principalTable: "TticketCategory",
                        principalColumn: "intTicketCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_TticketStatus_TicketStatusintTicketStatusID",
                        column: x => x.TicketStatusintTicketStatusID,
                        principalTable: "TticketStatus",
                        principalColumn: "intTicketStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TcustomerServiceTicket_Tuser_UserintUserID",
                        column: x => x.UserintUserID,
                        principalTable: "Tuser",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Torder",
                columns: table => new
                {
                    intOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    dtmOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    decTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    intShippingStatusID = table.Column<int>(type: "int", nullable: false),
                    strShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strTrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    strOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodintPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    ShippingStatusintShippingStatusID = table.Column<int>(type: "int", nullable: false),
                    UserintUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torder", x => x.intOrderID);
                    table.ForeignKey(
                        name: "FK_Torder_TpaymentMethod_PaymentMethodintPaymentMethod",
                        column: x => x.PaymentMethodintPaymentMethod,
                        principalTable: "TpaymentMethod",
                        principalColumn: "intPaymentMethod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Torder_TshippingStatus_ShippingStatusintShippingStatusID",
                        column: x => x.ShippingStatusintShippingStatusID,
                        principalTable: "TshippingStatus",
                        principalColumn: "intShippingStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Torder_Tuser_UserintUserID",
                        column: x => x.UserintUserID,
                        principalTable: "Tuser",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TproductRecommendation",
                columns: table => new
                {
                    intProductRecommendationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    dtmTimeOfRecommendation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    strRelevantScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductintProductID = table.Column<int>(type: "int", nullable: false),
                    UserintUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TproductRecommendation", x => x.intProductRecommendationID);
                    table.ForeignKey(
                        name: "FK_TproductRecommendation_Tproduct_ProductintProductID",
                        column: x => x.ProductintProductID,
                        principalTable: "Tproduct",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TproductRecommendation_Tuser_UserintUserID",
                        column: x => x.UserintUserID,
                        principalTable: "Tuser",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treview",
                columns: table => new
                {
                    intReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intUserID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    strReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductintProductID = table.Column<int>(type: "int", nullable: false),
                    UserintUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treview", x => x.intReviewID);
                    table.ForeignKey(
                        name: "FK_Treview_Tproduct_ProductintProductID",
                        column: x => x.ProductintProductID,
                        principalTable: "Tproduct",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treview_Tuser_UserintUserID",
                        column: x => x.UserintUserID,
                        principalTable: "Tuser",
                        principalColumn: "intUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TshoppingCart",
                columns: table => new
                {
                    intShoppingCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtmDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmDateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TuserintUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TshoppingCart", x => x.intShoppingCartID);
                    table.ForeignKey(
                        name: "FK_TshoppingCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TshoppingCart_Tuser_TuserintUserID",
                        column: x => x.TuserintUserID,
                        principalTable: "Tuser",
                        principalColumn: "intUserID");
                });

            migrationBuilder.CreateTable(
                name: "TorderItem",
                columns: table => new
                {
                    intOrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intOrderID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    intQuantity = table.Column<int>(type: "int", nullable: false),
                    monPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderintOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductintProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorderItem", x => x.intOrderItemID);
                    table.ForeignKey(
                        name: "FK_TorderItem_Torder_OrderintOrderID",
                        column: x => x.OrderintOrderID,
                        principalTable: "Torder",
                        principalColumn: "intOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TorderItem_Tproduct_ProductintProductID",
                        column: x => x.ProductintProductID,
                        principalTable: "Tproduct",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TcartItem",
                columns: table => new
                {
                    intCartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intShoppingCartID = table.Column<int>(type: "int", nullable: false),
                    intProductID = table.Column<int>(type: "int", nullable: false),
                    intQuantity = table.Column<int>(type: "int", nullable: false),
                    dtmDateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductintProductID = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartintShoppingCartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcartItem", x => x.intCartItemID);
                    table.ForeignKey(
                        name: "FK_TcartItem_Tproduct_ProductintProductID",
                        column: x => x.ProductintProductID,
                        principalTable: "Tproduct",
                        principalColumn: "intProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TcartItem_TshoppingCart_ShoppingCartintShoppingCartID",
                        column: x => x.ShoppingCartintShoppingCartID,
                        principalTable: "TshoppingCart",
                        principalColumn: "intShoppingCartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TcartItem_ProductintProductID",
                table: "TcartItem",
                column: "ProductintProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TcartItem_ShoppingCartintShoppingCartID",
                table: "TcartItem",
                column: "ShoppingCartintShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_TicketCategoryintTicketCategoryID",
                table: "TcustomerServiceTicket",
                column: "TicketCategoryintTicketCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_TicketStatusintTicketStatusID",
                table: "TcustomerServiceTicket",
                column: "TicketStatusintTicketStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_UserintUserID",
                table: "TcustomerServiceTicket",
                column: "UserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_PaymentMethodintPaymentMethod",
                table: "Torder",
                column: "PaymentMethodintPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_ShippingStatusintShippingStatusID",
                table: "Torder",
                column: "ShippingStatusintShippingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_UserintUserID",
                table: "Torder",
                column: "UserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TorderItem_OrderintOrderID",
                table: "TorderItem",
                column: "OrderintOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_TorderItem_ProductintProductID",
                table: "TorderItem",
                column: "ProductintProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TordersProduct_ProductintProductID",
                table: "TordersProduct",
                column: "ProductintProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TproductRecommendation_ProductintProductID",
                table: "TproductRecommendation",
                column: "ProductintProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TproductRecommendation_UserintUserID",
                table: "TproductRecommendation",
                column: "UserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Treview_ProductintProductID",
                table: "Treview",
                column: "ProductintProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Treview_UserintUserID",
                table: "Treview",
                column: "UserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TshoppingCart_TuserintUserID",
                table: "TshoppingCart",
                column: "TuserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TshoppingCart_UserId",
                table: "TshoppingCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuser_UserRoleintUserRoleID",
                table: "Tuser",
                column: "UserRoleintUserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
