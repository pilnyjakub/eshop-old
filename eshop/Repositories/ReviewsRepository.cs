using eshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Repositories
{
    public class ReviewsRepository
    {
        private readonly MyContext context = new();
        public List<Review> FindAllById(int id)
        {
            return context.TbReviews.Where(x => x.IdProduct == id).ToList();
        }
        public void Create(Review review)
        {
            context.TbReviews.Add(review);
            context.SaveChanges();
        }
    }
}
