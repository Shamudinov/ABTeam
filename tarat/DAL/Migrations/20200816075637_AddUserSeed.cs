using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_schools_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SchoolId", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "e45121cc-710c-4503-8868-31d8574a149b", "admin@gmail.com", false, false, null, null, null, "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAOdA7GmNJmKoW8wqllczD1w4HqU/dVP2db/RI7XKHoF9R+Pczges5nA+KBLIYAgJQ==", null, false, null, "c9c21dbb-e97b-4214-9b84-f55ed4d64fb8", null, false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1", "50209db0-e4a4-4d6e-92cb-2777a86e5f37" },
                    { "1", "d8ab412f-b321-4b26-8172-a5d075603dd3" },
                    { "1", "edb57926-50f6-4493-aad2-e1e657d05495" },
                    { "1", "edb57926-50f6-4493-aad2-e1e657d05490" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_schools_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_schools_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "50209db0-e4a4-4d6e-92cb-2777a86e5f37" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "d8ab412f-b321-4b26-8172-a5d075603dd3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "edb57926-50f6-4493-aad2-e1e657d05490" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "edb57926-50f6-4493-aad2-e1e657d05495" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_schools_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
