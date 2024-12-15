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
        public async Task AddService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }
        public async Task<Service?> GetService(int Id)
        {
            return await _context.Services.FindAsync(Id);
        }

        public async Task RemoveServiceAsync(int serviceId)
        {
           
                var service = await _context.Services.FindAsync(serviceId);
                if (service != null)
                {
                    _context.Services.Remove(service);
                    await _context.SaveChangesAsync();
                }
   

         }
    }
}
