using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSupply.Products.Api.Models
{
    public class ProductDefinitionDto
    {
        public ProductDefinitionDto(string name, byte[] photo, decimal price)
        {
            Name = name;
            Photo = photo;
            Price = price;
        }
        
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public decimal Price { get; set; }
    }
}
