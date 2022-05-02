using Microsoft.EntityFrameworkCore.Migrations;

namespace CsvContact.Migrations
{
    public partial class secondMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CsvFiles",
                schema: "dbo",
                columns: table => new
                {
                    IDFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmmountProcess = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsvFiles", x => x.IDFile);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateBirht = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Franchise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdFile = table.Column<long>(type: "bigint", nullable: false),
                    CsvFileModelIdFile = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.IdContact);
                    table.ForeignKey(
                        name: "FK_Contact_CsvFiles_CsvFileModelIdFile",
                        column: x => x.CsvFileModelIdFile,
                        principalSchema: "dbo",
                        principalTable: "CsvFiles",
                        principalColumn: "IDFile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogError",
                columns: table => new
                {
                    IdError = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Error = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdFile = table.Column<long>(type: "bigint", nullable: false),
                    CsvFileModelIdFile = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogError", x => x.IdError);
                    table.ForeignKey(
                        name: "FK_LogError_CsvFiles_CsvFileModelIdFile",
                        column: x => x.CsvFileModelIdFile,
                        principalSchema: "dbo",
                        principalTable: "CsvFiles",
                        principalColumn: "IDFile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CsvFileModelIdFile",
                table: "Contact",
                column: "CsvFileModelIdFile");

            migrationBuilder.CreateIndex(
                name: "IX_LogError_CsvFileModelIdFile",
                table: "LogError",
                column: "CsvFileModelIdFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "LogError");

            migrationBuilder.DropTable(
                name: "CsvFiles",
                schema: "dbo");
        }
    }
}
