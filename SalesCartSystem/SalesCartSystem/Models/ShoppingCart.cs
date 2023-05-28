using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCartSystem.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerMobile { get; set; }
        public string ShippingAddress { get; set; }
        public double Quantity { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
