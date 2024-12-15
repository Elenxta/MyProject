using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
             await _context.Database.MigrateAsync();

            if (!_context.Services.Any())
            {
                var services = GetServices();
                _context.Services.AddRange(services);
                await _context!.SaveChangesAsync();
            }

            if (!_context.Stylists.Any())
            {
                var stylists = GetStylists();
                _context.Stylists.AddRange(stylists);
                await _context!.SaveChangesAsync();
            }



            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "stylist@ssalon.com";
                var adminPassword = "Salonlover123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    PhoneNumber = "12345678"

                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        private List<Service> GetServices()
        {
            return
            [
                // the services that are available and their properties 
            new Service { Name = "Classic Manicure", Description = "Basic nail shaping, cuticle care, and polish.", Price = 20.00m, Duration = TimeSpan.FromMinutes(30) },
            new Service { Name = "Gel Manicure", Description = "Long-lasting manicure with gel polish.", Price = 35.00m, Duration = TimeSpan.FromMinutes(45) },
            new Service { Name = "Pedicure", Description = "Foot bath, nail shaping, and polish.", Price = 40.00m, Duration = TimeSpan.FromMinutes(45) },
            new Service { Name = "Facial", Description = "Deep skin cleansing, exfoliation, and hydration.", Price = 75.00m, Duration = TimeSpan.FromMinutes(60) },
            new Service { Name = "Eyebrow Shaping", Description = "Waxing or threading for well-defined brows.", Price = 15.00m, Duration = TimeSpan.FromMinutes(15) },
            new Service { Name = "Lash Extensions", Description = "Semi-permanent eyelash extensions for a fuller look.", Price = 120.00m, Duration = TimeSpan.FromMinutes(90) },
            new Service { Name = "Waxing - Full Leg", Description = "Complete hair removal from legs using wax.", Price = 50.00m, Duration = TimeSpan.FromMinutes(45) },
            new Service { Name = "Haircut - Women", Description = "Professional women's haircut and styling.", Price = 60.00m, Duration = TimeSpan.FromMinutes(60) },
            new Service { Name = "Blow Dry", Description = "Wash and blow-dry for smooth, styled hair.", Price = 35.00m, Duration = TimeSpan.FromMinutes(45) },
            new Service { Name = "Hair Coloring", Description = "Full hair coloring service with professional products.", Price = 100.00m, Duration = TimeSpan.FromMinutes(120) },
            new Service { Name = "Balayage", Description = "Hand-painted hair coloring technique for a natural look.", Price = 150.00m, Duration = TimeSpan.FromMinutes(150) },
            new Service { Name = "Keratin Treatment", Description = "Hair-smoothing treatment for frizz control.", Price = 200.00m, Duration = TimeSpan.FromMinutes(180) },
            new Service { Name = "Makeup Application", Description = "Professional makeup for special occasions.", Price = 75.00m, Duration = TimeSpan.FromMinutes(60) },
            new Service { Name = "Bridal Makeup", Description = "Custom bridal makeup for the big day.", Price = 150.00m, Duration = TimeSpan.FromMinutes(90) },
            new Service { Name = "Massage - Swedish", Description = "Relaxing Swedish full-body massage.", Price = 80.00m, Duration = TimeSpan.FromMinutes(60) },
            new Service { Name = "Massage - Deep Tissue", Description = "Intensive massage for muscle relief and relaxation.", Price = 100.00m, Duration = TimeSpan.FromMinutes(75) },
            new Service { Name = "Spray Tan", Description = "Even, natural-looking spray tan application.", Price = 40.00m, Duration = TimeSpan.FromMinutes(30) },
            new Service { Name = "Teeth Whitening", Description = "Cosmetic treatment to whiten and brighten teeth.", Price = 120.00m, Duration = TimeSpan.FromMinutes(60) },
            new Service { Name = "Body Scrub", Description = "Exfoliating treatment to refresh and rejuvenate skin.", Price = 55.00m, Duration = TimeSpan.FromMinutes(45) }
           ];
        }
        private List<Stylist> GetStylists()
        {
            return
            [
            new Stylist { Name = "John" },
            new Stylist { Name = "Emily" },
            new Stylist { Name = "Michael" },
            new Stylist { Name = "Sophia" },
            new Stylist { Name = "David" }
            ];
        }
    }
}
