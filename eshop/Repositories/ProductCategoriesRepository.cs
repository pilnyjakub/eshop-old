using eshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Repositories
{
    public class ProductCategoriesRepository
    {
        private readonly MyContext context = new();
        public List<ProductCategory> GetProductsByCategory(string category)
        {
            return context.TbProductCategories.Where(x => x.Category == category).ToList();
        }
        public List<ProductCategory> GetCategoriesByProduct(int id)
        {
            return context.TbProductCategories.Where(x => x.IdProduct == id).ToList();
        }
    }
}
