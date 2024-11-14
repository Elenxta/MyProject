using Microsoft.AspNetCore.Identity;
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

        public User? GetUserByUsername(string? username)
        {
            // Return the user with the specified username
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }
    }
}