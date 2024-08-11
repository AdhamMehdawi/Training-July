using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Banana4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "RegisterCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCourses_SemesterId",
                table: "RegisterCourses",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCourses_Semesters_SemesterId",
                table: "RegisterCourses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "SemesterNumber",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCourses_Semesters_SemesterId",
                table: "RegisterCourses");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCourses_SemesterId",
                table: "RegisterCourses");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "RegisterCourses");
        }
    }
}
