
using Mapster;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);

            
            TypeAdapterConfig.GlobalSettings
              .NewConfig<StudentDt,StudentModel >()
              .Map(dest => dest.Id, src => src.Id)
              .Map(dest => dest.Name, src => src.Name)
              .Map(dest => dest.Email, src => src.Email)
              .Map(dest => dest.PhoneNumber, src => src.Phone)
              .Map(dest => dest.City, src => src.City);
            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<TestMath>();

            builder.Services.AddDbContext<MyDatabase>(option =>
            {
                option.UseSqlServer(
                   "Server=.;Database=school1002;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            });

            var app = builder.Build();

           
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
