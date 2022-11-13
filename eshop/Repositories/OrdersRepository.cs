using eshop.Models;

namespace eshop.Repositories
{
    public class OrdersRepository
    {
        private readonly MyContext context = new();
        public int Create(Order order)
        {
            context.TbOrders.Add(order);
            context.SaveChanges();
            return order.Id;
        }
    }
}
