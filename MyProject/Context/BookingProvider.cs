using Microsoft.EntityFrameworkCore;
using MyProject.Components.Pages;
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

        //public async Task CreateBooking(User user, IEnumerable<Service> service)
        //{
        //    // Create a new booking
        //    var booking = new Booking
        //    {
        //        User = user,
        //        Boooking = booking.Select(bookings => new Booking
        //        {
        //            Service = bookings.Service,       // Service being booked
        //            Duration = bookings.Duration,     // Duration of the service
        //            Stylist = bookings.Stylist
        //        }).ToList(),
        //        Created = DateTime.Now,

        //    };

        //    // Add the booking to the database
        //    _context.Bookings.Add(booking);
        //    await _context.SaveChangesAsync();

        //}
    }
}
    
