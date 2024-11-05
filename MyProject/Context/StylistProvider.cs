using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class StylistProvider
    {
         private readonly DatabaseContext _context;

        public StylistProvider(DatabaseContext context) 
        {
            _context = context;
        }
        public async Task<List<Stylist>> GetStylistsAsync()
        {
            return await _context.Stylists.OrderBy(stylist => stylist.Name).ToListAsync();
        }
        public Stylist? GetStylist( int id)
        {
            return _context.Stylists.Find(id);
        }
    }
}
