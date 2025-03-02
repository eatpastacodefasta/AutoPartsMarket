﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Site.Data.Models;

public class StoreSale
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity should be a positive number.")]
    public int Quantity { get; set; }

    public Guid? Code { get; set; }

    public DateTime Date { get; set; }

    public int StoreId { get; set; }
    public Store? Store { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
