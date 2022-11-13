using eshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Repositories
{
    public class MessagesRepository
    {
        private readonly MyContext context = new();

        public List<Message> FindAll()
        {
            return context.TbMessages.ToList();
        }
        public void Create(Message message)
        {
            context.TbMessages.Add(message);
            context.SaveChanges();
        }
    }
}
