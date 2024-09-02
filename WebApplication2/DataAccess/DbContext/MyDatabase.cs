using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.DataAccess
{
    public class MyDatabase : DbContext
    {
        public MyDatabase(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourceModel> Cources { get; set; }
        public DbSet<RegistrationModel> Registration { get; set; }
        public DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<SectionModel> Section { get; set; }
        public DbSet<SectionCorseModel> SectionCourse { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<Assigment> Assigment { get; set; }



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

                table.HasData(new List<CourceModel>()
                {
                    new CourceModel()
                    {
                        Id = 1001,
                        Name = "C++"
                    }
                });
            });

            modelBuilder.Entity<SemesterModel>(table =>
            {
                table.HasKey(c => c.SemesterNumber);
                table.HasData(new List<SemesterModel>()
                {
                    new SemesterModel()
                    {
                        SemesterNumber = 1,
                        SemesterName = "A1"
                    }
                });
            });


            modelBuilder.Entity<TeacherModel>(table =>
            {
                table.HasMany(c => c.Courses)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey(c => c.TeacherId);

                table.HasData(new List<TeacherModel>()
                {
                    new TeacherModel()
                    {
                        Id = 1,
                        FullName = "T1"
                    }
                });
            });


            modelBuilder.Entity<StudentModel>(table =>
            {
                table.HasData(new List<StudentModel>()
                {
                    new StudentModel()
                    {
                        Id = 1,
                        City = "Ramallah",
                        Name = "Ali",
                        Email = "test@gmail.com",
                        PhoneNumber = "000000000000"
                    }
                });
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
