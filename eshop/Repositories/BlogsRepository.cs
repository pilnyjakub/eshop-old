using eshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Repositories
{
    public class BlogsRepository
    {
        private readonly MyContext context = new();

        public List<Blog> FindAll()
        {
            return context.TbBlogs.ToList();
        }
        public List<Blog> Top(int count)
        {
            return context.TbBlogs.OrderByDescending(x => x.Id).Take(count).ToList();
        }
        public Blog FindId(int id)
        {
            return context.TbBlogs.First(x => x.Id == id);
        }
        public void Create(Blog blog)
        {
            context.TbBlogs.Add(blog);
            context.SaveChanges();
        }
        public void Edit(Blog blog)
        {
            Blog db = context.TbBlogs.Find(blog.Id);
            db.Name = blog.Name;
            db.Author = blog.Author;
            db.Content = blog.Content;
            db.Image = blog.Image;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Blog Blog = context.TbBlogs.First(x => x.Id == id);
            context.TbBlogs.Remove(Blog);
            context.SaveChanges();
        }
    }
}
