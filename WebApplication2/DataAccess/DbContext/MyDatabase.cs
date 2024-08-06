using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.DataAccess
{
    public class MyDatabase : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyDatabase(DbContextOptions options) : base(options)
        {

        }

        DbSet<StudentModel> Students { get; set; }
    }


}
