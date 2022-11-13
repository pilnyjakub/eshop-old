using Microsoft.AspNetCore.Mvc;

namespace eshop.Components
{
    public class Navigation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
