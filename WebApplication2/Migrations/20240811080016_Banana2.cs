using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Banana2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_RegisterCourses_RegisterCourseId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCourses_Branches_BranchId",
                table: "RegisterCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Branches_BranchId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_BranchId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses");

            migrationBuilder.DropIndex(
                name: "IX_Branches_RegisterCourseId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "RegisterCourseId",
                table: "Branches");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses",
                column: "BranchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCourses_Branches_BranchId",
                table: "RegisterCourses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCourses_Branches_BranchId",
                table: "RegisterCourses");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses");

            migrationBuilder.AddColumn<int>(
                name: "RegisterCourseId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_BranchId",
                table: "Registrations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCourses_BranchId",
                table: "RegisterCourses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_RegisterCourseId",
                table: "Branches",
                column: "RegisterCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_RegisterCourses_RegisterCourseId",
                table: "Branches",
                column: "RegisterCourseId",
                principalTable: "RegisterCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCourses_Branches_BranchId",
                table: "RegisterCourses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Branches_BranchId",
                table: "Registrations",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
