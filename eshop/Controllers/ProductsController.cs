using eshop.Models;
using eshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ProductsRepository productsRepository = new();
        private readonly ProductCategoriesRepository productCategoriesRepository = new();
        private readonly ReviewsRepository reviewsRepository = new();

        public IActionResult Index(List<string> categories)
        {
            List<Product> products = productsRepository.Top(9);
            if (categories.Count != 0)
            {
                products.Clear();
                foreach (string category in categories)
                {
                    foreach (ProductCategory productCategory in productCategoriesRepository.GetProductsByCategory(category))
                    {
                        products.Add(productsRepository.FindId(productCategory.IdProduct));
                    }
                }
                products = products.GroupBy(x => x.Id).Select(y => y.First()).Take(9).ToList();
            }
            ViewBag.Products = products;
            return View();
        }
        public IActionResult Detail(int id)
        {
            ViewBag.Product = productsRepository.FindId(id);
            ViewBag.Reviews = reviewsRepository.FindAllById(id);
            ViewBag.Categories = productCategoriesRepository.GetCategoriesByProduct(id);
            ViewBag.Related = productsRepository.Top(4);
            return View();
        }
    }
}
