using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSupply.Products.Data.Models
{
    public class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
