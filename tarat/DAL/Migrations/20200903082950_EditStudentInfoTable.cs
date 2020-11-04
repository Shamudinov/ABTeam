using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditStudentInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_studentInfos",
                table: "studentInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "studentInfos");

            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "studentInfos",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentInfos",
                table: "studentInfos",
                column: "INN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_studentInfos",
                table: "studentInfos");

            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "studentInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "studentInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentInfos",
                table: "studentInfos",
                column: "Id");
        }
    }
}
