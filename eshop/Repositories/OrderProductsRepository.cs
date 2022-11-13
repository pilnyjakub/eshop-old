using eshop.Models;

namespace eshop.Repositories
{
    public class OrderProductsRepository
    {
        private readonly MyContext context = new();
        public void Create(OrderProduct orderProduct)
        {
            context.TbOrderProducts.Add(orderProduct);
            context.SaveChanges();
        }
    }
}
