using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class ServicesProvider
    {
        private readonly DatabaseContext _context;

        public ServicesProvider(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _context.Services.OrderBy(service => service.Id).ToListAsync();
        }

        public async Task<Service?> GetService(int id)
        {
            return await _context.Services.FindAsync(id);
        }
    }
}
