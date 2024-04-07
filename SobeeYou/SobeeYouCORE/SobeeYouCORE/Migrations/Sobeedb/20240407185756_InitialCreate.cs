using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SobeeYouCORE.Migrations.Sobeedb {
    /// <inheritdoc />
    public partial class InitialCreate : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new {
                    MigrationId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });
        }
    }
}
