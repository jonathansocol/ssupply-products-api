using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSupply.Products.Data.Models
{
    public class ProductImage
    {
        [Key]
        public Guid ProductDefinitionId { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
