using eshop.Models;
using eshop.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    public class AccountController : BaseController
    {
        private readonly LoginRepository LoginRepository = new();
        private readonly CommentsRepository CommentsRepository = new();
        private readonly ReviewsRepository ReviewsRepository = new();

        [HttpGet]
        public IActionResult Index(string c = "Home", string a = "Index", int i = 0)
        {
            return View(new LoginViewModel() { Controller = c, Action = a, Id = i });
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            Login login = LoginRepository.FindByEmail(model.Email);
            if (login != null)
            {
                if (login.Password == model.Password)
                {
                    HttpContext.Session.SetString("Login", model.Email);
                    return RedirectToAction(model.Action, model.Controller, new { id = model.Id });
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string c = "Home", string a = "Index")
        {
            return View(new LoginViewModel() { Controller = c, Action = a });
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel model)
        {
            Login login = LoginRepository.FindByEmail(model.Email);
            if (login == null)
            {
                LoginRepository.Create(new Login() { Email = model.Email, Password = model.Password, FirstName = model.FirstName, LastName = model.LastName });
                return RedirectToAction(model.Action, model.Controller);
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Login");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            if (HttpContext.Session.GetString("Login") != null)
            {
                comment.Author = HttpContext.Session.GetString("Login");
                CommentsRepository.Create(comment);
            }
            return RedirectToAction("Detail", "Blogs", new { id = comment.IdBlog });
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            if (HttpContext.Session.GetString("Login") != null)
            {
                review.Author = HttpContext.Session.GetString("Login");
                ReviewsRepository.Create(review);
            }
            return RedirectToAction("Detail", "Products", new { id = review.IdProduct });
        }
    }
}
