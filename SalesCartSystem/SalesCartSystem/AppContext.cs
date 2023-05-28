using SalesCartSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FairCleaning.Core.Models
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }


        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}

