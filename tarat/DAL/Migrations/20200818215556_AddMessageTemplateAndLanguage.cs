using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMessageTemplateAndLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mailTemplates_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6ce248d-0026-41ae-b41c-b7684f0baba8", "68c210af-b666-41f3-9cc7-4cc40efa5f9e" });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "kg" },
                    { 2, "ru" },
                    { 3, "en" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_mailTemplates_LanguageId",
                table: "mailTemplates",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mailTemplates");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e45121cc-710c-4503-8868-31d8574a149b", "c9c21dbb-e97b-4214-9b84-f55ed4d64fb8" });
        }
    }
}
