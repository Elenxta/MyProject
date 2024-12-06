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
                // Fetch the stylist from the database based on the provided stylistId
                var stylist = await _context.Stylists.FirstOrDefaultAsync(s => s.Id == stylistId);

                // Fetch the service from the database based on the provided serviceId
                var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);

                if (stylist == null) throw new InvalidOperationException("Stylist not found.");

                if (service == null) throw new InvalidOperationException("Service not found.");

                // Create a new booking object and set its properties
                var booking = new Booking
                {
                    User = user,
                    Service = service,
                    Notes = notes,
                    Date = date,
                    Time = time,
                    Stylist = stylist,
                };

                // Add the new booking to the database context
                _context.Bookings.Add(booking);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
        }
    }

