using eshop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    public class BlogsController : BaseController
    {
        private readonly BlogsRepository blogsRepository = new();
        private readonly CommentsRepository commentsRepository = new();
        public IActionResult Index()
        {
            ViewBag.Blogs = blogsRepository.Top(3);
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Blog = blogsRepository.FindId(id);
            ViewBag.Comments = commentsRepository.FindAllById(id);
            return View();
        }
    }
}
