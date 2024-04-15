using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Data.Models;

public class Supplier
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Telephone { get; set; }
    public ICollection<SuppliedProduct>? SuppliedProducts { get; set; }
}

public class SuppliedProduct
{
    public Product? Product { get; set; }
    public decimal? WholesalePrice { get; set; }
}
