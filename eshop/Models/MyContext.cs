using Microsoft.EntityFrameworkCore;

namespace eshop.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Product> TbProducts { get; set; }
        public DbSet<Blog> TbBlogs { get; set; }
        public DbSet<Login> TbLogins { get; set; }
        public DbSet<Order> TbOrders { get; set; }
        public DbSet<OrderProduct> TbOrderProducts { get; set; }
        public DbSet<Comment> TbComments { get; set; }
        public DbSet<Review> TbReviews { get; set; }
        public DbSet<ProductCategory> TbProductCategories { get; set; }
        public DbSet<Message> TbMessages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=192.168.0.200;database=DbShopOld;user=pilnyjakub;password=123456");
        }
    }
}
