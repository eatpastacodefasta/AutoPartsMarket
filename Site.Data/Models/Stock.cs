using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Data.Models;

public class Stock
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    public int ProductID { get; set; }
    public Product? Product { get; set; }

    public int AvailableStock { get; set; }

    public int MinimumStock { get; set; }
}
