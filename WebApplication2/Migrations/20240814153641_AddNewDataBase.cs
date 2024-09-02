using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterNumber);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionCourse_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionCourse_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionCourse_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SectionCourseId = table.Column<int>(type: "int", nullable: false),
                    RegistrationYear = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.UniqueConstraint("AK_Registration_StudentId_SectionCourseId_SemesterId_RegistrationYear", x => new { x.StudentId, x.SectionCourseId, x.SemesterId, x.RegistrationYear });
                    table.ForeignKey(
                        name: "FK_Registration_SectionCourse_SectionCourseId",
                        column: x => x.SectionCourseId,
                        principalTable: "SectionCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "SemesterNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1001, "Multimedia" },
                    { 1002, "Principles of Computer Networks" },
                    { 1003, "Introduction to databases" },
                    { 1004, "Graphic Evolution and Image Processing" },
                    { 1005, "Technical English" },
                    { 1006, "Web Programming" },
                    { 1007, "Physical Activity" },
                    { 1008, "Software Applications" },
                    { 1009, "Advanced Databases" },
                    { 1010, "Web Server Administration" }
                });

            migrationBuilder.InsertData(
                table: "Section",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Section 1" },
                    { 2, "Section 2" },
                    { 3, "Section 3" },
                    { 4, "Section 4" },
                    { 5, "Section 5" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterNumber", "SemesterName" },
                values: new object[,]
                {
                    { 1, "First Semester" },
                    { 2, "Second Semester" },
                    { 3, "Summer Semester" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ramallah", "lina.saeed@example.com", "Lina Saeed", "0598765432" },
                    { 2, "Nablus", "omar.nasser@example.com", "Omar Nasser", "0599876543" },
                    { 3, "Hebron", "maya.ibrahim@example.com", "Maya Ibrahim", "0599987654" },
                    { 4, "Jenin", "hassan.ali@example.com", "Hassan Ali", "0599998765" },
                    { 5, "Bethlehem", "dana.mustafa@example.com", "Dana Mustafa", "0598887654" },
                    { 6, "Jericho", "sami.fares@example.com", "Sami Fares", "0597776543" },
                    { 7, "Gaza", "yara.hani@example.com", "Yara Hani", "0596665432" },
                    { 8, "Tulkarm", "nour.adel@example.com", "Nour Adel", "0595554321" },
                    { 9, "Qalqilya", "fadi.hassan@example.com", "Fadi Hassan", "0594443210" },
                    { 10, "Rafah", "lama.tamer@example.com", "Lama Tamer", "0593332109" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Ahmad Salem" },
                    { 2, "Maher Mohammad" },
                    { 3, "Salma Mostafa" },
                    { 4, "Rabab Hasan" },
                    { 5, "Radwan Mahmoud" }
                });

            migrationBuilder.InsertData(
                table: "SectionCourse",
                columns: new[] { "Id", "EndTime", "SectionId", "StartTime", "TeacherId", "courseId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0), 1, 1001 },
                    { 2, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0), 2, 1002 },
                    { 3, new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0), 3, 1003 },
                    { 4, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0), 4, 1004 },
                    { 5, new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0), 5, 1005 },
                    { 6, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0), 1, 1006 },
                    { 7, new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0), 2, 1007 },
                    { 8, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0), 3, 1008 },
                    { 9, new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0), 4, 1009 },
                    { 10, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0), 5, 1010 }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "Id", "RegistrationYear", "SectionCourseId", "SemesterId", "StudentId" },
                values: new object[,]
                {
                    { 1, 2024, 1, 1, 1 },
                    { 2, 2024, 1, 1, 2 },
                    { 3, 2024, 1, 1, 3 },
                    { 4, 2024, 1, 1, 4 },
                    { 5, 2024, 1, 1, 5 },
                    { 6, 2024, 1, 1, 6 },
                    { 7, 2024, 1, 1, 7 },
                    { 8, 2024, 2, 1, 1 },
                    { 9, 2024, 2, 1, 2 },
                    { 10, 2024, 2, 1, 3 },
                    { 11, 2024, 2, 1, 4 },
                    { 12, 2024, 2, 1, 5 },
                    { 13, 2024, 2, 1, 6 },
                    { 14, 2024, 2, 1, 7 },
                    { 15, 2024, 3, 1, 1 },
                    { 16, 2024, 3, 1, 2 },
                    { 17, 2024, 3, 1, 3 },
                    { 18, 2024, 3, 1, 4 },
                    { 19, 2024, 3, 1, 5 },
                    { 20, 2024, 3, 1, 6 },
                    { 21, 2024, 3, 1, 7 },
                    { 22, 2024, 4, 1, 1 },
                    { 23, 2024, 4, 1, 2 },
                    { 24, 2024, 4, 1, 3 },
                    { 25, 2024, 4, 1, 4 },
                    { 26, 2024, 4, 1, 5 },
                    { 27, 2024, 4, 1, 6 },
                    { 28, 2024, 4, 1, 7 },
                    { 29, 2024, 5, 1, 1 },
                    { 30, 2024, 5, 1, 2 },
                    { 31, 2024, 5, 1, 3 },
                    { 32, 2024, 5, 1, 4 },
                    { 33, 2024, 5, 1, 5 },
                    { 34, 2024, 5, 1, 6 },
                    { 35, 2024, 5, 1, 7 },
                    { 36, 2024, 6, 1, 1 },
                    { 37, 2024, 6, 1, 2 },
                    { 38, 2024, 6, 1, 3 },
                    { 39, 2024, 6, 1, 4 },
                    { 40, 2024, 6, 1, 5 },
                    { 41, 2024, 6, 1, 6 },
                    { 42, 2024, 6, 1, 7 },
                    { 43, 2024, 7, 1, 1 },
                    { 44, 2024, 7, 1, 2 },
                    { 45, 2024, 7, 1, 3 },
                    { 46, 2024, 7, 1, 4 },
                    { 47, 2024, 7, 1, 5 },
                    { 48, 2024, 7, 1, 6 },
                    { 49, 2024, 7, 1, 7 },
                    { 50, 2024, 8, 1, 1 },
                    { 51, 2024, 8, 1, 2 },
                    { 52, 2024, 8, 1, 3 },
                    { 53, 2024, 8, 1, 4 },
                    { 54, 2024, 8, 1, 5 },
                    { 55, 2024, 8, 1, 6 },
                    { 56, 2024, 8, 1, 7 },
                    { 57, 2024, 9, 1, 1 },
                    { 58, 2024, 9, 1, 2 },
                    { 59, 2024, 9, 1, 3 },
                    { 60, 2024, 9, 1, 4 },
                    { 61, 2024, 9, 1, 5 },
                    { 62, 2024, 9, 1, 6 },
                    { 63, 2024, 9, 1, 7 },
                    { 64, 2024, 10, 1, 1 },
                    { 65, 2024, 10, 1, 2 },
                    { 66, 2024, 10, 1, 3 },
                    { 67, 2024, 10, 1, 4 },
                    { 68, 2024, 10, 1, 5 },
                    { 69, 2024, 10, 1, 6 },
                    { 70, 2024, 10, 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registration_SectionCourseId",
                table: "Registration",
                column: "SectionCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_SemesterId",
                table: "Registration",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionCourse_courseId",
                table: "SectionCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionCourse_SectionId",
                table: "SectionCourse",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionCourse_TeacherId",
                table: "SectionCourse",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "SectionCourse");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
