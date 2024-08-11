using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<RegisterStudentModel> Registrations { get; set; }
        public DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<BranchModel> Branches { get; set; }
        public DbSet<RegisterCourseModel> RegisterCourses { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegisterStudentModel>()
                .HasOne(rs => rs.Student)
                .WithMany(s => s.Registrations)
                .HasForeignKey(rs => rs.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RegisterStudentModel>()
                .HasOne(rs => rs.RegisterCourse)
                .WithMany(rc => rc.RegisterStudents)
                .HasForeignKey(rs => rs.RegisterCourseId)
                .OnDelete(DeleteBehavior.Restrict); 




            modelBuilder.Entity<RegisterCourseModel>()
                .HasOne(rc => rc.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(rc => rc.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

    
            modelBuilder.Entity<RegisterCourseModel>()
                .HasOne(rc => rc.Semester)
                .WithMany(s => s.RegisterdCourses)
                .HasForeignKey(rc => rc.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<SemesterModel>()
                .HasKey(s => s.SemesterNumber);

            modelBuilder.Entity<BranchModel>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<StudentModel>().HasKey(s => s.Id);
            modelBuilder.Entity<CourseModel>().HasKey(c => c.Id);
            modelBuilder.Entity<TeacherModel>().HasKey(t => t.Id);
        }
    }
}
