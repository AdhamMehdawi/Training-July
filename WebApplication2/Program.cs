
using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<TestMath>();
            builder.Services.AddDbContext<MyDatabase>(option =>
            {
                option.UseSqlServer(
                    "Server=.;Database=SchoolDb;TrustServerCertificate=True;MultipleActiveResultSets=true;User Id=sa; Password=Admin123#");
            });

            var app = builder.Build();

            MyDatabase test = new MyDatabase(new DbContextOptions<MyDatabase>());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
