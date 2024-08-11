using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Banana7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTimesModel_RegisterCourses_RegisterCourseId",
                table: "CourseTimesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTimesModel",
                table: "CourseTimesModel");

            migrationBuilder.RenameTable(
                name: "CourseTimesModel",
                newName: "CourseTimes");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTimesModel_RegisterCourseId",
                table: "CourseTimes",
                newName: "IX_CourseTimes_RegisterCourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTimes",
                table: "CourseTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTimes_RegisterCourses_RegisterCourseId",
                table: "CourseTimes",
                column: "RegisterCourseId",
                principalTable: "RegisterCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTimes_RegisterCourses_RegisterCourseId",
                table: "CourseTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTimes",
                table: "CourseTimes");

            migrationBuilder.RenameTable(
                name: "CourseTimes",
                newName: "CourseTimesModel");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTimes_RegisterCourseId",
                table: "CourseTimesModel",
                newName: "IX_CourseTimesModel_RegisterCourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTimesModel",
                table: "CourseTimesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTimesModel_RegisterCourses_RegisterCourseId",
                table: "CourseTimesModel",
                column: "RegisterCourseId",
                principalTable: "RegisterCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
