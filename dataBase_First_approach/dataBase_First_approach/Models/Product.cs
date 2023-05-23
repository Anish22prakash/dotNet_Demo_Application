using System;
using System.Collections.Generic;

namespace dataBase_First_approach.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
