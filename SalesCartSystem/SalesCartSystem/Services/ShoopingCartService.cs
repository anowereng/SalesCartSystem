using SalesCartSystem.Models;
using FairCleaning.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesCartSystem.Services
{
    public class ShoopingCartService
    {
        private readonly AppDbContext _db;
        public ShoopingCartService(AppDbContext db) => _db = db;        
        public void CartAdd(ShoppingCart model)
        {
            model.Total = model.Quantity * model.Price;
            _db.ShoppingCarts.Add(model);
            _db.SaveChanges();
           
        }
    }
}
