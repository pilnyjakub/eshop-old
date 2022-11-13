using eshop.Models;
using eshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace eshop.Controllers
{
    public class AdminController : SecuredController
    {
        private readonly ProductsRepository productsRepository = new();
        private readonly BlogsRepository blogsRepository = new();
        private readonly MessagesRepository messagesRepository = new();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            ViewBag.Products = productsRepository.FindAll();
            return View();
        }
        public IActionResult ProductRemove(int id)
        {
            productsRepository.Delete(id);
            return RedirectToAction("Products");
        }
        public IActionResult ProductEdit(int id)
        {
            if (id != 0)
            {
                ProductViewModel productViewModel = new() { Product = productsRepository.FindId(id) };
                ViewBag.Image = productViewModel.Product.Image;
                return View(productViewModel);
            }
            return View();
        }
        [HttpPost]
        public IActionResult ProductEdit(ProductViewModel productViewModel)
        {
            if (productViewModel.Image != null)
            {
                productViewModel.Product.Image = Guid.NewGuid().ToString() + productViewModel.Image.FileName;
                using FileStream fileStream = new("wwwroot/products/" + productViewModel.Product.Image, FileMode.Create);
                productViewModel.Image.CopyTo(fileStream);
            }
            if (productViewModel.Product.Id != 0)
            {
                productsRepository.Edit(productViewModel.Product);
            }
            else
            {
                productsRepository.Create(productViewModel.Product);
            }
            return RedirectToAction("Products");
        }
        public IActionResult Blogs()
        {
            ViewBag.Blogs = blogsRepository.FindAll();
            return View();
        }
        public IActionResult BlogRemove(int id)
        {
            blogsRepository.Delete(id);
            return RedirectToAction("Blogs");
        }
        public IActionResult BlogEdit(int id)
        {
            if (id != 0)
            {
                BlogViewModel blogViewModel = new() { Blog = blogsRepository.FindId(id) };
                ViewBag.Image = blogViewModel.Blog.Image;
                return View(blogViewModel);
            }
            return View();
        }
        [HttpPost]
        public IActionResult BlogEdit(BlogViewModel blogViewModel)
        {
            if(blogViewModel.Image != null)
            {
                blogViewModel.Blog.Image = Guid.NewGuid().ToString() + blogViewModel.Image.FileName;
                using FileStream fileStream = new("wwwroot/blogs/" + blogViewModel.Blog.Image, FileMode.Create);
                blogViewModel.Image.CopyTo(fileStream);
            }
            if (blogViewModel.Blog.Id != 0)
            {
                blogsRepository.Edit(blogViewModel.Blog);
            }
            else
            {
                blogsRepository.Create(blogViewModel.Blog);
            }
            return RedirectToAction("Blogs");
        }
        public IActionResult Messages()
        {
            ViewBag.Messages = messagesRepository.FindAll();
            return View();
        }
    }
}
