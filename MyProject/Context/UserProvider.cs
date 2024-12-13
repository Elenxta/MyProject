using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Context;
using MyProject.Model;

namespace MyProject.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
        }

        public User? GetUserByUsernameAsync(string? username)
        {
            // Return the user with the specified username
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

        public async Task<string?> GetPhoneNumberAsync(Booking booking)
        {
            return await _context.Users
                .Where(u => u.Id == booking.User.Id)
                .Select(u => u.PhoneNumber)
                .FirstOrDefaultAsync();
        }
    }
}