namespace eshop.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdBlog { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
