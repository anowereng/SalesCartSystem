﻿using System.ComponentModel.DataAnnotations;

namespace SalesCartSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

    }
}
