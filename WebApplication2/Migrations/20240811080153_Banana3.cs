using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Banana3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses",
                column: "BranchId",
                unique: true);
        }
    }
}
