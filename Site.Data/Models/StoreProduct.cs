using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Data.Models;

public class StoreProduct
{
    public int StoreID { get; set; }
    public Store? Store { get; set; }

    public int ProductID { get; set; }
    public Product? Product { get; set; }

    public int AvailableStock { get; set; }

    public int MinimumStock { get; set; }

    public int SalesCount { get; set; }
}
