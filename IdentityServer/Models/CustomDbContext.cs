using Microsoft.EntityFrameworkCore;

namespace IdentityServer.AuthServer.Models
{
    public class CustomDbContext:DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> opts):base(opts)
        {

        }

        public DbSet<CustomUser> CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // md5 sha256 sha512

            modelBuilder.Entity<CustomUser>().HasData(
                new CustomUser() { Id = 1, Email = "fcakiroglu@outlook.com", Password = "password", City = "istanbul", UserName = "facakiroglu16" },
                         new CustomUser() { Id = 2, Email = "ahmet@outlook.com", Password = "password", City = "Ankara", UserName = "ahmet16" },
                                new CustomUser() { Id = 3, Email = "mehmet@outlook.com", Password = "password", City = "Konya", UserName = "mehmet16" }

            );

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IITT7DV;Initial Catalog=CustomDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


    }
}
