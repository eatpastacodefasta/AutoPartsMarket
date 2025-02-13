﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Site.Data.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    public Guid? Code { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity should be a positive number.")]
    public int Quantity { get; set; }

    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
