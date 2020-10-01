using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LokwaInnovation.Migrations
{
    public partial class AddReffDsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnonymousMessages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Full_name = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymousMessages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Log_in",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Full_name = table.Column<string>(nullable: false),
                    Phone_number = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Roles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_in", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "PDF_Documents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Document_name = table.Column<string>(maxLength: 50, nullable: false),
                    Document_description = table.Column<string>(maxLength: 300, nullable: false),
                    Book_url = table.Column<string>(nullable: true),
                    Cover_url = table.Column<string>(nullable: true),
                    Date_modified = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDF_Documents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pdf_refference",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Doc_id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Refference_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdf_refference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Visits_counter",
                columns: table => new
                {
                    Visit_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits_counter", x => x.Visit_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnonymousMessages");

            migrationBuilder.DropTable(
                name: "Log_in");

            migrationBuilder.DropTable(
                name: "PDF_Documents");

            migrationBuilder.DropTable(
                name: "Pdf_refference");

            migrationBuilder.DropTable(
                name: "Visits_counter");
        }
    }
}
