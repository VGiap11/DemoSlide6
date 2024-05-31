
using DemoSlide6.API.AppDbContext;
using DemoSlide6.API.IRepositoryStudent;
using DemoSlide6.API.IRepositoryStudent.RepositoryStudent;
using Microsoft.EntityFrameworkCore;

namespace DemoSlide6.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContexts>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect"));
            });
            builder.Services.AddControllers();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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