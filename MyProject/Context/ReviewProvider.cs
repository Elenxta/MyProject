using Microsoft.EntityFrameworkCore;
using MyProject.Components.Pages;
using MyProject.Model;

namespace MyProject.Context
{
    public class ReviewProvider
    {
        private readonly DatabaseContext _context;

        public ReviewProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }
        public async Task CreateReviewAsync(int serviceId, int stars, string description, string imageBase64)
        {
            // Retrieve the service based on the provided ID
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);

            // Create a new Review object
            var review = new Review
            {
                Service = service,
                Stars = stars,
                Description = description,
                Images = string.IsNullOrEmpty(imageBase64) ? null : imageBase64 // Handle null or empty image
            };

            // Add the review to the DbContext and save changes
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

        }
    }
}



