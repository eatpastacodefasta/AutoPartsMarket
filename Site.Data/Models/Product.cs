using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Site.Data.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public string? Make { get; set; }


    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    public ICollection<SupplierProduct>? SupplierProducts { get; set; }
}
