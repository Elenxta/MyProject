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

        public async Task CreateBooking(User user, int serviceId, DateTime date, TimeSpan time, int stylistId, string notes)
        {

            // get the stylist from the database
            var stylist = await _context.Stylists.FirstOrDefaultAsync(stylist => stylist.Id == stylistId);

            // get the service from the database

            var service = await _context.Services.FirstOrDefaultAsync(service => service.Id == serviceId);

            // Create a new booking
            var booking = new Booking
            {
                User = user,
                Service= service,
                Date = date,
                Time = time,
                Stylist = stylist,
                Notes = notes,
               
            };

            // Add the booking to the database
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
}


