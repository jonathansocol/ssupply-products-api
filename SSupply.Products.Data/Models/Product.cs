using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSupply.Products.Data.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid PhotoId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
