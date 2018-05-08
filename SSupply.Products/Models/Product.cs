using System;
using System.ComponentModel.DataAnnotations;

namespace SSupply.Products.Models
{
    public class Product
    {
        public Product() { }

        public Product(Guid id, string name, string photo, decimal price, DateTime lastModified)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Price = price;
            LastModified = lastModified;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public DateTime LastModified { get; set; }
    }
}
