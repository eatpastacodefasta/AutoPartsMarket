using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Site.Data.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Category { get; set; }

    [Required]
    public string? Make { get; set; }


    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    public ICollection<SupplierProduct>? SupplierProducts { get; set; }
    public ICollection<StoreProduct>? StoreProducts { get; set; }
    public ICollection<Stock>? Stock { get; set; }
}
