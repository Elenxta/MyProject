using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Notes { get; set; }
        public User User { get; set; }
        public Stylist Stylist { get; set; }
        public Service Service { get; set; }

    }
}
