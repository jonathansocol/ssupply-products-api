﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSupply.Products.Data.Models
{
    public class ProductDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Url]
        [Required]
        public string Photo { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
