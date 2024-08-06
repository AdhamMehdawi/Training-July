using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.DataAccess
{
    public class MyDatabase : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyDatabase(DbContextOptions options) : base(options)
        {

        }

        DbSet<UserModel> Users { get; set; }
        DbSet<StudentModel> Students { get; set; }
        DbSet<EmployeeModel> Employees { get; set; }
        DbSet<CourseModel> Courses { get; set; }
        DbSet<AddressModel> Addresses { get; set; }
        DbSet<RegistrationModel> Registration { get; set; }
        DbSet<DepartmentModel> Departmens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegistrationModel>()
                .HasKey(r => new { r.StudentId, r.CourseId });
        }


    }
    

}
