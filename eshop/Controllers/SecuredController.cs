using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.Controllers
{
    public class SecuredController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (HttpContext.Session.GetString("Login") == null)
            {
                context.Result = RedirectToAction("Index", "Account", new
                {
                    c = context.RouteData.Values["controller"],
                    a = context.RouteData.Values["action"],
                    i = context.RouteData.Values["id"]
                });
            }
        }
    }
}
