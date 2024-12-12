namespace MyProject.Model
{
    public class Review
    {
        public int Id { get; set; } 
        public int Stars { get; set; }
        public string Description { get; set; }
        public string? Images { get; set; }
        public Service Service { get; set; }    


   
    }
}
