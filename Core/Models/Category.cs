﻿using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public required string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
