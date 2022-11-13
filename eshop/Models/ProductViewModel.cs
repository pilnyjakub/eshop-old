using Microsoft.AspNetCore.Http;

namespace eshop.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}
