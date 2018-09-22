using Microsoft.EntityFrameworkCore.Migrations;

namespace FinT.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Sent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "InboxMail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PersonId = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxMail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboxMail_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PersonId = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboxMail_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxMail_PersonId",
                table: "InboxMail",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMail_PersonId",
                table: "OutboxMail",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxMail");

            migrationBuilder.DropTable(
                name: "OutboxMail");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
