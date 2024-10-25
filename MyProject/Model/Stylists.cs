using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Stylist
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
    