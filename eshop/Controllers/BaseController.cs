using eshop.Models;
using eshop.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eshop.Controllers
{
    public class BaseController : Controller
    {
        private readonly BlogsRepository blogsRepository = new();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Login = HttpContext.Session.GetString("Login");
            ViewBag.BottomBlogs = blogsRepository.Top(2);
            if (HttpContext.Session.GetString("Checkout") == null)
            {
                List<CheckoutItem> checkoutItems = new();
                HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkoutItems));
            }
        }
    }
}
