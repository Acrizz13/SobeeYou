using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Migrations
{
    /// <inheritdoc />
    public partial class NewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TcustomerServiceTicket_AspNetUser_UserId",
                table: "TcustomerServiceTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Torder_AspNetUser_UserId",
                table: "Torder");

            migrationBuilder.DropForeignKey(
                name: "FK_TproductRecommendation_AspNetUser_UserId",
                table: "TproductRecommendation");

            migrationBuilder.DropForeignKey(
                name: "FK_Treview_AspNetUser_UserId",
                table: "Treview");

            migrationBuilder.DropForeignKey(
                name: "FK_TshoppingCart_AspNetUser_UserId",
                table: "TshoppingCart");

            migrationBuilder.DropTable(
                name: "AspNetRoleAspNetUser");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaim");

            migrationBuilder.DropTable(
                name: "AspNetUserClaim");

            migrationBuilder.DropTable(
                name: "AspNetUserLogin");

            migrationBuilder.DropTable(
                name: "AspNetUserToken");

            migrationBuilder.DropTable(
                name: "AspNetRole");

            migrationBuilder.DropTable(
                name: "AspNetUser");

            migrationBuilder.DropIndex(
                name: "IX_TshoppingCart_UserId",
                table: "TshoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Treview_UserId",
                table: "Treview");

            migrationBuilder.DropIndex(
                name: "IX_TproductRecommendation_UserId",
                table: "TproductRecommendation");

            migrationBuilder.DropIndex(
                name: "IX_Torder_UserId",
                table: "Torder");

            migrationBuilder.DropIndex(
                name: "IX_TcustomerServiceTicket_UserId",
                table: "TcustomerServiceTicket");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TshoppingCart",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Treview",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TproductRecommendation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Torder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TcustomerServiceTicket",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TshoppingCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Treview",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TproductRecommendation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Torder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TcustomerServiceTicket",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IntUserRoleId = table.Column<int>(type: "int", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.Id);
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_TshoppingCart_UserId",
                table: "TshoppingCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treview_UserId",
                table: "Treview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TproductRecommendation_UserId",
                table: "TproductRecommendation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Torder_UserId",
                table: "Torder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TcustomerServiceTicket_UserId",
                table: "TcustomerServiceTicket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAspNetUser_UsersId",
                table: "AspNetRoleAspNetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaim_RoleId",
                table: "AspNetRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaim_UserId",
                table: "AspNetUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogin_UserId",
                table: "AspNetUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserToken_UserId1",
                table: "AspNetUserToken",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TcustomerServiceTicket_AspNetUser_UserId",
                table: "TcustomerServiceTicket",
                column: "UserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Torder_AspNetUser_UserId",
                table: "Torder",
                column: "UserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TproductRecommendation_AspNetUser_UserId",
                table: "TproductRecommendation",
                column: "UserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treview_AspNetUser_UserId",
                table: "Treview",
                column: "UserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TshoppingCart_AspNetUser_UserId",
                table: "TshoppingCart",
                column: "UserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");
        }
    }
}
