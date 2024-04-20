using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Data.Models;

public class SupplierProduct
{
    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SupplierPrice { get; set; }
}
