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
        DbSet<CourceModel> Cources { get; set; }
        DbSet<RegistrationModel> Registration { get; set; }
        DbSet<SemesterModel> Semesters { get; set; }

        DbSet<ClassModel> Classes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegistrationModel>(builder =>
            {
                builder.HasKey(c => c.Id); 

                builder.HasOne(c => c.Student)
                    .WithMany(c => c.RegistredCources)
                    .HasForeignKey(c => c.StudentId);

                builder.HasOne(c => c.CourceModel)
                    .WithMany(c => c.RegistredStudents)
                    .HasForeignKey(c => c.CourceId);


                builder.HasOne(c => c.SemesterModel)
                    .WithMany(c => c.Registration)
                    .HasForeignKey(c => c.SemesterId);

                builder.HasOne(c => c.Classes)
                    .WithMany(c => c.RegistredStudents)
                    .HasForeignKey(c => c.ClassId);

            });
        }
    }


}
