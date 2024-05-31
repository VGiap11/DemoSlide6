using DemoSlide6.API.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DemoSlide6.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            builder.Services.AddDbContext<AppDbContexts>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect"));
            });
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}