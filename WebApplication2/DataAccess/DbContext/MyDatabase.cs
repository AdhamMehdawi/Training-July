using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.DataAccess
{
    public class MyDatabase : DbContext
    {
        public MyDatabase(DbContextOptions options) : base(options)
        {

        }

        DbSet<StudentModel> Students { get; set; }
       public DbSet<CourceModel> Cources { get; set; }
        DbSet<RegistrationModel> Registration { get; set; }
        DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<SectionModel> Section { get; set; }
        DbSet<SectionCorseModel> SectionCourse { get; set; }
        DbSet<TeacherModel> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegistrationModel>(builder =>
            {
                builder.HasKey(c => c.Id); 

                builder.HasOne(c => c.Student)
                    .WithMany(c => c.RegistredCources)
                    .HasForeignKey(c => c.StudentId);

                builder.HasOne(c => c.SectionCourse)
                    .WithMany(c => c.RegistredStudents)
                    .HasForeignKey(c => c.SectionCourseId);


                builder.HasOne(c => c.SemesterModel)
                    .WithMany(c => c.Registration)
                    .HasForeignKey(c => c.SemesterId);

            });

            modelBuilder.Entity<SectionModel>(builder =>
            {
                builder.HasMany(c => c.CourseSection)
                    .WithOne(c => c.Section)
                    .HasForeignKey(c => c.SectionId);

                builder.HasData(new List<SectionModel>()
                {
                    new SectionModel()
                    {
                        Id = 1,
                        Name = "A1"
                    },
                    new SectionModel()
                    {
                        Id = 2,
                        Name = "A2"
                    },
                    new SectionModel()
                    {
                        Id = 3,
                        Name = "A4"
                    },
                    new SectionModel()
                    {
                        Id = 4,
                        Name = "A4"
                    },
                    new SectionModel()
                    {
                        Id = 5,
                        Name = "A5"
                    },
                });

            });

            modelBuilder.Entity<CourceModel>(table =>
            {
                table.HasMany(c => c.SectionCorse)
                    .WithOne(c => c.course)
                    .HasForeignKey(key => key.courseId);
            });

            modelBuilder.Entity<SemesterModel>(table =>
            {
                table.HasKey(c => c.SemesterNumber);
            });


            modelBuilder.Entity<TeacherModel>(table =>
            {
                table.HasMany(c => c.Courses)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey(c => c.TeacherId);
            });

        }
    }


}
