using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddKeyToLanuageID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mailTemplates_languages_LanguageId",
                table: "mailTemplates");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "mailTemplates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mailTemplates_languages_LanguageId",
                table: "mailTemplates",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mailTemplates_languages_LanguageId",
                table: "mailTemplates");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "mailTemplates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_mailTemplates_languages_LanguageId",
                table: "mailTemplates",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
