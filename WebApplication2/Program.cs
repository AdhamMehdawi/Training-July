
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

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
                    "Server=.;Database=SchoolDbsafiyaTest;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            });

            //register the Auth 
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                   // option.Audience = "frontend";
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                      //  ValidateLifetime = true, 
                     //   ValidateAudience = true, 
                     //   ValidateIssuer = true,
                      //  ValidAudience = "",
                      //  ValidIssuer = "",
                        IssuerSigningKey = new
                            SymmetricSecurityKey(
                                Encoding.UTF8
                                    .GetBytes("mDMEY80SdRYJKwYBBAHaRw8BAQdAPRHN6MR+NQOCgMBSk0a69VPhRQMAJHcZgDv4\r\nY8+qxPG0JkNhcnBhdGggPGFkaGFtLm1laGRhd2lAaWNvbm5lY3Rocy5jb20+iJkE\r\n"))
                    };
                });
            //solving the problem
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MyDatabase>()
            .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminUser", 
                    policy=> policy.RequireRole("Admin"));
                option.AddPolicy("StudentUser",
                    policy => policy.RequireRole("student"));
            });

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
