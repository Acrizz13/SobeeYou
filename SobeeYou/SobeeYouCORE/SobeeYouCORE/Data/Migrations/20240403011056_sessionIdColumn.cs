using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Data.Migrations
{
    /// <inheritdoc />
    public partial class sessionIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "db_owner",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "TCustomerServiceTickets_TTicketCategories_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "TCustomerServiceTickets_TTicketStatus_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "TCustomerServiceTickets_TUsers_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "TOrdersProducts_TProducts_FK",
                schema: "db_owner",
                table: "TOrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TShoppingCarts_TUsers_TuserintUserID",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK__TShopping__intUs__178D7CA5",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_intUserRoleID",
                schema: "db_owner",
                table: "TUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "db_owner");

            migrationBuilder.DropIndex(
                name: "IX_TShoppingCarts_intUserID",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_TShoppingCarts_TuserintUserID",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "TOrdersProducts_PK",
                schema: "db_owner",
                table: "TOrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_TCustomerServiceTickets_intTicketCategoryID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropIndex(
                name: "IX_TCustomerServiceTickets_intUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropColumn(
                name: "TuserintUserID",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropColumn(
                name: "intUserID",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "TOrdersProducts",
                schema: "db_owner",
                newName: "TordersProducts",
                newSchema: "db_owner");

            migrationBuilder.RenameColumn(
                name: "IntOrdersProductId",
                schema: "db_owner",
                table: "TordersProducts",
                newName: "intOrdersProductID");

            migrationBuilder.AlterColumn<int>(
                name: "intUserRoleID",
                schema: "db_owner",
                table: "TUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "db_owner",
                table: "TUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "db_owner",
                table: "TShoppingCarts",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "db_owner",
                table: "TReviews",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "db_owner",
                table: "TProductRecommendations",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "intPaymentMethodID",
                schema: "db_owner",
                table: "TPayments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "intPaymentMethod",
                schema: "db_owner",
                table: "TPayments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "strOrdersProduct",
                schema: "db_owner",
                table: "TordersProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "intOrdersProductID",
                schema: "db_owner",
                table: "TordersProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "db_owner",
                table: "TOrders",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TUserintUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketStatusintTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "intUserRoleID",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "strBillingAddress",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "strFirstName",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "strLastName",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "strShippingAddress",
                schema: "db_owner",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "db_owner",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TordersProducts",
                schema: "db_owner",
                table: "TordersProducts",
                column: "intOrdersProductID");

            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                schema: "dbo",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateIndex(
                name: "IX_TShoppingCarts_user_id",
                schema: "db_owner",
                table: "TShoppingCarts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TReviews_user_id",
                schema: "db_owner",
                table: "TReviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TProductRecommendations_user_id",
                schema: "db_owner",
                table: "TProductRecommendations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TordersProducts_intProductID",
                schema: "db_owner",
                table: "TordersProducts",
                column: "intProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TOrders_user_id",
                schema: "db_owner",
                table: "TOrders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_TicketStatusintTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "TicketStatusintTicketStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_TUserintUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "TUserintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_user_id",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "db_owner",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TCustomerServiceTickets_AspNetUsers",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "user_id",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TCustomerServiceTickets_TTicketStatus_TicketStatusintTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "TicketStatusintTicketStatusID",
                principalSchema: "db_owner",
                principalTable: "TTicketStatus",
                principalColumn: "intTicketStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TCustomerServiceTickets_TUsers_TUserintUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "TUserintUserID",
                principalSchema: "db_owner",
                principalTable: "TUsers",
                principalColumn: "intUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "TCustomerServiceTickets_TTicketStatus_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intTicketStatusID",
                principalSchema: "db_owner",
                principalTable: "TTicketCategories",
                principalColumn: "intTicketCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TORders_AspNetUsers",
                schema: "db_owner",
                table: "TOrders",
                column: "user_id",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TordersProducts_TProducts_intProductID",
                schema: "db_owner",
                table: "TordersProducts",
                column: "intProductID",
                principalSchema: "db_owner",
                principalTable: "TProducts",
                principalColumn: "intProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TProductRecommendations_AspNetUsers",
                schema: "db_owner",
                table: "TProductRecommendations",
                column: "user_id",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TReviews_AspNetUsers",
                schema: "db_owner",
                table: "TReviews",
                column: "user_id",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TShoppingCarts_AspNetUsers",
                schema: "db_owner",
                table: "TShoppingCarts",
                column: "user_id",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_intUserRoleID",
                schema: "db_owner",
                table: "TUsers",
                column: "intUserRoleID",
                principalSchema: "db_owner",
                principalTable: "TUserRoles",
                principalColumn: "intUserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "db_owner",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_TCustomerServiceTickets_AspNetUsers",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TCustomerServiceTickets_TTicketStatus_TicketStatusintTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TCustomerServiceTickets_TUsers_TUserintUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "TCustomerServiceTickets_TTicketStatus_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TORders_AspNetUsers",
                schema: "db_owner",
                table: "TOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TordersProducts_TProducts_intProductID",
                schema: "db_owner",
                table: "TordersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TProductRecommendations_AspNetUsers",
                schema: "db_owner",
                table: "TProductRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_TReviews_AspNetUsers",
                schema: "db_owner",
                table: "TReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_TShoppingCarts_AspNetUsers",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_intUserRoleID",
                schema: "db_owner",
                table: "TUsers");

            migrationBuilder.DropTable(
                name: "__MigrationHistory",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_TShoppingCarts_user_id",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_TReviews_user_id",
                schema: "db_owner",
                table: "TReviews");

            migrationBuilder.DropIndex(
                name: "IX_TProductRecommendations_user_id",
                schema: "db_owner",
                table: "TProductRecommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TordersProducts",
                schema: "db_owner",
                table: "TordersProducts");

            migrationBuilder.DropIndex(
                name: "IX_TordersProducts_intProductID",
                schema: "db_owner",
                table: "TordersProducts");

            migrationBuilder.DropIndex(
                name: "IX_TOrders_user_id",
                schema: "db_owner",
                table: "TOrders");

            migrationBuilder.DropIndex(
                name: "IX_TCustomerServiceTickets_TicketStatusintTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropIndex(
                name: "IX_TCustomerServiceTickets_TUserintUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropIndex(
                name: "IX_TCustomerServiceTickets_user_id",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "db_owner",
                table: "TShoppingCarts");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "db_owner",
                table: "TReviews");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "db_owner",
                table: "TProductRecommendations");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "db_owner",
                table: "TOrders");

            migrationBuilder.DropColumn(
                name: "TUserintUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropColumn(
                name: "TicketStatusintTicketStatusID",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "db_owner",
                table: "TCustomerServiceTickets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "intUserRoleID",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strBillingAddress",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strFirstName",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strLastName",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strShippingAddress",
                schema: "db_owner",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TordersProducts",
                schema: "db_owner",
                newName: "TOrdersProducts",
                newSchema: "db_owner");

            migrationBuilder.RenameColumn(
                name: "intOrdersProductID",
                schema: "db_owner",
                table: "TOrdersProducts",
                newName: "IntOrdersProductId");

            migrationBuilder.AlterColumn<int>(
                name: "intUserRoleID",
                schema: "db_owner",
                table: "TUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                schema: "db_owner",
                table: "TUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TuserintUserID",
                schema: "db_owner",
                table: "TShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "intUserID",
                schema: "db_owner",
                table: "TShoppingCarts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "intPaymentMethodID",
                schema: "db_owner",
                table: "TPayments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "intPaymentMethod",
                schema: "db_owner",
                table: "TPayments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "strOrdersProduct",
                schema: "db_owner",
                table: "TOrdersProducts",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IntOrdersProductId",
                schema: "db_owner",
                table: "TOrdersProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "db_owner",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "TOrdersProducts_PK",
                schema: "db_owner",
                table: "TOrdersProducts",
                column: "intProductID");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "db_owner",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    intUserRoleID = table.Column<int>(type: "int", nullable: false),
                    strBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

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
                name: "IX_TCustomerServiceTickets_intTicketCategoryID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intTicketCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TCustomerServiceTickets_intUserID",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "db_owner",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "db_owner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "TCustomerServiceTickets_TTicketCategories_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intTicketCategoryID",
                principalSchema: "db_owner",
                principalTable: "TTicketCategories",
                principalColumn: "intTicketCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "TCustomerServiceTickets_TTicketStatus_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intTicketStatusID",
                principalSchema: "db_owner",
                principalTable: "TTicketStatus",
                principalColumn: "intTicketStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "TCustomerServiceTickets_TUsers_FK",
                schema: "db_owner",
                table: "TCustomerServiceTickets",
                column: "intUserID",
                principalSchema: "db_owner",
                principalTable: "TUsers",
                principalColumn: "intUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "TOrdersProducts_TProducts_FK",
                schema: "db_owner",
                table: "TOrdersProducts",
                column: "intProductID",
                principalSchema: "db_owner",
                principalTable: "TProducts",
                principalColumn: "intProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TShoppingCarts_TUsers_TuserintUserID",
                schema: "db_owner",
                table: "TShoppingCarts",
                column: "TuserintUserID",
                principalSchema: "db_owner",
                principalTable: "TUsers",
                principalColumn: "intUserID");

            migrationBuilder.AddForeignKey(
                name: "FK__TShopping__intUs__178D7CA5",
                schema: "db_owner",
                table: "TShoppingCarts",
                column: "intUserID",
                principalSchema: "db_owner",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_intUserRoleID",
                schema: "db_owner",
                table: "TUsers",
                column: "intUserRoleID",
                principalSchema: "db_owner",
                principalTable: "TUserRoles",
                principalColumn: "intUserRoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
