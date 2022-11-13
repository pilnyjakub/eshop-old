using Microsoft.AspNetCore.Http;

namespace eshop.Models
{
    public class BlogViewModel
    {
        public Blog Blog { get; set; }
        public IFormFile Image { get; set; }
    }
}
