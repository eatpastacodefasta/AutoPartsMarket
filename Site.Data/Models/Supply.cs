using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Data.Models;

public class Supply
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Store? Store { get; set; }
}
