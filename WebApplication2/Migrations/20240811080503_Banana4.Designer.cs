﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240811080503_Banana4")]
    partial class Banana4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Entities.BranchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("WebApplication2.Entities.CourseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebApplication2.Entities.RegisterCourseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("TeacherId");

                    b.ToTable("RegisterCourses");
                });

            modelBuilder.Entity("WebApplication2.Entities.RegisterStudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("RegisterCourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegisterCourseId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudentId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("WebApplication2.Entities.SemesterModel", b =>
                {
                    b.Property<int>("SemesterNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemesterNumber"));

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SemesterNumber");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("WebApplication2.Entities.StudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication2.Entities.TeacherModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("WebApplication2.Entities.RegisterCourseModel", b =>
                {
                    b.HasOne("WebApplication2.Entities.BranchModel", "Branch")
                        .WithMany("RegisterCourse")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.CourseModel", "Course")
                        .WithMany("Registrations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.SemesterModel", "Semester")
                        .WithMany("RegisterdCourses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.TeacherModel", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Course");

                    b.Navigation("Semester");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("WebApplication2.Entities.RegisterStudentModel", b =>
                {
                    b.HasOne("WebApplication2.Entities.RegisterCourseModel", "RegisterCourse")
                        .WithMany("RegisterStudents")
                        .HasForeignKey("RegisterCourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.SemesterModel", "Semester")
                        .WithMany("Registrations")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.StudentModel", "Student")
                        .WithMany("Registrations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisterCourse");

                    b.Navigation("Semester");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplication2.Entities.BranchModel", b =>
                {
                    b.Navigation("RegisterCourse");
                });

            modelBuilder.Entity("WebApplication2.Entities.CourseModel", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("WebApplication2.Entities.RegisterCourseModel", b =>
                {
                    b.Navigation("RegisterStudents");
                });

            modelBuilder.Entity("WebApplication2.Entities.SemesterModel", b =>
                {
                    b.Navigation("RegisterdCourses");

                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("WebApplication2.Entities.StudentModel", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("WebApplication2.Entities.TeacherModel", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
