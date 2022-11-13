using eshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Repositories
{
    public class ProductsRepository
    {
        private readonly MyContext context = new();

        public List<Product> FindAll()
        {
            return context.TbProducts.ToList();
        }
        public List<Product> Top(int count)
        {
            return context.TbProducts.OrderByDescending(x => x.Id).Take(count).ToList();
        }
        public Product FindId(int id)
        {
            return context.TbProducts.First(x => x.Id == id);
        }
        public void Create(Product product)
        {
            context.TbProducts.Add(product);
            context.SaveChanges();
        }
        public void Edit(Product product)
        {
            Product db = context.TbProducts.Find(product.Id);
            db.Name = product.Name;
            db.Vendor = product.Vendor;
            db.Description = product.Description;
            db.Price = product.Price;
            db.Discount = product.Discount;
            db.Quantity = product.Quantity;
            db.Rating = product.Rating;
            db.Image = product.Image;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Product Product = context.TbProducts.First(x => x.Id == id);
            context.TbProducts.Remove(Product);
            context.SaveChanges();
        }
    }
}
