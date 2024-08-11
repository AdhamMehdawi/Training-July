using Microsoft.EntityFrameworkCore;
using WebApplication2.Controllers;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        DbSet<StudentModel> Students { get; set; }
        DbSet<CourseModel> Courses { get; set; }
        DbSet<RegisterationModel> registrationList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<RegisterationModel>()
                .HasOne<StudentModel>(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId);


            modelBuilder.Entity<RegisterationModel>()
                .HasOne<CourseModel>(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId);

        }
          
    }
}
