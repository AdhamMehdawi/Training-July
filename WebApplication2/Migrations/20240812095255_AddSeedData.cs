using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cources",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1001, "C++" });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterNumber", "SemesterName" },
                values: new object[] { 1, "A1" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "City", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "Ramallah", "test@gmail.com", "Ali", "000000000000" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 1, "T1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cources",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "SemesterNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
