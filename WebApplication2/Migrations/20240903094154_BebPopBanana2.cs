using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class BebPopBanana2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10add637-60df-4af2-aa98-e4da342bc616", null, "Student", "STUDENT" },
                    { "24c7fcad-f31b-497e-8a69-c4090a107284", null, "Admin", "ADMIN" },
                    { "f6069390-ee29-4436-b884-1b7e2d3b0623", null, "Teacher", "TEACHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10add637-60df-4af2-aa98-e4da342bc616");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24c7fcad-f31b-497e-8a69-c4090a107284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6069390-ee29-4436-b884-1b7e2d3b0623");
        }
    }
}
