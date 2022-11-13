using eshop.Models;
using eshop.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eshop.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ProductsRepository productsRepository = new();
        private readonly OrdersRepository ordersRepository = new();
        private readonly OrderProductsRepository orderProductsRepository = new();
        public IActionResult Index()
        {
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            List<Product> products = productsRepository.FindAll();
            ViewBag.CheckoutItems = checkoutItems;
            ViewBag.Products = products;
            double total = 0;
            foreach (CheckoutItem checkoutItem in checkoutItems)
            {
                Product product = products.Find(x => x.Id == checkoutItem.ProductId);
                total += Math.Round(product.Price * (1 - product.Discount / 100) * checkoutItem.Quantity, 2);
            }
            ViewBag.Total = Math.Round(total, 2);
            return View();
        }
        [HttpPost]
        public IActionResult Add(CheckoutItem checkoutItem)
        {
            if (checkoutItem.Quantity < 1) { return RedirectToAction("Detail", "Products", new { id = checkoutItem.ProductId }); }
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            checkoutItems.Add(new CheckoutItem { ProductId = checkoutItem.ProductId, Quantity = checkoutItem.Quantity });
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkoutItems));
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            checkoutItems.RemoveAll(x => x.ProductId == id);
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkoutItems));
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Checkout");
            return RedirectToAction("Index");
        }
        public IActionResult Information()
        {
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            if (checkoutItems.Count == 0)
            {
                return RedirectToAction("Index");
            }
            List<Product> products = productsRepository.FindAll();
            ViewBag.CheckoutItems = checkoutItems;
            ViewBag.Products = products;
            double total = 0;
            foreach (CheckoutItem checkoutItem in checkoutItems)
            {
                Product product = products.Find(x => x.Id == checkoutItem.ProductId);
                total += Math.Round(product.Price * (1 - product.Discount / 100) * checkoutItem.Quantity, 2);
            }
            ViewBag.Total = Math.Round(total, 2);
            return View();
        }
        [HttpPost]
        public IActionResult Information(Order order)
        {
            HttpContext.Session.SetString("CheckoutInformation", JsonConvert.SerializeObject(order));
            return RedirectToAction("Shipping");
        }
        public IActionResult Shipping()
        {
            if (HttpContext.Session.GetString("CheckoutInformation") == null)
            {
                return RedirectToAction("Information");
            }
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            if (checkoutItems.Count == 0)
            {
                return RedirectToAction("Index");
            }
            List<Product> products = productsRepository.FindAll();
            ViewBag.CheckoutItems = checkoutItems;
            ViewBag.Products = products;
            double total = 0;
            foreach (CheckoutItem checkoutItem in checkoutItems)
            {
                Product product = products.Find(x => x.Id == checkoutItem.ProductId);
                total += Math.Round(product.Price * (1 - product.Discount / 100) * checkoutItem.Quantity, 2);
            }
            ViewBag.Total = Math.Round(total, 2);
            Order order = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("CheckoutInformation"));
            ViewBag.Order = order;
            return View();
        }
        [HttpPost]
        public IActionResult Shipping(Order o)
        {
            Order order = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("CheckoutInformation"));
            order.Shipping = o.Shipping;
            HttpContext.Session.SetString("CheckoutInformation", JsonConvert.SerializeObject(order));
            return RedirectToAction("Payment");
        }
        public IActionResult Payment()
        {
            if (HttpContext.Session.GetString("CheckoutInformation") == null)
            {
                return RedirectToAction("Information");
            }
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            if (checkoutItems.Count == 0)
            {
                return RedirectToAction("Index");
            }
            List<Product> products = productsRepository.FindAll();
            ViewBag.CheckoutItems = checkoutItems;
            ViewBag.Products = products;
            double total = 0;
            foreach (CheckoutItem checkoutItem in checkoutItems)
            {
                Product product = products.Find(x => x.Id == checkoutItem.ProductId);
                total += Math.Round(product.Price * (1 - product.Discount / 100) * checkoutItem.Quantity, 2);
            }
            ViewBag.Total = Math.Round(total, 2);
            Order order = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("CheckoutInformation"));
            ViewBag.Order = order;
            return View();
        }
        [HttpPost]
        public IActionResult Payment(Order o)
        {
            Order order = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("CheckoutInformation"));
            List<CheckoutItem> checkoutItems = JsonConvert.DeserializeObject<List<CheckoutItem>>(HttpContext.Session.GetString("Checkout"));
            order.Payment = o.Payment;
            int id = ordersRepository.Create(order);
            foreach (CheckoutItem checkoutItem in checkoutItems)
            {
                orderProductsRepository.Create(new OrderProduct() { IdOrder = id, IdProduct = checkoutItem.ProductId, Quantity = checkoutItem.Quantity });
            }
            HttpContext.Session.Remove("Checkout");
            return RedirectToAction("Index", "Home");
        }
    }
}
