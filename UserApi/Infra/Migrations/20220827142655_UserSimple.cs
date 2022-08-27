using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApi.Migrations
{
    public partial class UserSimple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "d67f4ec3-0dee-4224-9752-ffcd1c79dfa0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "6101e3b4-b3fd-4fb3-955d-692a4f428ca6", "simple", "SIMPLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8179a4e-767c-4534-9d9f-5b6cef709f80", "AQAAAAEAACcQAAAAEOanQF/XjPob1XUkVdno8BmTndok7ZNo6ma9JB5AcjjF88iC3vRN1r4WA3aE77hrNQ==", "820dccde-97a9-4159-af16-c2e0d76508b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f5a4fe3f-203e-4505-adb1-ef437e79a30e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b740f3a-6386-4d74-8634-bdb77246603f", "AQAAAAEAACcQAAAAEEoA8nSZFBIVLnjd04Ch1rR76mqXmu3feCGQTSWVSDcFsHFnNRZ9WtIDAn7FxZlL0g==", "f13371b5-2862-4f9a-96df-a5f20e54843f" });
        }
    }
}
