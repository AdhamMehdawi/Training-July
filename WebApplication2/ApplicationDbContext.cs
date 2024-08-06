using Microsoft.EntityFrameworkCore;
using WebApplication2.Controllers;

namespace WebApplication2
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<registrationModel> registrationList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<registrationModel>()
                .HasOne<Student>(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId);


            modelBuilder.Entity<registrationModel>()
                .HasOne<Course>(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId);

        }
          
    }
}
