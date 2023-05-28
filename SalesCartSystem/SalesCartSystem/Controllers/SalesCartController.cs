using FairCleaning.Core.Models;
using Microsoft.AspNetCore.Mvc;
using SalesCartSystem.Models;

namespace SalesCartSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesCartController : ControllerBase
    {
        private AppDbContext _db;

        public SalesCartController(AppDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Create(ShoppingCart model)
        {
            model.Total = model.Quantity * model.Price;
            _db.ShoppingCarts.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Create));
        }
    }
}
