using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSupply.Products.Api.Models
{
    public class ProductDto
    {
        public ProductDto(Guid id, string name, string photo, decimal price)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Price = price;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public DateTime LastModified { get; set; }
    }
}
