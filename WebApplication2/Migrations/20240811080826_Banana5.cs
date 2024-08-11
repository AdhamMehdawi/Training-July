using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Banana5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Semesters_SemesterId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_SemesterId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "Registrations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SemesterId",
                table: "Registrations",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Semesters_SemesterId",
                table: "Registrations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "SemesterNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
