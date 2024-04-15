﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Data.Models;

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public Supplier? Supplier { get; set; }
}
