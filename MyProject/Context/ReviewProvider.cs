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

        public async Task CreateReview(int userId, int serviceId, int stars, string description, string imageBase64)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);

            var review = new Review
            {
                Service = service,
                Stars = stars,
                Description = description,
                Images = imageBase64
            };

            _context.Reviews.Add(review); // Add the review to the DbContext
            await _context.SaveChangesAsync(); // Save the changes to the database
        }

    }
}

