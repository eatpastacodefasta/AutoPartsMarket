using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Data.Models;

public class Supplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    public ICollection<SupplierProduct>? SupplierProducts { get; set; }
}

public class SupplierProduct
{
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }

    public int ProductID { get; set; }
    public Product? Product { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SupplierPrice { get; set; }
}
