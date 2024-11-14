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
        
        //public async Task CreateBooking(User user, int serviceId, DateTime date, TimeSpan time, string, )
        //{
        //    // get the stylist from the database
        //    return await _context.Stylist.OrderBy(Stylist => stylist .Id).ToListAsync();

        //    // get the service from the database


        //    // Create a new booking
        //    var booking = new Booking
        //    {
        //        User = user,
        //        Created = DateTime.Now,
                
        //    };

        //    // Add the booking to the database
        //    _context.Bookings.Add(booking);
        //    await _context.SaveChangesAsync();
        //}
    }
}


