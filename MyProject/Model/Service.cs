using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Booking> Bookings { get; set; }    

         


    }
}
