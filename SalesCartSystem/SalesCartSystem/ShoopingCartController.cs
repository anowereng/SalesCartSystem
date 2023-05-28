using SalesCartSystem.Data;
using SalesCartSystem.Models;
using SalesCartSystem.ViewModels;
using FairCleaning.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Pipelines;

namespace SalesCartSystem.Controllers
{
    public class ShoopingCartController : Controller
    {
        private readonly ILogger<ShoopingCartController> _logger;
        private AppDbContext _context;

        public ShoopingCartController(ILogger<ShoopingCartController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.ShoppingCarts
                        .Select(x => new ShoopingCartViewModel { CustomerMobile = x.CustomerMobile, CustomerName = x.CustomerName, ProductId = x.ProductId,  Quantity = x.Quantity, ShippingAddress = x.ShippingAddress, Price = x.Price, Total  =  x.Total ,
                            Id = x.Id }).ToList();


            foreach (var item in list)
            {
                var product = GetProductValue(item.ProductId);
                if (product != null)
                {
                    item.ProductName = product.Name;
                }

            }
            return View(list);
        }
        private Product GetProductValue(int id)
        {
            ProductData data  =  new ProductData();
            var allProducts = data.GetAllProducts();
            var product = allProducts.FirstOrDefault(y => y.Id == id);
            return product;
        }
        public IActionResult Create()
        {
            ProductData list = new ProductData();
            ViewBag.ProductList = list.GetProductNames();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShoppingCart model)
        {
            model.Total = model.Quantity * model.Price;
            _context.ShoppingCarts.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Create));
        }
    }
}