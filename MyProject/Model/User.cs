using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get;set; }

        [Required]
        public string PhoneNumber { get; set; }
        
        public string? Notes { get; set; }

        public List<Booking> Bookings { get; set; }  
       
    }
}
