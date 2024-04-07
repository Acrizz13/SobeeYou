using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "intUserID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "intUserRoleID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "strBillingAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "strDateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "strFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "strLastLoginDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "strLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "strShippingAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "intUserID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "intUserRoleID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strBillingAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strDateCreated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strLastLoginDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "strShippingAddress",
                table: "AspNetUsers");
        }
    }
}
