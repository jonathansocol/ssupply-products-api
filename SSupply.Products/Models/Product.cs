using System;
using System.ComponentModel.DataAnnotations;

namespace SSupply.Products.Models
{
    public class Product
    {
        public Product(Guid id, string name, byte[] photo, decimal price)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Price = price;      
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public decimal Price { get; set; }
    }
}
