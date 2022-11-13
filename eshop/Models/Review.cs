namespace eshop.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
    }
}
