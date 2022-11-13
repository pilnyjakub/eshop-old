namespace eshop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Appartment { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Shipping { get; set; }
        public string Payment { get; set; }
    }
}
