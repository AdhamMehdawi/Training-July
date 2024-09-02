using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.DataAccess
{
    public class MyDatabase : DbContext
    {
        public MyDatabase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<RegistrationModel> Registration { get; set; }
        public DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<SectionModel> Section { get; set; }
        public DbSet<SectionCourseModel> SectionCourse { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<Assigment> Assigment { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DefaultData defaultData = new DefaultData();



            modelBuilder.Entity<SectionModel>(builder =>
            {
                builder.HasMany(c => c.CourseSection)
                    .WithOne(c => c.Section)
                    .HasForeignKey(c => c.SectionId);

                builder.HasData(defaultData.getSections());
            });

            modelBuilder.Entity<CourseModel>(table =>
            {
                table.HasMany(c => c.SectionCourse)
                    .WithOne(c => c.course)
                    .HasForeignKey(key => key.courseId);

                table.HasData(defaultData.getCourses());
            });

            modelBuilder.Entity<SemesterModel>(table =>
            {
                table.HasKey(c => c.SemesterNumber);
                table.HasData(defaultData.getSemesters());
            });

            modelBuilder.Entity<TeacherModel>(table =>
            {
                table.HasMany(c => c.Courses)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey(c => c.TeacherId);
                table.HasData(defaultData.getTeachers());
            });

            modelBuilder.Entity<StudentModel>(table =>
            {
                table.HasData(defaultData.getStudents());
            });

            modelBuilder.Entity<SectionCourseModel>(table =>
            {
                table.HasKey(c => c.Id);

                table.HasOne(c => c.course)
                     .WithMany(c => c.SectionCourse)
                     .HasForeignKey(c => c.courseId);

                table.HasOne(c => c.Section)
                     .WithMany(s => s.CourseSection)
                     .HasForeignKey(c => c.SectionId);

                table.HasOne(c => c.Teacher)
                     .WithMany(t => t.Courses)
                     .HasForeignKey(c => c.TeacherId);

                table.HasData(defaultData.getSectionCourse());
            });






            modelBuilder.Entity<RegistrationModel>(table =>
            {
                table.HasKey(c => c.Id);
                table.HasAlternateKey(c => new { c.StudentId, c.SectionCourseId, c.SemesterId, c.RegistrationYear });

                table.HasOne(c => c.Student)
                    .WithMany(c => c.RegistredCourses)
                    .HasForeignKey(c => c.StudentId);

                table.HasOne(c => c.SectionCourse)
                    .WithMany(c => c.RegistredStudents)
                    .HasForeignKey(c => c.SectionCourseId);

                table.HasOne(c => c.SemesterModel)
                    .WithMany(c => c.Registration)
                    .HasForeignKey(c => c.SemesterId);
                table.HasData(defaultData.getRegistration());
            });

            modelBuilder.Entity<Assigment>(table =>
                {
                    table.HasOne(c=>c.Registration)
                        .WithMany(c => c.StudentAssigment)
                        .HasForeignKey(c => c.RegistrationId);

                    table.Property(c => c.Title).IsRequired();

                    table.Property(c => c.Description).HasMaxLength(600);
                }
            );
        }
    }
}