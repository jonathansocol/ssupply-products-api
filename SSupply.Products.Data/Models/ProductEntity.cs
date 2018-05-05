using System;
using System.ComponentModel.DataAnnotations;

namespace SSupply.Products.Data.Models
{
    public class ProductEntity
    {
        public ProductEntity() { }

        public ProductEntity(Guid id, string name, string photo, decimal price, DateTime lastUpdated)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Price = price;
            LastUpdated = lastUpdated;
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Url]
        public string Photo { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
