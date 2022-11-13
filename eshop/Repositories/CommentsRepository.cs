using eshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Repositories
{
    public class CommentsRepository
    {
        private readonly MyContext context = new();
        public List<Comment> FindAllById(int id)
        {
            return context.TbComments.Where(x => x.IdBlog == id).ToList();
        }
        public void Create(Comment comment)
        {
            context.TbComments.Add(comment);
            context.SaveChanges();
        }
    }
}
