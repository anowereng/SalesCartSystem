using System.ComponentModel.DataAnnotations;

namespace SalesCartSystem.ViewModels
{
    public class ShoopingCartViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerMobile { get; set; }
        public string ShippingAddress { get; set; }
        public double Quantity { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
