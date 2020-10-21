using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LokwaInnovation.Migrations
{
    public partial class addedToken13336 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access_Tokens",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    DateModified = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_Tokens", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "AnonymousMessages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Full_name = table.Column<string>(nullable: true),
                    Phone_number = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    Roles = table.Column<bool>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymousMessages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client_account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token_balance = table.Column<string>(nullable: true),
                    Phone_number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    chatID = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.ID);
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
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    chatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mpesa_Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    User_id = table.Column<string>(nullable: true),
                    Ammount = table.Column<float>(nullable: false),
                    TransactionDate = table.Column<string>(nullable: true),
                    strResultCode = table.Column<string>(nullable: true),
                    ResultDesc = table.Column<string>(nullable: true),
                    CheckoutRequestID = table.Column<string>(nullable: true),
                    transactionCode = table.Column<string>(nullable: true),
                    Payment_status = table.Column<bool>(nullable: false),
                    Transaction_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mpesa_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MpesaTransactions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    MpesaReceiptNumber = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpesaTransactions", x => x.ID);
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
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Full_name = table.Column<string>(nullable: false),
                    Phone_number = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Roles = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Token_price",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token_pricelist = table.Column<float>(nullable: false),
                    DateModified = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token_price", x => x.ID);
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
                name: "Access_Tokens");

            migrationBuilder.DropTable(
                name: "AnonymousMessages");

            migrationBuilder.DropTable(
                name: "Client_account");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "Log_in");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Mpesa_Status");

            migrationBuilder.DropTable(
                name: "MpesaTransactions");

            migrationBuilder.DropTable(
                name: "PDF_Documents");

            migrationBuilder.DropTable(
                name: "Pdf_refference");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Token_price");

            migrationBuilder.DropTable(
                name: "Visits_counter");
        }
    }
}
