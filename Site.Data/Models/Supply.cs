using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Site.Data.Models;

public class Supply
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Guid? Code { get; set; }

    public DateTime Date { get; set; }

    public int StoreId { get; set; }

    public Store? Store { get; set; }
}
