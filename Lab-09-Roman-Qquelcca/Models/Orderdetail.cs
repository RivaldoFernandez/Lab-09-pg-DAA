﻿using System;
using System.Collections.Generic;

namespace Lab_09_Roman_Qquelcca.Models;

public partial class Orderdetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
