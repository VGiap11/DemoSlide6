using DemoSlide6.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoSlide6.API.AppDbContext
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts()
        {

        }
        public AppDbContexts(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VGiap;Initial Catalog=DemoSlide6;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<LopHoc> LopHoc { get; set;}

    }
}
