using Microsoft.AspNetCore.Mvc;

namespace eshop.Components
{
    public class Product : ViewComponent
    {
        public IViewComponentResult Invoke(Models.Product product)
        {
            ViewBag.Product = product;
            return View();
        }
    }
    public class RowProduct : ViewComponent
    {
        public IViewComponentResult Invoke(Models.Product product)
        {
            ViewBag.Product = product;
            return View();
        }
    }
    public class Review : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
