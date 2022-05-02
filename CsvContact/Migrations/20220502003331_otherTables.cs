using Microsoft.EntityFrameworkCore.Migrations;

namespace CsvContact.Migrations
{
    public partial class otherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_CsvFiles_CsvFileModelIdFile",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Concatc");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_CsvFileModelIdFile",
                table: "Concatc",
                newName: "IX_Concatc_CsvFileModelIdFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concatc",
                table: "Concatc",
                column: "IdContact");

            migrationBuilder.AddForeignKey(
                name: "FK_Concatc_CsvFiles_CsvFileModelIdFile",
                table: "Concatc",
                column: "CsvFileModelIdFile",
                principalSchema: "dbo",
                principalTable: "CsvFiles",
                principalColumn: "IDFile",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concatc_CsvFiles_CsvFileModelIdFile",
                table: "Concatc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concatc",
                table: "Concatc");

            migrationBuilder.RenameTable(
                name: "Concatc",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Concatc_CsvFileModelIdFile",
                table: "Contact",
                newName: "IX_Contact_CsvFileModelIdFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "IdContact");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_CsvFiles_CsvFileModelIdFile",
                table: "Contact",
                column: "CsvFileModelIdFile",
                principalSchema: "dbo",
                principalTable: "CsvFiles",
                principalColumn: "IDFile",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
