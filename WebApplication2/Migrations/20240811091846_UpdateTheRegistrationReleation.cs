using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTheRegistrationReleation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Cources_CourceId",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "CourceId",
                table: "Registration",
                newName: "SectionCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_CourceId",
                table: "Registration",
                newName: "IX_Registration_SectionCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_SectionCourse_SectionCourseId",
                table: "Registration",
                column: "SectionCourseId",
                principalTable: "SectionCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_SectionCourse_SectionCourseId",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "SectionCourseId",
                table: "Registration",
                newName: "CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_SectionCourseId",
                table: "Registration",
                newName: "IX_Registration_CourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Cources_CourceId",
                table: "Registration",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
