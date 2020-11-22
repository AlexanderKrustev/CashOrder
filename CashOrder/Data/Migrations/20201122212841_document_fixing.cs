using Microsoft.EntityFrameworkCore.Migrations;

namespace CashOrder.Data.Migrations
{
    public partial class document_fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentEntityModel_FirmEntityModel_FirmId",
                table: "DocumentEntityModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FirmEntityModel",
                table: "FirmEntityModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentEntityModel",
                table: "DocumentEntityModel");

            migrationBuilder.DropColumn(
                name: "FirmID",
                table: "FirmEntityModel");

            migrationBuilder.RenameTable(
                name: "FirmEntityModel",
                newName: "Firms");

            migrationBuilder.RenameTable(
                name: "DocumentEntityModel",
                newName: "Documents");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentEntityModel_FirmId",
                table: "Documents",
                newName: "IX_Documents_FirmId");

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "Documents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firms",
                table: "Firms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Firms_FirmId",
                table: "Documents",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Firms_FirmId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firms",
                table: "Firms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Firms",
                newName: "FirmEntityModel");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "DocumentEntityModel");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_FirmId",
                table: "DocumentEntityModel",
                newName: "IX_DocumentEntityModel_FirmId");

            migrationBuilder.AddColumn<int>(
                name: "FirmID",
                table: "FirmEntityModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "DocumentEntityModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirmEntityModel",
                table: "FirmEntityModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentEntityModel",
                table: "DocumentEntityModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentEntityModel_FirmEntityModel_FirmId",
                table: "DocumentEntityModel",
                column: "FirmId",
                principalTable: "FirmEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
