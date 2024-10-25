using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; } 
        public DbSet<Service> Services { get; set; }
        public DbSet<Stylist> Stylists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
