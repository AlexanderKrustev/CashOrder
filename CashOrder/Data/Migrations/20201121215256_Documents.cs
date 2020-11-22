using Microsoft.EntityFrameworkCore.Migrations;

namespace CashOrder.Data.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.CreateTable(
                name: "FirmEntityModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Vat = table.Column<string>(maxLength: 11, nullable: false),
                    FirmID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmEntityModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentEntityModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receiver = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    FirmId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEntityModel_FirmEntityModel_FirmId",
                        column: x => x.FirmId,
                        principalTable: "FirmEntityModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntityModel_FirmId",
                table: "DocumentEntityModel",
                column: "FirmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntityModel");

            migrationBuilder.DropTable(
                name: "FirmEntityModel");

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VAT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                });
        }
    }
}
