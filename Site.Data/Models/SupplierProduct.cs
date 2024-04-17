using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Data.Models;

public class SupplierProduct
{
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }

    public int ProductID { get; set; }
    public Product? Product { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SupplierPrice { get; set; }
}
