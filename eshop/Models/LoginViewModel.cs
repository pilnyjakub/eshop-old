using System.ComponentModel.DataAnnotations;

namespace eshop.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
        public int Id { get; set; }
    }
}
