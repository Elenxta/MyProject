using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class BookingProvider
    {
        private readonly DatabaseContext _context;

        public BookingProvider(DatabaseContext context)
        {
            _context = context;
        }

      
         public async Task CreateBooking(User user, int serviceId, DateTime date, string time, int stylistId, string notes)
        {
            // Fetch the stylist from the database based on the provided stylistId
            var stylist = await _context.Stylists.FirstOrDefaultAsync(s => s.Id == stylistId);

            // Fetch the service from the database based on the provided serviceId
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);

            
           var booking = new Booking
           {
               User = user,
               Service = service,
               Notes = notes,
               Date = date,
               Time = time,
               Stylist = stylist,
           };

           
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Booking>?> GetBookingsAsync(User? user)
        {

            // Return all orders for the specified user
            return await _context.Bookings
                .Where(booking => booking.User.UserName == user.UserName)
                .Include(booking => booking.Service)         // Include related service details
                .Include(booking => booking.Stylist)         // Include related stylist details
                .OrderBy(booking => booking.Date)            // Order by date
                .ThenBy(booking => booking.Time)             // Order by time
                .ToListAsync(); ;
        }
    }
}

